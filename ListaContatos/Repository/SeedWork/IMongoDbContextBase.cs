using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaContatos.Repository.SeedWork
{
    public interface IMongoDbContextBase
    {
        IMongoDatabase Database { get; }
    }
}
