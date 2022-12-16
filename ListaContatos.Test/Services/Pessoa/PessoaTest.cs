using ListaContatos.Dtos.Pessoa;
using ListaContatos.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ListaContatos.Test.Services.Pessoa
{
    public class PessoaTest : PessoaDados
    {
        private IPessoaService _service;
        private Mock<IPessoaService> _serviceMock;

        [Fact(DisplayName = "GET")]
        public async Task EhPossivelExecutarGet()
        {
            _serviceMock = new Mock<IPessoaService>();
            _serviceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(pessoaDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdUsuario);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomePessoa, result.Name);
        }

        [Fact(DisplayName = "GETALL")]
        public async Task EhPossivelExecutarGetAll()
        {
            _serviceMock = new Mock<IPessoaService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaPessoas);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() > 0);
            Assert.True(result.Count() == 10);

            var _listResult = new List<PessoaDto>();
            _serviceMock = new Mock<IPessoaService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();

            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }

        [Fact(DisplayName = "POST")]
        public async Task EhPossivelExecutarAdicionar()
        {
            _serviceMock = new Mock<IPessoaService>();
            _serviceMock.Setup(m => m.Post(pessoaDtoCreate)).ReturnsAsync(pessoaDto);
            _service = _serviceMock.Object;

            var result = await _service.Post(pessoaDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomePessoa, result.Name);
        }


        [Fact(DisplayName = "DELETE")]
        public async Task EhPossivelExecutarDeletar()
        {
            _serviceMock = new Mock<IPessoaService>();
            _serviceMock.Setup(m => m.Delete(IdUsuario)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(IdUsuario);
            Assert.True(deletado);

            _serviceMock = new Mock<IPessoaService>();
            _serviceMock.Setup(m => m.Delete((It.IsAny<string>()))).ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(It.IsAny<string>());
            Assert.False(deletado);
        }
    }
}
