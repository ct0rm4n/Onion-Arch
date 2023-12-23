using Application.Repositories;
using Core.Domain.Entities.Concrates.Catalog;
using Microsoft.AspNetCore.Mvc;
using Service.Interface.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace API.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IList<Product>>> GetAllAsync([FromQuery] ProductSearchDto productSearchDto)
        {
            try
            {
                //TODO : apply filter in services
                var result = (await _productRepository.GetProducts()).ToList();
                if(result is null || result.Count() == 0)
                {
                    return NotFound("all");
                }
                return Ok(result);
            }
            catch (ValidationException e)
            {
                _logger.LogError(e, e.Message + "/n Validation Exception Details.");
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id:int}",Name ="GetById")]
        public async Task<ActionResult<Product>> GetByIdAsync([FromQuery] int id)
        {
            try
            {
                return await _productRepository.FindAsync(id);
            }
            catch(ValidationException e)
            {
                _logger.LogError(e, e.Message + "/n Validation Exception Details.");
                return BadRequest(e.Message);
            }        
        }
        [HttpPost(Name = "Create")]
        public async Task<Product?> Create([FromForm]Product product) 
        {
            try
            {
                return await _productRepository.AddAsync(product);
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, $"{HttpStatusCode.InternalServerError} {ex.Message}");
                return null;
            }
        }
    }
}
