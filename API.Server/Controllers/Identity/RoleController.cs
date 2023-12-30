using Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.ComponentModel.DataAnnotations;
using ViewModels.AppRole;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IAppRoleService _appRoleService;
        private readonly ILogger<RoleController> _logger;
        public RoleController(IAppRoleService appRoleService, ILogger<RoleController> logger)
        {
            _appRoleService = appRoleService;
            _logger = logger;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var roles = (await _appRoleService.GetAll()).Data.AsQueryable<AppRoleVM>();
                return Ok(roles);
            }
            catch (ValidationException ex)
            {
                return Problem(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
