using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iS3.Server.Utility
{
    public class iS3Exception : Exception
    {
        public iS3Exception(string e) : base(e)
        {

        }
    }
}