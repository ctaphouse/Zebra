using MediatR;

namespace Zebra.Shared.Features.ManageAnimals.EditAnimal;

public record GetAnimalRequest(int AnimalId) : IRequest<GetAnimalRequest.Response>
{
    public const string RouteTemplate = "/api/animals/{animalId}";
    public record Animal(int Id, string Name, int CategoryId);
    public record Response(Animal Animal);
}