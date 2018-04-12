using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IS3.Core;
using IS3.Geology;

namespace iS3.Server.Repository
{
    public class GeologyRepo
    {
        Project project;
        Domain domain;
        string boreholeName = "AllBoreholes";
        string stratumName = "AllStratum";
        
        public GeologyRepo(string projectName)
        {
            project = new Project();
            project.loadDefinition(projectName + ".xml");
            domain = project.domains["Geology"];
        }
        
        public Borehole getBoreholeById(int id)
        {
            domain.loadObjects(boreholeName);
            DGObjects objs = domain["AllBoreholes"];

            if (!objs.containsKey(id)) return null;

            Borehole borehole = objs[id] as Borehole;
            return borehole;
        }

        public List<Borehole> getAllBorehole()
        {
            domain.loadObjects(boreholeName);
            DGObjects objs = domain["AllBoreholes"];

            if (objs.count == 0) return null;

            List<Borehole> boreholes = new List<Borehole>();
            foreach(DGObject obj in objs.values)
            {
                boreholes.Add(obj as Borehole);
            }
            return boreholes;
        }
    }
}