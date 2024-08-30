using CrossDataBase.Server.DataAccess.Abstraction.Core.Memory;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.DataAccess.Core.SQLite;

[InjectAsSingleton(typeof(IDbWriter))]
internal class DbWriter(ISQLiteExecutor executor,
                ISqlScriptReader scriptReader) : IDbWriter
{
    private readonly ISQLiteExecutor executor = executor;
    private readonly ISqlScriptReader scriptReader = scriptReader;
}
