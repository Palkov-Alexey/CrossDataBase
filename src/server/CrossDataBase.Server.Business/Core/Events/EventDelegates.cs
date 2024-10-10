namespace CrossDataBase.Server.Business.Core.Events;

public delegate Task AsyncEventHandler<TEventArgs>(object sender, TEventArgs args, CancellationToken token);
