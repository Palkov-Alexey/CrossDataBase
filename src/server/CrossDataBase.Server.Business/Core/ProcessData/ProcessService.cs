using CrossDataBase.Server.Business.Abstraction.Core.ProcessData;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Core.ProcessData;

[InjectAsSingleton]
public class ProcessService(
    IProcessDataReader processDataReader,
    IProcessDataWriter processDataWriter) : IProcessService
{
    public Task<int> GetOnCreateAsync(int? processId)
    {
        if (processId == null)
        {
            return processDataWriter.InsertAsync();
        }
        
        return Task.FromResult(processId.Value);
    }
}