using Microsoft.AspNetCore.Mvc;

namespace CrossDataBase.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = new[]
            {
                new { Name = "Oleg" },
                new { Name = "Dima" }
            };

            return Ok(users);
        }
    }
}
