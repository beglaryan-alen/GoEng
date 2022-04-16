using GoEng.Models.Game;
using System.Collections.Generic;

namespace GoEng.Services.DefaultRepository
{
    public interface IDefaultRepository
    {
        public IEnumerable<GameBindableModel> GetStartGames();
    }
}
