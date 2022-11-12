using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.Factories;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.Factories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.RegisterNewCustomer;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.RegisterNewCustomer.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Settings;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Application.DependencyInjection;

public static class Bootstrapper
{
    // Public Methods
    public static void ConfigureDependencyInjection(IDependencyInjectionContainer dependencyInjectionContainer, AppSettings appSettings)
    {
        // Factories
        dependencyInjectionContainer.RegisterSingleton<IExternalEventFactory, ExternalEventFactory>();

        // Use Cases
        dependencyInjectionContainer.RegisterScoped<IRegisterNewCustomerUseCase, RegisterNewCustomerUseCase>();
    }
}