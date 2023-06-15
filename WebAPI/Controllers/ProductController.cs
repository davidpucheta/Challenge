using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMapper _mapper;

    public ProductController(IMapper mapper)
    {
        _mapper = mapper;
    }


    [HttpGet]
    public IEnumerable<Product> Get()
    {
        return new List<Product>();
    }

    [HttpPost]
    public IActionResult Post(Product product)
    {
        var prod = _mapper.Map<Product, Models.Data.Product>(product);

        return Ok(prod);
    }
}