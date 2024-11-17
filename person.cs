using System.ComponentModel.DataAnnotations;
using Lombok.NET;

namespace trainingnet;

[NoArgsConstructor]
public partial class Person
{
    private Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Il a probablement un nom quand même :(")] 
    public string Name { get; set; } = string.Empty;

    public DateOnly SignUpDate { get; }= DateOnly.FromDateTime(DateTime.Now);

    public Person(string name)
    {
        Name = name;
    }

    public override string ToString() => $"Name : {Name} , Guid : {Id} , SignUpDate : {SignUpDate} ";
}

public record PersonDto
{
    public required string Name { get; set; }
    public DateOnly SignUpDate { get; set; }
}
    
