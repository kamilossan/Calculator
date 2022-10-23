using Calculator.Models;
using Calculator.Services;
using Calculator.Utilities.Helpers;
using Calculator.Utilities.Logger;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly ICalculatorService _calculatorService;
        private readonly IBasicAuthorizationService _authorizationService;

        public CalculatorController(ICalculatorService calculatorService, IBasicAuthorizationService authorizationService, ILogger<CalculatorController> logger)
        {
            _logger = logger;
            _calculatorService = calculatorService;
            _authorizationService = authorizationService;

        }
        [HttpPost(Name = "Calculate")]
        public IActionResult Calculate(CalculatorRequest request)
        {

            if (_authorizationService.IsAuthorized(ControllerContext.HttpContext.Request))
            {
                if (request.Parameters != null && request.Operation != null) _logger.LogSQL(LogEntryHelpers.GenerateLogEntry(request.Operation, request.Parameters), LogLevel.Information);
                if (request.Parameters == null || request.Parameters?.Length < 2)
                {
                    return new BadRequestObjectResult(
                        JsonConvert.SerializeObject(new CalculatorRequestResponse
                        {
                            Error = "At least 2 parameters must be specified to perform an operation."
                        })
                        );
                }

                CalculatorRequestResponse response = request.Operation?.ToLower() switch
                {

                    "add" => _calculatorService.Add(request),
                    "subtract" => _calculatorService.Subtract(request),
                    "multiply" => _calculatorService.Multiply(request),
                    "divide" => _calculatorService.Divide(request),
                    _ => new CalculatorRequestResponse { Error = "Invalid operation type" },
                };
                return response.IsError ? new UnprocessableEntityObjectResult(JsonConvert.SerializeObject(response)) : new OkObjectResult(JsonConvert.SerializeObject(response));
            }

            return new UnauthorizedResult();
        }

    }
}