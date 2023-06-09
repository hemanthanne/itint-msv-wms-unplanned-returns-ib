using Lakeshore.SendUnplannedReturn.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Lakeshore.SendUnplannedReturn.Infrastructure.EntityModelConfiguration
{

    public class UnplannedReturnDbContext : DbContext
    {
        public UnplannedReturnDbContext(DbContextOptions<UnplannedReturnDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public virtual DbSet<Hrt_dtl> Hrt_dtl { get; set; }

        public virtual DbSet<Hrt_hdr> Hrt_hdr { get; set; }

    }
}

