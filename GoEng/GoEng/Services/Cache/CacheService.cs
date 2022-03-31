using MonkeyCache.SQLite;
using System;

namespace GoEng.Services.Cache
{
    public class CacheService : ICacheService
    {
        public void Add(string key, string data, TimeSpan expireIn)
        {
            Barrel.Current.Add<string>(key, data, expireIn);
        }

        public void Empty(params string[] key)
        {
            Barrel.Current.Empty(key);
        }

        public string Get(string key)
        {
            return Barrel.Current.Get<string>(key);
        }

        public bool IsExpired(string key)
        {
            return Barrel.Current.IsExpired(key);
        }
    }
}
