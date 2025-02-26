
using Microsoft.EntityFrameworkCore;

using NpiRelay.Models;

namespace NpiRelay.Context
{
    public class NpiRelayDbContext : DbContext
    {
        public NpiRelayDbContext(DbContextOptions<NpiRelayDbContext> options)
            : base(options)
        {
        }

        public DbSet<CmsRecord> CmsRecords { get; set; }
        public DbSet<Taxonomy> Taxonomy { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}