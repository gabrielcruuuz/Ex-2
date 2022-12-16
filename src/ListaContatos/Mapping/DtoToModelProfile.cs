using AutoMapper;
using ListaContatos.Dtos.Contato;
using ListaContatos.Dtos.Pessoa;
using ListaContatos.Model;

namespace ListaContatos.Mapping
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<PessoaModel, PessoaDto>()
                .ForMember(dest => dest.Contatos, opt => opt.MapFrom(src => src.Contatos))
                .ReverseMap();
            CreateMap<PessoaModel, PessoaDtoCreate>()
               .ForMember(dest => dest.Contatos, opt => opt.MapFrom(src => src.Contatos))
               .ReverseMap();
            CreateMap<PessoaModel, PessoaDtoUpdate>()
              .ForMember(dest => dest.Contatos, opt => opt.MapFrom(src => src.Contatos))
              .ReverseMap();

            CreateMap<ContatoModel, ContatDtoCreate>()
                .ReverseMap();
        }
    }
}
