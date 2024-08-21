using CrossDataBase.Server.DataAccess.Abstraction.Core.Memory;
using CrossDataBase.Server.DataAccess.Abstraction.Infrastructure;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.DataAccess.Core.Memory;

[InjectAsSingleton(typeof(IDbWritter))]
internal class DbWritter : IDbWritter
{
    private readonly IMemoryExecutor executor;
    public DbWritter(IMemoryExecutor executor)
    {
        this.executor = executor;
        this.executor.Init();
    }
}
