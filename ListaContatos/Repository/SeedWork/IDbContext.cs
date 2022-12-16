using MongoDB.Driver;

namespace ListaContatos.Repository.SeedWork
{
    public interface IDbContext
    {
        IMongoCollection<TDocument> GetCollection<TDocument>(string name);
    }
}
