using ListaContatos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaContatos.Repository
{
    public interface IPessoaRepository
    {
        Task<PessoaModel> InsertAsync(PessoaModel item);
        Task<PessoaModel> UpdateAsync(PessoaModel item);
        Task<bool> DeleteAsync(string id);
        Task<PessoaModel> SelectAsync(string id);
        Task<IEnumerable<PessoaModel>> SelectAsync();
        Task<bool> ExistAsync(string id);
    }
}
