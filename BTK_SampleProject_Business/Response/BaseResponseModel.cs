namespace BTK_SampleProject.Response
{
    public class BaseResponseModel
    {
        public object? Data { get; set; }
        public string Message { get; set; }
        public bool isSuccess { get; set;}
    }
}
