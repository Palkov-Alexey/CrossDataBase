using CrossDataBase.Server.Enum;

namespace CrossDataBase.Server.Business.Core.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class NodeAttribute(NodeType type) : Attribute
{
    public string Name { get; } = type.ToString();
}
