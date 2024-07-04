using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CrossDataBase.Server.Infrastructure.DependencyInjection;

internal class DIInstaller(IServiceCollection services)
{
    private bool initialized;
    private readonly Dictionary<Type, List<Action<IServiceCollection>>> registerBehaviorActionDictionary = [];
    private readonly Dictionary<Type, bool> multipleImplementationsPossibleDictionary = [];

    public void Initialize()
    {
        if (initialized)
        {
            return;
        }

        foreach (var action in registerBehaviorActionDictionary.SelectMany(x => x.Value))
        {
            action(services);
        }

        initialized = true;
    }

    public void RegisterByDIAttribute(string assemblyPath, string assemblySearchPattern)
    {
        var assemblyByPatternList = AssemblyExtensions.GetAssemblyByPattern(assemblyPath, assemblySearchPattern);
        RegisterByDIAttribute(assemblyByPatternList);
    }

    public void RegisterByDIAttribute(params Assembly[] assemblyList)
    {
        var injectInfoList = assemblyList
            .SelectMany(a => a.GetTypes())
            .Where(x => x.IsDefined(typeof(InjectAttribute), false))
            .SelectMany(GetInterfaces);

        foreach (var (service, implementation, lifetime) in injectInfoList)
        {
            RegisterBehavior(service, container => container.Add(new ServiceDescriptor(service, implementation, lifetime)));
        }
    }

    private static (Type Service, Type Implementation, ServiceLifetime Lifetime)[] GetInterfaces(Type type)
    {
        var result = Attribute.GetCustomAttributes(type, typeof(InjectAttribute), false)
            .Cast<InjectAttribute>()
            .Select(x => (Service: x.AbstractType, Implementation: type, Lifetime: GetLifetime(x)))
            .ToArray();

        //Если атрибут один и без явного указания типа абстракции, то ищем его интерфейсы, и регистрируем все
        if (result.Length == 1 && result[0].Service == null)
        {
            result = result
                .SelectMany(x => type.GetInterfaces()
                    .Where(i => i.Namespace.StartsWith("CrossDataBase.Server"))
                    .Select(service => (Service: service, x.Implementation, x.Lifetime)))
                .ToArray();
        }

        return result.Where(x => x.Service != null && x.Service.IsAssignableFrom(x.Implementation)).ToArray();
    }

    private static ServiceLifetime GetLifetime(InjectAttribute attr) => attr.Lifetime switch
    {
        InjectionLifetime.Transient => ServiceLifetime.Transient,
        InjectionLifetime.PerScope => ServiceLifetime.Scoped,
        InjectionLifetime.Singleton => ServiceLifetime.Singleton,
        _ => throw new ArgumentOutOfRangeException(),
    };

    private void RegisterBehavior(Type serviceType, Action<IServiceCollection> registerAction)
    {
        if (CheckMultipleImplementationsPossible(serviceType) == false)
        {
            UnregisterBehavior(serviceType);
        }
        if (registerBehaviorActionDictionary.ContainsKey(serviceType) == false)
        {
            registerBehaviorActionDictionary.Add(serviceType, []);
        }
        registerBehaviorActionDictionary[serviceType].Add(registerAction);
    }

    private void UnregisterBehavior(Type serviceType)
    {
        registerBehaviorActionDictionary.Remove(serviceType);
    }

    private bool CheckMultipleImplementationsPossible(Type serviceType)
    {
        if (multipleImplementationsPossibleDictionary.TryGetValue(serviceType, out bool value))
        {
            return value;
        }

        var result = serviceType.IsDefined(typeof(MultipleImplementationsPossibleAttribute), false);
        multipleImplementationsPossibleDictionary.Add(serviceType, result);

        return result;
    }
}
