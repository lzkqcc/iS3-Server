using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iS3.Server.Models.Project;
using iS3.Server.Utility;
using iS3.Server.DTO.Project;
using System.Text;
using AutoMapper;

using IS3.Core;
using IS3.Geology;

using iS3.Server.DTO;
using iS3.Server.DTO.Geology;

namespace iS3.Server.Repository
{
    //public class GeologyRepo : DGObjectRepo
    //{
    //    public GeologyRepo(string projectName)
    //    {
    //        project = CentralRepo.getProject(projectName);
    //        domain = project.domains["Geology"];
    //    }
    //}

    public class GeologyRepo
    {
        DB_iS3_ProjectContext db;

        public GeologyRepo(string code)
        {
            db = new DB_iS3_ProjectContext(code);
        }

        public BoreholeDTO getBoreholeById(int id)
        {
            var query = from b in db.Geology_Boreholes
                        join g in db.Geology_BoreholeStrataInfo on new { c1 = (int?)b.StratumSection, c2 = (int?)b.SectionSequence }
                        equals new { c1 = (int?)g.StratumSectionID, c2 = (int?)g.SectionSequenceBorhole } into bg
                        where b.ID == id
                        select new { Borehole = b, Geologies = bg };
            var item = query.FirstOrDefault();

            BoreholeDTO res = Mapper.Map<BoreholeDTO>(item.Borehole);
            res.Geologies = Mapper.Map<List<BoreholeGeologyDTO>>(item.Geologies);
            setBoreholeGeologyTop(res);
            return res;
        }

        public List<BoreholeDTO> getBoreholeByIds(int[] ids)
        {
            var query = from b in db.Geology_Boreholes
                        join g in db.Geology_BoreholeStrataInfo on new { c1 = (int?)b.StratumSection, c2 = (int?)b.SectionSequence }
                        equals new { c1 = (int?)g.StratumSectionID, c2 = (int?)g.SectionSequenceBorhole } into bg
                        where ids.Contains(b.ID)
                        select new { Borehole = b, Geologies = bg };
            var tmps = query.ToList();
            List<BoreholeDTO> res = new List<BoreholeDTO>();
            foreach (var tmp in tmps)
            {
                BoreholeDTO b = Mapper.Map<BoreholeDTO>(tmp.Borehole);
                b.Geologies = Mapper.Map<List<BoreholeGeologyDTO>>(tmp.Geologies);
                setBoreholeGeologyTop(b);
                res.Add(b);
            }
            return res;
        }

        public List<BoreholeDTO> getAllBoreholeByProject()
        {
            var query = from b in db.Geology_Boreholes
                        join g in db.Geology_BoreholeStrataInfo on new { c1 = (int?)b.StratumSection, c2 = (int?)b.SectionSequence }
                        equals new { c1 = (int?)g.StratumSectionID, c2 = (int?)g.SectionSequenceBorhole } into bg
                        select new { Borehole = b, Geologies = bg };
            var tmps = query.ToList();
            List<BoreholeDTO> res = new List<BoreholeDTO>();
            foreach (var tmp in tmps)
            {
                BoreholeDTO b = Mapper.Map<BoreholeDTO>(tmp.Borehole);
                b.Geologies = Mapper.Map<List<BoreholeGeologyDTO>>(tmp.Geologies);
                setBoreholeGeologyTop(b);
                res.Add(b);
            }
            return res;
        }

        private void setBoreholeGeologyTop(BoreholeDTO b)
        {
            double top = b.Top;
            foreach (BoreholeGeologyDTO bg in b.Geologies)
            {
                bg.Top = top;
                top = bg.Base;
            }
        }

        public StratumDTO getStratumById(int id)
        {
            var query = from s in db.Geology_Strata
                        where s.ID == id
                        select s;
            var item = query.FirstOrDefault();
            StratumDTO res = Mapper.Map<StratumDTO>(item);
            return res;
        }

        public List<StratumDTO> getAllStratum()
        {
            var query = from s in db.Geology_Strata
                        select s;
            var item = query.ToList();
            List<StratumDTO> res = Mapper.Map<List<StratumDTO>>(item);
            return res;
        }

        public StratumSectionDTO getStratumSectionById(int id)
        {
            var query = from s in db.Geology_StrataSection
                        where s.ID == id
                        select s;
            var item = query.FirstOrDefault();
            StratumSectionDTO res = Mapper.Map<StratumSectionDTO>(item);
            return res;
        }

        public List<StratumSectionDTO> getAllStratumSection()
        {
            var query = from s in db.Geology_StrataSection
                        select s;
            var item = query.ToList();
            List<StratumSectionDTO> res = Mapper.Map<List<StratumSectionDTO>>(item);
            return res;
        }

        public SoilPropertyDTO getSoilPropertyById(int id)
        {
            var query = from s in db.Geology_SoilProperties
                        where s.ID == id
                        select s;
            var item = query.FirstOrDefault();
            SoilPropertyDTO res = Mapper.Map<SoilPropertyDTO>(item);
            res.StaticProp = Mapper.Map<SoilStaticPropertyDTO>(item);
            res.DynamicProp = Mapper.Map<SoilDynamicPropertyDTO>(item);
            return res;
        }

        public List<SoilPropertyDTO> getAllSoilProperty()
        {
            var query = from s in db.Geology_SoilProperties
                        select s;
            var item = query.ToList();

            List<SoilPropertyDTO> res = new List<SoilPropertyDTO>();
            foreach (var i in item)
            {
                SoilPropertyDTO tmp = Mapper.Map<SoilPropertyDTO>(i);
                tmp.StaticProp = Mapper.Map<SoilStaticPropertyDTO>(i);
                tmp.DynamicProp = Mapper.Map<SoilDynamicPropertyDTO>(i);
                res.Add(tmp);
            }
            return res;
        }

        public PhreaticWaterDTO getPhreaticWaterById(int id)
        {
            var query = from s in db.Geology_PhreaticWater
                        where s.ID == id
                        select s;
            var item = query.FirstOrDefault();
            PhreaticWaterDTO res = Mapper.Map<PhreaticWaterDTO>(item);
            return res;
        }

        public List<PhreaticWaterDTO> getAllPhreaticWater()
        {
            var query = from s in db.Geology_PhreaticWater
                        select s;
            var item = query.ToList();
            List<PhreaticWaterDTO> res = Mapper.Map<List<PhreaticWaterDTO>>(item);
            return res;
        }

        public ConfinedWaterDTO getConfinedWaterById(int id)
        {
            var query = from s in db.Geology_ConfinedWater
                        where s.ID == id
                        select s;
            var item = query.FirstOrDefault();
            ConfinedWaterDTO res = Mapper.Map<ConfinedWaterDTO>(item);
            return res;
        }

        public List<ConfinedWaterDTO> getAllConfinedWater()
        {
            var query = from s in db.Geology_ConfinedWater
                        select s;
            var item = query.ToList();
            List<ConfinedWaterDTO> res = Mapper.Map<List<ConfinedWaterDTO>>(item);
            return res;
        }

        public WaterPropertyDTO getWaterPropertyById(int id)
        {
            var query = from s in db.Geology_WaterProperties
                        where s.ID == id
                        select s;
            var item = query.FirstOrDefault();
            WaterPropertyDTO res = Mapper.Map<WaterPropertyDTO>(item);
            return res;
        }

        public List<WaterPropertyDTO> getAllWaterProperty()
        {
            var query = from s in db.Geology_WaterProperties
                        select s;
            var item = query.ToList();
            List<WaterPropertyDTO> res = Mapper.Map<List<WaterPropertyDTO>>(item);
            return res;
        }
    }
}