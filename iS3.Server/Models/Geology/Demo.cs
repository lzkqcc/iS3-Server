using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iS3.Server.Models.Geology
{
    public class Demo
    {
        public int id { get; set; }
        public string name { get; set; }
        public double deep { get; set; }
        public bool isVisible { get; set; }

        public Demo()
        {

        }

        public Demo(int id, string name, double deep, bool isVisible)
        {
            this.id = id;
            this.name = name;
            this.deep = deep;
            this.isVisible = isVisible;
        }
    }
}