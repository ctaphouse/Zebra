using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Zebra.Api.Persistence;
using Zebra.Api.Persistence.Entities;
using Zebra.Shared.Features.ManageAnimals.AddAnimal;

namespace Zebra.Api.Features.ManageAnimals.AddAnimal;

public class AddAnimalEndpoint : EndpointBaseAsync.WithRequest<AddAnimalRequest>.WithActionResult<int>
{
    private readonly ZebraContext _context;

    public AddAnimalEndpoint(ZebraContext context)
    {
        _context = context;
    }
    [HttpPost(AddAnimalRequest.RouteTemplate)]
    public override async Task<ActionResult<int>> HandleAsync(AddAnimalRequest request, CancellationToken cancellationToken = default)
    {
        var animal = new Animal{ Id = request.Animal.Id, Name = request.Animal.Name, CategoryId = request.Animal.CategoryId};

        await _context.Animals.AddAsync(animal, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Ok(animal.Id);
    }
}