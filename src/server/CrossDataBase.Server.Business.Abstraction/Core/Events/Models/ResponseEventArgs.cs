﻿namespace CrossDataBase.Server.Business.Abstraction.Core.Events.Models;
public class ResponseEventArgs : EventArgs
{
    public Guid Guid { get; set; }
    public string NodeKey { get; set; }
    public object Result { get; set; }
}
