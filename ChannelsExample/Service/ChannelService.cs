
using System.Collections.Concurrent;
using System.Threading.Channels;
using ChannelsExample.Model;

namespace ChannelsExample.Service;

public sealed class ChannelService
{
   public readonly ConcurrentQueue<Message> _ConsumedMessage = new();
    public Channel<string> _Channel { get; } = Channel.CreateUnbounded<string>();
}
