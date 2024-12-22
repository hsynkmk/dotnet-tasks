namespace App.Domain.Entities;

public class Course
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int Category { get; set; }
    public decimal Price { get; set; }
    public required string Currency { get; set; }
}
