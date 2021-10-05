using System;
using System.ComponentModel;
using Godot;
using SimpleInjector;
using Container = SimpleInjector.Container;

public class DependencyInjectionSystem : Node
{
    private Container _container;

    public override void _EnterTree()
    {
        base._EnterTree();
        _container = new Container();
        
        _container.Register<Player>(Lifestyle.Singleton);
        
        _container.Verify();
        
        GD.Print("Finished registering dependencies");
    }

    public object Resolve<T> (T dependencyType) where T : Type
    {
        return _container.GetInstance(dependencyType);
    }
}
