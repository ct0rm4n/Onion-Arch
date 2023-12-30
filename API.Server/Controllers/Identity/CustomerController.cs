using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ILogger<CustomerController> logger) 
        { 
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> Get()
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
        public async Task<ActionResult> Create()
        {
            try
            {
                return Ok();
            }catch(ValidationException ex)
            {
                return Problem(ex.Message);
            }
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
