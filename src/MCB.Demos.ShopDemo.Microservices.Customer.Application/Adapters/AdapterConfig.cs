using Mapster;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.RegisterNewCustomer.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Services.Customers.Inputs;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Application.Adapters;

public class AdapterConfig
{
    public static void Configure(TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.ForType<RegisterNewCustomerUseCaseInput, RegisterNewCustomerServiceInput>();
    }
}
