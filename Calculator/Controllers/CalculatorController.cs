using Calculator.Utilities.Logger;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Add")]
        public string Add()
        {
            _logger.LogSQL("teehee {agent}", "lmao");
            return null;
        }

        [HttpGet(Name = "Subtract")]
        public string Subtract()
        {
            _logger.LogInformation("teehee");
            return null;
        }

        [HttpGet(Name = "Multiply")]
        public string Multiply()
        {
            _logger.LogInformation("teehee");
            return null;
        }

        [HttpGet(Name = "Divide")]
        public string Divide()
        {
            _logger.LogInformation("teehee");
            return null;
        }
    }
}