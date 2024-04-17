namespace ApnaDukaan_v1.BLL.Exceptions
{
    public class BusinessException : Exception
    {
        public string Title { get; set; }
        public BusinessException(string title, string? message) : base(message)
        {
            this.Title = title;
        }
    }
}
