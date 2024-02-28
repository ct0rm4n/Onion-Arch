using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Application.Repositories;
using ViewModels.Account;
using ViewModels.AppRole;
using ViewModels.AppUser;
using Wrappers;
using Domain.Entities.Concrates;
using Domain.Enums;
using System.Collections.Generic;
using ViewModels.AppUserRole;

namespace Services
{
    public class AppUserService : GenericService<AppUserSaveVM, AppUserVM, AppUser>, IAppUserService
    {
        protected readonly UserManager<AppUser> _userManager;
        protected readonly SignInManager<AppUser> _signInManager;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        //protected readonly IEMailService _eMailService;
        protected readonly IAppUserRepository _appUserRepository;

        public AppUserService(IGenericRepository<AppUser> repository, IMapper mapper, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor, IAppUserRepository appUserRepository) : base(repository, mapper)
        {
           // _eMailService = eMailService;
            _userManager.RegisterTokenProvider(TokenOptions.DefaultProvider, new EmailTokenProvider<AppUser>());
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _appUserRepository = appUserRepository;
        }

        public async Task<Result<AppUserSaveVM>> RegisterBasicUserAsync(AppUserSaveVM viewModel, string origin)
        {
            bool isUserNameExist = await _userManager.FindByNameAsync(viewModel.UserName) == null ? false : true;
            if (isUserNameExist)
                return Result<AppUserSaveVM>.Fail($"{viewModel.UserName} already exist");

            bool isMailExist = await _userManager.FindByEmailAsync(viewModel.Email) == null ? false : true;
            if (isMailExist)
                return Result<AppUserSaveVM>.Fail($"an account already registered with {viewModel.Email}");

            AppUser appUser = _mapper.Map<AppUser>(viewModel);

            IdentityResult result = await _userManager.CreateAsync(appUser, viewModel.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, Role.Member.ToString());
                string verificationUri = await GenerateVerificationEmailUri(appUser, origin);
                //await _eMailService.SendAsync(new EMailDTO()
                //{
                //    To = viewModel.Email,
                //    Body = $"click {verificationUri} to complete registration",
                //    Subject = "registration"
                //});
                AppUserSaveVM appUserSaveVM = _mapper.Map<AppUserSaveVM>(appUser);
                return Result<AppUserSaveVM>.Success(appUserSaveVM, $"check your e-mail to confirm your account.");
            }
            return Result<AppUserSaveVM>.Fail($"an error occured");

        }

        //Private Method For Creating Email Uri
        private async Task<string> GenerateVerificationEmailUri(AppUser user, string origin)
        {
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

            string route = "Account/ConfirmEmail";
            Uri uri = new Uri(string.Concat($"{origin}/", route));
            string verificationUri = QueryHelpers.AddQueryString(uri.ToString(), "userId", user.Id.ToString());
            verificationUri = QueryHelpers.AddQueryString(verificationUri, "token", token);

            return $"<a href={verificationUri}>Verification Link</a>";
        }


        public async Task<string> ConfirmEmailAsync(string userId, string token)
        {
            AppUser? user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return "No Accounts registered with this user";

            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            IdentityResult result = await _userManager.ConfirmEmailAsync(user, token);

            if (!result.Succeeded)
                return $"An error occurred while confirming account related {user.Email}.";


            return $"Account confirmed for {user.Email} - ({user.UserName}). You can now use the app as a Member";
        }

        public async Task<Result<AppUserSaveVM>> LoginAsync(AppUserLoginVM vm)
        {
            AppUser? user = await _userManager.FindByEmailAsync(vm.Email);
            if (user == null)
                return Result<AppUserSaveVM>.Fail("wrong e-mail");

            if (!user.EmailConfirmed)
                return Result<AppUserSaveVM>.Fail("e-mail is not verified");

            SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName, vm.Password, vm.RememberMe, lockoutOnFailure: false);

            if (!result.Succeeded)
                return Result<AppUserSaveVM>.Fail("wrong password");

            AppUserSaveVM appUserSaveVM = _mapper.Map<AppUserSaveVM>(user);
            return Result<AppUserSaveVM>.Success(appUserSaveVM);
        }

        //create sign out method
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<Result<AppUserVM>> GetUserAsync()
        {
            HttpContext? httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                AppUser? curUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                AppUserVM appUserVM = _mapper.Map<AppUserVM>(curUser);
                return Result<AppUserVM>.Success(appUserVM);
            }
            return Result<AppUserVM>.Fail("user not found");
        }

        //get app users with its roles
        public async Task<Result<List<AppUserVM>>> GetAllAppUsersWithRoles()
        {
            List<AppUser> appUsers =  _repository.GetAllAsIQueryable().ToList();
            List<AppUserVM> appUserVMs = _mapper.Map<List<AppUserVM>>(appUsers);
            return Result<List<AppUserVM>>.Success(appUserVMs);
        }

        //get app user with role and set isAssigned as true 
        public async Task<Result<AppUserVM>> GetAppUserWithRoles(int id)
        {
            AppUser appUser = await _appUserRepository.FirstOrDefaultAsync(x => x.Id == id);//GetAppUserWithRoles(id);
            AppUserVM appUserVM = _mapper.Map<AppUserVM>(appUser);
            List<AppRoleVM>? roles = new List<AppRoleVM>();//(await GetAllRoles()).Data;
            foreach (int item in appUserVM.AppUserRoleVMs.Select(x => x.RoleId))
                if (roles.Select(x => x.Id).Contains(item))
                    roles.FirstOrDefault(x => x.Id == item).isAssigned = true;
            appUserVM.AppRoleVMs = roles;
            return Result<AppUserVM>.Success(appUserVM);
        }
        
        ////get all roles 
        // public async Task<Result<List<AppRoleVM>>> GetAllRoles()
        //{
        //    List<AppRole> appRoles = await _roleManager.Roles.ToListAsync();
        //    List<AppRoleVM> appRoleVMs = _mapper.Map<List<AppRoleVM>>(appRoles);
        //    return Result<List<AppRoleVM>>.Success(appRoleVMs);
        //}

        //update app user role
        public async Task<Result<AppUserVM>> UpdateAppUserRole(AppUserVM viewModel)
        {
            List<string> rolesToBeAdded = viewModel.AppRoleVMs.Where(x => x.isAssigned).Select(x => x.Name).ToList(); //m,s
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            IList<string> userRoles = await _userManager.GetRolesAsync(appUser);

            if (userRoles != null)
                await _userManager.RemoveFromRolesAsync(appUser, userRoles);

            foreach (string item in rolesToBeAdded)
                await _userManager.AddToRoleAsync(appUser, item);
            AppUser user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user.Id == viewModel.Id)
                await _signInManager.RefreshSignInAsync(user);
            return Result<AppUserVM>.Success(_mapper.Map<AppUserVM>(appUser));
        }
    }
}