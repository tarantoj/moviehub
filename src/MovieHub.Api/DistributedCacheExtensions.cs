using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace MovieHub.Api;

public static class DistributedCacheExtensions
{
    public static async Task<T> GetOrCreate<T>(this IDistributedCache cache, string key, Func<Task<T>> factory, DistributedCacheEntryOptions? options = default)
    {
        var bytes = await cache.GetAsync(key);
        if (bytes is not null)
        {
            using var stream = new MemoryStream(bytes);

            var deserialized = await JsonSerializer.DeserializeAsync<T>(stream);
            if (deserialized is not null)
            {
                return deserialized;
            }
        }

        var value = await factory();
        var utf8Json = JsonSerializer.SerializeToUtf8Bytes(value);
        await cache.SetAsync(key, utf8Json, options ?? new DistributedCacheEntryOptions { });

        return value;
    }
}
