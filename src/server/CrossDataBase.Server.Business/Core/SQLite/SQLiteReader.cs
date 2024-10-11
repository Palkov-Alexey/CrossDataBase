using CrossDataBase.Server.Business.Abstraction.Core.SQLite;
using CrossDataBase.Server.DataAccess.Abstraction.Core.SQLite;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Core.SQLite;

[InjectAsSingleton(typeof(ISQLiteReader))]
internal class SQLiteReader(IDbReader dbReader) : ISQLiteReader
{
}
