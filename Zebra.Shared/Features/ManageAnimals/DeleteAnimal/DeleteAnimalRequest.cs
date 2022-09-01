using MediatR;

namespace Zebra.Shared.Features.ManageAnimals.DeleteAnimal;

public record DeleteAnimalRequest(int AnimalId) : IRequest<DeleteAnimalRequest.Response>
{
    public const string RouteTemplate = "/api/animals/animalId";
    public record Response(bool IsSucessful);
}