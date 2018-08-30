using VFS.Common.Models.Masters;

namespace VFS.MicroServices.MDM.Models
{
    public partial class MstcountryLangMap
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }

        public Country Country { get; set; }
        public Language Language { get; set; }
    }
}
