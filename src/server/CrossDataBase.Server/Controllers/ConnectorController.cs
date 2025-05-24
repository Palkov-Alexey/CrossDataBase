using CrossDataBase.Server.Business.Abstraction.Core.Connectors;
using CrossDataBase.Server.Common;
using CrossDataBase.Server.Mapper;
using CrossDataBase.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrossDataBase.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConnectorController(
    IConnectorReader connectorReader,
    IConnectorWriter connectorWriter) : ControllerBase
{
    /// <summary>
    /// Get connectors
    /// </summary>
    [HttpGet]
    [ProducesResponseType(200)]
    [SwaggerOperation(Tags = ["Connector"])]
    public async Task<IActionResult> GetAsync(int processId)
    {
        var result = await connectorReader.GetAsync(processId);
        return new ApiDataResult(result.Map());
    }

    /// <summary>
    /// Create connector
    /// </summary>
    [HttpPost]
    [ProducesResponseType(200)]
    [SwaggerOperation(Tags = ["Connector"])]
    public async Task<IActionResult> CreateAsync(int processId, Connector connector)
    {
        var result = await connectorWriter.CreateAsync(processId, connector.Map());
        return new ApiDataResult(result);
    }

    /// <summary>
    /// Update connector
    /// </summary>
    [HttpPut]
    [ProducesResponseType(200)]
    [SwaggerOperation(Tags = ["Connector"])]
    public async Task<IActionResult> UpdateAsync(int processId, Connector connector)
    {
        await connectorWriter.UpdateAsync(processId, connector.Map());
        return Ok();
    }

    /// <summary>
    /// Delete connector
    /// </summary>
    [HttpDelete]
    [ProducesResponseType(200)]
    [SwaggerOperation(Tags = ["Connector"])]
    public async Task<IActionResult> DeleteAsync(int processId, int connectorId)
    {
        await connectorWriter.DeleteAsync(processId, connectorId);
        return new ApiDataResult();
    }
}