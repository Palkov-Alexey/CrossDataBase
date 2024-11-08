
namespace CrossDataBase.Server.Business.Abstraction.Core.Engine;
public interface IEngineService
{
    Task RunAsync(long processId);
    //Task StartAsync(long processId, long historyId);
}
