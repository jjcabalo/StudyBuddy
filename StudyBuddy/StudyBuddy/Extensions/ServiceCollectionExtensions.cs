using StudyBuddy.Handlers;
using StudyBuddy.Options;
using StudyBuddy.Services;
using Microsoft.Extensions.Options;

namespace StudyBuddy.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddGemini(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GeminiOptions>(configuration.GetSection("Gemini"));

            services.AddTransient<GeminiDelegatingHandler>();

            services.AddHttpClient<GeminiClient>((serviceProvider, httpClient) =>
            {
                var geminiOptions = serviceProvider.GetRequiredService<IOptions<GeminiOptions>>().Value;

                httpClient.BaseAddress = new Uri(geminiOptions.Url);
            })
            .AddHttpMessageHandler<GeminiDelegatingHandler>();
        }
    }
}