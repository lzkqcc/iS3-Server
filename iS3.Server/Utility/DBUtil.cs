using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iS3.Server.Utility
{
    public class DBUtil
    {
        public string ip { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public DBUtil(string name)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string[] ss = conn.Split(';');
            ip = ss[0].Split('=')[1];
            user = ss[3].Split('=')[1];
            password = ss[4].Split('=')[1];
        }
    }
}