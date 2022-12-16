using AutoMapper;
using ListaContatos.Context;
using ListaContatos.Mapping;
using ListaContatos.Repository;
using ListaContatos.Repository.SeedWork;
using ListaContatos.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaContatos
{
    public class DependencyInjection
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped<IPessoaService, PessoaService>();
        }

        public static void ConfigureDependenciesRepository(IServiceCollection serviceColletion)
        {
            serviceColletion.AddSingleton<IDbContext, DbContext>();
            serviceColletion.AddScoped<IPessoaRepository, PessoaRepository>();
        }

        public static IMapper ConfigureMapper()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new DtoToModelProfile());
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }
    }

}
