using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using RabbitMQ.Client;
using Treinaí.RabbitMQ;

namespace Treinai.UnitTests
{
    public class RabbitMQServiceTests
    {
        [Fact]
        public void Publish_PublishesMessageToQueue()
        {
           
            var configuration = new Mock<IConfiguration>();
            var logger = new Mock<ILogger<RabbitMQService>>();

            
            var mockConnectionFactory = new Mock<IConnectionFactory>();
            var mockConnection = new Mock<IConnection>();
            var mockModel = new Mock<IModel>();

            mockConnectionFactory.Setup(x => x.CreateConnection()).Returns(mockConnection.Object);
            mockConnection.Setup(x => x.CreateModel()).Returns(mockModel.Object);

            var rabbitMQService = new RabbitMQService(configuration.Object, logger.Object);
            
            string message = "Teste de mensagem para RabbitMQ";

            
            rabbitMQService.Publish(message);

           
            mockModel.Verify(x => x.BasicPublish(
                It.IsAny<string>(),    
                It.IsAny<string>(),    
                It.IsAny<bool>(),      
                It.IsAny<IBasicProperties>(), 
                It.IsAny<byte[]>()),   
                Times.Once);

        }
    }
}