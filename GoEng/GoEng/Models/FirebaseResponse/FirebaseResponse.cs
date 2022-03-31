using Firebase.Auth;
using System.Net;

namespace GoEng.Models.FirebaseResponse
{
    public class FirebaseResponse
    {
        public bool IsSuccess { get; set; }

        /// <summary>
        /// If success will be null
        /// </summary>
        public AuthErrorReason AuthErrorReason { get; set; }

        /// <summary>
        /// Status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
    }
}
