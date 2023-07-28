namespace Our.Umbraco.SecurityTxt;

internal class SecurityTxtConstants
{
    public static class Package
    {
        public const string Name = "Our.Umbraco.SecurityTxt";
    }

    public static class SettingSections
    {
        public const string SecurityTxtSettings = "SecurityTxt";
    }

    public static class Trees
    {
        public static class SecurityTxt
        {
            public const string Alias = "SecurityTxt";
            public const string Group = "SecurityTxt";
            public const string Title = "Security.txt";
        }
    }

    public static class Database
    {
        public static class Tables
        {
            public const string SecurityTxt = "securityTxt";
        }
    }
}
