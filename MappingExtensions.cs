using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace trainingnet;

public static class MappingExtensions 
{
    [Benchmark]
    public static TDto ToDto<T, TDto>(this T source)
    {    
        var dto = Activator.CreateInstance<TDto>();
        var sourceProperties = typeof(T).GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        var targetProperties = typeof(TDto).GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        foreach (var targetProp in targetProperties)
        {
            // Trouver la propriété correspondante dans le type source
            var sourceProp = sourceProperties.FirstOrDefault(p => p.Name == targetProp.Name && p.PropertyType == targetProp.PropertyType);
            if (sourceProp == null || !sourceProp.CanRead || !targetProp.CanWrite) continue;
            var value = sourceProp.GetValue(source);
            targetProp.SetValue(dto, value);
        }
        return dto;
    }
    
    [Benchmark]
    public static T FromDto<T, TDto>(this TDto source)
    {
        var t = Activator.CreateInstance<T>();
        var sourceProperties = typeof(TDto).GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        var targetProperties = typeof(T).GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        foreach (var targetProp in targetProperties)
        {
            var sourceProp = sourceProperties.FirstOrDefault(p => p.Name == targetProp.Name && p.PropertyType == targetProp.PropertyType);
            if (sourceProp == null || !sourceProp.CanRead || !targetProp.CanWrite) continue;
            var value = sourceProp.GetValue(source);
            targetProp.SetValue(t, value);
        }
        return t;
    }
}