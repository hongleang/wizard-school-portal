using System.Text.Json;

namespace SchoolPortalApi.Core.Middlewares.ExceptionModel
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string ErrorType { get; set; }
        public string Message { get; set; }
    }
}