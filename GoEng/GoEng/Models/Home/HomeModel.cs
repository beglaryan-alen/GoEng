using GoEng.Enums;

namespace GoEng.Models.Home
{
    public class HomeModel
    {
        public string Id { get; set; }
        public string UserUID { get; set; }
        public string Name { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsPassed { get; set; }
        public bool IsTest { get; set; }
        public EStar Star { get; set; }
    }
}
