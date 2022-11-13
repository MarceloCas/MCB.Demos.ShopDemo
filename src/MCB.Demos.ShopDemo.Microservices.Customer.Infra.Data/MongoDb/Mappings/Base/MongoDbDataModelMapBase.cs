using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataModels.Base;
using MongoDB.Bson.Serialization;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.Mappings.Base;

public abstract class MongoDbDataModelMapBase<TMongoDbDataModel>
        where TMongoDbDataModel : MongoDbDataModelBase
{
    // Protected Methods
    protected abstract void MapInternal(BsonClassMap<TMongoDbDataModel> classMap);

    // Public Methods
    public void Map()
    {
        BsonClassMap.RegisterClassMap<TMongoDbDataModel>(classMap =>
        {
            classMap.MapIdMember(dataModel => dataModel.Id);

            classMap.MapMember(dataModel => dataModel.CreatedAt);
            classMap.MapMember(dataModel => dataModel.CreatedBy);

            classMap.MapMember(dataModel => dataModel.LastUpdatedAt);
            classMap.MapMember(dataModel => dataModel.LastUpdatedBy);

            classMap.MapMember(dataModel => dataModel.LastSourcePlatform);

            classMap.MapMember(dataModel => dataModel.RegistryVersion);

            classMap.MapExtraElementsMember(dataModel => dataModel.ExtraElements);
            classMap.SetDiscriminator(typeof(TMongoDbDataModel).Name);

            MapInternal(classMap);
        });
    }
}
