namespace Zebra.Api.Persistence.Entities;

public class Habitat
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public IEnumerable<Animal> Animals { get; set; } = new List<Animal>();
}