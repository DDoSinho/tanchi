using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tanchi.dal.Entities;

namespace tanchi.Mapping
{
    public class MapperConfig
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, DTOs.RegisterViewModel>();
                cfg.CreateMap<DTOs.RegisterViewModel, User>();

            });

            var mapper = config.CreateMapper();

            return mapper;
        }
    }
}
