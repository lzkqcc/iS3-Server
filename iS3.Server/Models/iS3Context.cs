using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using iS3.Server.Utility;

namespace iS3.Server.Models
{
    public partial class iS3Context : DbContext
    {
        public iS3Context(string db, string path)
            : base(ConnectString(db, path))
        {
        }

        private static string ConnectString(string db, string path)

        {
            DBUtil conn = new DBUtil("DefaultConnection");
            SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
            {
                DataSource = conn.ip,
                InitialCatalog = db,
                UserID = conn.user,
                Password = conn.password,
                //PersistSecurityInfo = true,
                //IntegratedSecurity = true,
                //MultipleActiveResultSets = true
            };

            //Build an Entity Framework connection string

            EntityConnectionStringBuilder entityString = new EntityConnectionStringBuilder()
            {
                Provider = "System.Data.SqlClient",
                Metadata = "res://*/" + path + ".csdl|res://*/" + path + ".ssdl|res://*/" + path + ".msl",
                ProviderConnectionString = sqlString.ToString()
            };
            return entityString.ConnectionString;
        }
    }
}