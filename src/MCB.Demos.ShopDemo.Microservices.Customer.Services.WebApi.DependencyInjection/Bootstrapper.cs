using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.DependencyInjection;

public static class Bootstrapper
{
    // Public Methods
    public static void ConfigureDependencyInjection(IDependencyInjectionContainer dependencyInjectionContainer)
    {
        // Inject Dependencies
        Core.Domain.DependencyInjection.Bootstrapper.ConfigureServices(dependencyInjectionContainer);

        // Inject Layers
        Application.DependencyInjection.Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer);
        Domain.DependencyInjection.Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer);
        Domain.Entities.DependencyInjection.Bootstrapper.ConfigureDependencyInjection(dependencyInjectionContainer);
    }
}