using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Models.Interfaces;
using Models.ViewModels;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public CategoryController(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<CategoryViewModel> Get()
    {
        var categories = _repository.GetAll();

        return _mapper.Map<List<CategoryViewModel>>(categories);
    }

    [HttpPost]
    public IActionResult Post(CategoryViewModel category)
    {
        var cat = _mapper.Map<Category>(category);
        _repository.Add(cat);

        return Ok(cat);
    }
}