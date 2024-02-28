using AutoMapper;
using Microsoft.AspNetCore.Http;
using Application.Repositories;
using ViewModels.AppRole;
using Wrappers;
using Domain.Entities.Concrates;
using Domain.Enums;
using ViewModels.AppUserRole;
namespace Services
{
    public class AppUserRoleService : GenericService<AppUserRoleSaveVM, AppUserRoleVM, AppUserRole>, IAppUserRoleService
    {        
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public AppUserRoleService(IGenericRepository<AppUserRole> repository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(repository, mapper)
        {
            _httpContextAccessor = httpContextAccessor;            
        }

        //get all roles 
        public async Task<Result<List<AppUserRoleVM>>> GetAll(bool deleted = false)
        {
            List<AppUserRole> appRoles = _repository.GetAllAsIQueryable().Where( x=> !x.Status.Equals(Status.Deleted)).ToList();
            if(deleted)
                appRoles = _repository.GetAllAsIQueryable().ToList();
            List<AppUserRoleVM> appRoleVMs = _mapper.Map<List<AppUserRoleVM>>(appRoles);
            return Result<List<AppUserRoleVM>>.Success(appRoleVMs);
        }
        public async Task<Result<AppUserRoleVM>> RegisterUserRoleAsync(AppUserRoleVM role)
        {            
            AppUserRole appRoleVMs = _mapper.Map<AppUserRole>(role);
            await _repository.AddAsync(appRoleVMs);
            return Result<AppUserRoleVM>.Success(role);
        }

    }
}