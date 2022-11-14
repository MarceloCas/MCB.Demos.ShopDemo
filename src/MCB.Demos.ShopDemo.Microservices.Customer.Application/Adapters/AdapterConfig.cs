using Mapster;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.RegisterNewCustomer.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Events.CustomerHasBeenRegistered;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Services.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.V1.Events.CustomerHasBeenRegistered;
using MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.V1.Models;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Application.Adapters;

public class AdapterConfig
{
    public static void Configure(TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.ForType<RegisterNewCustomerUseCaseInput, RegisterNewCustomerServiceInput>();

        // ExternalEvents
        typeAdapterConfig.ForType<CustomerHasBeenRegisteredDomainEvent, CustomerHasBeenRegisteredEvent>()
            .Map(dest => dest.Customer, src => src.AggregationRoot);
        typeAdapterConfig.ForType<Domain.Entities.Customers.Customer, CustomerDto>();

    }
}
