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
       var response = await _context.Animals.SingleOrDefaultAsync(animal => animal.Id == animalId, cancellationToken); 

        if(response is null)
            return BadRequest("Animal could not be found.");

       var animal = new GetAnimalRequest.Animal(Id: response.Id, Name: response.Name, CategoryId: response.CategoryId);

       return Ok(new GetAnimalRequest.Response(animal));
   }
}