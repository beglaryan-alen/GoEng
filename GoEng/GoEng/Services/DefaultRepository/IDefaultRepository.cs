using GoEng.Enums.Game;
using GoEng.Models.Game;
using GoEng.Models.GameVariant;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoEng.Services.DefaultRepository
{
    public interface IDefaultRepository
    {
        public IEnumerable<GameBindableModel> GetStartGames();
        public Task<IEnumerable<GameBindableModel>> GetGameBindableModels(IEnumerable<GameModel> models);
        public IEnumerable<GameVariantBindableModel> GetGameVariants(EGameVariant gameVariant, EGame game);
        public int GetGameVariantsCount(EGame game);
    }
}
