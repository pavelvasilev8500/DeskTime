namespace Resources.Classes.Models.Weather
{
    internal class ErrorModel
    {  
        public Error Error { get; set; }
    }

    internal class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
