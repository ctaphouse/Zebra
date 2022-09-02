using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zebra.Api.Persistence;
using Zebra.Shared.Features.ManageAnimals.DeleteAnimals;

namespace Zebra.Api.Features.ManageAnimals.DeleteAnimals;

public class DeleteAnimalsEndpoint : EndpointBaseAsync.WithoutRequest.WithActionResult<bool>
{
    private readonly ZebraContext _context;

    public DeleteAnimalsEndpoint(ZebraContext context)
    {
        _context = context;
    }
    [HttpDelete(DeleteAnimalsRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var animals = await _context.Animals.ToListAsync();

        foreach(var animal in animals)
            _context.Remove(animal);

        await _context.SaveChangesAsync(cancellationToken);

        return(true);
    }
}