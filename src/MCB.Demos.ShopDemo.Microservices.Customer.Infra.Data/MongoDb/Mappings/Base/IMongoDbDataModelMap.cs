using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataModels.Base;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.Mappings.Base;

public interface IMongoDbDataModelMap<TMongoDbDataModel>
    where TMongoDbDataModel : MongoDbDataModelBase
{
    void Map();
}
