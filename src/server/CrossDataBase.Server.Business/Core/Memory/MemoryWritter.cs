﻿using CrossDataBase.Server.Business.Abstraction.Core.Memory;
using CrossDataBase.Server.DataAccess.Abstraction.Core.Memory;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Core.Memory;

[InjectAsSingleton(typeof(IMemoryWritter))]
internal class MemoryWritter(IDbWriter dbWritter) : IMemoryWritter
{
    private readonly IDbWriter dbWritter = dbWritter;
}