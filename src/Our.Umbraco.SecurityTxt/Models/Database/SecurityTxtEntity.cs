using NPoco;
using Umbraco.Cms.Infrastructure.Persistence.DatabaseAnnotations;

namespace Our.Umbraco.SecurityTxt.Models.Database;

[TableName("securityTxt")]
[PrimaryKey("Id", AutoIncrement = true)]
internal class SecurityTxtEntity
{
    [Column("Id")]
    [PrimaryKeyColumn(AutoIncrement = true)]
    public int Id { get; set; }

    [Column("Content")]
    [SpecialDbType(SpecialDbTypes.NVARCHARMAX)]
    public string? Content { get; set; }
}
