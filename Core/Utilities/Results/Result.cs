namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }
        public string Message { get; }

        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public Result(bool success)
        {
            this.Success = success;
        }
    }
}
