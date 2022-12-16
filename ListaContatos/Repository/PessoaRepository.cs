using ListaContatos.Model;
using ListaContatos.Repository.SeedWork;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaContatos.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private IMongoCollection<PessoaModel> _context;

        public PessoaRepository(IDbContext dbContext)
        {
            _context = dbContext.GetCollection<PessoaModel>("Pessoa");
        }
        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                var result = await SelectAsync(id);
                if (result == null)
                    return false;

                var filter = Builders<PessoaModel>.Filter.Eq(x => x.Id, id);

                await _context.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public async Task<PessoaModel> InsertAsync(PessoaModel item)
        {
            try
            {
                item.CreateAt = DateTime.UtcNow;
                await _context.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<PessoaModel> SelectAsync(string id)
        {
            try
            {
                var filter = Builders<PessoaModel>.Filter.Eq(x => x.Id, id);
                var pessoa = await (await _context.FindAsync(filter)).FirstOrDefaultAsync();

                return pessoa;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<PessoaModel>> SelectAsync()
        {
            try
            {
                var pessoas = await (await _context.FindAsync(_ => true)).ToListAsync();

                return pessoas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PessoaModel> UpdateAsync(PessoaModel item)
        {
            try
            {
                var result = await SelectAsync(item.Id);

                if (result == null)
                    return null;

                item.UpdateAt = DateTime.UtcNow;

                var filter = Builders<PessoaModel>.Filter.Eq(x => x.Id, item.Id);
                var update = Builders<PessoaModel>.Update.Set("Contatos", item.Contatos);

                result = await _context.FindOneAndUpdateAsync(filter, update);

                var objetoAtualizado = await SelectAsync(item.Id);

                return objetoAtualizado;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<bool> ExistAsync(string id)
        {
            var filter = Builders<PessoaModel>.Filter.Eq(x => x.Id, id);
            var pessoa = await (await _context.FindAsync(filter)).FirstOrDefaultAsync();

            return pessoa != null ? true : false;
        }
    }

}
