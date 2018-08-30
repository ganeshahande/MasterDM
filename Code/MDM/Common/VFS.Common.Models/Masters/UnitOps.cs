using System;
using System.Collections.Generic;
using System.Text;

namespace VFS.Common.Models.Masters
{
    public partial class UnitOps
    {
        public UnitOps()
        {
            MstcountryMap = new HashSet<MstcountryMap>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int UnitOpsCode { get; set; }
        public int JurisdictionId { get; set; }

        public JurisdictionMap Jurisdiction { get; set; }        
        public ICollection<MstcountryMap> MstcountryMap { get; set; }
    }
}
