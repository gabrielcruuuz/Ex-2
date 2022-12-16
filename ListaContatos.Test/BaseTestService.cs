using AutoMapper;
using ListaContatos.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListaContatos.Test
{
    public abstract class BaseTestService
    {
        public IMapper Mapper { get; set; }

        public BaseTestService()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }

        public class AutoMapperFixture : IDisposable
        {
            public IMapper GetMapper()
            {
                var config = new MapperConfiguration(config =>
                {
                    config.AddProfile(new DtoToModelProfile());
                });

                return config.CreateMapper();
            }

            public void Dispose()
            {

            }
        }
    }
}
