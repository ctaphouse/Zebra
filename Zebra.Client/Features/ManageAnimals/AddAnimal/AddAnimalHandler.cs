using MediatR;
using Zebra.Shared.Features.ManageAnimals.AddAnimal;
using System.Net.Http.Json;

namespace Zebra.Client.Features.ManageAnimals.AddAnimal;

public class AddAnimalHandler :IRequestHandler<AddAnimalRequest, AddAnimalRequest.Response>
{
    private readonly HttpClient _httpClient;

    public AddAnimalHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AddAnimalRequest.Response> Handle(AddAnimalRequest request, CancellationToken cancellationToken)
    {
        var animalId = -111;

        var response = await _httpClient.PostAsJsonAsync(AddAnimalRequest.RouteTemplate, request, cancellationToken);

        if(response.IsSuccessStatusCode)
        {
            animalId = await response.Content.ReadFromJsonAsync<int>(cancellationToken: cancellationToken);
            return new AddAnimalRequest.Response(animalId);
        }

        return new AddAnimalRequest.Response(animalId);
    }
}