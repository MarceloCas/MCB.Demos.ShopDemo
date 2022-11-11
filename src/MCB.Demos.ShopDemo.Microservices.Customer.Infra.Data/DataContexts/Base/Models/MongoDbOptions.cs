using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Infra.Data.DataContexts.Base.Models
{
    public class MongoDbOptions
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public MongoDatabaseSettings? MongoDatabaseSettings { get; set; }
        public ClientSessionOptions? MongoDbClientSessionOptions { get; set; }
    }
}
