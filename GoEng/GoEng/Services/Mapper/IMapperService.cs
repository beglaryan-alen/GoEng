using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoEng.Services.Mapper
{
    public interface IMapperService
    {
        Task<T> MapAsync<T>(object source);

        Task<IEnumerable<T>> MapRangeAsync<T>(IEnumerable<object> items);
    }
}
