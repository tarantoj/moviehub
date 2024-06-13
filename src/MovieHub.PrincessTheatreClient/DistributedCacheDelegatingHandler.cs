using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace MovieHub.PrincessTheatreClient;

public class DistributedCacheDelegatingHandler(
    IDistributedCache? cache,
    ILogger<DistributedCacheDelegatingHandler> logger
) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken
    )
    {
        if (cache is null || request.Method != HttpMethod.Get || request.RequestUri is null)
        {
            logger.LogDebug("Request is not cacheable {@Request}", request);
            return await base.SendAsync(request, cancellationToken);
        }

        var key = request.RequestUri.ToString();

        var cached = await cache.GetAsync(key, cancellationToken);

        if (cached is not null)
        {
            logger.LogInformation("Returning cached response for {Key}", key);

            return new HttpResponseMessage { Content = new ByteArrayContent(cached) };
        }

        var response = await base.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode || (response.Headers.CacheControl?.NoCache ?? false))
        {
            logger.LogDebug("Response is not cacheable. {@Response}", response);
            return response;
        }

        var responseContent = await response.Content.ReadAsByteArrayAsync(cancellationToken);

        await cache.SetAsync(
            key,
            responseContent,
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow =
                    response.Headers.CacheControl?.MaxAge ?? TimeSpan.FromHours(1)
            },
            cancellationToken
        );

        return response;
    }
}
