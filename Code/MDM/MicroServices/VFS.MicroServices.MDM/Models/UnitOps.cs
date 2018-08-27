using System;
using System.Collections.Generic;

namespace VFS.MicroServices.MDM.Models
{
    public partial class UnitOps
    {
        public UnitOps()
        {
            LanguageMap = new HashSet<LanguageMap>();
            MstcountryMap = new HashSet<MstcountryMap>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int UnitOpsCode { get; set; }
        public int JurisdictionId { get; set; }

        public JurisdictionMap Jurisdiction { get; set; }
        public ICollection<LanguageMap> LanguageMap { get; set; }
        public ICollection<MstcountryMap> MstcountryMap { get; set; }
    }
}
