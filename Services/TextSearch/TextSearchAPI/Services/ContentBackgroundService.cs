using System.Text;
using System.Text.Json;
using AutoMapper;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using TextSearchAPI.Models;
using TextSearchAPI.Models.Dtos;

namespace TextSearchAPI.Services
{
    public class ContentBackgroundService : BackgroundService
    {

        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;
        public static string ExchangeName = "TextSearchExchange";
        public static string RoutingComment = "textsearch-route-send";
        public static string QueueName = "queue-textsearch-send";
        private readonly IServiceProvider _serviceProvider;
        private readonly IContentService _contentService;
        private readonly IMapper _mapper;

        public ContentBackgroundService(ConnectionFactory connectionFactory, IServiceProvider serviceProvider, IContentService contentService, IMapper mapper)
        {
            _connectionFactory = connectionFactory;
            _channel = Connect();
            _serviceProvider = serviceProvider;
            _contentService = contentService;
            _mapper = mapper;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var channel = Connect();
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var likeCreatedEvent = JsonSerializer.Deserialize<TextSearchContentEvent>(Encoding.UTF8.GetString(ea.Body.ToArray()));
                    var content=_mapper.Map<Content>(likeCreatedEvent);
                    _contentService.SaveAsync(content);
                };

                channel.BasicConsume(queue: QueueName, autoAck: true, consumer: consumer);

                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }

        public IModel Connect()
        {
            _connection = _connectionFactory.CreateConnection();
            if (_channel is { IsOpen: true })
            {
                return _channel;
            }
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(ExchangeName, type: "direct", true, false);
            _channel.QueueDeclare(QueueName, durable: true, exclusive: false, false, null);
            _channel.QueueBind(exchange: ExchangeName, queue: QueueName, routingKey: RoutingComment);
            return _channel;
        }
    }
}