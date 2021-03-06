using RabbitMQ.Client;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OrderApi.Service.v1.Services;
using Microsoft.Extensions.Options;
using OrderApi.Messaging.Receive.Options.v1;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using OrderApi.Service.v1.Models;
using Microsoft.Extensions.Logging;

namespace OrderApi.Messaging.Receive.Receiver.v1
{
    public class CustomerFullNameUpdateReceiver : BackgroundService
    {
        private IModel _channel;
        private IConnection _connection;
        private readonly ICustomerNameUpdateService _customerNameUpdateService;
        private readonly string _hostname;
        private readonly string _queueName;
        private readonly string _username;
        private readonly string _password;
        private readonly ILogger<CustomerFullNameUpdateReceiver> _logger;

        public CustomerFullNameUpdateReceiver(ICustomerNameUpdateService customerNameUpdateService, IOptions<RabbitMqConfiguration> rabbitMqOptions, ILogger<CustomerFullNameUpdateReceiver> logger)
        {
            _logger = logger;
            _hostname = rabbitMqOptions.Value.Hostname;
            _queueName = rabbitMqOptions.Value.QueueName;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;
            _customerNameUpdateService = customerNameUpdateService;
            InitializeRabbitMqListener();
        }

        private void InitializeRabbitMqListener()
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };
            _connection = factory.CreateConnection();
            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (ch, ea) =>
              {
                  var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                  var updateCustomerFullNameModel = JsonConvert.DeserializeObject<UpdateCustomerFullNameModel>(content);

                  HandleMessage(updateCustomerFullNameModel);
                  _channel.BasicAck(ea.DeliveryTag, false);
                  _logger.LogInformation($"Message received. Content: {content}");
              };
            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerCancelled;

            _channel.BasicConsume(_queueName, false, consumer);
            return Task.CompletedTask;
        }

        private void OnConsumerCancelled(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerRegistered(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerShutdown(object sender, ShutdownEventArgs e)
        {
        }

        private void HandleMessage(UpdateCustomerFullNameModel updateCustomerFullNameModel)
        {
            _customerNameUpdateService.UpdateCustomerNameInOrder(updateCustomerFullNameModel);
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
