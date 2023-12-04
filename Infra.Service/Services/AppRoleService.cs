using AutoMapper;
using Microsoft.AspNetCore.Http;
using Application.Repositories;
using ViewModels.AppRole;
using Wrappers;
using Domain.Entities.Concrates;
namespace Services
{
    public class AppRoleService : GenericService<AppRoleSaveVM, AppRoleVM, AppRole>, IAppRoleService
    {        
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public AppRoleService(IGenericRepository<AppRole> repository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(repository, mapper)
        {
            _httpContextAccessor = httpContextAccessor;            
        }

        //get all roles 
        public async Task<Result<List<AppRoleVM>>> GetAll()
        {
            List<AppRole> appRoles = _repository.GetAllAsIQueryable().ToList();
            List<AppRoleVM> appRoleVMs = _mapper.Map<List<AppRoleVM>>(appRoles);
            return Result<List<AppRoleVM>>.Success(appRoleVMs);
        }
        public async Task<Result<AppRoleVM>> RegisterRoleAsync(AppRoleVM role)
        {            
            AppRole appRoleVMs = _mapper.Map<AppRole>(role);
            await _repository.AddAsync(appRoleVMs);
            return Result<AppRoleVM>.Success(role);
        }

    }
}