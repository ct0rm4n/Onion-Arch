using Microsoft.AspNetCore.Mvc;
using Services;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Application.Dto.ViewModels.Wrappers;
using Application.Dto.Helpers;
using Application.Dto.ViewModels.Banner;

namespace API.Server.Controllers.Banner
{
    [ApiController]
    [Route("api/[controller]")]
    public class BannerController : ControllerBase
    {
        private readonly IBannerService _repository;
        private readonly ILogger<BannerController> _logger;
        public BannerController(ILogger<BannerController> logger, IBannerService repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IList<BannerVM>>> GetAllAsync([FromQuery] PaginationFilter filter)
        {
            try
            {
                var route = Request.Path.Value;
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var data = (await _repository.GetAll()).Data;
                var pagedData = data
                   .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                   .Take(validFilter.PageSize)
                   .ToList();
                var totalRecords = data.Count();
                var pagedReponse = PaginationHelper.CreatePagedReponse<BannerVM>(pagedData, validFilter, totalRecords, route, "https://localhost:7279");
                return Ok(pagedReponse);
            }
            catch (ValidationException e)
            {
                _logger.LogError(e, e.Message + "/n Validation Exception Details.");
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetBy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BannerVM>> GetByIdAsync([FromQuery] int id)
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
        public async Task<BannerSaveVM?> Create([FromForm] BannerSaveVM model)
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
