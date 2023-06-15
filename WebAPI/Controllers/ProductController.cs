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
    public IEnumerable<ProductViewModel> Get()
    {
        return new List<ProductViewModel>();
    }

    [HttpPost]
    public IActionResult Post(ProductViewModel productViewModel)
    {
        var prod = _mapper.Map<ProductViewModel, Models.Data.Product>(productViewModel);

        return Ok(prod);
    }
}