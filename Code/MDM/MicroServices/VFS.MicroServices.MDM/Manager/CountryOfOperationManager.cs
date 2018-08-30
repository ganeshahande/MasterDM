using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VFS.MicroServices.MDM.Repository;
using VFS.Common.Models.Masters;
using VFS.MicroServices.MDM.DataContext;
//using Microsoft.EntityFrameworkCore;

namespace VFS.MicroServices.MDM.Manager
{
    public class CountryOfOperationManager : IDataRepository<CountryOfOperation, Guid>
    {
        ApplicationContext ctx;
        public CountryOfOperationManager(ApplicationContext c)
        {
            ctx = c;
        }

        public CountryOfOperation Get(Guid id)
        {
            var countryOfOperation = ctx.CountryOfOperation.FirstOrDefault(b => b.Id == id);
            return countryOfOperation;
        }

        public IEnumerable<CountryOfOperation> GetAll()
        {
            var countryOfOperation = ctx.CountryOfOperation.ToList();
            return countryOfOperation;
        }
        public int Add(CountryOfOperation b)
        {
            throw new NotImplementedException();
        }

        
        public int Update(Guid id, CountryOfOperation b)
        {
            throw new NotImplementedException();
        }
        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
