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
using ViewModels.Category;
using ViewModels.Product;

namespace API.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _catRepository;
        private readonly ILogger<CategoryController> _logger;
        private readonly IMapper _mapper;
        public CategoryController(ILogger<CategoryController> logger, ICategoryRepository catRepository, IMapper mapper)
        {
            _logger = logger;
            _catRepository = catRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IList<CategoryVM>>> GetAllAsync([FromQuery] PaginationFilter filter)
        {
            try
            {
                var route = Request.Path.Value;
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var data = (_catRepository.GetAllCategoryWithAllChildren().Result).Select(product => _mapper.Map<CategoryVM>(product)).ToList();
                var pagedData =data
                   .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                   .Take(validFilter.PageSize)
                   .ToList();

                var totalRecords = data.Count();
                var pagedReponse = PaginationHelper.CreatePagedReponse<CategoryVM>(pagedData, validFilter, totalRecords, route, "https://localhost:7279");
                return Ok(pagedReponse);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message + "/n Validation Exception Details.");
                return BadRequest(e.Message);
            }
        }        
    }
}
