using MassTransit;
using ServiceApp.Library.Models;

namespace WorkerService.Library.Helpers
{
    public interface IBusConsumer : IConsumer<BusModel>
    { }
}