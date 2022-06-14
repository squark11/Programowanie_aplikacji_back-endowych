using MassTransit;
using ServiceApp.Library.Models;

namespace WebApi.Library.Helpers
{
    public class LogSender : ILogSender
    {
        private readonly IBus _bus;

        public LogSender(IBus bus)
        {
            _bus = bus;
        }
        public async Task Send(string AuthorId, string RequestedUrl, string Method, string RequestedArgs, string Description, string ResponeMessage)
        {
            var message = new BusModel
            {
                AuthorId = AuthorId,
                RequestedUrl = RequestedUrl,
                RequestedArgs = RequestedArgs,
                Description = Description,
                ResponeMessage = ResponeMessage,
                RequestedDate = DateTime.Now,
                Method = Method,
            };
            await _bus.Publish(message);
        }
    }
}
