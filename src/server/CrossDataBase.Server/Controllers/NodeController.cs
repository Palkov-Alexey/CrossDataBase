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
