using CrossDataBase.Server.Business.Abstraction.Common;
using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Common;
using Microsoft.AspNetCore.Mvc;

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
        return new ApiDataResult(nodeService.GetNodeInfo());
    }

    [HttpGet("GetNodeData/{nodeId:long}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetNodeDataAsync(long nodeId)
    {
        return new ApiDataResult();
    }
}
