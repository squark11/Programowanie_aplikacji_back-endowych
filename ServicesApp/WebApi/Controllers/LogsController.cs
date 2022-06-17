using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Library.Data;
using WebApi.Library.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogsData _data;

        public LogsController(ILogsData data)
        {
            _data = data;
        }

        [HttpGet]
        public async Task<IEnumerable<LogModel>> GetLogs()
        {
            return await _data.GetLogsAsync();
        }
    }
}
