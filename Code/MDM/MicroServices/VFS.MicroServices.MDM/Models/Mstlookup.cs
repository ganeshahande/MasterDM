using System;
using System.Collections.Generic;

namespace VFS.MicroServices.MDM.Models
{
    public partial class Mstlookup
    {
        public Mstlookup()
        {
            Language = new HashSet<Language>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Language> Language { get; set; }
    }
}
