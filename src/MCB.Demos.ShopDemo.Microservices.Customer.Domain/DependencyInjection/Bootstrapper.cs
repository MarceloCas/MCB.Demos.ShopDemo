using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Services.Customers;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Services.Customers.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Settings;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.DependencyInjection;

public static class Bootstrapper
{
    // Public Methods
    public static void ConfigureDependencyInjection(IDependencyInjectionContainer dependencyInjectionContainer, AppSettings appSettings)
    {
        // Services
        dependencyInjectionContainer.RegisterScoped<ICustomerService, CustomerService>();
    }
}