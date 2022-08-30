namespace Zebra.Api.Persistence.Entities;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public IEnumerable<Habitat> Habitats { get; set; } = new List<Habitat>();
}