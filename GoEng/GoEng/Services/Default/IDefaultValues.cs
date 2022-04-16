using GoEng.Enums.Game;
using GoEng.Models.Game;
using System.Collections.Generic;

namespace GoEng.Services.Default
{
    public interface IDefaultValues
    {
        IEnumerable<GameBindableModel> GetGamesFromLevel(EGame game);
    }
}
