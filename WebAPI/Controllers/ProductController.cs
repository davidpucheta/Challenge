using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Data;
using Models.Filters;
using Models.Interfaces;
using Models.ViewModels;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRepository<Product> _repository;
    public ProductController(IMapper mapper, IRepository<Product> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProductViewModel>> Get([FromQuery] Filter filter)
    {
        var prodQuery = _repository.Get();

        prodQuery = filter.SortDesc
            ? prodQuery.OrderByDescending(c => EF.Property<Product>(c, filter.SortBy))
            : prodQuery.OrderBy(c => EF.Property<Product>(c, filter.SortBy));

        prodQuery = prodQuery.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);

        var products = prodQuery.ToList();
        var productsViewModels = _mapper.Map<List<CategoryViewModel>>(products);
        return Ok(productsViewModels);
    }

    [HttpPost]
    public IActionResult Post(ProductViewModel productViewModel)
    {
        var prod = _mapper.Map<ProductViewModel, Models.Data.Product>(productViewModel);

        return Ok(prod);
    }
}