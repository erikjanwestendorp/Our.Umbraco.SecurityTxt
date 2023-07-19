using Our.Umbraco.SecurityTxt.Models;
using Our.Umbraco.SecurityTxt.Models.Database;
using System.Linq;
using Umbraco.Cms.Infrastructure.Scoping;
using Umbraco.Extensions;

namespace Our.Umbraco.SecurityTxt.Repositories.Implementation;

internal class SecurityTxtRepository : ISecurityTxtRepository
{
    private IScopeProvider _scopeProvider;

    public SecurityTxtRepository(IScopeProvider scopeProvider)
    {
        _scopeProvider = scopeProvider;
    }

    public SecurityTxtModel Get(int id)
    {
        using var scope = _scopeProvider.CreateScope(autoComplete: true);
        var entity = scope.Database.FirstOrDefault<SecurityTxtEntity>(scope.SqlContext.Sql()
            .SelectAll()
            .From<SecurityTxtEntity>()
            .Where<SecurityTxtEntity>(it => it.Id == id));
        return entity is null ? null : MapToModel(entity);
    }

    public SecurityTxtModel Add(SecurityTxtModel model)
    {
        return Update(model);
    }

    public SecurityTxtModel Update(SecurityTxtModel model)
    {
        using (var scope = _scopeProvider.CreateScope(autoComplete: true))
        {
            scope.Database.Save(MapToEntity(model));
        }
        return Get(model.Id);
    }

    public IEnumerable<SecurityTxtModel> GetAll()
    {
        using var scope = _scopeProvider.CreateScope(autoComplete: true);

        return scope.Database.Fetch<SecurityTxtEntity>(scope.SqlContext.Sql()
            .SelectAll()
            .From<SecurityTxtEntity>()).Select(MapToModel);
    }

    private static SecurityTxtModel MapToModel(SecurityTxtEntity entity)
    {
        return new SecurityTxtModel
        {
            Id = entity.Id,
            Content = entity.Content
        };
    }

    private static SecurityTxtEntity MapToEntity(SecurityTxtModel model)
    {
        return new SecurityTxtEntity
        {
            Id = model.Id,
            Content = model.Content
        };
    }
}
