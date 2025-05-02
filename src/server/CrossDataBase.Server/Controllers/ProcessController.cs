using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessData;
using CrossDataBase.Server.Common;
using CrossDataBase.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace CrossDataBase.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProcessController(IProcessService processService,
    INodeService nodeService) : ControllerBase
{
    /// <summary>
    /// Get process or create default
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(int), 200)]
    [SwaggerOperation(Tags = ["Process"])]
    public async Task<IActionResult> GetAsync(int? processId)
    {
        var result = await processService.GetOnCreateAsync(processId);
        return new ApiDataResult(result);
    }

    /// <summary>
    /// Open process from json file
    /// </summary>
    [HttpPost("OpenFromFile")]
    [ProducesResponseType(typeof(int), 200)]
    [SwaggerOperation(Tags = ["Process"])]
    public async Task<IActionResult> OpenFromFileAsync(IFormFile file)
    {
        if (file.ContentType != "application/json" || file.Length == 0)
        {
            return UnprocessableEntity(new ModelStateDictionary());
        }

        using var streamReader = new StreamReader(file.OpenReadStream());
        var json = await streamReader.ReadToEndAsync();
        var data = JsonConvert.DeserializeObject<Process>(json);
        
        return Ok();
    }
    
    /// <summary>
    /// Download process
    /// </summary>
    [HttpGet("Download")]
    [ProducesResponseType(typeof(File), 200)]
    [SwaggerOperation(Tags = ["Process"])]
    public async Task<IActionResult> DownloadAsync(int processId)
    {
        return File([], "application/json", "Test.json");
    }
    
    /// <summary>
    /// Run process
    /// </summary>
    [HttpGet("Run")]
    [SwaggerOperation(Tags = ["Process"])]
    public async Task<IActionResult> RunAsync(int processId)
    {
        return new ApiDataResult();
    }
}
