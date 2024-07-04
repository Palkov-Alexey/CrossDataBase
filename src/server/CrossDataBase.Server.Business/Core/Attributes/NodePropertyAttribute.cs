namespace CrossDataBase.Server.Business.Core.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class NodePropertyAttribute(string name) : Attribute
{
    public string Name { get; } = name;
}
