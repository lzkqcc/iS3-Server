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
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;
            string[] ss = conn.Split(';');
            foreach(string s in ss)
            {
                string[] kv = s.Split('=');

                if (kv[0].ToLower().Equals("data source"))
                    ip = kv[1];

                if (kv[0].ToLower().Equals("user id"))
                    user = kv[1];

                if (kv[0].ToLower().Equals("password"))
                    password = kv[1];
            }
        }
    }
}