using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

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
        private readonly ILogger<RabbitMQService> _logger;
        private readonly IConnectionFactory _factory;

        public RabbitMQService(IConfiguration configuration, ILogger<RabbitMQService> logger)
        {
            _hostname = configuration["RabbitMQ:Host"];
            _username = configuration["RabbitMQ:UserName"];
            _password = configuration["RabbitMQ:Password"];
            _logger = logger;
            _factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };

            CreateConnection();
        }

        private void CreateConnection()
        {
            

            try
            {
                _logger.LogInformation($"Tentando conectar ao RabbitMQ em {_hostname} com usuário {_username}...");
                _connection = _factory.CreateConnection();
                _logger.LogInformation("Conexão com RabbitMQ estabelecida com sucesso.");
            }
            catch (BrokerUnreachableException ex)
            {
                _logger.LogError($"Erro ao conectar ao RabbitMQ: {ex.Message}");
                _logger.LogError($"Detalhes do erro: {ex.InnerException?.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro inesperado: {ex.Message}");
                throw; 
            }
        }

        public void Publish(string message)
        {

            if (_connection == null || !_connection.IsOpen)
            {
                _logger.LogError("A conexão com RabbitMQ não está aberta. Tentando reconectar...");
                CreateConnection();
            }

            try
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

                    _logger.LogInformation($"Mensagem publicada no RabbitMQ: {message}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao publicar mensagem no RabbitMQ: {ex.Message}");
                throw; 
            }
        }
    }

}