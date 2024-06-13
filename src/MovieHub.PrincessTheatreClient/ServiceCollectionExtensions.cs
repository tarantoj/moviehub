using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;

namespace MovieHub.PrincessTheatreClient;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPrincessTheatreClient(
        this IServiceCollection services,
        string configSectionPath = "PrincessTheatreClient"
    )
    {
        services.AddTransient<DistributedCacheDelegatingHandler>();

        services
            .AddOptions<PrincessTheatreClientOptions>()
            .BindConfiguration(configSectionPath)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services
            .AddHttpClient<IPrincessTheatreService, PrincessTheatreService>()
            .AddPolicyHandler(
                HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
                    .WaitAndRetryAsync(
                        Backoff.AwsDecorrelatedJitterBackoff(
                            TimeSpan.FromMilliseconds(10),
                            TimeSpan.FromMilliseconds(100),
                            5
                        )
                    )
            )
            .AddHttpMessageHandler<DistributedCacheDelegatingHandler>();

        return services;
    }
}
