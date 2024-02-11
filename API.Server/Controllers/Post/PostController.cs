using Microsoft.AspNetCore.Mvc;
using Services;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Application.ViewModels.Post;
using Application;
using Application.Dto.ViewModels.Wrappers;
using Application.Dto.Helpers;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Wrappers;

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
                var data = (await _repository.GetList(true));
                var pagedData = data.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                   .Take(validFilter.PageSize)
                   .ToList();

                var totalRecords = data.Count();
                var pagedReponse = PaginationHelper.CreatePagedReponse<PostVM>(pagedData, validFilter, totalRecords, route, "https://localhost:7279");
                return Ok(pagedReponse);
            }
            catch (ValidationException e)
            {
                _logger.LogError(e, e.Message + "/n Validation Exception Details.");
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message + "/n Validation exception Details.");
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<PostVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BadRequestObjectResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(JsonResult))]
        [ProducesResponseType(StatusCodes.Status302Found, Type = typeof(NotFoundObjectResult))]
        public async Task<ActionResult<Result<PostVM>>> GetByIdAsync([FromQuery] int id)
        {
            try
            {
                if (id <= 0) 
                    return Result<PostVM>.Fail(StatusCodes.Status302Found, new List<string>(){ "Invalid Id." });

                var entity = await _repository.FirstOrDefaultAsync(x => x.Id == id);

                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return Result<PostVM>.Fail(StatusCodes.Status500InternalServerError, new List<string>() { e.Message, "Exception Details." });
            }
        }
        [HttpPost("Create")]
        public async Task<ActionResult<PostSaveVM?>> Create([FromForm] PostSaveVM model)
        {
            try
            {
                await _repository.AddAsync(model);
                return model;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message + "/n Validation exception Details.");
                return BadRequest(e.Message);
            }
        }
    }
}
