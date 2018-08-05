using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using iS3.Server.DTO;
using iS3.Server.DTO.Monitoring;
using iS3.Server.Models.Project;
using iS3.Server.Utility;
using iS3.Server.DTO.Project;
using AutoMapper;
using System.Data.Entity.Infrastructure;

namespace iS3.Server.Repository
{
    public class MonitoringRepo
    {
        DB_iS3_ProjectContext db;

        public MonitoringRepo(string code)
        {
            db = new DB_iS3_ProjectContext(code);
        }

        public MonPointDTO getMonPointById(int id)
        {
            var query = from m in db.Monitoring_MonPointInfo
                        where m.ID == id
                        select m;
            var item = query.FirstOrDefault();

            MonPointDTO res = Mapper.Map<MonPointDTO>(item);
            var query2 = from m in db.Monitoring_MonData
                        where m.MonPointID == id
                        orderby m.DataTime ascending
                        select m;
            var items = query2.ToList();

            List<MonPointDataDTO> res2 = Mapper.Map<List<MonPointDataDTO>>(items);
            res.MonDatas = res2;
            return res;
        }

        public List<MonPointDataDTO> getMonPointDataById(int id)
        {
            var query = from m in db.Monitoring_MonData
                        where m.MonPointID == id
                        orderby m.DataTime ascending
                        select m;
            var items = query.ToList();

            List<MonPointDataDTO> res = Mapper.Map<List<MonPointDataDTO>>(items);
            return res;
        }
 
        public MonGroupDTO getMonGroupById(int id)
        {
            var query = from mg in db.Monitoring_MonGroupInfo
                        join mp in db.Monitoring_MonPointInfo on mg.ID equals mp.MonGroupID into mps
                        where mg.ID == id
                        select new { grp = mg, ptn = mps };
            var item = query.FirstOrDefault();
            MonGroupDTO res = Mapper.Map<MonGroupDTO>(item.grp);
            res.MonPoints = Mapper.Map<List<MonPointDTO>>(item.ptn);
            return res;
        }

        public MonProjectDTO getMonProjectById(int id)
        {
            var query = from mpp in db.Monitoring_MonProjectInfo
                        join mg in db.Monitoring_MonGroupInfo on mpp.ID equals mg.MonProjectID
                        join mp in db.Monitoring_MonPointInfo on mg.ID equals mp.MonGroupID into mps
                        where mpp.ID == id
                        select new { prj = mpp, grp = mg, ptn = mps };
            var item = query.ToList();
            if (item.Count == 0) return null;
            MonProjectDTO res = Mapper.Map<MonProjectDTO>(item[0].prj);
            res.MonGroups = new List<MonGroupDTO>();
            foreach(var tmp in item)
            {
                MonGroupDTO mg = Mapper.Map<MonGroupDTO>(tmp.grp);
                mg.MonPoints = Mapper.Map<List<MonPointDTO>>(tmp.ptn);
                res.MonGroups.Add(mg);
            }
            return res;
        }

        #region 对象组方法
        public List<MonPointDTO> getMonPointByObjs(string filter)
        {
            string sql = DGObjectsFilter.GetDGObjectsSQL("Monitoring_MonPointInfo", filter);
            var result = ((IObjectContextAdapter)db).ObjectContext.ExecuteStoreQuery<Monitoring_MonPointInfo>(sql).ToList();
            return Mapper.Map<List<MonPointDTO>>(result.ToList());
        }
        public List<MonGroupDTO> getMonGroupByObjs(string filter)
        {
            string sql = DGObjectsFilter.GetDGObjectsSQL("Monitoring_MonGroupInfo", filter);
            var result = ((IObjectContextAdapter)db).ObjectContext.ExecuteStoreQuery<Monitoring_MonGroupInfo>(sql).ToList();
            return Mapper.Map<List<MonGroupDTO>>(result.ToList());
        }
        public List<MonProjectDTO> getMonProjectByObjs(string filter)
        {
            string sql = DGObjectsFilter.GetDGObjectsSQL("Monitoring_MonProjectInfo", filter);
            var result = ((IObjectContextAdapter)db).ObjectContext.ExecuteStoreQuery<Monitoring_MonProjectInfo>(sql).ToList();
            return Mapper.Map<List<MonProjectDTO>>(result.ToList());
        }
        #endregion

    }
}