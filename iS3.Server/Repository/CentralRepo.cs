using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iS3.Server.Utility;

using IS3.Core;
using IS3.Servers;

namespace iS3.Server.Repository
{
    public static class CentralRepo
    {
        static readonly object _lock = new object();

        public static Dictionary<string, IDataService> dataServices { get; set; }
        public static Dictionary<string, Project> projects { get; set; }

        static CentralRepo()
        {
            dataServices = new Dictionary<string, IDataService>();
            projects = new Dictionary<string, Project>();
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

        // temp function & low performance
        public static Project getProject(string CODE)
        {
            lock (_lock)
            {
                if (!FileUtil.projectExit(CODE))
                    throw new iS3Exception(string.Format("{0}工程不存在", CODE));
                Project project = new Project();
                project.loadDefinition(CODE + ".xml");
                return project;
            }
        }
    }
}