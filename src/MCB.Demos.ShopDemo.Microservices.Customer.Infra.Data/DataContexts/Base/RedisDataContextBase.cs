using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts.Base.Abstractions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts.Base;

public abstract class RedisDataContextBase
    : IRedisDataContext
{
    public Task OpenConnectionAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public Task CloseConnectionAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public Task RollbackTransactionAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
