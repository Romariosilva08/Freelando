
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Freelando.Api.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache cache;

        public CacheService(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public async Task<T> GetCachedDataAsync<T>(string Key)
        {
            var cachedData = await cache.GetStringAsync(Key);
            return cachedData != null ? JsonSerializer.Deserialize<T>(cachedData) : default;
        }

        public async Task SetCachedDataAsync<T>(string Key, T data, TimeSpan expiration)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration
            };

            var serializedData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(Key, serializedData, options);
        }

        public async Task RemoveCachedDataAsync(string key)
        {
            await cache.RemoveAsync(key);
        }
    }
}
