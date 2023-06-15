namespace Models.ViewModels;

public class Product
{
    public int Code { get; set; }

    public required string Name { get; set; }

    public int CategoryCode { get; set; }

    public DateTime CreationDate { get; set; }
}