using Mapster;
using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Enums;
using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Settings;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.DependencyInjection;

public static class Bootstrapper
{
    // Public Methods
    public static void ConfigureDependencyInjection(
        IDependencyInjectionContainer dependencyInjectionContainer,
        Action<TypeAdapterConfig> adapterMapAction,
        AppSettings appSettings
    )
    {
        // Inject Dependencies
        Core.Infra.CrossCutting.DependencyInjection.Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer);
        Core.Infra.CrossCutting.DesignPatterns.DependencyInjection.Bootstrapper.ConfigureServices(
            dependencyInjectionContainer,
            adapterConfiguration =>
            {
                adapterConfiguration.DependencyInjectionLifecycle = DependencyInjectionLifecycle.Singleton;
                adapterConfiguration.TypeAdapterConfigurationFunction = new Func<TypeAdapterConfig>(() =>
                {
                    var typeAdapterConfig = new TypeAdapterConfig();

                    adapterMapAction(typeAdapterConfig);

                    return typeAdapterConfig;
                });
            }
        );
        Core.Domain.DependencyInjection.Bootstrapper.ConfigureServices(dependencyInjectionContainer);

        // Inject Layers
        Application.DependencyInjection.Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer, appSettings);
        Domain.DependencyInjection.Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer, appSettings);
        Domain.Entities.DependencyInjection.Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer, appSettings);
        Infra.Data.DependencyInjection.Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer, appSettings);
    }
}