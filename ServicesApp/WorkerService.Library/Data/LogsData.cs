using ServiceApp.Library.DbAccess;
using ServiceApp.Library.Models;

namespace WorkerService.Library.Data
{
    public class LogsData : ILogsData
    {
        private readonly ISqlDataAccess _data;

        public LogsData(ISqlDataAccess data)
        {
            _data = data;
        }
        public async Task SaveLog(BusModel model)
        {
            await _data.SaveDataAsync("[dbo].[sp_LogsAdd]", new
            {
                AuthorId = model.AuthorId,
                RequestedUrl = model.RequestedUrl,
                Method = model.Method,
                RequestedArgs = model.RequestedArgs,
                Date = model.RequestedDate,
                Description = model.Description,
                ResponeMessage = model.ResponeMessage
            }, "ServiceApp");
        }
    }
}
