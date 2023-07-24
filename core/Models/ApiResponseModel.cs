namespace core.Models
{
    public class ApiResponseModel
    {
        public string Message { get; set; }

        public string Data { get; set; }

        public ApiResponseModel() { }
        public ApiResponseModel(string message)
        {
            Message = message;
        }
        public ApiResponseModel(string message, string data) : this(message)
        {
            Data = data;
        }
    }
    public class ApiResponseModel<T>
    {
        public string Message { get; set; }

        public T Data { get; set; }

        public ApiResponseModel() { }
        public ApiResponseModel(string message)
        {
            Message = message;
        }
        public ApiResponseModel(string message, T data) : this(message)
        {
            Data = data;
        }
    }
    public class ApiErrorResponseModel : ApiResponseModel<ErrorsDictionary>
    {
        public ApiErrorResponseModel() { }
        public ApiErrorResponseModel(string message) : base(message) { }
        //public ApiErrorResponseModel(string _message, ModelStateDictionary _modelState) : base(_message, new ErrorsDictionary(_modelState)) { }
    }

    public class ErrorsDictionary
    {
        public Dictionary<string, string[]> Errors { get; set; }

        //public ErrorsDictionary(ModelStateDictionary _modelState) { Errors = _modelState.GetErrorsDictionary(); }
    }

}
