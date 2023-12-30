using Microsoft.AspNetCore.Mvc;
using Services;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Application.ViewModels.Post;
using Application;
using Application.Dto.ViewModels.Wrappers;
using Application.Dto.Helpers;

namespace API.Server.Controllers.Post
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _repository;
        private readonly ILogger<PostController> _logger;
        public PostController(ILogger<PostController> logger, IPostService repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IList<PostVM>>> GetAllAsync([FromQuery] PaginationFilter filter)
        {
            try
            {
                var route = Request.Path.Value;
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var pagedData = (await _repository.GetAll()).Data
                   .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                   .Take(validFilter.PageSize)
                   .ToList();
                var totalRecords = (await _repository.GetAll()).Data.Count();
                var pagedReponse = PaginationHelper.CreatePagedReponse<PostVM>(pagedData, validFilter, totalRecords, route, "https://localhost:7279");
                return Ok(pagedReponse);
            }
            catch (ValidationException e)
            {
                _logger.LogError(e, e.Message + "/n Validation Exception Details.");
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetBy")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Application.ViewModels.Post.PostVM>> GetByIdAsync([FromQuery] int id)
        {
            try
            {
                if (id <= 0) return BadRequest(new { Id = "Id", menssage = "Invalid Id." });

                var entity = await _repository.FirstOrDefaultAsync(x=>x.Id == id);
                return entity.Data;
            }
            catch (ValidationException e)
            {
                _logger.LogError(e, e.Message + "/n Validation Exception Details.");
                return Problem(e.Message);
            }
        }
        [HttpPost("Create")]
        public async Task<PostSaveVM?> Create([FromForm] PostSaveVM model)
        {
            try
            {
                await _repository.AddAsync(model);
                return model;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"{HttpStatusCode.InternalServerError} {ex.Message}");
                return null;
            }
        }
    }
}
