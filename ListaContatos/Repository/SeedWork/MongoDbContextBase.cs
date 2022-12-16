using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;

namespace ListaContatos.Repository.SeedWork
{
    public abstract class MongoDbContextBase : IMongoDbContextBase, IDisposable
    {
        public IMongoDatabase Database { get; }

        public MongoDbContextBase(IConfiguration configuration)
        {
            string conexao = Environment.GetEnvironmentVariable("DATABASE_URL");

            var settings = MongoClientSettings.FromUrl(new MongoUrl(conexao));

            MongoClient mc = new MongoClient(settings);

            Database = mc.GetDatabase("PessoaContato");
        }

        protected abstract void OnRegisterMappers();

        protected virtual void RegisterClassMap<Entity, Mapper>() where Mapper : BsonClassMap<Entity>, new()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Entity)))
            {
                BsonClassMap.RegisterClassMap(new Mapper());
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
