using Ardalis.ApiEndpoints;
using Zebra.Api.Persistence;
using Zebra.Shared.Features.ManageAnimals.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Zebra.Api.Features.ManageAnimals.Shared;

public class GetAnimalsEndpoint : EndpointBaseAsync.WithoutRequest.WithActionResult<GetAnimalsRequest.Response>
{
    private readonly ZebraContext _context;

    public GetAnimalsEndpoint(ZebraContext context)
    {
        _context = context;
    }
    [HttpGet(GetAnimalsRequest.RouteTemplate)]
    public override async Task<ActionResult<GetAnimalsRequest.Response>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var animals = await _context.Animals.ToListAsync(cancellationToken);

        var response = new GetAnimalsRequest.Response(animals.Select(animal => 
            new GetAnimalsRequest.Animal(animal.Id, animal.Name, animal.CategoryId)));

        return Ok(response);
    }
}