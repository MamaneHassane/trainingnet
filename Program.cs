using System.Reflection;
using trainingnet;

Person me = new("Mi");
var you = Activator.CreateInstance<PersonDto>();
you.Name = "Mi";
you.SignUpDate = DateOnly.FromDateTime(DateTime.Now);

var you2 = you.FromDto<Person, PersonDto>();
Console.WriteLine(you2);

var dto = me.ToDto<Person, PersonDto>(); // Tu peux invoquer les extensions methods ainsi

Console.WriteLine("Fin");