using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VFS.MicroServices.MDM.Repository;
using VFS.Common.Models.Masters;
using VFS.MicroServices.MDM.DataContext;


namespace VFS.MicroServices.MDM.Manager
{
    public class UnitOpsManager : IDataRepository<UnitOps, Guid>
    {

        ApplicationContext ctx;
        public UnitOpsManager(ApplicationContext c)
        {
            ctx = c;
        }
        public UnitOps Get(Guid id)
        {
            var unitOps = ctx.UnitOps.FirstOrDefault(b => b.Id == id);
            return unitOps;
        }

        public IEnumerable<UnitOps> GetAll()
        {
            var unitOps = ctx.UnitOps.ToList();
            return unitOps;
        }
        public int Add(UnitOps b)
        {
            throw new NotImplementedException();
        }
        public int Update(Guid id, UnitOps b)
        {
            throw new NotImplementedException();
        }
        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        
    }
}
