using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private const string CONTAINERIZED = "containerized";
        private readonly ILogger<EnvironmentController> _logger;

        public EnvironmentController(ILogger<EnvironmentController> logger)
        {
            _logger = logger;
        }

        [HttpGet("iscontainerized")]
        public bool IsRunningInContainer()
        {
            var isContainerized = Environment.GetEnvironmentVariable(CONTAINERIZED);
            if (isContainerized == null)
            {
                return false;
            }

            return bool.Parse(isContainerized);
        }
    }
}