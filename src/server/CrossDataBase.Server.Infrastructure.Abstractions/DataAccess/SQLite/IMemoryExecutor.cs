﻿using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Models;

namespace CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
public interface IMemoryExecutor
{
    Task ExecuteAsync(QueryObject query);
}