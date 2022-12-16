using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListaContatos.Dtos.Contato
{
    public class ContatDtoCreate
    {
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? Email { get; set; }
        public string? WhatsApp { get; set; }
        public string? Telefone { get; set; }
    }
}
