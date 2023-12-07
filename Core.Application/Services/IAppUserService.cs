using Application.ViewModels;
using ViewModels.AppRole;
using ViewModels.Account;
using ViewModels.AppUser;
using Wrappers;
using Domain.Entities.Concrates;

namespace Services
{
    public interface IAppUserService : IGenericService<AppUserSaveVM, AppUserVM, AppUser>
    {
        public Task<Result<AppUserSaveVM>> RegisterBasicUserAsync(AppUserSaveVM viewModel, string origin);
        public Task<string> ConfirmEmailAsync(string userId, string token);
        public Task<Result<AppUserSaveVM>> LoginAsync(AppUserLoginVM vm);
        public Task SignOutAsync();
        public Task<Result<AppUserVM>> GetUserAsync();
        public Task<Result<List<AppUserVM>>> GetAllAppUsersWithRoles();
        //public Task<Result<AppUserVM>> GetAppUserWithRoles(int id);
        //public Task<Result<List<AppRoleVM>>> GetAllRoles();
        //public Task<Result<AppRoleVM>> InsertRoles();
        public Task<Result<AppUserVM>> UpdateAppUserRole(AppUserVM viewModel);

    }
}
