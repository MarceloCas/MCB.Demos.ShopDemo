using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Repositories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.Repositories;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DependencyInjection;

public static class Bootstrapper
{
    // Public Methods
    public static void ConfigureDependencyInjection(IDependencyInjectionContainer dependencyInjectionContainer)
    {
        // Services
        dependencyInjectionContainer.RegisterScoped<ICustomerRepository, CustomerRepository>();
    }
}