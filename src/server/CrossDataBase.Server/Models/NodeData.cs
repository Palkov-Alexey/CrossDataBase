namespace CrossDataBase.Server.Models;

public class NodeData
{
    public NodeElement[] Nodes { get; set; }

    public Connector[] Connectors { get; set; }
}

public class NodeElement
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int PosX { get; set; }

    public int PosY { get; set; }

    public object Data { get; set; }

    public Fields Fields { get; set; }
}

public class Fields
{
    public string[] Inputs { get; set; }

    public string[] Outputs { get; set; }
}

public class ConnectionPoint
{
    public string Name { get; set; }
}

public class Connector
{
    public int Id { get; set; }

    public int FromNode { get; set; }

    public string From { get; set; }

    public int ToNode { get; set; }

    public string To { get; set; }
}
