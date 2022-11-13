using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataModelRepositories.Base.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataModels;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataModelRepositories.Interfaces;

public interface ICustomerMongoDbDataModelRepository
    : IMongoDbDataModelRepository<CustomerMongoDbDataModel>
{
}
