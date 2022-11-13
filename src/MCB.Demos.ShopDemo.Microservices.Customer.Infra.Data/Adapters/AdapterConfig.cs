using Mapster;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataModels;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataModels.Base;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.Adapters;

public class AdapterConfig
{
    // Public Methods
    public static void Configure(TypeAdapterConfig typeAdapterConfig)
    {
        MapDomainEntityToMongoDbDataModel<Domain.Entities.Customers.Customer, CustomerMongoDbDataModel>(typeAdapterConfig);

        typeAdapterConfig.ForType<CustomerMongoDbDataModel, Domain.Entities.Customers.Inputs.SetExistingCustomerInfoInput>();
    }

    // Private Methods
    private static void MapDomainEntityToMongoDbDataModel<TDomainEntityBase, TMongoDbDataModel>(TypeAdapterConfig typeAdapterConfig)
        where TDomainEntityBase : DomainEntityBase
        where TMongoDbDataModel : MongoDbDataModelBase
    {
        typeAdapterConfig.ForType<TDomainEntityBase, TMongoDbDataModel>()
            .Map(dest => dest.CreatedAt, src => src.AuditableInfo.CreatedAt)
            .Map(dest => dest.CreatedBy, src => src.AuditableInfo.CreatedBy)
            .Map(dest => dest.LastUpdatedAt, src => src.AuditableInfo.LastUpdatedAt)
            .Map(dest => dest.LastUpdatedBy, src => src.AuditableInfo.LastUpdatedBy)
            .Map(dest => dest.LastSourcePlatform, src => src.AuditableInfo.LastSourcePlatform);
    }
}
