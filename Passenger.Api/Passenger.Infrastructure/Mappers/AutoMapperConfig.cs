using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Infrastructure.Dto;

namespace Passenger.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
            })
            .CreateMapper();
        }
    }
}
