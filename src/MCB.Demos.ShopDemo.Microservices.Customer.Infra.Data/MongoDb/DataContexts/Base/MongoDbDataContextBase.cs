using MongoDB.Driver;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataContexts.Base.Models;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataContexts.Base.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataModels.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.Mappings.Base;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataContexts.Base;

public abstract class MongoDbDataContextBase
    : IMongoDbDataContext
{
    // Constants
    public const string TRANSACTION_ALREADY_STARTED = "TRANSACTION_ALREADY_STARTED";
    public const string TRANSACTION_NOT_STARTED = "TRANSATRANSACTION_NOT_STARTEDCTION_ALREADY_STARTED";

    // Fields
    private IClientSessionHandle? _clientSessionHandle;
    private readonly Dictionary<Type, object> _mongoCollectionDictionary;

    // Properties
    protected MongoDbOptions Options { get; }
    protected MongoClient Client { get; }
    protected IMongoDatabase Database { get; }

    // Constructors
    protected MongoDbDataContextBase(MongoDbOptions options)
    {
        _mongoCollectionDictionary = new Dictionary<Type, object>();

        Options = options;

        Client = new MongoClient(connectionString: Options.ConnectionString);

        Database = Client.GetDatabase(
            name: Options.DatabaseName,
            settings: Options.MongoDatabaseSettings
        );
    }

    // Public Methods
    public Task OpenConnectionAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
    public Task CloseConnectionAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        if (_clientSessionHandle is not null)
            throw new InvalidOperationException(TRANSACTION_ALREADY_STARTED);

        _clientSessionHandle = await Client.StartSessionAsync(
            options: Options.MongoDbClientSessionOptions,
            cancellationToken
        );
    }
    public async Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        if (_clientSessionHandle is null)
            throw new InvalidOperationException(TRANSACTION_NOT_STARTED);

        await _clientSessionHandle.CommitTransactionAsync(cancellationToken);

        _clientSessionHandle.Dispose();
        _clientSessionHandle = null;
    }
    public async Task RollbackTransactionAsync(CancellationToken cancellationToken)
    {
        if (_clientSessionHandle is null)
            throw new InvalidOperationException(TRANSACTION_NOT_STARTED);

        await _clientSessionHandle.AbortTransactionAsync(cancellationToken);

        _clientSessionHandle.Dispose();
        _clientSessionHandle = null;
    }

    public IMongoCollection<TMongoDbDataModel>? GetCollection<TMongoDbDataModel>()
    {
        _mongoCollectionDictionary.TryGetValue(typeof(TMongoDbDataModel), out object? mongoCollection);

        return (IMongoCollection<TMongoDbDataModel>?)mongoCollection;
    }

    public void RegisterMongoCollection<TMongoDbDataModel>(
        string name,
        MongoDbDataModelMapBase<TMongoDbDataModel> mongoDbDataModelMap,
        Action<IndexKeysDefinition<TMongoDbDataModel>> indexConfigHandler
    )
        where TMongoDbDataModel : MongoDbDataModelBase
    {
        var indexKeysDefinition = Builders<TMongoDbDataModel>.IndexKeys
            .Ascending(q => q.CreatedBy)
            .Ascending(q => q.CreatedAt)
            .Ascending(q => q.LastUpdatedAt)
            .Ascending(q => q.LastUpdatedBy)
            .Ascending(q => q.LastSourcePlatform)
            .Ascending(q => q.RegistryVersion);

        mongoDbDataModelMap.Map();

        indexConfigHandler(indexKeysDefinition);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
