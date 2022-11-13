using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataModels;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.Mappings.Base;
using MongoDB.Bson.Serialization;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.Mappings;

public class CustomerMongoDbDataModelMap
    : MongoDbDataModelMapBase<CustomerMongoDbDataModel>
{
    protected override void MapInternal(BsonClassMap<CustomerMongoDbDataModel> classMap)
    {
        classMap.MapMember(dataModel => dataModel.FirstName);
        classMap.MapMember(dataModel => dataModel.LastName);
        classMap.MapMember(dataModel => dataModel.BirthDate);
        classMap.MapMember(dataModel => dataModel.Email);
    }
}
