using System;
using System.Collections.Generic;
using System.Text;

namespace VFS.Common.Models.Masters
{
    public partial class JurisdictionMap
    {
        public JurisdictionMap()
        {
            UnitOps = new HashSet<UnitOps>();
        }

        public int Id { get; set; }
        public Guid? JurisdictionId { get; set; }
        public Guid? CountryOpsId { get; set; }
        public int StatusId { get; set; }
        public string StatusReason { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDateUtc { get; set; }

        public CountryOfOperation CountryOps { get; set; }
        public Jurisdiction Jurisdiction { get; set; }
        public ICollection<UnitOps> UnitOps { get; set; }
    }
}
