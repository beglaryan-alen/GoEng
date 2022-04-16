using AutoMapper;
using GoEng.Models.Game;
using GoEng.Models.User;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoEng.Services.Mapper
{
    public class MapperService : IMapperService
    {
        private TaskCompletionSource<IMapper> _mapperCompletionSource;

        public MapperService()
        {
            _mapperCompletionSource = new TaskCompletionSource<IMapper>();
            Task.Run(ConfigMapper);
        }

        public async Task<T> MapAsync<T>(object source)
        {
            var mapper = await _mapperCompletionSource.Task;

            return mapper.Map<T>(source);
        }

        public async Task<IEnumerable<T>> MapRangeAsync<T>(IEnumerable<object> items)
        {
            var mapper = await _mapperCompletionSource.Task;

            return items.Select(x => mapper.Map<T>(x));
        }

        private void ConfigMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, UserBindableModel>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.PhotoUrl, act => act.MapFrom(src => src.PhotoUrl))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
                .ForMember(dest => dest.DateOfBirth, act => act.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Gender, act => act.MapFrom(src => src.Gender))
                .ReverseMap();

                cfg.CreateMap<GameModel, GameBindableModel>()
               .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
               .ForMember(dest => dest.Game, act => act.MapFrom(src => src.Game))
               .ForMember(dest => dest.IsTest, act => act.MapFrom(src => src.IsTest))
               .ForMember(dest => dest.Star, act => act.MapFrom(src => src.Star))
               .ForMember(dest => dest.GameVariant, act => act.MapFrom(src => src.GameVariant))
               .ForMember(dest => dest.IsCurrent, act => act.MapFrom(src => src.IsCurrent))
               .ReverseMap();
            });

            _mapperCompletionSource.SetResult(mapperConfiguration.CreateMapper());
        }
    }
}
