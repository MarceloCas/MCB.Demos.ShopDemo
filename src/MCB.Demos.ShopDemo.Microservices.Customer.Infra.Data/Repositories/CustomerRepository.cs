using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Repositories.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.Repositories;

public class CustomerRepository
    : ICustomerRepository
{
    public Task<bool> AddAsync(Domain.Entities.Customers.Customer aggregationRoot, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddOrUpdateAsync(Domain.Entities.Customers.Customer aggregationRoot, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Domain.Entities.Customers.Customer> Get(Func<Domain.Entities.Customers.Customer, bool> expression)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Domain.Entities.Customers.Customer> GetAll(Guid tenantId, Guid id)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<Domain.Entities.Customers.Customer> GetAllAsync(Guid tenantId, Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.Customers.Customer> GetAsync(Guid tenantId, Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<Domain.Entities.Customers.Customer> GetAsync(Func<Domain.Entities.Customers.Customer, bool> expression, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<(bool success, int removeCount)> RemoveAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(Domain.Entities.Customers.Customer aggregationRoot, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<(bool success, int removeCount)> RemoveAsync(Func<Domain.Entities.Customers.Customer, bool> expression, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Domain.Entities.Customers.Customer aggregationRoot, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
