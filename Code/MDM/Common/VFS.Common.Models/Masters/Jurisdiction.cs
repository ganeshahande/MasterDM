using System;
using System.Collections.Generic;
using System.Text;

namespace VFS.Common.Models.Masters
{
    public partial class Jurisdiction
    {
        public Jurisdiction()
        {
            JurisdictionMap = new HashSet<JurisdictionMap>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<JurisdictionMap> JurisdictionMap { get; set; }
    }
}
