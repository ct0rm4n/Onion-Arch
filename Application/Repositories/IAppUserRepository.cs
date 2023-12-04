using Domain.Entities.Concrates;

namespace Application.Repositories
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
        public Task<List<AppUser>> GetAllAppUsersWithRoles();
        public Task<AppUser> GetAppUserWithRoles(int id);

    }
}
