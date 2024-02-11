using Application.Dto.DTOs;
using Application.Dto.Helpers;
using Application.Dto.ViewModels.Wrappers;
using Application.Repositories;
using Application.ViewModels.Post;
using AutoMapper;
using Core.Domain.Entities.Concrates.Catalog;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using ViewModels.Product;

namespace API.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository, IMapper mapper)
        {
            _logger = logger;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IList<ProductVM>>> GetAllAsync([FromQuery] PaginationFilter filter)
        {
            try
            {
                var route = Request.Path.Value;
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var data = ((await _productRepository.GetProducts()).ToList()).Select(product => _mapper.Map<ProductVM>(product)).ToList();
                var pagedData = data
                   .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                   .Take(validFilter.PageSize)
                   .ToList();

                var totalRecords = data.Count();
                var pagedReponse = PaginationHelper.CreatePagedReponse<ProductVM>(pagedData, validFilter, totalRecords, route, "https://localhost:7279");
                return Ok(pagedReponse);
            }
            catch (ValidationException e)
            {
                _logger.LogError(e, e.Message + "/n Validation Exception Details.");
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetByIdAsync([FromQuery] int id)
        {
            try
            {
                if (id <= 0) return BadRequest(new { Id = "Id", menssage = "Invalid Id." });
                
                return await _productRepository.FindAsync(id);
            }
            catch(ValidationException e)
            {
                _logger.LogError(e, e.Message + "/n Validation Exception Details.");
                return Problem(e.Message);
            }        
        }
        [HttpPost("Create")]
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
