using MediatR;

namespace Zebra.Shared.Features.ManageAnimals.DeleteAnimals;

public record DeleteAnimalsRequest() : IRequest<DeleteAnimalsRequest.Response>
{
    public const string RouteTemplate = "/api/animals";
    public record Response(bool IsSuccessful);
}