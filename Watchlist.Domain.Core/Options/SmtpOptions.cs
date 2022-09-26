namespace Watchlist.Domain.Core.Options
{
    public class SmtpOptions
    {
        public const string SMTP = "SMTP";

        public string Login { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string MockEmail { get; set; }
    }
}
