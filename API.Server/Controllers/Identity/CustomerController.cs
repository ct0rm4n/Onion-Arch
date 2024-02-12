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
using Services;
using Application.Dto.Helpers;
using Application.Dto.ViewModels.Wrappers;
using ViewModels.Product;

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
        private readonly Services.IAppUserService _servicesUser;
        public CustomerController(ILogger<CustomerController> logger, IMapper mapper,
            UserManager<AppUser> userManager, IUserStore<AppUser> userStore,
            SignInManager<AppUser> SignInManager, IEmailSender<AppUser> EmailSender, IAppUserService servicesUser) 
        { 
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _userStore = userStore;
            _SignInManager = SignInManager;
            _EmailSender = EmailSender;
            _servicesUser = servicesUser;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            try
            {
                ;
                var route = Request.Path.Value;
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var data = ((await _servicesUser.GetAllAppUsersWithRoles()).Data.ToList()).Select(product => _mapper.Map<ProductVM>(product)).ToList();
                var pagedData = data
                   .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                   .Take(validFilter.PageSize)
                   .ToList();

                var totalRecords = data.Count();
                var pagedReponse = PaginationHelper.CreatePagedReponse<ProductVM>(pagedData, validFilter, totalRecords, route, "https://localhost:7279");
                return Ok(pagedReponse);
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
                var entity = (from users in (await _servicesUser.GetAllAppUsersWithRoles()).Data
                 where users.Id == id select users).FirstOrDefault();
                return Ok(entity);
            }
            catch (ValidationException ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestObjectResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(JsonResult))]
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
