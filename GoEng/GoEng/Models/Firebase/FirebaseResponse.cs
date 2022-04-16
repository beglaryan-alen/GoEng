using GoEng.Enums.Firebase;
using GoEng.Models.Game;

namespace GoEng.Models.Firebase
{
    public class FirebaseResponse
    {
        public FirebaseResponse(
            EFirebaseExcType type, string message = "")
        {
            ErrorType = type;
            if (type == EFirebaseExcType.Ok)
                IsSuccessful = true;
        }
        public bool IsSuccessful { get; set; }
        public EFirebaseExcType ErrorType { get; set; }
        public string Message { get; set; }
        public object Content { get; set; }
    }
}
