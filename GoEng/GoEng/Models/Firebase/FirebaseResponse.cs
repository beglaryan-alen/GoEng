using GoEng.Enums.Firebase;
using GoEng.Models.Game;

namespace GoEng.Models.Firebase
{
    public class FirebaseResponse
    {
        public bool IsSuccessful { get; set; }
        public EFirebaseStatus Status { get; set; }
        public string Message { get; set; }
        public object Content { get; set; }
    }
}
