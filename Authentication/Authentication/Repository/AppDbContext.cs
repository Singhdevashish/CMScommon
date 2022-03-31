using Authentication.DTOs;
using Authentication.Models;
using Authentication.Models.Registration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Repository
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<MemberDTO> Members { get; set; }
        public virtual DbSet<Admin> RegAdmin { get; set; }
    }
}
