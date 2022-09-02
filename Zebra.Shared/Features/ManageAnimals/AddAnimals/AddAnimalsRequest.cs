using MediatR;

namespace Zebra.Shared.Features.ManageAnimals.AddAnimals;

public record AddAnimalsRequest() : IRequest<AddAnimalsRequest.Response>
{
    public const string RouteTemplate = "/api/animals";
    public record Response(bool IsSuccessful);
}

