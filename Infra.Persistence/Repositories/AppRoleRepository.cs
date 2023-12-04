using Application.Repositories;
using Domain.Entities.Concrates;
using Infraestrutura.Context;
using Microsoft.AspNetCore.Identity;

namespace Infraestrutura.Repositories
{
    public class AppRoleRepository : GenericRepository<AppRole>, IAppRoleRepository
    {
        public AppRoleRepository(AppDbContext appDbContext, UserManager<AppUser> userManager) : base(appDbContext)
        {
        }
    }
}
