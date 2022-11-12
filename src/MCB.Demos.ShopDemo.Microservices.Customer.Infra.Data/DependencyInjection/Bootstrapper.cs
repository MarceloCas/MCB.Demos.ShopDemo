using MCB.Core.Infra.CrossCutting.DependencyInjection.Abstractions.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Repositories.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.CrossCutting.Settings;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts.Interfaces;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.Repositories;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DependencyInjection;

public static class Bootstrapper
{
    // Public Methods
    public static void ConfigureDependencyInjection(IDependencyInjectionContainer dependencyInjectionContainer, AppSettings appSettings)
    {
        // Data Contexts
        dependencyInjectionContainer.RegisterSingleton<IDefaultMongoDbDataContext>(dependencyInjectionContainer =>
            new DefaultMongoDbDataContext(
                new DataContexts.Base.Models.MongoDbOptions(
                    connectionString: appSettings.MongoDb.ConnectionString,
                    databaseName: appSettings.MongoDb.DatabaseName,
                    mongoDatabaseSettings: null,
                    mongoDbClientSessionOptions: null
                )
            )
        );
        dependencyInjectionContainer.RegisterSingleton<IDefaultRedisDataContext>(dependencyInjectionContainer =>
            new DefaultRedisDataContext(
                new DataContexts.Base.Models.RedisOptions(
                    connectionString: appSettings.Redis.ConnectionString
                )
            )
        );

        // Repositories
        dependencyInjectionContainer.RegisterScoped<ICustomerRepository, CustomerRepository>();
    }
}