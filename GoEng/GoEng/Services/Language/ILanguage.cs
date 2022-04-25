using GoEng.Enums.Game;
using GoEng.Enums.Language;

namespace GoEng.Services.Language
{
    public interface ILanguage
    {
        string GetGameName(ELanguage language, EGame game);
    }
}
