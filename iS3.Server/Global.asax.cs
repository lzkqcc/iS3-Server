﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IS3.Core;
using IS3.Servers;
using iS3.Server.Utility;
using iS3.Server.DTO;

namespace iS3.Server
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // iS3 core
            Runtime.dataPath = Server.MapPath(@"~/App_Data/project");
            DBUtil db = new DBUtil();
            string ipaddress = DBUtil.ip;
            string user = DBUtil.user;
            string password = DBUtil.password;

            Globals.iS3Service = new IS3Service();
            IDataService sqlserver = new DataServiceSqlServer();

            Globals.iS3Service.dataServiceDict = new Dictionary<DbServiceType, IDataService>();
            Globals.iS3Service.dataServiceDict[sqlserver.type] = sqlserver;

            Globals.iS3Service.SetNowDataService(DbServiceType.SQLSERVER);
            Globals.iS3Service.DataService.initializeDataService(ipaddress, user, password);

            // automapper
            AutoMapperConfig.Initialize();
        }
    }
}