using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ListaContatos.Model
{
    public class PessoaModel
    {
        [BsonElement("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        private DateTime? _createAt;
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        private DateTime? _updateAt;

        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = (value == null ? DateTime.UtcNow : value); }
        }

        public DateTime? UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = (value == null ? DateTime.UtcNow : value); }
        }

        public string Name { get; set; }
        public List<ContatoModel> Contatos { get; set; }
    }
}
