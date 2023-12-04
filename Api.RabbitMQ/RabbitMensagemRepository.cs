using Rabbit.Repositories.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using API.Rabbit.Entities;

namespace API.Rabbit.Repositories
{
    public class RabbitMensagemRepository : IRabbitMensagemRepository
    {
        public void SendMensagem(RabbitMensagem mensagem)
        {
            var factory = new ConnectionFactory() { 
                HostName = "127.0.0.1",
                UserName = "guest",
                Password = "guest",
                Port = Protocols.DefaultProtocol.DefaultPort,
                VirtualHost = "/"
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "rabbitMensagesQueue",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string json =  JsonSerializer.Serialize(mensagem);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "",
                                     routingKey: "rabbitMensagesQueue",
                                     basicProperties: null,
                                     body: body);                
            }
        }
    }
}
