using Core.Domain.Entities.Concrates.Catalog;
using Domain.Entities.Concrates;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infraestrutura.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole,int,AppUserClaim,AppUserRole, AppUserLogin,AppRoleClaim,AppUserToken>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        public DbSet<Banner> Banners { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);//We've to call this first in order to avoid creating extra columns comes from Identity        
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }        
    }
}
