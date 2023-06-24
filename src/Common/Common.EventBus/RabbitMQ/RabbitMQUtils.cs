using RabbitMQ.Client;

namespace Common.EventBus.RabbitMQ;

public class RabbitMQUtils
{
    public static IConnection CreateConnection(string hostName, string userName, string password)
    {
        var factory = new ConnectionFactory()
        {
            UserName = userName,
            Password = password,
            HostName = hostName
        };
        return factory.CreateConnection();
    }
}