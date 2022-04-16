using GoEng.Models.Firebase;
using GoEng.Models.Game;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoEng.Services.Game
{
    public interface IGame
    {
        public Task<FirebaseResponse> UpdateGamesAsync(IEnumerable<GameModel> games);
        public Task<FirebaseResponse> GetUserGames();
    }
}
