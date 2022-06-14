namespace WebApi.Library.Helpers
{
    public interface ILogSender
    {
        Task Send(string AuthorId, string RequestedUrl, string Method, string RequestedArgs, string Description, string ResponeMessage);
    }
}