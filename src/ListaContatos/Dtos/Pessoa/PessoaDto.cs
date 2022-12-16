using ListaContatos.Model;
using System;
using System.Collections.Generic;

namespace ListaContatos.Dtos.Pessoa
{
    public class PessoaDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ContatoModel> Contatos { get; set; }
    }
}
