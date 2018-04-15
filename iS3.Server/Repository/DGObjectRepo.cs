using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IS3.Core;

namespace iS3.Server.Repository
{
    public abstract class DGObjectRepo
    {
        public Project project { get; set; }
        public Domain domain { get; set; }

        public T getObjectById<T>(int id) where T : DGObject
        {
            string klassName = typeof(T).Name;
            string name = domain.objsDefinitions.Values.FirstOrDefault((d) => d.Type == klassName).Name;
            domain.loadObjects(name);
            DGObjects objs = domain[name];

            if (!objs.containsKey(id)) return default(T);

            DGObject obj = objs[id];
            return (T)obj;
        }

        public List<T> getAllObjects<T>() where T : DGObject
        {
            string klassName = typeof(T).Name;
            string name = domain.objsDefinitions.Values.FirstOrDefault((d) => d.Type == klassName).Name;
            domain.loadObjects(name);
            DGObjects objs = domain[name];

            if (objs.count == 0) return null;

            List<T> res = new List<T>();
            foreach (DGObject obj in objs.values)
            {
                res.Add((T)obj);
            }
            return res;
        }
    }
}