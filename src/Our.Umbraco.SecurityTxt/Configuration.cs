namespace Our.Umbraco.SecurityTxt;

public class Configuration
{
    public class SecurityTxtSettings
    {
        public bool AsSection { get; set; } = false;

        public string Path { get; set; } = SecurityTxtConstants.Settings.DefaultPath;
    }
}
