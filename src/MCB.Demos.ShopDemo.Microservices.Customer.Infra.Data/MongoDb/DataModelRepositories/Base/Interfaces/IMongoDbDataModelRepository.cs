﻿using MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataModels.Base;
using System.Linq.Expressions;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.MongoDb.DataModelRepositories.Base.Interfaces;

public interface IMongoDbDataModelRepository<TMongoDbDataModel>
    where TMongoDbDataModel : MongoDbDataModelBase
{
    Task AddAsync(TMongoDbDataModel dataModel, CancellationToken cancellationToken);
    Task<IEnumerable<TMongoDbDataModel>> FindAsync(Expression<Func<TMongoDbDataModel, bool>> filter, CancellationToken cancellationToken);
}
