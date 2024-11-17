using System.ComponentModel.DataAnnotations;

namespace trainingnet;

public class Person(string name)
{
    private Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Il a probablement un nom quand même :(")] 
    public string Name { get; set; } = name;

    public DateOnly SignUpDate { get; }= DateOnly.FromDateTime(DateTime.Now);

    public override string ToString() => $"Name : {Name} , Guid : {Id} , SignUpDate : {SignUpDate} ";
}

public record PersonDto
{
    public required string Name { get; set; }
    public DateOnly SignUpDate { get; set; }
}
    
