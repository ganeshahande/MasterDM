using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VFS.MicroServices.MDM.Repository;
using VFS.Common.Models.Masters;
using VFS.MicroServices.MDM.DataContext;

namespace VFS.MicroServices.MDM.Manager
{
    public class CountryManager : IDataRepository<Country, int>
    {
        ApplicationContext ctx;
        public CountryManager(ApplicationContext c)
        {
            ctx = c;
        }
        public Country Get(int id)
        {
            var country = ctx.Country.FirstOrDefault(b => b.Id == id);
            return country;
        }
        public IEnumerable<Country> GetAll()
        {
            var country = ctx.Country.ToList();
            return country;
        }
        public int Add(Country country)
        {
            ctx.Country.Add(country);
            int countryId = ctx.SaveChanges();
            return countryId;
        }
        public int Delete(int id)
        {
            int countryId = 0;
            var country = ctx.Country.FirstOrDefault(b => b.Id == id);
            if (country != null)
            {
                ctx.Country.Remove(country);
                countryId = ctx.SaveChanges();
            }
            return countryId;
        }
        public int Update(int id, Country item)
        {
            int countryId = 0;
            var country = ctx.Country.Find(id);
            if (country != null)
            {
                country.Name = item.Name;
                country.Code = item.Code;
                country.Isocode2 = item.Isocode2;
                country.Isocode3 = item.Isocode3;
                country.DialCode = item.DialCode;
                country.Nationality = item.Nationality;
                countryId = ctx.SaveChanges();
            }
            return countryId;
        }
       
    }
}
