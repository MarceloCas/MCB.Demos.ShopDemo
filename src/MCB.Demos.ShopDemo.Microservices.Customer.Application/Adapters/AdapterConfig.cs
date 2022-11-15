using Mapster;
using MCB.Core.Domain.Entities.Abstractions;
using MCB.Core.Domain.Entities.Abstractions.ValueObjects;
using MCB.Core.Domain.Entities.DomainEntitiesBase.Events;
using MCB.Demos.ShopDemo.Microservices.Customer.Application.UseCases.RegisterNewCustomer.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Customers.Events.CustomerHasBeenRegistered;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Services.Customers.Inputs;
using MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.V1.Events.CustomerHasBeenRegistered;
using MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.V1.Models;
using MCB.Demos.ShopDemo.Microservices.Customer.Messages.Internal.V1.Models.Base;
using static MCB.Demos.ShopDemo.Microservices.Customer.Application.Adapters.AdapterConfig;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Application.Adapters;

public class AdapterConfig
{
    // Public Methods
    public static void Configure(TypeAdapterConfig typeAdapterConfig)
    {
        typeAdapterConfig.ForType<RegisterNewCustomerUseCaseInput, RegisterNewCustomerServiceInput>();

        // ExternalEvents
        typeAdapterConfig.ForType<CustomerHasBeenRegisteredDomainEvent, CustomerHasBeenRegisteredEvent>()
            .Map(dest => dest.Customer, src => ((Domain.Entities.Customers.Customer)src.AggregationRoot).Adapt<CustomerDto>());

        MapDomainEntityToDto<Domain.Entities.Customers.Customer, CustomerDto>();
    }

    private static void MapDomainEntityToDto<TAggregationRoot, TDtoBase>()
        where TAggregationRoot : IAggregationRoot
        where TDtoBase : DtoBase
    {
        TypeAdapterConfig<TAggregationRoot, TDtoBase>.NewConfig()
            .Map(dest => dest.CreatedAt, src => src.AuditableInfo.CreatedAt)
            .Map(dest => dest.CreatedBy, src => src.AuditableInfo.CreatedBy)
            .Map(dest => dest.LastUpdatedAt, src => src.AuditableInfo.LastUpdatedAt)
            .Map(dest => dest.LastUpdatedBy, src => src.AuditableInfo.LastUpdatedBy)
            .Map(dest => dest.LastSourcePlatform, src => src.AuditableInfo.LastSourcePlatform);
    }
}
