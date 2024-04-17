namespace ApnaDukaan_v1.BLL.Exceptions
{
    public class LoginException : Exception
    {
        public string Title { get; set; }
        public LoginException(string title, string? message) : base(message)
        {
            this.Title = title;
        }
    }
}
