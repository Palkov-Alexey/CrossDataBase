namespace CrossDataBase.Server.Business.Abstraction.Core.ProcessData;

public interface IProcessService
{
    Task<int> GetOnCreateAsync(int? processId);
}