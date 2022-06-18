using ServiceApp.Library.DbAccess;
using WebApi.Library.Models;

namespace WebApi.Library.Data
{
    public class LogsData : ILogsData
    {
        private readonly ISqlDataAccess _data;

        public LogsData(ISqlDataAccess data)
        {
            _data = data;
        }

        public async Task<IEnumerable<LogModel>> GetLogsAsync()
        {
            return await _data.LoadDataAsync<LogModel, dynamic>("[dbo].[sp_LogsGet]", new { }, "ServiceApp");
        }
        public async Task<IEnumerable<LogModel>> GetLogsFromLastHourAsync()
        {
            return await _data.LoadDataAsync<LogModel, dynamic>("[dbo].[sp_LogsGetFromLastHour]", new { Date = DateTime.Now.AddHours(-1) }, "ServiceApp");
        }
    }
}
