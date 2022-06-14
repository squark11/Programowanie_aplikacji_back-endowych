using MassTransit;
using Microsoft.Extensions.Logging;
using ServiceApp.Library.Models;
using WorkerService.Library.Data;

namespace WorkerService.Library.Helpers
{
    public class BusConsumer : IBusConsumer
    {
        private readonly ILogger<BusConsumer> _logger;
        private readonly ILogsData _data;

        public BusConsumer(ILogger<BusConsumer> logger, ILogsData data)
        {
            _logger = logger;
            _data = data;
        }
        public Task Consume(ConsumeContext<BusModel> context)
        {
            _logger.LogInformation($"Message: {context.Message.Description} - {context.Message.AuthorId} - {context.Message.RequestedDate}");
            _data.SaveLog(context.Message);

            return Task.CompletedTask;
        }
    }
}
