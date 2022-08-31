namespace Zebra.Shared.Features.ManageAnimals.Shared;

public class AnimalDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int CategoryId { get; set; }
}