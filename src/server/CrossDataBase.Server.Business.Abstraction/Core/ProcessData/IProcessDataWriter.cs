namespace CrossDataBase.Server.Business.Abstraction.Core.ProcessData;
public interface IProcessDataWriter
{
    Task<int> InsertAsync();
}
