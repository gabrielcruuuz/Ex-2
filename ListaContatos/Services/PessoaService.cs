using AutoMapper;
using ListaContatos.Dtos.Pessoa;
using ListaContatos.Model;
using ListaContatos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaContatos.Services
{
    public class PessoaService : IPessoaService
    {
        private IPessoaRepository _repository;
        private readonly IMapper _mapper;

        public PessoaService(IPessoaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(string id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<PessoaDto> Get(string id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<PessoaDto>(entity) ?? null;
        }

        public async Task<IEnumerable<PessoaDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<PessoaDto>>(listEntity);
        }

        public async Task<PessoaDto> Post(PessoaDtoCreate pessoa)
        {
            var model = _mapper.Map<PessoaModel>(pessoa);
            var result = await _repository.InsertAsync(model);

            return _mapper.Map<PessoaDto>(result);
        }

        public async Task<PessoaDto> Put(PessoaDtoUpdate pessoa)
        {
            var model = _mapper.Map<PessoaModel>(pessoa);
            var result = await _repository.UpdateAsync(model);

            return _mapper.Map<PessoaDto>(result);

        }
    }
}
