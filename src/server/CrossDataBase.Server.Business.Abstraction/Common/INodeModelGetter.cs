using System;
using CrossDataBase.Server.Enum;

namespace CrossDataBase.Server.Business.Abstraction.Common;

public interface INodeModelGetter
{
    object GetDataModel(NodeType type);
}
