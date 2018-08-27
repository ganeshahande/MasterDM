using System;
using System.Collections.Generic;

namespace VFS.MicroServices.MDM.Models
{
    public partial class LanguageMap
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public Guid MissionId { get; set; }
        public Guid? CountryOpsId { get; set; }
        public Guid? UnitOpsId { get; set; }

        public CountryOfOperation CountryOps { get; set; }
        public Language Language { get; set; }
        public Mission Mission { get; set; }
        public UnitOps UnitOps { get; set; }
    }
}
