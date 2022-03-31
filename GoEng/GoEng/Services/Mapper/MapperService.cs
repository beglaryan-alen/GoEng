using AutoMapper;
using Firebase.Auth;
using Firebase.Database;
using GoEng.Models.FirebaseResponse;
using GoEng.Models.Home;
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
                cfg.CreateMap<FirebaseAuthException, FirebaseResponse>()
                .ForMember(dest => dest.AuthErrorReason, act => act.MapFrom(src => src.Reason));

                cfg.CreateMap<FirebaseException, FirebaseResponse>()
                .ForMember(dest => dest.StatusCode, act => act.MapFrom(src => src.StatusCode));

                cfg.CreateMap<HomeModel, HomeBindableModel>()
                .ForMember(dest => dest.IsBlocked, act => act.MapFrom(src => src.IsBlocked))
                .ForMember(dest => dest.Star, act => act.MapFrom(src => src.Star))
                .ForMember(dest => dest.IsTest, act => act.MapFrom(src => src.IsTest))
                .ForMember(dest => dest.IsPassed, act => act.MapFrom(src => src.IsPassed))
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ReverseMap();
            });

            _mapperCompletionSource.SetResult(mapperConfiguration.CreateMapper());
        }
    }
}
