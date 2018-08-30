using Microsoft.EntityFrameworkCore;
using VFS.Common.Models.Masters;

namespace VFS.MicroServices.MDM.DataContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions opts) : base(opts)
        {
        }

        public DbSet<Country> Country { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
