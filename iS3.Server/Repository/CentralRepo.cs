using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IS3.Core;
using IS3.Servers;

namespace iS3.Server.Repository
{
    public static class CentralRepo
    {
        public static Dictionary<string, IDataService> dataServices { get; set; }

        static CentralRepo()
        {
            dataServices = new Dictionary<string, IDataService>();
        }

        public static IDataService getService(string name)
        {
            if (!dataServices.ContainsKey(name))
            {
                IDataService service = new DataServiceSqlServer();
                dataServices[name] = service;
            }
                
            return dataServices[name];
        }
    }
}