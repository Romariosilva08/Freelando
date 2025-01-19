namespace Freelando.Api.Services;

public interface ICacheService
{
    Task<T> GetCachedDataAsync<T>(string Key);
    Task SetCachedDataAsync<T>(string Key, T data, TimeSpan expiration);
    Task RemoveCachedDataAsync(string key);


}
