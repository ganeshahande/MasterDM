using System;
using System.Collections.Generic;


namespace VFS.Common.Models.Masters
{
    public partial class Mission
    {
        public Mission()
        {
            CountryOfOperation = new HashSet<CountryOfOperation>();            
            MstcountryMap = new HashSet<MstcountryMap>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<CountryOfOperation> CountryOfOperation { get; set; }        
        public ICollection<MstcountryMap> MstcountryMap { get; set; }
    }
}
