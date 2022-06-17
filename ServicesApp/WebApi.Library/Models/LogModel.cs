using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
