using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts.Base.Abstractions;
using MongoDB.Driver;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataContexts.Base.Interfaces;

public interface IMongoDbDataContext
    : IDataContext
{
    IMongoCollection<TMongoDbDataModel> GetCollection<TMongoDbDataModel>();
}
