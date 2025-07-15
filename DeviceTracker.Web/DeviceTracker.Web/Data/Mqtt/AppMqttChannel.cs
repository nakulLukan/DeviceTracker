using DeviceTracker.Core.Constants;
using DeviceTracker.Core.Contracts;
using DeviceTracker.Shared.Dto.ChannelPayload;
using MediatR;
using MQTTnet;
using MQTTnet.Packets;
using System.Security.Authentication;
using System.Text;

namespace DeviceTracker.Web.Data.Mqtt;

public class AppMqttChannel : IMqttChannel
{
    private readonly IMqttClient _mqttClient;
    private readonly MqttClientFactory _factory;
    private readonly IConfiguration _configuration;
    private readonly IServiceProvider _serviceProvider;

    public AppMqttChannel(IConfiguration configuration, IServiceProvider serviceProvider)
    {
        _configuration = configuration;
        _factory = new MqttClientFactory();
        _mqttClient = _factory.CreateMqttClient();

        _mqttClient.ConnectedAsync += e =>
        {
            Console.WriteLine("Connected to MQTT broker.");
            return Task.CompletedTask;
        };


        _mqttClient.ApplicationMessageReceivedAsync += MessageReceived;
        _serviceProvider = serviceProvider;
    }

    public async Task InitChannelAsync()
    {
        await ConnectAsync(CancellationToken.None);
        await Subscribe();
    }

    public Task ConnectAsync(CancellationToken cancellationToken)
    {
        var options = new MqttClientOptionsBuilder()
            .WithTcpServer(_configuration[AppsettingKeyConstants.Mqtt_Host], int.Parse(_configuration[AppsettingKeyConstants.Mqtt_Port]!))
            .WithCredentials(_configuration[AppsettingKeyConstants.Mqtt_Username], _configuration[AppsettingKeyConstants.Mqtt_Password])
            .WithTlsOptions(
                        o =>
                        {
                            // The used public broker sometimes has invalid certificates. This sample accepts all
                            // certificates. This should not be used in live environments.
                            o.WithCertificateValidationHandler(_ => true);

                            // The default value is determined by the OS. Set manually to force version.
                            o.WithSslProtocols(SslProtocols.Tls12);
                        })
            .Build();
        return _mqttClient.ConnectAsync(options, cancellationToken);
    }

    public async Task Subscribe()
    {
        var mqttSubscribeOptions = _factory.CreateSubscribeOptionsBuilder().WithTopicFilter(new MqttTopicFilter()
        {
            Topic = "PowerData",
        }).Build();

        await _mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
    }

    private async Task MessageReceived(MqttApplicationMessageReceivedEventArgs e)
    {
        if (e.ApplicationMessage.Topic != "PowerData") return;
        using (var scope = _serviceProvider.CreateScope())
        {
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            await mediator.Send(new Core.Requests.Metric.StoreMetricCommand
            {
                JsonPayload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload)
            }, CancellationToken.None);

        }
    }

    public async Task<bool> PublishMessage(string deviceName, ChannelPayloadBaseDto payload, CancellationToken cancellationToken = default)
    {
        var applicationMessage = new MqttApplicationMessageBuilder()
                .WithTopic($"ControlData:{deviceName}")
                .WithPayload(payload.SerializePayload())
                .Build();

        var result = await _mqttClient.PublishAsync(applicationMessage, cancellationToken);
        return result.IsSuccess;
    }
}
