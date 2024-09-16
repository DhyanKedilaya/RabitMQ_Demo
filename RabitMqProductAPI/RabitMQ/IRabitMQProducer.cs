namespace RabitMqProductAPI.RabitMQ
{
    public interface IRabitMQProducer
    {
        public void SendProductMessage <T> (T message);
        //the purpose of this is for the message queue inside the RabbitMQ folder.
    }
}
