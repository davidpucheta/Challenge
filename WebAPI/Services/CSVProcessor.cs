using Models.Data;
using Models.Interfaces;

namespace WebAPI.Services;

public class CsvProcessor : ICSVProcessor
{
    private readonly IRepository<Category> _categoryRepository;
    private readonly IRepository<Product> _productRepository;

    public CsvProcessor(IRepository<Category> categoryRepository, IRepository<Product> productRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
    }

    public void ImportCSVFile(string filePath)
    {
        var categories = new List<Category>();
        var products = new List<Product>();

        using var reader = new StreamReader(filePath);

        reader.ReadLine();

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line == null)
                continue;

            var data = line.Split(',');

            var product = new Product
            {
                Code = int.Parse(data[0]),
                Name = data[1],
                CategoryCode = int.Parse(data[2]),
                CreationDate = DateTime.UtcNow
            };

            if(products.All(p => p.Code != product.Code))
                products.Add(product);

            var category = new Category
            {
                Code = int.Parse(data[3]),
                Name = data[4],
                CreationDate = DateTime.UtcNow
            };

            if(categories.All(c => c.Code != category.Code))
                categories.Add(category);
        }

        reader.Close();

        SaveData(categories, products);
    }

    private void SaveData(List<Category> categories, List<Product> products)
    {
        foreach (var category in categories)
        {
            _categoryRepository.Add(category);
        }

        foreach (var product in products)
        {
            _productRepository.Add(product);
        }
    }
}
