namespace Service.Rabbit.Consumer.Interfaces
{
    public interface IConsumerService
    {
        void ConsumerQueue(string queueName);
    }
}
