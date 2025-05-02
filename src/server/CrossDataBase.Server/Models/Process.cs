namespace CrossDataBase.Server.Models;

public class Process
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public ProcessData Data { get; set; }
}

public class ProcessData
{
    public Node[] Nodes { get; set; }

    public Connector[] Connectors { get; set; }
}