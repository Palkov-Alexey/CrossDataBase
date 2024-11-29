
using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory;

namespace CrossDataBase.Server.HostedServices;

public class ReconnectMemoryDbHostedService(IProcessHistoryWriter historyWriter) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}
