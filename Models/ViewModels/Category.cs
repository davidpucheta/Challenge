namespace Models.ViewModels;

public class Category
{
    public int Code { get; set; }

    public required string Name { get; set; }

    public DateTime CreationDate { get; set; }
}