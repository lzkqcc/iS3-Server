using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.IO;

using iS3.Server.Filters;
using iS3.Server.Utility;

namespace iS3.Server.Controllers
{
    // 参考：https://blogs.msdn.microsoft.com/codefx/2012/02/23/more-about-rest-file-upload-download-service-with-asp-net-web-api-and-windows-phone-background-file-transfer/
    
    /// <summary>
    /// 文件操作相关接口
    /// </summary>
    [RoutePrefix("api/file")]
    public class FileController : ApiController
    {
        /// <summary>
        /// 下载项目文件
        /// </summary>
        /// <param name="CODE">项目代号</param>
        /// <param name="file">文件全称，如iS3Demo.py</param>
        /// <returns></returns>
        [Route("{CODE}")]
        [HttpGet]
        [ResponseFilterAttribute]
        public HttpResponseMessage download(string CODE, string file)
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["DataPath"].ToString()
                + "/" + CODE;
            string filepath = path + "/" + file;

            if (!File.Exists(filepath))
            {
                throw new iS3Exception("文件不存在");
            }

            try
            {
                MemoryStream responseStream = new MemoryStream();
                Stream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite);
                bool fullContent = true;
                if (this.Request.Headers.Range != null)
                {
                    fullContent = false;

                    // Currently we only support a single range.
                    var range = this.Request.Headers.Range.Ranges.First();

                    // From specified, so seek to the requested position.
                    if (range.From != null)
                    {
                        fileStream.Seek(range.From.Value, SeekOrigin.Begin);

                        // In this case, actually the complete file will be returned.
                        if (range.From == 0 && (range.To == null || range.To >= fileStream.Length))
                        {
                            fileStream.CopyTo(responseStream);
                            fullContent = true;
                        }
                    }
                    if (range.To != null)
                    {
                        // 10-20, return the range.
                        if (range.From != null)
                        {
                            long? rangeLength = range.To - range.From;
                            int length = (int)Math.Min(rangeLength.Value, fileStream.Length - range.From.Value);
                            byte[] buffer = new byte[length];
                            fileStream.Read(buffer, 0, length);
                            responseStream.Write(buffer, 0, length);
                        }
                        // -20, return the bytes from beginning to the specified value.
                        else
                        {
                            int length = (int)Math.Min(range.To.Value, fileStream.Length);
                            byte[] buffer = new byte[length];
                            fileStream.Read(buffer, 0, length);
                            responseStream.Write(buffer, 0, length);
                        }
                    }
                    // No Range.To
                    else
                    {
                        // 10-, return from the specified value to the end of file.
                        if (range.From != null)
                        {
                            if (range.From < fileStream.Length)
                            {
                                int length = (int)(fileStream.Length - range.From.Value);
                                byte[] buffer = new byte[length];
                                fileStream.Read(buffer, 0, length);
                                responseStream.Write(buffer, 0, length);
                            }
                        }
                    }
                }
                // No Range header. Return the complete file.
                else
                {
                    fileStream.CopyTo(responseStream);
                }
                fileStream.Close();
                responseStream.Position = 0;

                HttpResponseMessage response = new HttpResponseMessage();
                response.StatusCode = fullContent ? HttpStatusCode.OK : HttpStatusCode.PartialContent;
                response.Content = new StreamContent(responseStream);
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = file
                };
                return response;
            }
            catch (IOException)
            {
                throw new iS3Exception("下载文件过程发生错误");
            }
        }
        
        /// <summary>
        /// 上传项目文件
        /// </summary>
        /// <param name="CODE">项目代号</param>
        /// <param name="file">文件全称，如iS3Demo.py</param>
        /// <returns></returns>
        [Route("{CODE}")]
        [HttpPut]
        [Authorize]
        public string upload(string CODE, string file)
        {
            var task = this.Request.Content.ReadAsStreamAsync();
            task.Wait();
            Stream requestStream = task.Result;

            ;
            string path = System.Configuration.ConfigurationManager.AppSettings["DataPath"].ToString()
                + "/" + CODE;
            string filepath = path + "/" + file;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (File.Exists(filepath))
            {
                throw new iS3Exception("文件已经存在");
            }

            try
            {
                Stream fileStream = File.Create(filepath);
                requestStream.CopyTo(fileStream);
                fileStream.Close();
                requestStream.Close();
            }
            catch (IOException)
            {
                throw new iS3Exception("文件上传发生错误");
            }

            return "提交成功";
        }

        /// <summary>
        /// 更新项目文件
        /// </summary>
        /// <param name="CODE">项目代号</param>
        /// <param name="file">文件全称，如iS3Demo.py</param>
        /// <returns></returns>
        [Route("{CODE}")]
        [HttpPost]
        [Authorize]
        public string update(string CODE, string file)
        {
            var task = this.Request.Content.ReadAsStreamAsync();
            task.Wait();
            Stream requestStream = task.Result;

            ;
            string path = System.Configuration.ConfigurationManager.AppSettings["DataPath"].ToString()
                + "/" + CODE;
            string filepath = path + "/" + file;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (!File.Exists(filepath))
            {
                throw new iS3Exception("文件不存在");
            }
            File.Delete(filepath);

            try
            {
                Stream fileStream = File.Create(filepath);
                requestStream.CopyTo(fileStream);
                fileStream.Close();
                requestStream.Close();
            }
            catch (IOException)
            {
                throw new iS3Exception("文件上传发生错误");
            }

            return "更新成功";
        }   
    }
}
