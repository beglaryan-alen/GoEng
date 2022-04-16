using Android.Gms.Tasks;
using Android.Runtime;
using Firebase.Auth;
using Firebase.Firestore;
using GoEng.Enums.Firebase;
using GoEng.Enums.Game;
using GoEng.Enums.User;
using GoEng.Models.Firebase;
using GoEng.Models.Game;
using Java.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoEng.Droid.ServiceListeners
{
    public enum ListenerStatus
    {
        Read,
        Create,
        Update,
    }
    public class OnGetGamesCompleteListener : Java.Lang.Object, IOnCompleteListener
    {
        private TaskCompletionSource<FirebaseResponse> _tcs;
        private IEnumerable<GameModel> _games;
        private readonly ListenerStatus _status;

        public OnGetGamesCompleteListener(TaskCompletionSource<FirebaseResponse> tcs,
            ListenerStatus status, IEnumerable<GameModel> games = default)
        {
            _tcs = tcs;
            _games = games;
            _status = status;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                // process document
                var result = task.Result;

                if (result is DocumentSnapshot doc)
                {
                    if (doc.Exists())
                    {
                        if (_status == ListenerStatus.Read)
                        {
                            List<GameModel> games = new List<GameModel>();
                            for (int i = 0; i < 12; i++)
                            {
                                var game = doc.Get($"game-{(EGame)i}");
                                var dictioanryFromHashMap = new JavaDictionary<string, string>(game.Handle, Android.Runtime.JniHandleOwnership.DoNotRegister);
                                GameModel gameToAdd = new GameModel();
                                gameToAdd.Name = dictioanryFromHashMap["name"];
                                gameToAdd.IsTest = bool.Parse(dictioanryFromHashMap["isTest"]);
                                gameToAdd.IsCurrent = bool.Parse(dictioanryFromHashMap["isCurrent"]);
                                gameToAdd.GameVariant = (EGameVariant)int.Parse(dictioanryFromHashMap["gameVariant"]);
                                gameToAdd.Star = (EStar)int.Parse(dictioanryFromHashMap["star"]);
                                gameToAdd.Game = (EGame)int.Parse(dictioanryFromHashMap["game"]);
                                games.Add(gameToAdd);
                            }

                            _tcs.SetResult(new FirebaseResponse(EFirebaseExcType.Ok)
                            {
                                Content = games
                            });
                        }
                        else if(_status == ListenerStatus.Update)
                        {
                            IDictionary<string, Java.Lang.Object> allToUpdate = new Dictionary<string, Java.Lang.Object>();
                            foreach (var item in _games)
                            {
                                HashMap gameMap = new HashMap();
                                gameMap.Put("name", item.Name);
                                gameMap.Put("isTest", item.IsTest);
                                gameMap.Put("isCurrent", item.IsCurrent);
                                gameMap.Put("gameVariant", (int)item.GameVariant);
                                gameMap.Put("star", (int)item.Star);
                                gameMap.Put("game", (int)item.Game);
                                allToUpdate.Add($"game-{item.Game}", gameMap);
                            }
                            
                            FirebaseFirestore.Instance.Collection("games")
                                .Document(FirebaseAuth.Instance.CurrentUser.Uid)
                                .Update(allToUpdate);

                            _tcs.SetResult(new FirebaseResponse(EFirebaseExcType.Ok));
                        }
                        else
                        {
                            _tcs.SetResult(new FirebaseResponse(EFirebaseExcType.ServerException));
                        }
                    }
                    else
                    {
                        if (_status == ListenerStatus.Read ||
                            _status == ListenerStatus.Update) _tcs.SetResult(new FirebaseResponse(EFirebaseExcType.ServerException));
                        HashMap allGames = new HashMap();
                        foreach (var item in _games)
                        {
                            HashMap gameMap = new HashMap();
                            gameMap.Put("name", item.Name);
                            gameMap.Put("isTest", item.IsTest);
                            gameMap.Put("isCurrent", item.IsCurrent);
                            gameMap.Put("gameVariant", (int)item.GameVariant);
                            gameMap.Put("star", (int)item.Star);
                            gameMap.Put("game", (int)item.Game);
                            allGames.Put($"game-{item.Game}", gameMap);
                        }

                        FirebaseFirestore.Instance.Collection("games")
                                .Document(FirebaseAuth.Instance.CurrentUser.Uid)
                                .Set(allGames);
                        _tcs.SetResult(new FirebaseResponse(EFirebaseExcType.Ok));
                    }
                }
            }
            // something went wrong
            _tcs.TrySetResult(new FirebaseResponse(Enums.Firebase.EFirebaseExcType.ServerException));
        }
    }
}
