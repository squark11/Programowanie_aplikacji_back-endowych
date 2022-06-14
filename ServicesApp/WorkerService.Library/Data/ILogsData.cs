using ServiceApp.Library.Models;

namespace WorkerService.Library.Data
{
    public interface ILogsData
    {
        Task SaveLog(BusModel model);
    }
}