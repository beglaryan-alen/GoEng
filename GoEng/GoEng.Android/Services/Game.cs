using Firebase.Auth;
using Firebase.Firestore;
using GoEng.Droid.ServiceListeners;
using GoEng.Droid.Services;
using GoEng.Models.Firebase;
using GoEng.Models.Game;
using GoEng.Services.Game;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Game))]
namespace GoEng.Droid.Services
{
    public class Game : IGame
    {
        public Task<FirebaseResponse> GetUserGames()
        {
            var tcs = new TaskCompletionSource<FirebaseResponse>();

            FirebaseFirestore.Instance
                .Collection("games")
                .Document(FirebaseAuth.Instance.CurrentUser.Uid)
                .Get()
                .AddOnCompleteListener(new OnGetGamesCompleteListener(tcs, ListenerStatus.Read));

            return tcs.Task;
        }

        public Task<FirebaseResponse> UpdateGamesAsync(IEnumerable<GameModel> games)
        {
            var tcs = new TaskCompletionSource<FirebaseResponse>();

            FirebaseFirestore.Instance
                .Collection("games")
                .Document(FirebaseAuth.Instance.CurrentUser.Uid)
                .Get()
                .AddOnCompleteListener(new OnGetGamesCompleteListener(tcs, ListenerStatus.Create, games));

            return tcs.Task;

            
        }
    }
}
