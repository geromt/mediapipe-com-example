using UnityEngine;
using VContainer;
using VContainer.Unity;

public class InitLifetimeScope : LifetimeScope
{
    [SerializeField] private InitScreen screen;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ISocketService, TcpService>(Lifetime.Singleton);
    }
}