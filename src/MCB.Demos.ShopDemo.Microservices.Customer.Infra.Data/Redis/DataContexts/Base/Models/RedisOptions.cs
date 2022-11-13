namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.Redis.DataContexts.Base.Models;

public class RedisOptions
{
    // Properties
    public string ConnectionString { get; }

    // Constructors
    public RedisOptions(string connectionString)
    {
        ConnectionString = connectionString;
    }
}
