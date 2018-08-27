using System;
using System.Collections.Generic;

namespace VFS.MicroServices.MDM.Models
{
    public partial class CountryOfOperation
    {
        public CountryOfOperation()
        {
            JurisdictionMap = new HashSet<JurisdictionMap>();
            LanguageMap = new HashSet<LanguageMap>();
            MstcountryMap = new HashSet<MstcountryMap>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int CountryId { get; set; }
        public Guid MissionId { get; set; }

        public Country Country { get; set; }
        public Mission Mission { get; set; }
        public ICollection<JurisdictionMap> JurisdictionMap { get; set; }
        public ICollection<LanguageMap> LanguageMap { get; set; }
        public ICollection<MstcountryMap> MstcountryMap { get; set; }
    }
}
