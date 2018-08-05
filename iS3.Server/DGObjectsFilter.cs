using iS3.Server.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iS3.Server
{
    public static class DGObjectsFilter
    {
        public static string GetDGObjectsSQL(string tableName, string filter)
        {
            //filter字符串解码
            filter = MessageConverter.Decode(filter);
            if ((filter != null) && (filter != ""))
            {
                return string.Format("select * from {0} where ({1})", tableName, filter);
            }
            else
            {
                return string.Format("select * from {0}", tableName);

            }
        }
    }
}