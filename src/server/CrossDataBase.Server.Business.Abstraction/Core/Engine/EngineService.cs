
namespace CrossDataBase.Server.Business.Abstraction.Core.Engine;
public interface IEngineService
{
    Task StartAsync(long processId, long historyId);
}
