using ListaContatos.Dtos.Contato;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ListaContatos.Dtos.Pessoa
{
    public class PessoaDtoCreate
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        public List<ContatDtoCreate> Contatos { get; set; }
    }
}
