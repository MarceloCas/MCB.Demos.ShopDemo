using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts.Base;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts.Base.Models;
using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts;

public class DefaultRedisDataContext
    : RedisDataContextBase,
    IDefaultRedisDataContext
{
    public DefaultRedisDataContext(
        RedisOptions redisOptions
    ) : base(redisOptions)
    {
    }
}
