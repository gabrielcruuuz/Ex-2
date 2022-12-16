using ListaContatos.Dtos.Pessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaContatos.Services
{
    public interface IPessoaService
    {
        Task<PessoaDto> Get(string id);
        Task<IEnumerable<PessoaDto>> GetAll();
        Task<PessoaDto> Post(PessoaDtoCreate pessoa);
        Task<PessoaDto> Put(PessoaDtoUpdate pessoa);
        Task<bool> Delete(string id);
    }
}
