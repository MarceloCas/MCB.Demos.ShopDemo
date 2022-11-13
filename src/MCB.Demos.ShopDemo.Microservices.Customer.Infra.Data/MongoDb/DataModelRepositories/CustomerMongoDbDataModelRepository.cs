using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataContexts.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataModelRepositories.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataModelRepositories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataModels;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataModelRepositories;
public class CustomerMongoDbDataModelRepository
    : MongoDbDataModelRepositoryBase<CustomerMongoDbDataModel>,
    ICustomerMongoDbDataModelRepository
{
    // Constructors
    public CustomerMongoDbDataModelRepository(
        IDefaultMongoDbDataContext dataContext
    ) : base(dataContext)
    {
    }
}
