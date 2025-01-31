using UnityEngine;
using VContainer;
using VContainer.Unity;

public class InitLifetimeScope : LifetimeScope
{
    [SerializeField] private InitScreen initScreen;
    
    protected override void Configure(IContainerBuilder builder)
    {
        // Entry Points
        builder.RegisterEntryPoint<InitPresenter>();
        
        // Services
        var configRepository = new ConfigYamlRepository(".\\Assets\\config.yaml");
        builder.Register<ISocketService, TcpService>(Lifetime.Singleton)
            .WithParameter("port", configRepository.GetPort());
        
        // Components
        builder.RegisterComponent(initScreen);
    }
}