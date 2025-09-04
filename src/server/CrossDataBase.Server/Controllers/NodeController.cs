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
    /// Get node settings
    /// </summary>
    [HttpGet("GetNodeSettings")]
    [ProducesResponseType(200)]
    [SwaggerOperation(Tags = ["Node"])]
    public IActionResult GetNodeSettingsAsync()
    {
        return new ApiDataResult(nodeService.GetNodeInfo());
    }

    /// <summary>
    /// Get node data
    /// </summary>
    [HttpGet("GetNodeData/{nodeId:long}")]
    [ProducesResponseType(200)]
    [SwaggerOperation(Tags = ["Node"])]
    public async Task<IActionResult> GetNodeDataAsync(int processId, int nodeId)
    {
        return new ApiDataResult();
    }

    /// <summary>
    /// Create element
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(int), 200)]
    [SwaggerOperation(Tags = ["Node"])]
    public async Task<IActionResult> CreateAsync(int processId, Node node)
    {
        var result = await nodeWriter.CreateAsync(processId, node.Map());
        return new ApiDataResult(result);
    }
    
    /// <summary>
    /// Update element
    /// </summary>
    [HttpPut]
    [ProducesResponseType(typeof(int), 200)]
    [SwaggerOperation(Tags = ["Node"])]
    public async Task<IActionResult> UpdateAsync(int processId, Node node)
    {
        await nodeWriter.UpdateAsync(processId, node.Map());
        return Ok();
    }

    /// <summary>
    /// Delete element
    /// </summary>
    [HttpDelete]
    [ProducesResponseType(200)]
    [SwaggerOperation(Tags = ["Node"])]
    public async Task<IActionResult> DeleteAsync(int processId, int nodeId)
    {
        await nodeWriter.DeleteAsync(processId, nodeId);
        return Ok();
    }
}
