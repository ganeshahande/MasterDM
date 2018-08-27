using System;
using System.Collections.Generic;

namespace VFS.MicroServices.MDM.Models
{
    public partial class MstcountryMap
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public Guid MissionId { get; set; }
        public Guid? CountryOpsId { get; set; }
        public Guid? UnitOpsId { get; set; }

        public Country Country { get; set; }
        public CountryOfOperation CountryOps { get; set; }
        public Mission Mission { get; set; }
        public UnitOps UnitOps { get; set; }
    }
}
