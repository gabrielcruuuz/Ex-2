using ListaContatos.Dtos.Contato;
using ListaContatos.Dtos.Pessoa;
using ListaContatos.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListaContatos.Test.Services.Pessoa
{
    public class PessoaDados
    {
        public static string NomePessoa { get; set; }
        public static string IdUsuario { get; set; }

        public List<PessoaDto> listaPessoas = new List<PessoaDto>();

        public PessoaDto pessoaDto;
        public PessoaDtoCreate pessoaDtoCreate;

        public PessoaDados()
        {
            IdUsuario = "1";
            NomePessoa = Faker.Name.FullName();

            var contatos = new List<ContatoModel>();

            var contato = new ContatoModel()
            {
                Email = Faker.Internet.Email()
            };

            contatos.Add(contato);

            var contatosCreate = new List<ContatDtoCreate>();

            var contatoCreate = new ContatDtoCreate()
            {
                Email = Faker.Internet.Email()
            };

            contatosCreate.Add(contatoCreate);

            for (int i = 0; i < 10; i++)
            {
                var contatos10 = new List<ContatoModel>();

                contato.Email = Faker.Internet.Email();

                contatos10.Add(contato);

                var dto = new PessoaDto()
                {
                    Id = i.ToString(),
                    Name = Faker.Name.FullName(),
                    Contatos = contatos10,
                };
                listaPessoas.Add(dto);
            }

            pessoaDto = new PessoaDto()
            {
                Id = IdUsuario,
                Name = NomePessoa,
                Contatos = contatos,
            };

            pessoaDtoCreate = new PessoaDtoCreate()
            {
                Name = NomePessoa,
                Contatos = contatosCreate
            };

        }
    }
}
