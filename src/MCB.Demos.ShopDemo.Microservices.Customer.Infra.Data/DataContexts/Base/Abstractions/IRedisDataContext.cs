﻿using StackExchange.Redis;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts.Base.Abstractions;

public interface IRedisDataContext
    : IDataContext
{
    Task<bool> StringSetAsync(string key, string value, TimeSpan? expiry, CommandFlags commandFlags = CommandFlags.None);
    Task<RedisValue> StringGetAsync(string key, CommandFlags commandFlags = CommandFlags.None);
    Task<double> StringIncrementAsync(string key, double value = 1, CommandFlags commandFlags = CommandFlags.None);
}
