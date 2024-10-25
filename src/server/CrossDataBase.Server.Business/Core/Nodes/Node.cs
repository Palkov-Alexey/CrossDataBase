using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Business.Abstraction.Core.Results;
using CrossDataBase.Server.Business.Abstraction.Nodes.Models;
using CrossDataBase.Server.Business.Core.Results;

namespace CrossDataBase.Server.Business.Core.Nodes;
public abstract class Node : NodeBase
{
    protected ExecutionResult Done() => Noop();
}

public abstract class Node<TData> : Node where TData : INodeData
{
    protected virtual Task<ExecutionResult> OnExecuteAsync(TData data) => Task.FromResult(OnExecute(data));
    protected virtual ExecutionResult OnExecute(TData data) => Noop();
}

public abstract class Node<TData, TOutput> : Node where TOutput : INodeData where TData : INodeData
{
    protected virtual Task<ExecutionResult> OnExecuteAsync(TData data) => Task.FromResult(OnExecute(data));
    protected virtual ExecutionResult OnExecute(TData data) => Noop();

    protected ExecutionResult Done(TOutput output) => Outcomes(output);

    protected ExecutionResult Outcomes(TOutput output) => new OutcomeResult(output);
}

public abstract class Node<TInput, TData, TOutput> : Node where TOutput : INodeData where TData : INodeData where TInput : INodeData
{

}