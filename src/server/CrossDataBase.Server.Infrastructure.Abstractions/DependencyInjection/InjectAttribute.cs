namespace CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class InjectAttribute : Attribute
{
    protected InjectAttribute(InjectionLifetime lifetime, Type abstractType)
    {
        Lifetime = lifetime;
        AbstractType = abstractType;
    }

    public InjectionLifetime Lifetime { get; }

    public Type AbstractType { get; }
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class InjectAsSingletonAttribute : InjectAttribute
{
    public InjectAsSingletonAttribute(Type abstractType) : base(InjectionLifetime.Singleton, abstractType)
    {
    }

    public InjectAsSingletonAttribute() : base(InjectionLifetime.Singleton, null) 
    {
    }
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class InjectAsTransientAttribute : InjectAttribute
{
    public InjectAsTransientAttribute(Type abstractType) : base(InjectionLifetime.Transient, abstractType)
    {
    }

    public InjectAsTransientAttribute() : base(InjectionLifetime.Transient, null)
    {
    }
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class InjectAsPerScopeAttribute : InjectAttribute
{
    public InjectAsPerScopeAttribute(Type abstractType) : base(InjectionLifetime.PerScope, abstractType)
    {
    }

    public InjectAsPerScopeAttribute() : base(InjectionLifetime.PerScope, null)
    {
    }
}

[AttributeUsage(AttributeTargets.Interface)]
public class MultipleImplementationsPossibleAttribute : Attribute
{
}
