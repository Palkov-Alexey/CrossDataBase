﻿using CrossDataBase.Server.Business.Abstraction.Core.ProcessData;
using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessData;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Core.ProcessData;

[InjectAsSingleton(typeof(IProcessDataWriter))]
internal class ProcessDataWriter(IProcessDataDbWriter dbWriter) : IProcessDataWriter
{
}