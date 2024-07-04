using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Business.Abstraction.Nodes.Models;

namespace CrossDataBase.Server.Business.Core.Nodes;
public abstract class Node : NodeBase
{
}

public abstract class Node<TData> : Node where TData : INodeData
{

}

public abstract class Node<TData, TOutput> : Node where TOutput : INodeData where TData : INodeData
{

}

public abstract class Node<TInput, TData, TOutput> : Node where TOutput : INodeData where TData : INodeData where TInput : INodeData
{

}