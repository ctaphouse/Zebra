using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zebra.Api.Persistence;
using Zebra.Shared.Features.ManageAnimals.DeleteAnimal;

namespace Zebra.Api.Features.ManageAnimals.DeleteAnimal;

public class DeleteAnimalEndpoint : EndpointBaseAsync.WithRequest<DeleteAnimalRequest>.WithActionResult<bool>
{
    private readonly ZebraContext _context;

    public DeleteAnimalEndpoint(ZebraContext context)
    {
        _context = context;
    }
    [HttpDelete(DeleteAnimalRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(DeleteAnimalRequest request, CancellationToken cancellationToken = default)
    {
        var animal = await _context.Animals.SingleOrDefaultAsync(animal => animal.Id == request.AnimalId, cancellationToken);
        
        if(animal is null)
            return BadRequest("Animal could not be found.");

        _context.Animals.Remove(animal);

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(true);
    }
}