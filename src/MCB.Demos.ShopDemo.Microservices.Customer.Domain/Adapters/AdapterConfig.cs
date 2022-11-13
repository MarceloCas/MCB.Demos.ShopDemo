using Mapster;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Services.Customers.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Adapters;

public class AdapterConfig
{
    // Public Methods
    public static void Configure(TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.ForType<RegisterNewCustomerServiceInput, RegisterNewCustomerInput>();
    }
}
