using CrossDataBase.Server.Enum;

namespace CrossDataBase.Server.Business.Abstraction.Core.Nodes.Models;

public class NodeModel
{
        public int Id { get; set; }

        public NodeType Type { get; set; }

        public int PosX { get; set; }

        public int PosY { get; set; }

        public object Data { get; set; }
}

public class Fields
{
    public string[] Inputs { get; set; }

    public string[] Outputs { get; set; }
}