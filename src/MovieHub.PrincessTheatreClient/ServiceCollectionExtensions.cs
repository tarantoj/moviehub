using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;

namespace MovieHub.PrincessTheatreClient;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPrincessTheatreClient(this IServiceCollection services, string configSectionPath = "PrincessTheatreClient")
    {
        services.AddOptions<PrincessTheatreClientOptions>()
                .BindConfiguration(configSectionPath)
                .ValidateDataAnnotations()
                .ValidateOnStart();


        services.AddHttpClient<IPrincessTheatreService, PrincessTheatreService>()
                .AddPolicyHandler(HttpPolicyExtensions.HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(Backoff.AwsDecorrelatedJitterBackoff(
                    minDelay: TimeSpan.FromMilliseconds(10),
                    maxDelay: TimeSpan.FromMilliseconds(100),
                    retryCount: 5)));


        return services;
    }
}
