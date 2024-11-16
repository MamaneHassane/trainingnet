using System.Reflection;
using trainingnet;

Person me = new("Hassane");

Type type = me.GetType();

Console.WriteLine(type.FullName);

PropertyInfo[] properties = type.GetProperties();

Console.WriteLine("Propriétés d'une personne :");
foreach (var prop in properties)
{
    Console.WriteLine($"- {prop.Name} : ({prop.PropertyType})");
}