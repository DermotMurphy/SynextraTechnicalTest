using Microsoft.AspNetCore.Mvc;
using Synextra.Domain;
using Synextra.WebApi.Services;

namespace Synextra.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class IssLocationController : ControllerBase
{

    private readonly ILogger<IssLocationController> _logger;
    private readonly IIssService _issService;

    public IssLocationController(ILogger<IssLocationController> logger, IIssService issService)
    {
        _logger = logger;
        _issService = issService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var message = await _issService.GetMessageAsync();
        return Ok(message);
    }
}