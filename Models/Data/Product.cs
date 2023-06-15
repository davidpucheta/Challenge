using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Data;

[Table("Products")]
public class Product
{
    [Key, Column("Product_Code")]
    public int Code { get; set; }

    [Column("Product_Name")]
    public required string Name { get; set; }

    [ForeignKey(nameof(Category.Code))]
    [Column("Product_Category_Code")]
    public int CategoryCode { get; set; }

    [Column("Product_Creation_Date")]
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
}