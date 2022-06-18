using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Library.Data;
using WebApi.Library.Helpers;
using WebApi.Library.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogsData _data;
        private readonly ILogSender _log;

        public LogsController(ILogsData data, ILogSender log)
        {
            _data = data;
            _log = log;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<LogModel>> GetLogs()
        {
            var logs = await _data.GetLogsAsync();
            await Send(null, "Getting logs", logs.ToString());
            return logs;
        }
        private async Task Send(string args, string descrioption, string? responseMessage)
        {
            await _log.Send(this.User?.Identity?.Name, this.Request?.Path.ToString(), this.Request?.Method, args, descrioption, responseMessage);
        }
    }
}
