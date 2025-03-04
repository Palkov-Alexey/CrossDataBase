using CrossDataBase.Server.Business.Abstraction.Core.NodeContext;
using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Business.Abstraction.Core.Results;
using CrossDataBase.Server.Business.Abstraction.Nodes.Models;
using CrossDataBase.Server.Business.Core.Attributes;
using CrossDataBase.Server.Business.Core.Results;
using System.Reflection;

namespace CrossDataBase.Server.Business.Core.Nodes;
public abstract class Node : NodeBase
{

    protected ExecutionResult Done() => Noop();

    public override Type GetInputType() => null;

    public override PropertyInfo[] GetInputProperties() => null;

    public override Type GetDataType() => null;
    public override PropertyInfo[] GetDataProperties() => null;

    public override Type GetOutputType() => null;
    public override PropertyInfo[] GetOutputProperties() => null;
}

public abstract class Node<TInput> : Node where TInput : INodeData
{
    protected virtual Task<ExecutionResult> OnExecuteAsync(TInput data) => Task.FromResult(OnExecute(data));
    protected virtual ExecutionResult OnExecute(TInput data) => Noop();

    public override Type GetInputType() => typeof(TInput);
    public override PropertyInfo[] GetInputProperties() =>
        [.. GetInputType()
            .GetProperties()
            .Where(prop => Attribute.IsDefined(prop, typeof(NodePropertyAttribute)))];
}

public abstract class NodeDataOut<TData, TOutput> : Node where TOutput : INodeData where TData : INodeData
{
    protected virtual Task<ExecutionResult> OnExecuteAsync(TData data) => Task.FromResult(OnExecute(data));
    protected virtual ExecutionResult OnExecute(TData data) => Noop();
    protected ExecutionResult Done(TOutput output) => Outcomes(output);
    protected ExecutionResult Outcomes(TOutput output) => new OutcomeResult(output);

    public override Type GetDataType() => typeof(TData);
    public override PropertyInfo[] GetDataProperties() =>
        [.. GetDataType()
            .GetProperties()
            .Where(prop => Attribute.IsDefined(prop, typeof(NodePropertyAttribute)))];

    public override Type GetOutputType() => typeof(TOutput);
    public override PropertyInfo[] GetOutputProperties() =>
        [.. GetOutputType()
            .GetProperties()
            .Where(prop => Attribute.IsDefined(prop, typeof(NodePropertyAttribute)))];
}

public abstract class Node<TInput, TData, TOutput> : Node where TOutput : INodeData where TData : INodeData where TInput : INodeData
{
    protected virtual Task<ExecutionResult> OnExecuteAsync(NodeExecutionContext context, TData data, TInput input) => Task.FromResult(OnExecute(context, data, input));
    protected virtual ExecutionResult OnExecute(NodeExecutionContext context, TData data, TInput input) => Noop();
    protected ExecutionResult Done(TOutput output) => Outcomes(output);
    protected ExecutionResult Outcomes(TOutput output) => new OutcomeResult(output);

    public override Type GetInputType() => typeof(TInput);
    public override PropertyInfo[] GetInputProperties() =>
        [.. GetInputType()
            .GetProperties()
            .Where(prop => Attribute.IsDefined(prop, typeof(NodePropertyAttribute)))];

    public override Type GetDataType() => typeof(TData);
    public override PropertyInfo[] GetDataProperties() =>
        [.. GetDataType()
            .GetProperties()
            .Where(prop => Attribute.IsDefined(prop, typeof(NodePropertyAttribute)))];

    public override Type GetOutputType() => typeof(TOutput);
    public override PropertyInfo[] GetOutputProperties() =>
        [.. GetOutputType()
            .GetProperties()
            .Where(prop => Attribute.IsDefined(prop, typeof(NodePropertyAttribute)))];
}