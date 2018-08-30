using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VFS.MicroServices.MDM.Repository;
using VFS.Common.Models.Masters;
using VFS.MicroServices.MDM.DataContext;
using Microsoft.EntityFrameworkCore;

namespace VFS.MicroServices.MDM.Manager
{
    public class CountryMapManager : IDataRepository<MstcountryMap, int>
    {
        ApplicationContext ctx;
        public CountryMapManager(ApplicationContext c)
        {
            ctx = c;
        }
        public MstcountryMap Get(int id)
        {
            //var countryMap = ctx.MstcountryMap.FirstOrDefault(b => b.Id == id);
            //return countryMap;

            //if (id == null)
            //{
            //    return NotFound();
            //}

            var countryMap = ctx.MstcountryMap
                .Include(m => m.Country)
                .Include(m => m.CountryOps)
                .Include(m => m.Mission)
                .Include(m => m.UnitOps)
                .FirstOrDefault(m => m.Id == id);

            return countryMap;

        }
        public IEnumerable<MstcountryMap> GetAll()
        {
            var countryMap = ctx.MstcountryMap.Include(m => m.Country).Include(m => m.CountryOps).Include(m => m.Mission).Include(m => m.UnitOps);
            return countryMap.ToList();
        }
        public int Add(MstcountryMap countryMap)
        {
            ctx.MstcountryMap.Add(countryMap);
            int Id = ctx.SaveChanges();
            return Id;
        }
        public int Delete(int id)
        {
            int countryMapId = 0;
            var countryMap = ctx.MstcountryMap.FirstOrDefault(b => b.Id == id);
            if (countryMap != null)
            {
                ctx.MstcountryMap.Remove(countryMap);
                countryMapId = ctx.SaveChanges();
            }
            return countryMapId;
        }
        public int Update(int id, MstcountryMap item)
        {
            int countryMapId = 0;
            var countryMap = ctx.MstcountryMap.Find(id);
            if (countryMap != null)
            {
                countryMap.CountryId = item.CountryId;
                countryMap.MissionId = item.MissionId;
                countryMap.CountryOpsId = item.CountryOpsId;
                countryMap.UnitOpsId = item.UnitOpsId;
                countryMapId = ctx.SaveChanges();
            }
            return countryMapId;
        }       
    }
}
