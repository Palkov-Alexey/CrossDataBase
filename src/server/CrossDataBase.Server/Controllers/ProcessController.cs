using CrossDataBase.Server.Business.Abstraction.Common;
using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessData;
using CrossDataBase.Server.Common;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrossDataBase.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProcessController(IProcessService processService,
    INodeService nodeService) : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(int), 200)]
    [SwaggerOperation(Tags = ["Process"])]
    public async Task<IActionResult> GetAsync()
    {
        var result = await processService.GetOnCreateAsync(null);
        return new ApiDataResult(result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nodeId"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(int), 200)]
    [SwaggerOperation(Tags = ["Process"])]
    public async Task<IActionResult> GetNodeDataAsync(long nodeId)
    {
        return new ApiDataResult();
    }

    /// <summary>
    /// Open process from json file
    /// </summary>
    /// <param name="processJson"></param>
    /// <returns></returns>
    [HttpPost("OpenFromFile")]
    public async Task<IActionResult> OpenFromFileAsync(string processJson)
    {
        return Ok();
    }
    
    /// <summary>
    /// Download process
    /// </summary>
    /// <param name="processId"></param>
    /// <returns></returns>
    [HttpGet("Download")]
    public async Task<IActionResult> DownloadAsync(int processId)
    {
        return File([], "application/json", "Test.json");
    }
}
