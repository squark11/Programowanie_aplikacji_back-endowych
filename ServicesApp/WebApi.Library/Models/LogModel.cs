namespace WebApi.Library.Models
{
    public class LogModel
    {
        public string AuthorId { get; set; }
        public string RequestedUrl { get; set; }
        public string Method { get; set; }
        public string RequestedArgs { get; set; }
        public DateTime RequestedDate { get; set; }
        public string Description { get; set; }
        public string ResponeMessage { get; set; }
        public override string ToString()
        {
            return $"AuthorId: {AuthorId}, RequestedUrl: {RequestedUrl}, Method: {Method}, RequestedArgs: {RequestedArgs}"
                + ", RequestedDate: {RequestedDate}, Description {Description}, ResponeMessage: {ResponeMessage}";
        }
    }
}
