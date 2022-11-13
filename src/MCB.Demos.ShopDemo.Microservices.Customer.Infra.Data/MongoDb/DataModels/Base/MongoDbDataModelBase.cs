namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataModels.Base;

public abstract class MongoDbDataModelBase
{
    // Properties
    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTimeOffset? LastUpdatedAt { get; set; }
    public string? LastUpdatedBy { get; set; }
    public string LastSourcePlatform { get; set; }
    public DateTimeOffset RegistryVersion { get; set; }

    public IDictionary<string, object>? ExtraElements { get; set; }

    // Public Methods
    public MongoDbDataModelBase()
    {
        CreatedBy = string.Empty;
        LastSourcePlatform = string.Empty;
    }
}
