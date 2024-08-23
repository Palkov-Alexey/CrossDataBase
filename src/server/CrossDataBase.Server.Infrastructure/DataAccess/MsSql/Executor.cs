using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.MsSql;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Infrastructure.DataAccess.MsSql;
[InjectAsSingleton(typeof(IExecutor))]
internal class Executor : IExecutor
{
}
