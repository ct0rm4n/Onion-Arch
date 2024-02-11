using Application.Dto.DTOs;
using Application.Dto.Helpers;
using Application.Dto.ViewModels.Wrappers;
using Application.Repositories;
using Application.ViewModels.Post;
using AutoMapper;
using Core.Domain.Entities.Concrates.Catalog;
using Microsoft.AspNetCore.Mvc;
using Service.Application.Services.Misc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using ViewModels.Product;

namespace API.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CnpjController : ControllerBase
    {
        private readonly ILogger<CnpjController> _logger;
        private readonly IMapper _mapper;
        private readonly CnpjService _cnpjService;
        public CnpjController(ILogger<CnpjController> logger, IMapper mapper, CnpjService cnpjService)
        {
            _logger = logger;
            _mapper = mapper;
            _cnpjService = cnpjService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<CnpjDto>> GetAllAsync([FromQuery] string cnpj)
        {
            try
            {
                var reponse = await _cnpjService.GetCnpj(cnpj);
                return Ok(reponse);
            }
            catch (ValidationException e)
            {
                _logger.LogError(e, e.Message + "/n Validation Exception Details.");
                return BadRequest(e.Message);
            }
        }        
    }
}
