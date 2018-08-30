using System.Collections.Generic;
namespace VFS.Common.Models.Masters
{
    public class Country
    {
        public Country()
        {
            CountryOfOperation = new HashSet<CountryOfOperation>();           
            MstcountryMap = new HashSet<MstcountryMap>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Isocode2 { get; set; }
        public string Isocode3 { get; set; }
        public string DialCode { get; set; }
        public string Nationality { get; set; }

        public ICollection<CountryOfOperation> CountryOfOperation { get; set; }
        public ICollection<MstcountryMap> MstcountryMap { get; set; }
    }
}
