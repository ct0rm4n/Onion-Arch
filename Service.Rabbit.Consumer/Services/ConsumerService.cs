using System.Text.Json;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Service.Rabbit.Consumer.Interfaces;
using Service.Rabbit.Consumer.Entities;

public class ConsumerService : IConsumerService
{
    public ConsumerService()
    {

    }
    public void ConsumerQueue(string queueName)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "127.0.0.1",
            UserName = "guest",
            Password = "guest",
            Port = Protocols.DefaultProtocol.DefaultPort,
            VirtualHost = "/"
        };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: queueName,//"rabbitMensagesQueue",
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
            channel.BasicConsume(queue: queueName,//"rabbitMensagesQueue",
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
} 
    
