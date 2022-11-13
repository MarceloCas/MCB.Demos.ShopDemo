using Mapster;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.RegisterNewCustomer.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.Controllers.Customers.Payloads;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Services.WebApi.Adapters;

public class AdapterConfig
{
    // Public Methods
    public static void Configure(TypeAdapterConfig typeAdapterConfig)
    {
        ConfigureForWebApi(typeAdapterConfig);

        Application.Adapters.AdapterConfig.Configure(typeAdapterConfig);
        Domain.Adapters.AdapterConfig.Configure(typeAdapterConfig);
        Infra.Data.Adapters.AdapterConfig.Configure(typeAdapterConfig);
    }

    // Private Methods
    private static void ConfigureForWebApi(TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.ForType<RegisterNewCustomerPayload, RegisterNewCustomerUseCaseInput>();
    }
}
