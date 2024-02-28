using Application.Repositories;
using Domain.Entities.Concrates;
using Infraestrutura.Context;
using Microsoft.AspNetCore.Identity;

namespace Infraestrutura.Repositories
{
    public class AppUserRoleRepository : GenericRepository<AppUserRole>, IAppUserRoleRepository
    {
        public AppUserRoleRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
