using Microsoft.AspNetCore.Mvc;
using Models.Interfaces;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CsvController : ControllerBase
{
    private readonly ICSVProcessor _csvProcessor;

    public CsvController(ICSVProcessor csvProcessor)
    {
        _csvProcessor = csvProcessor;
    }

    [HttpPost]
    public IActionResult ImportCsvFile(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            var fileName = file.FileName;
            var fileSize = file.Length;
            var fileContentType = file.ContentType;

            var filePath = "file.csv";
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            _csvProcessor.ImportCSVFile(filePath);
        }

        return Ok("File imported successfully");
    }
}