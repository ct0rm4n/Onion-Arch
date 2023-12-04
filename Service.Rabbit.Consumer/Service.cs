using System.Text.Json;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Rabbit.Models.Entities;

public class Service
{
    public void initService()
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest",
            Port = 15672
        };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "rabbitMensagesQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);

                RabbitMensagem mensagem = JsonSerializer.Deserialize<RabbitMensagem>(json);

                System.Threading.Thread.Sleep(1000);

                Console.WriteLine($"Titulo: {mensagem.Titulo}; Texto={mensagem.Texto}; Id={mensagem.Id}");
            };
            channel.BasicConsume(queue: "rabbitMensagesQueue",
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
} 
    
