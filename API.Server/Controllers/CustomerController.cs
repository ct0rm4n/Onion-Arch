using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Server.Controllers
{
    [ApiController]
    [Route("api/v1/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ILogger<CustomerController> logger) 
        { 
            _logger = logger;
        }

        [HttpGet]
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
        [HttpPost]
        public async Task<ActionResult> Post()
        {
            try
            {
                return Ok();
            }catch(ValidationException ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpPut]
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
