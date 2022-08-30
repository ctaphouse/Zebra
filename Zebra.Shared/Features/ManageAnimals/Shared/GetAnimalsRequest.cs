using MediatR;

namespace Zebra.Shared.Features.ManageAnimals.Shared;

public record GetAnimalsRequest() : IRequest<GetAnimalsRequest.Response>
{
    public const string RouteTemplate = "/api/animals";
    public record Animal(int Id, string Name, int CategoryId);
    public record Response(IEnumerable<Animal> Animals);
}
