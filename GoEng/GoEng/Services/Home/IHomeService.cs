using GoEng.Models.Home;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoEng.Services.Home
{
    public interface IHomeService
    {
        public Task<IEnumerable<HomeBindableModel>> GetHomeModels();
        public Task<bool> UpdateGameStatus(HomeBindableModel model);
    }
}
