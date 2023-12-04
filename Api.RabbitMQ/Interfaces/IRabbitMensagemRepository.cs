using API.Rabbit.Entities;

namespace Rabbit.Repositories.Interfaces
{
    public interface IRabbitMensagemRepository
    {
        void SendMensagem(RabbitMensagem mensagem);
    }
}
