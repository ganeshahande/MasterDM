using System;
using System.Collections.Generic;

namespace VFS.MicroServices.MDM.Models
{
    public partial class Mission
    {
        public Mission()
        {
            CountryOfOperation = new HashSet<CountryOfOperation>();
            LanguageMap = new HashSet<LanguageMap>();
            MstcountryMap = new HashSet<MstcountryMap>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<CountryOfOperation> CountryOfOperation { get; set; }
        public ICollection<LanguageMap> LanguageMap { get; set; }
        public ICollection<MstcountryMap> MstcountryMap { get; set; }
    }
}
