using CrossDataBase.Server.Business.Abstraction.Core.Memory;
using CrossDataBase.Server.DataAccess.Abstraction.Core.Memory;
using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessData;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Core.Memory;

[InjectAsSingleton(typeof(IMemoryWriter))]
internal class MemoryWriter(IDbWriter dbWriter) : IMemoryWriter
{
}
