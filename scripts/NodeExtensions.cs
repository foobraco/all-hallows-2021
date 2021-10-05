using Godot;
using System;
using System.Linq;
using System.Reflection;

public static class NodeExtensions
{
    public static void ResolveDependencies(this Node node)
    {
        var disPath = "/root/DependencyInjectionSystem";
        var dis = node.GetNode<DependencyInjectionSystem>(disPath);
        var at = typeof(InjectAttribute);
        var fields = node.GetType()
            .GetRuntimeFields()
            .Where(f => f.GetCustomAttributes(at, true).Any());

        foreach (var field in fields)
        {
            GD.Print($"The type of the dependency is " + field.FieldType);
            var obj = dis.Resolve(field.FieldType);
            try
            {
                field.SetValue(node, obj);
            }
            catch (InvalidCastException)
            {
                GD.PrintErr($"Error converting value " +
                            $"{obj} ({obj.GetType()})" +
                            $" to {field.FieldType}");               
                throw;
            }
        }
    }
}
