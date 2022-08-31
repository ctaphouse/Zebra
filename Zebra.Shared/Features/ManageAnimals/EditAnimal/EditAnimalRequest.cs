using MediatR;
using Zebra.Shared.Features.ManageAnimals.Shared;

namespace Zebra.Shared.Features.ManageAnimals.EditAnimal;

public record EditAnimalRequest(AnimalDto Animal) : IRequest<EditAnimalRequest.Response>
{
    public const string RouteTemplate = "/api/animals";
    public record Response(bool IsSuccessful);
}