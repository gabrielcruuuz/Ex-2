using ListaContatos.Dtos.Contato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaContatos.Dtos.Pessoa
{
    public class PessoaDtoUpdate
    {
        public string Id { get; set; }
        public List<ContatDtoCreate> Contatos { get; set; }
    }
}
