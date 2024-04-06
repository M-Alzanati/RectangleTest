using Microsoft.AspNetCore.Mvc;
using RectangleApi.Models;
using RectangleApi.Services;

namespace RectangleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RectangleController(RectangleService rectangleService)
{
    [HttpGet]
    public async Task<IActionResult> GetDimensions(CancellationToken cancellationToken)
    {
        var dimensions = await rectangleService.GetDimensions(cancellationToken);
        return dimensions is not null ? new OkObjectResult(dimensions) : new NotFoundResult();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDimensions(Dimensions dimensions, CancellationToken cancellationToken)
    {
        await rectangleService.UpdateDimensions(dimensions, cancellationToken);
        return new OkResult();
    }
}