using MediatR;
using Zebra.Shared.Features.ManageAnimals.Shared;

namespace Zebra.Shared.Features.ManageAnimals.AddAnimal;

public record AddAnimalRequest(AnimalDto Animal) : IRequest<AddAnimalRequest.Response>
{
    public const string RouteTemplate = "/api/animal";
    public record Response(int AnimalId);
}