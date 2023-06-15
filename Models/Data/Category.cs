using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Data;

[Table("Categories")]
public class Category
{
    [Key]
    [Column("Category_Code")]
    public int Code { get; set; }

    [Column("Category_Name")]
    public required string Name { get; set; }

    [Column("Category_Creation_Date")]
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
}