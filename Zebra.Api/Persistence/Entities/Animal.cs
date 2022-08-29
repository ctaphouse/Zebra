namespace Zebra.Api.Persistence.Entities;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Category { get; set; }
    public Category Category { get; set; } = default!;
}