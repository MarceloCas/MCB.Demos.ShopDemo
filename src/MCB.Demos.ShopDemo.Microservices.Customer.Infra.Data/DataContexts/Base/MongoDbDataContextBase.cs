using MongoDB.Bson;
using MongoDB.Driver;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts.Base.Abstractions;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts.Base.Models;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts.Base;

public abstract class MongoDbDataContextBase
    : IMongoDbDataContext
{
    // Constants
    public const string TRANSACTION_ALREADY_STARTED = "TRANSACTION_ALREADY_STARTED";
    public const string TRANSACTION_NOT_STARTED = "TRANSATRANSACTION_NOT_STARTEDCTION_ALREADY_STARTED";

    // Fields
    private IClientSessionHandle? _clientSessionHandle;

    // Properties
    protected MongoDbOptions Options { get; }
    protected MongoClient MongoClient { get; }
    protected IMongoDatabase MongoDatabase { get; }

    // Constructors
    protected MongoDbDataContextBase(MongoDbOptions options)
    {
        Options = options;

        MongoClient = new MongoClient(connectionString: Options.ConnectionString);

        MongoDatabase = MongoClient.GetDatabase(
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

        _clientSessionHandle = await MongoClient.StartSessionAsync(
            options: Options.MongoDbClientSessionOptions,
            cancellationToken
        );
    }
    public async Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        if(_clientSessionHandle is null)
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

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
