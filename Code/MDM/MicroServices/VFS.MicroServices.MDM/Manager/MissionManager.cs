using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VFS.MicroServices.MDM.Repository;
using VFS.Common.Models.Masters;
using VFS.MicroServices.MDM.DataContext;

namespace VFS.MicroServices.MDM.Manager
{
    public class MissionManager : IDataRepository<Mission, Guid>
    {
        ApplicationContext ctx;
        public MissionManager(ApplicationContext c)
        {
            ctx = c;
        }       

        public Mission Get(Guid id)
        {
            var mission = ctx.Mission.FirstOrDefault(b => b.Id == id);
            return mission;
        }

        public IEnumerable<Mission> GetAll()
        {
            var mission = ctx.Mission.ToList();
            return mission;
        }
        public int Add(Mission b)
        {
            throw new NotImplementedException();
        }
        public int Update(Guid id, Mission b)
        {
            throw new NotImplementedException();
        }
        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
