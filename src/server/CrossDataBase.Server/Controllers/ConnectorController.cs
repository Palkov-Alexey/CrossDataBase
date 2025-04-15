using CrossDataBase.Server.Business.Abstraction.Common;
using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Common;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrossDataBase.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConnectorController(INodeModelGetter nodeModelGetter,
    INodeService nodeService) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(200)]
    [SwaggerOperation(Tags = ["Connector"])]
    public IActionResult GetNodeList()
    {
        return new ApiDataResult(nodeService.GetNodeInfo());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nodeId"></param>
    /// <returns></returns>
    [HttpGet("GetNodeData/{nodeId:long}")]
    [ProducesResponseType(200)]
    [SwaggerOperation(Tags = ["Connector"])]
    public async Task<IActionResult> GetNodeDataAsync(long nodeId)
    {
        return new ApiDataResult();
    }
}
