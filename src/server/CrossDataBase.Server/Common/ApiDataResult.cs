using Microsoft.AspNetCore.Mvc;

namespace CrossDataBase.Server.Common;

public class ApiDataResult(object data = null) : IActionResult
{
    public Task ExecuteResultAsync(ActionContext context)
    {
        var value = new { data };
        var objectResult = new ObjectResult(value)
        {
            StatusCode = StatusCodes.Status200OK
        };
            
        return objectResult.ExecuteResultAsync(context);
    }
}