namespace Our.Umbraco.SecurityTxt.Services;

public interface ISecurityTxtService
{
    string GetContent();
    void SetContent(string content);
}