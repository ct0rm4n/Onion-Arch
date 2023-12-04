using Application.Repositories;
using Domain.Entities.Concrates;
using Infraestrutura.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositories
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {

        public AppUserRepository(AppDbContext appDbContext, UserManager<AppUser> userManager) : base(appDbContext)
        {
        }

        //get all appusers with roles and return List<AppUser>
        public async Task<List<AppUser>> GetAllAppUsersWithRoles()
        {
            return await GetActivesAsIQueryable()                                                   
                                                .Include(x => x.UserRoles)
                                                .ThenInclude(x => x.Role)
                                                .ToListAsync();
             
        }

        //get app user with roles and return AppUser
        public async Task<AppUser> GetAppUserWithRoles(int id)
        {
            AppUser? appUser = await GetActivesAsIQueryable()
                                     .Include(x => x.UserRoles)
                                     .ThenInclude(x => x.Role)
                                     .FirstOrDefaultAsync(x => x.Id == id);
            return appUser;
        }
        
    }
}
