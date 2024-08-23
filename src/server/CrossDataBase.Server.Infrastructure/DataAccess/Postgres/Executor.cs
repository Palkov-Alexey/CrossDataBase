using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Postgres;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Infrastructure.DataAccess.Postgres;
[InjectAsSingleton(typeof(IExecutor))]
internal class Executor : IExecutor
{
}
