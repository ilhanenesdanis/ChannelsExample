using System;
using System.Text.Json;
using ChannelsExample.Model;

namespace ChannelsExample.Service;

public sealed class ConsumerService : BackgroundService
{
    private readonly ChannelService _channelService;

    public ConsumerService(ChannelService channelService)
    {
        _channelService = channelService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var json in _channelService._Channel.Reader.ReadAllAsync(stoppingToken))
        {
            var data = JsonSerializer.Deserialize<Message>(json) ?? throw new InvalidOperationException("Failed to deserialize message");

            _channelService._ConsumedMessage.Enqueue(data);

            Console.WriteLine($"Consumed: {data.Id} - {data.Text}");
        }
    }
}
