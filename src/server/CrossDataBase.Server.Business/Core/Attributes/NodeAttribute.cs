using CrossDataBase.Server.Enum;

namespace CrossDataBase.Server.Business.Core.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class NodeAttribute(NodeType type) : Attribute
{
    public NodeType Name { get; } = type;
}
