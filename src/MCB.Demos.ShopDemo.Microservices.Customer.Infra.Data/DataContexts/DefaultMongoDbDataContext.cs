using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts.Base.Models;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts;

public class DefaultMongoDbDataContext
    : MongoDbDataContextBase,
    IDefaultMongoDbDataContext
{
    public DefaultMongoDbDataContext(
        MongoDbOptions options
    ) : base(options)
    {
    }
}
