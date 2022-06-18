using WebApi.Library.Models;

namespace WebApi.Library.Data
{
    public interface ILogsData
    {
        Task<IEnumerable<LogModel>> GetLogsAsync();
        Task<IEnumerable<LogModel>> GetLogsFromLastHourAsync();
    }
}