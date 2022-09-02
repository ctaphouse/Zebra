using MediatR;
using Zebra.Shared.Features.ManageAnimals.Shared;

namespace Zebra.Shared.Features.ManageAnimals.DeleteAnimal;

public record DeleteAnimalRequest(int AnimalId) : IRequest<DeleteAnimalRequest.Response>
{
    public const string RouteTemplate = "/api/animals";
    public record Response(bool IsSucessful);
}