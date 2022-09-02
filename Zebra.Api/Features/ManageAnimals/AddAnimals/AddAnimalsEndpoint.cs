using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Zebra.Api.Persistence;
using Zebra.Api.Persistence.Entities;
using Zebra.Shared.Features.ManageAnimals.AddAnimals;

namespace Zebra.Api.Features.ManageAnimals.AddAnimals;

public class AddAnimalsEndpoint : EndpointBaseAsync.WithoutRequest.WithActionResult<bool>
{
    private readonly ZebraContext _context;

    public AddAnimalsEndpoint(ZebraContext context)
    {
        _context = context;
    }
    [HttpPost(AddAnimalsRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var bear = new Animal { Name = "Bear", CategoryId = 1};

        var wolf = new Animal { Name = "Wolf", CategoryId = 1};

        var animals = new List<Animal> { bear, wolf};

        await _context.AddRangeAsync(animals);
        
        await _context.SaveChangesAsync(cancellationToken);

        return(true);
    }
}