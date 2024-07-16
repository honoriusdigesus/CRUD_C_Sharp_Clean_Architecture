namespace MyWebAPI.Exceptions.Model
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }

        public ErrorResponse(int code, string error, string message)
        {
            Code = code;
            Error = error;
            Message = message;
        }
    }
}
