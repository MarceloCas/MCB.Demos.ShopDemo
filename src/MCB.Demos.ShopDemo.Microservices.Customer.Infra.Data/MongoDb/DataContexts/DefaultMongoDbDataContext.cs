using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataContexts.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataContexts.Base.Models;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.Mappings;
using MongoDB.Driver;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb;

public class DefaultMongoDbDataContext
    : MongoDbDataContextBase,
    IDefaultMongoDbDataContext
{
    public DefaultMongoDbDataContext(
        MongoDbOptions options
    ) : base(options)
    {
        RegisterMongoCollection(
            name: "Customer",
            mongoDbDataModelMap: new CustomerMongoDbDataModelMap(),
            indexConfigHandler: indexConfig =>
            {
                indexConfig
                    .Ascending(q => q.Email)
                    .Ascending(q => q.BirthDate);
            }
        );
    }
}
