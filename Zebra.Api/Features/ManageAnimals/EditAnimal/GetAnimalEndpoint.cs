using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zebra.Api.Persistence;
using Zebra.Shared.Features.ManageAnimals.EditAnimal;

namespace Zebra.Api.Features.ManageAnimals.EditAnimal;

public class GetAnimalEndpoint : EndpointBaseAsync.WithRequest<int>.WithActionResult<GetAnimalRequest.Response>
{
    private readonly ZebraContext _context;

    public GetAnimalEndpoint(ZebraContext context)
    {
        _context = context;
    }
    [HttpGet(GetAnimalRequest.RouteTemplate)]
    public override async Task<Microsoft.AspNetCore.Mvc.ActionResult<GetAnimalRequest.Response>> HandleAsync(int animalId, CancellationToken cancellationToken = default)
   {
       var animal = await _context.Animals.SingleOrDefaultAsync(animal => animal.Id == animalId, cancellationToken); 

        if(animal is null)
            return BadRequest("Animal could not be found.");

       var response = new GetAnimalRequest.Response(new GetAnimalRequest.Animal(Id: animal.Id, Name: animal.Name, CategoryId: animal.CategoryId));

       return Ok(response);
   }
}