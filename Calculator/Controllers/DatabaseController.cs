using Calculator.Services;
using Calculator.Utilities.SQL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Calculator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private DataBaseContext _dataBaseContext;
        private IBasicAuthorizationService _basicAuthorizationService;
        public DatabaseController(DataBaseContext dataBaseContext, IBasicAuthorizationService basicAuthorizationService)
        {
            _dataBaseContext = dataBaseContext;
            _basicAuthorizationService = basicAuthorizationService;
        }

        [HttpGet(Name = "Get Logs")]  
        public IActionResult GetLogs()
        {
            if (!_basicAuthorizationService.IsAuthorized(ControllerContext.HttpContext.Request)) return new UnauthorizedResult();
            var logs = _dataBaseContext.LogEntries.Select(x => $"{x.RequestId}:{x.TimeStamp}:{x.Operation}:{x.Request}").ToArray();
            return new OkObjectResult(JsonConvert.SerializeObject(logs));
        }
    }
}
