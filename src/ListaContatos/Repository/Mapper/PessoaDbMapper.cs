using ListaContatos.Model;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaContatos.Repository.Mapper
{
    public class PessoaDbMapper : BsonClassMap<PessoaModel>
    {
        public PessoaDbMapper()
        {
            AutoMap();
            SetIgnoreExtraElements(true);
            MapIdMember(x => x.Id);
        }
    }
}
