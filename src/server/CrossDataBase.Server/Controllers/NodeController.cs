using CrossDataBase.Server.Business.Abstraction.Common;
using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Common;
using CrossDataBase.Server.Mapper;
using CrossDataBase.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrossDataBase.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NodeController(
    INodeModelGetter nodeModelGetter,
    INodeService nodeService,
    INodeWriter nodeWriter) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetNodeList")]
    [ProducesResponseType(200)]
    [SwaggerOperation(Tags = ["Node"])]
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
    [SwaggerOperation(Tags = ["Node"])]
    public async Task<IActionResult> GetNodeDataAsync(int nodeId)
    {
        return new ApiDataResult();
    }

    /// <summary>
    /// Create element
    /// </summary>
    /// <param name="processId"></param>
    /// <param name="node"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(int), 200)]
    [SwaggerOperation(Tags = ["Node"])]
    public async Task<IActionResult> CreateAsync(int processId, NodeElement node)
    {
        var result = await nodeWriter.CreateAsync(processId, node.Map());
        return new ApiDataResult(result);
    }
    
    /// <summary>
    /// Update element
    /// </summary>
    /// <param name="processId"></param>
    /// <param name="node"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(typeof(int), 200)]
    [SwaggerOperation(Tags = ["Node"])]
    public async Task<IActionResult> UpdateAsync(int processId, NodeElement node)
    {
        await nodeWriter.UpdateAsync(processId, node.Map());
        return Ok();
    }

    /// <summary>
    /// Delete element
    /// </summary>
    /// <param name="processId"></param>
    /// <param name="nodeId"></param>
    /// <returns></returns>
    [HttpDelete]
    [ProducesResponseType(200)]
    [SwaggerOperation(Tags = ["Node"])]
    public async Task<IActionResult> DeleteAsync(int processId, int nodeId)
    {
        await nodeWriter.DeleteAsync(processId, nodeId);
        return Ok();
    }
}
