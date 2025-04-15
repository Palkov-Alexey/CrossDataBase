
namespace CrossDataBase.Server.Business.Abstraction.Core.Engine;
public interface IEngineService
{
    Task RunAsync(int processId);
    //Task StartAsync(long processId, long historyId);
}
