using AutoMapper;
using ListaContatos.Dtos.Pessoa;
using ListaContatos.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ListaContatos.Test.Services.AutoMapper
{
    public class PessoaMapper : BaseTestService
    {
        [Fact(DisplayName = "É possível mapear os modelos")]
        public void EhPossivelMapearModelos()
        {
            var listaContatos = new List<ContatoModel>();

            var contato = new ContatoModel()
            {
                WhatsApp = "12344567",
                Email = Faker.Internet.Email(),
                Telefone = "12345678901"
            };

            listaContatos.Add(contato);

            var model = new PessoaModel
            {
                Id = "1234",
                Name = Faker.Name.FullName(),
                Contatos = listaContatos,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            // Model > Dto
            var pessoaDto = Mapper.Map<PessoaDto>(model);

            Assert.Equal(pessoaDto.Id, model.Id);
            Assert.Equal(pessoaDto.Name, model.Name);
            Assert.Equal(pessoaDto.Contatos, model.Contatos);

            // DTO > Model
            var model2 = Mapper.Map<PessoaDto>(pessoaDto);

            Assert.Equal(model2.Id, pessoaDto.Id);
            Assert.Equal(model2.Name, pessoaDto.Name);

        }
    }
}
