using Domain.Entities.Concrates;
using ViewModels.AppRole;
using ViewModels.Category;
using Wrappers;

namespace Services
{
    public interface IAppRoleService : IGenericService<AppRoleSaveVM, AppRoleVM, AppRole>
    {
        public Task<Result<List<AppRoleVM>>> GetAll();
        public Task<Result<AppRoleVM>> RegisterRoleAsync(AppRoleVM role);
    }
}
