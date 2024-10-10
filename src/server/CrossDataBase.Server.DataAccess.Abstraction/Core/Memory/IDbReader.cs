
namespace CrossDataBase.Server.DataAccess.Abstraction.Core.Memory;

public interface IDbReader
{
    Task<IReadOnlyList<object>> GetAsync(Guid processId);
}
