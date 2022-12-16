using ListaContatos.Repository.SeedWork;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaContatos.Context
{
    public class DbContext : MongoDbContextBase, IDbContext
    {
        public DbContext(IConfiguration configuration) : base (configuration)
        {
            OnRegisterMappers();
        }
        public IMongoCollection<TDocument> GetCollection<TDocument>(string name)
        {
            return Database.GetCollection<TDocument>(name);
        }

        protected override void OnRegisterMappers()
        {
            //TODO
            //RegisterClassMap
        }
    }
}
