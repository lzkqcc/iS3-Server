using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iS3.Server.Models
{
    public class IS3Result
    {
        public bool success { get; set; }
        public object data { get; set; }
        public String error { get; set; }

        public IS3Result(bool success, object data, String error)
        {
            this.success = success;
            this.data = data;
            this.error = error;
        }
    }
}