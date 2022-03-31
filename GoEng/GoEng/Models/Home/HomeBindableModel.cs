using GoEng.Enums;

namespace GoEng.Models.Home
{
    public class HomeBindableModel
    {
        public string Name { get; set; }

        public bool IsBlocked { get; set; }

        public bool IsPassed { get; set; }

        public bool IsTest { get; set; }

        public EStar Star { get; set; }
    }
}
