using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Category> Get()
    {
        return new List<Category>();
    }
}