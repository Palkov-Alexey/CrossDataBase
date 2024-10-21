using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Business.Abstraction.Core.Results;
using CrossDataBase.Server.Business.Abstraction.Nodes.Models;

namespace CrossDataBase.Server.Business.Core.Nodes;
public abstract class Node : NodeBase
{
    protected NodeResult Done() => Noop();
}

public abstract class Node<TData> : Node where TData : INodeData
{
    protected virtual Task<NodeResult> OnExecuteAsync(TData data) => Task.FromResult(OnExecute(data));
    protected virtual NodeResult OnExecute(TData data) => Noop();
}

public abstract class Node<TData, TOutput> : Node where TOutput : IOutputData where TData : INodeData
{

}

public abstract class Node<TInput, TData, TOutput> : Node where TOutput : IOutputData where TData : INodeData where TInput : IInputData
{

}