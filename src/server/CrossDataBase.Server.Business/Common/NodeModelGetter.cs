using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using CrossDataBase.Server.Business.Abstraction.Common;
using CrossDataBase.Server.Business.Abstraction.Nodes.Models;
using CrossDataBase.Server.Business.Core.Attributes;
using CrossDataBase.Server.Business.Core.Nodes;
using CrossDataBase.Server.Enum;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace CrossDataBase.Server.Business.Common;

[InjectAsSingleton]
public class NodeModelGetter(IServiceProvider serviceProvider) : INodeModelGetter
{
    public object GetDataModel(NodeType type)
    {
        return null;
        //var data = serviceProvider.<object>()
        //    .Cast<Node>()
        //    .FirstOrDefault(x => x.GetType().GetCustomAttribute<NodeAttribute>().Name == type);

        //if(data is null)
        //{
        //    throw new NotImplementedException();
        //}

        //return data.GetType();
    }
}
