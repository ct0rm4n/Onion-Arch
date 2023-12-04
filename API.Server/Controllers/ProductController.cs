using Application.Repositories;
using Domain.Entities.Concrates;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                return await _productRepository.GetProducts();                
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Product>();
            }
        }
        [HttpGet(Name ="GetById")]
        public async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                return await _productRepository.FindAsync(id);
            }
            catch(Exception ex)
            {
                return new Product();
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
