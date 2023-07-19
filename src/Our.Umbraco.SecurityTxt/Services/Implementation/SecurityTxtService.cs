using Our.Umbraco.SecurityTxt.Models;
using Our.Umbraco.SecurityTxt.Repositories;

namespace Our.Umbraco.SecurityTxt.Services.Implementation;

internal class SecurityTxtService : ISecurityTxtService
{
    private readonly ISecurityTxtRepository _securityTxtRepository;

    public SecurityTxtService(ISecurityTxtRepository securityTxtRepository)
    {
        _securityTxtRepository = securityTxtRepository;
    }

    public string GetContent()
    {
        return _securityTxtRepository.GetAll().FirstOrDefault()?.Content ?? string.Empty;
    }

    public void SetContent(string content)
    {

        var model = _securityTxtRepository.GetAll().FirstOrDefault() ?? new SecurityTxtModel();

        model.Content = content;
        _securityTxtRepository.Update(model);
    }
}
