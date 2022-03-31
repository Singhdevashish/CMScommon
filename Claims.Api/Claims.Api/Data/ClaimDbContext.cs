using Claim.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Claim.Api.Data
{
    public class ClaimDbContext : DbContext
    {
        public ClaimDbContext() { }

        public ClaimDbContext(DbContextOptions<ClaimDbContext> options) : base(options) { }

        public DbSet<ClaimRequest> ClaimRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClaimRequest>().HasKey(c => c.ClaimId);
        }
    }
}
