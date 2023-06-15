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
public class CategoryController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRepository<Category> _repository;
    public CategoryController(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CategoryViewModel>> Get([FromQuery] Filter filter)
    {
        var catQuery = _repository.Get();

        catQuery = filter.SortDesc
            ? catQuery.OrderByDescending(c => EF.Property<Category>(c, filter.SortBy.ToString()))
            : catQuery.OrderBy(c => EF.Property<Category>(c, filter.SortBy.ToString()));

        catQuery = catQuery.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);

        var categories = catQuery.ToList();
        var categoriesViewModels = _mapper.Map<List<CategoryViewModel>>(categories);
        return Ok(categoriesViewModels);
    }

    [HttpPost]
    public IActionResult Post(CategoryViewModel category)
    {
        var cat = _mapper.Map<Category>(category);
        _repository.Add(cat);

        return Ok(cat);
    }
}