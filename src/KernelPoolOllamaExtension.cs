using Microsoft.SemanticKernel;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Extensions.ValueTask;
using Soenneker.SemanticKernel.Cache.Abstract;
using Soenneker.SemanticKernel.Dtos.Options;
using Soenneker.Utils.HttpClientCache.Abstract;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.SemanticKernel.Pool.Ollama;

/// <summary>
/// Provides Ollama-specific registration extensions for KernelPoolManager, enabling integration with local LLMs via Semantic Kernel.
/// </summary>
public static class KernelPoolOllamaExtension
{
    /// <summary>
    /// Registers an Ollama model with the kernel pool.
    /// </summary>
    public static async ValueTask RegisterOllama(this KernelPoolManager pool, string key, string modelId, string endpoint, IHttpClientCache httpClientCache,
        int? rps, int? rpm, int? rpd, int? tokensPerDay = null, int? maxTokens = null, double? temperature = null,
        CancellationToken cancellationToken = default)
    {
        var options = new SemanticKernelOptions
        {
            ModelId = modelId,
            Endpoint = endpoint,
            RequestsPerSecond = rps,
            RequestsPerMinute = rpm,
            RequestsPerDay = rpd,
            TokensPerDay = tokensPerDay,
            MaxTokens = maxTokens,
            Temperature = temperature,
            KernelFactory = async (opts, _) =>
            {
                HttpClient httpClient = await httpClientCache.Get($"ollama:{modelId}", () => new HttpClientOptions
                {
                    Timeout = TimeSpan.FromSeconds(600),
                    BaseAddress = opts.Endpoint
                }, cancellationToken);

#pragma warning disable SKEXP0070
                return Kernel.CreateBuilder().AddOllamaChatCompletion(modelId: opts.ModelId!, httpClient);
#pragma warning restore SKEXP0070
            }
        };

        var rateLimiter = new KernelRateLimiter(rps, rpm, rpd);

        var entry = new KernelPoolEntry {Key = key, Options = options, RateLimiter = rateLimiter};

        await pool.Register(key, entry, cancellationToken).NoSync();
    }

    public static async ValueTask UnregisterOllama(this KernelPoolManager pool, string key, IHttpClientCache httpClientCache, ISemanticKernelCache kernelCache,
        CancellationToken cancellationToken = default)
    {
        await pool.Unregister(key, cancellationToken);
        await httpClientCache.Remove($"ollama:{key}").NoSync();
        await kernelCache.Remove(key).NoSync();
    }
}