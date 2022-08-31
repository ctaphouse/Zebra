using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zebra.Api.Persistence;
using Zebra.Api.Persistence.Entities;
using Zebra.Shared.Features.ManageAnimals.EditAnimal;

namespace Zebra.Api.Features.ManageAnimals.EditAnimal;

public class EditAnimalEndpoint : EndpointBaseAsync.WithRequest<EditAnimalRequest>.WithActionResult<bool>
{
    private readonly ZebraContext _context;

    public EditAnimalEndpoint(ZebraContext context)
    {
        _context = context;
    }
    [HttpPut(EditAnimalRequest.RouteTemplate)]
    public override async Task<ActionResult<bool>> HandleAsync(EditAnimalRequest request, CancellationToken cancellationToken = default)
    {
        var animal = await _context.Animals.SingleOrDefaultAsync(animal => animal.Id == request.Animal.Id, cancellationToken);

        if(animal is null)
            return BadRequest("Animal could not be found");

        animal.Name = request.Animal.Name;

        animal.CategoryId = request.Animal.CategoryId;

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(true);
    }
}