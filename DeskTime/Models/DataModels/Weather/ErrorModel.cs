namespace DeskTime.Models.DataModels.Weather
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
