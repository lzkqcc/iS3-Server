using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IS3.Core;
using System.IO; 

namespace iS3.Server.Utility
{
    public class FileUtil
    {
        public static bool projectExit(string name)
        {
            string path = Runtime.dataPath + "/" + name + "/" + name + ".xml";
            return File.Exists(path);

        }
    }
}