namespace CrossDataBase.Server.Business.Abstraction.Core.Results;
public interface INodeResult
{
    Task ExecuteAsync(IServiceProvider serviceProvider);
}
