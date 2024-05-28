using CrossDataBase.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrossDataBase.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NodeController(ILogger<NodeController> logger) : ControllerBase
{
    private readonly ILogger<NodeController> _logger = logger;

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(NodeData))]
    public IActionResult Get()
    {
        var data = new NodeData
        {
            Nodes =
            [
                new() {Id = 1, Name = "Server", x = 89, y = 82, Fields = new Fields{ Outputs = [new(){Name = "Server"}] } },
                new() {Id = 2, Name = "Script", x = 140, y = 92, Fields = new Fields{ Inputs = [new(){Name = "Server"}], Outputs = [new(){Name = "Res"}] }}
            ],
            Connectors =
            [
                new (){Id = 1, FromNode = 1, From = "Server", ToNode = 2, To = "Server"}
            ]
        };

        return Ok(data);
    }
}
