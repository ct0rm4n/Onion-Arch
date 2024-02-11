using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text;
using ViewModels.AppUser;
using Domain.Entities.Concrates;
using AutoMapper;
using Application.ViewModels.Post;
using Services.Account;

namespace API.Server.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserStore<AppUser> _userStore;
        private readonly SignInManager<AppUser> _SignInManager;
        private readonly IEmailSender<AppUser> _EmailSender;
        
        public CustomerController(ILogger<CustomerController> logger, IMapper mapper,
            UserManager<AppUser> userManager, IUserStore<AppUser> userStore,
            SignInManager<AppUser> SignInManager, IEmailSender<AppUser> EmailSender) 
        { 
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _userStore = userStore;
            _SignInManager = SignInManager;
            _EmailSender = EmailSender;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok();
            }catch (ValidationException ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                return Ok();
            }
            catch (ValidationException ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpPost("Create")]
        public async Task<ActionResult> Create(AppUserVM user, string returnUrl = "")
        {
            try
            {
                IEnumerable<IdentityError>? identityErrors;
                var userEntity = _mapper.Map<AppUser>(user);
                await _userStore.SetUserNameAsync(userEntity, user.Email, CancellationToken.None);
                var emailStore = GetEmailStore();
                await emailStore.SetEmailAsync(userEntity, user.Email, CancellationToken.None);
                userEntity.Status = Domain.Enums.Status.Inserted;
                var result = await _userManager.CreateAsync(userEntity, user.Password);

                if (!result.Succeeded)
                {
                    var responseError = string.Empty;
                    return Problem(string.Join(",", result.Errors));
                }
                var userId = await _userManager.GetUserIdAsync(userEntity);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(userEntity);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));                

                await _SignInManager.SignInAsync(userEntity, isPersistent: false);
                return Ok();
            }
            catch(ValidationException ex)
            {
                return Problem(ex.Message);
            }
        }
        private IUserEmailStore<AppUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<AppUser>)_userStore;
        }
        [HttpPut("Update")]
        public async Task<ActionResult> Update()
        {
            try
            {
                return Ok();
            }
            catch (ValidationException ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
