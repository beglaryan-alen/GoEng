using System;

namespace GoEng.Services.Cache
{
    public interface ICacheService
    {
        void Add(string key, string data, TimeSpan expireIn);
        string Get(string key);
        void Empty(params string[] key);
        bool IsExpired(string key);
    }
}
