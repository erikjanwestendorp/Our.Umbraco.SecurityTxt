using Our.Umbraco.SecurityTxt.Models;

namespace Our.Umbraco.SecurityTxt.Repositories;

public interface ISecurityTxtRepository
{
    SecurityTxtModel? Get(int id);
    SecurityTxtModel? Add(SecurityTxtModel model);
    SecurityTxtModel? Update(SecurityTxtModel model);
    IEnumerable<SecurityTxtModel> GetAll();
}
