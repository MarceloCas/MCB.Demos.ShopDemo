using Mapster;
using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Enums;
using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.DependencyInjection;

public static class Bootstrapper
{
    // Public Methods
    public static void ConfigureDependencyInjection(IDependencyInjectionContainer dependencyInjectionContainer)
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

                    //typeAdapterConfig.ForType<AddressDto, Address>();

                    return typeAdapterConfig;
                });
            }
        );
        Core.Domain.DependencyInjection.Bootstrapper.ConfigureServices(dependencyInjectionContainer);

        // Inject Layers
        Application.DependencyInjection.Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer);
        Domain.DependencyInjection.Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer);
        Domain.Entities.DependencyInjection.Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer);
        Infra.Data.DependencyInjection.Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer);
    }
}