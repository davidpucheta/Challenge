namespace Models.ViewModels;

public class ProductViewModel
{
    public int Code { get; set; }

    public required string Name { get; set; }

    public int CategoryCode { get; set; }
}