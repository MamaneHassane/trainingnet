using System.ComponentModel.DataAnnotations;

namespace trainingnet;

public class Person(string _name)
{
    Guid Id { get; set; } = new Guid();

    [Required(ErrorMessage = "Person name is required")] 
    string Name { get; set; } = _name;

    readonly DateOnly SignUpDate = DateOnly.FromDateTime(DateTime.Now);
}

public record PersonDto(
    string Name,
    DateOnly SignUpDate
);