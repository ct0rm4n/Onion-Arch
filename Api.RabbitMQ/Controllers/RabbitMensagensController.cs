using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Rabbit.Entities;
using Rabbit.Services.Interfaces;

namespace API.Rabbit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RabbitMensagensController : ControllerBase
    {
        private readonly IRabbitMensagemService _service;

        public RabbitMensagensController(IRabbitMensagemService service)
        {
            _service = service;
        }

        [HttpPost(Name = "AddMensagem")]
        public void AddMensagem(RabbitMensagem mensagem)
        {
            _service.SendMensagem(mensagem);
        }
    }
}
