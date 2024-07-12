namespace CrossDataBase.Server.Business.Abstraction.Core.Results;
public class NoopResult : NodeResult
{
    protected override void Execute(IServiceProvider serviceProvider)
    {
    }
}
