using Domain.Entities.Concrates;
using ViewModels.AppRole;
using ViewModels.AppUserRole;
using ViewModels.Category;
using Wrappers;

namespace Services
{
    public interface IAppUserRoleService : IGenericService<AppUserRoleSaveVM, AppUserRoleVM, AppUserRole>
    {
        public Task<Result<List<AppUserRoleVM>>> GetAll(bool deleted = false);
        public Task<Result<AppUserRoleVM>> RegisterUserRoleAsync(AppUserRoleVM role);
    }
}
