namespace CrossDataBase.Server.Business.Core.Events;
internal static class EventHandlerExtensions
{
    public static async Task InvokeAsync<TEventArgs>(this AsyncEventHandler<TEventArgs> handler, object sender, TEventArgs args, CancellationToken token)
    {
        var delegates = handler.GetInvocationList();
        if (delegates is { Length: > 0 })
        {
            var tasks = delegates
                .Cast<AsyncEventHandler<TEventArgs>>()
                .Select(e =>
                    Task.Run(async () => await e.Invoke(sender, args, token)));
            await Task.WhenAll(tasks);
        }
    }
}
