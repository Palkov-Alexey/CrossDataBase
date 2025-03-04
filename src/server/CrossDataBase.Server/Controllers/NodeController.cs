using CrossDataBase.Server.Business.Abstraction.Common;
using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Enum;
using CrossDataBase.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CrossDataBase.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NodeController(ILogger<NodeController> logger,
    INodeModelGetter nodeModelGetter,
    INodeService nodeService) : ControllerBase
{

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(NodeData))]
    public IActionResult Get()
    {
        var data = new NodeData
        {
            Nodes =
            [
                new()
                {
                    Id = 1,
                    Name = "Server",
                    PosX = 89,
                    PosY = 82,
                    Fields = new Fields{ Outputs = ["Server"] }
                },
                new()
                {
                    Id = 2,
                    Name = "Script",
                    PosX = 452,
                    PosY = 92,
                    Fields = new Fields{ Inputs = ["Server"], Outputs = ["Res"] }
                },
                new()
                {
                    Id = 3,
                    Name = "Server",
                    PosX = 89,
                    PosY = 390,
                    Fields = new Fields{ Outputs = ["Server"] }
                },
                new()
                {
                    Id = 4,
                    Name = "Script",
                    PosX = 452,
                    PosY = 390,
                    Fields = new Fields{ Inputs = ["Server"], Outputs = ["Res"] }
                },
                new()
                {
                    Id = 5,
                    Name = "Join",
                    PosX = 1070,
                    PosY = 250,
                    Fields = new Fields{ Inputs = ["Sql1", "Sql2"], Outputs = ["Res"] }
                }
            ],
            Connectors =
            [
                new (){Id = 1, FromNode = 1, From = "Server", ToNode = 2, To = "Server"},
                new (){Id = 2, FromNode = 3, From = "Server", ToNode = 4, To = "Server"},
                new (){Id = 3, FromNode = 2, From = "Res", ToNode = 5, To = "Sql1"},
                new (){Id = 4, FromNode = 4, From = "Res", ToNode = 5, To = "Sql2"},
            ]
        };

        logger.LogInformation(message: JsonConvert.SerializeObject(data));
        return Ok(data);
    }

    [HttpGet("GetNodeList")]
    [ProducesResponseType(200)]
    public IActionResult GetNodeList()
    {
        return Ok(nodeService.GetNodeInfo());
    }

    /*[HttpGet("GetNodeData")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetNodeDataAsync(NodeType type, long nodeId)
    {
        var t = nodeResolver.Resolve(type);
        return Ok();
    }*/

    
}
