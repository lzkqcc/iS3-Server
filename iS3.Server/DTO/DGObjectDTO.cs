using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iS3.Server.DTO
{
    public class DGObjectDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string fullName { get; set; }
        public string description { get; set; }

        public DGObjectDTO() { }
    }
}