using RabbitMQ.Client;
using System.Text;

namespace Treinaí.RabbitMQ
{
    public interface IRabbitMQService
    {
        void Publish(string message);
    }

    public class RabbitMQService : IRabbitMQService
    {
        private readonly string _hostname;
        private readonly string _username;
        private readonly string _password;
        private IConnection _connection;

        public RabbitMQService(IConfiguration configuration)
        {
            _hostname = configuration["RabbitMQ:Host"];
            _username = configuration["RabbitMQ:UserName"];
            _password = configuration["RabbitMQ:Password"];

            CreateConnection();
        }

        private void CreateConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };

            _connection = factory.CreateConnection();
        }

        public void Publish(string message)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: "treinai_queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "treinai_queue",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}