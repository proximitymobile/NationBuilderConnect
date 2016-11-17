using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NationBuilderConnect.Client.Utilities.Auth;
using NationBuilderConnect.Client.Utilities.Extensions;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Utilities
{
    public abstract class NationBuilderService : IDisposable
    {
        private static readonly JsonSerializerSettings DefaultSerializerSettings = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            Formatting = Formatting.None,
            TypeNameHandling = TypeNameHandling.None
        };

        protected NationBuilderService(RequestOptions options)
        {
            EnsureInitialized();
            Options = RequestOptions.Combine(Connect.DefaultRequestOptions, options);
            Client = GetHttpClient();
        }

        protected HttpClient Client { get; }
        protected RequestOptions Options { get; }
        protected IUrlProvider UrlProvider => Connect.UrlProvider;

        public void Dispose()
        {
            Client?.Dispose();
        }

        protected virtual Task<ApiResponse> PostJsonAsync(string endpoint, object content,
            CancellationToken cancellationToken = default(CancellationToken),
            bool isContentAlreadyJson = false)
        {
            return SendJsonNoResponseAsync(endpoint, HttpMethod.Post, content, cancellationToken, isContentAlreadyJson,
                true);
        }

        protected virtual ApiResponse PostJson(string endpoint, object content,
            CancellationToken cancellationToken = default(CancellationToken),
            bool isContentAlreadyJson = false)
        {
            return
                SendJsonNoResponseAsync(endpoint, HttpMethod.Post, content, cancellationToken, isContentAlreadyJson,
                    true).Result;
        }

        protected virtual Task<ApiResponse<TResponse>> PostJsonAsync<TResponse>(string endpoint, object content,
            CancellationToken cancellationToken = default(CancellationToken), bool isContentAlreadyJson = false) where TResponse : class
        {
            return SendJsonAsync<TResponse>(endpoint, HttpMethod.Post, content, cancellationToken, isContentAlreadyJson, true);
        }

        protected virtual ApiResponse<TResponse> PostJson<TResponse>(string endpoint, object content,
            CancellationToken cancellationToken = default(CancellationToken), bool isContentAlreadyJson = false) where TResponse : class
        {
            return SendJsonAsync<TResponse>(endpoint, HttpMethod.Post, content, cancellationToken, isContentAlreadyJson, true).Result;
        }

        protected virtual Task<ApiResponse<TResponse>> DeleteJsonAsync<TResponse>(string endpoint,
            CancellationToken cancellationToken = default(CancellationToken), bool throwOnFailureCodes = true,
            object content = null)
            where TResponse : class
        {
            return SendJsonAsync<TResponse>(endpoint, HttpMethod.Delete, content, cancellationToken, false,
                throwOnFailureCodes);
        }

        protected virtual ApiResponse<TResponse> DeleteJson<TResponse>(string endpoint,
            CancellationToken cancellationToken = default(CancellationToken), bool throwOnFailureCodes = true,
            object content = null)
            where TResponse : class
        {
            return
                SendJsonAsync<TResponse>(endpoint, HttpMethod.Delete, content, cancellationToken, false,
                    throwOnFailureCodes).Result;
        }

        protected virtual Task<ApiResponse> DeleteJsonAsync(string endpoint,
            CancellationToken cancellationToken = default(CancellationToken), bool throwOnFailureCodes = true,
            object content = null)
        {
            return SendJsonNoResponseAsync(endpoint, HttpMethod.Delete, content, cancellationToken, false,
                throwOnFailureCodes);
        }

        protected virtual ApiResponse DeleteJson(string endpoint,
            CancellationToken cancellationToken = default(CancellationToken), bool throwOnFailureCodes = true, 
            object content = null)
        {
            return
                SendJsonNoResponseAsync(endpoint, HttpMethod.Delete, content, cancellationToken, false, throwOnFailureCodes)
                    .Result;
        }

        protected virtual Task<ApiResponse> PutJsonAsync(string endpoint, object content,
            CancellationToken cancellationToken = default(CancellationToken),
            bool isContentAlreadyJson = false)
        {
            return SendJsonNoResponseAsync(endpoint, HttpMethod.Put, content, cancellationToken, isContentAlreadyJson,
                true);
        }

        protected virtual ApiResponse PutJson(string endpoint, object content,
            CancellationToken cancellationToken = default(CancellationToken),
            bool isContentAlreadyJson = false)
        {
            return
                SendJsonNoResponseAsync(endpoint, HttpMethod.Put, content, cancellationToken, isContentAlreadyJson, true)
                    .Result;
        }

        protected virtual Task<ApiResponse<TResponse>> PutJsonAsync<TResponse>(string endpoint, object content,
            CancellationToken cancellationToken = default(CancellationToken),
            bool isContentAlreadyJson = false) where TResponse : class
        {
            return SendJsonAsync<TResponse>(endpoint, HttpMethod.Put, content, cancellationToken,
                isContentAlreadyJson, true);
        }

        protected virtual ApiResponse<TResponse> PutJson<TResponse>(string endpoint, object content,
            CancellationToken cancellationToken = default(CancellationToken),
            bool isContentAlreadyJson = false) where TResponse : class
        {
            return SendJsonAsync<TResponse>(endpoint, HttpMethod.Put, content, cancellationToken,
                isContentAlreadyJson, true).Result;
        }

        protected virtual Task<ApiResponse<TResponse>> GetJsonAsync<TResponse>(string endpoint,
            CancellationToken cancellationToken = default(CancellationToken),
            bool throwOnFailureCodes = true) where TResponse : class
        {
            return SendJsonAsync<TResponse>(endpoint, HttpMethod.Get, null, cancellationToken, false,
                throwOnFailureCodes);
        }

        protected virtual ApiResponse<TResponse> GetJson<TResponse>(string endpoint,
            CancellationToken cancellationToken = default(CancellationToken),
            bool throwOnFailureCodes = true) where TResponse : class
        {
            return
                SendJsonAsync<TResponse>(endpoint, HttpMethod.Get, null, cancellationToken, false, throwOnFailureCodes)
                    .Result;
        }

        protected virtual string AddCredentialsToUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new InvalidOperationException("Endpoint is null or empty");

            string token = null;

            var credentials = Options.Credentials;

            var simple = credentials as SimpleApiTokenCredentials;
            if (simple != null) token = simple.Token;
            var oauth = credentials as OAuthCredentials;
            if (oauth != null) token = oauth.Token;

            if (string.IsNullOrWhiteSpace(token)) throw new InvalidOperationException("Invalid credentials");

            return HttpUtility.AddQueryStringValueToUri(url, "access_token", token);
        }

        private async Task<ApiResponse<TResponse>> SendJsonAsync<TResponse>(string partialEndpoint, HttpMethod method,
            object content, CancellationToken cancellationToken, bool isContentAlreadyJson, bool throwOnFailureCodes,
            bool isNoResponse = false) where TResponse : class
        {
            var endpoint = AddCredentialsToUrl(partialEndpoint);
            endpoint = GetFullEndpointUrl(Options, endpoint);

            var useFakeDelete = method == HttpMethod.Delete && content != null;

            var request = new HttpRequestMessage
            {
                Content = GetJsonContent(content, isContentAlreadyJson),
                Method = useFakeDelete ? HttpMethod.Post : method,
                RequestUri = new Uri(endpoint)
            };

            if (useFakeDelete)
            {
                request.Headers.Add("X-HTTP-Method-Override", "DELETE");
            }

            var response = await Client.SendAsync(request, cancellationToken);

            var rateLimit = ApiRateLimitDetails.CreateFromResponse(response);

            if (!response.IsSuccessStatusCode && !throwOnFailureCodes)
                return new ApiResponse<TResponse>(response.StatusCode, rateLimit, null,
                    await GetErrorResponseAsync(response));

            await ThrowIfApiFailAsync(response);

            // If we can ignore the response, just return without it
            if (isNoResponse) return new ApiResponse<TResponse>(response.StatusCode, rateLimit, null);

            var resultJson = await response.Content.ReadAsStringAsync();
            var resultObject = JsonConvert.DeserializeObject<TResponse>(resultJson);
            return new ApiResponse<TResponse>(response.StatusCode, rateLimit, resultObject);
        }

        private async Task<ApiResponse> SendJsonNoResponseAsync(string partialEndpoint, HttpMethod method,
            object content,
            CancellationToken cancellationToken, bool isContentAlreadyJson, bool throwOnFailureCodes)
        {
            var result =
                await SendJsonAsync<object>(partialEndpoint, method, content, cancellationToken, isContentAlreadyJson,
                    throwOnFailureCodes, true);
            return result;
        }

        private static void EnsureInitialized()
        {
            if (!Connect.IsInitialized)
                throw new InvalidOperationException(
                    "NationBuilderClient must be initialized (NationBuilderClient.Initialize()).");
        }

        private static string GetFullEndpointUrl(RequestOptions options, string endpoint)
        {
            if (string.IsNullOrWhiteSpace(options.NationSlug))
                throw new InvalidOperationException("NationSlug must be set.");
            if (string.IsNullOrWhiteSpace(endpoint))
                throw new InvalidOperationException("Endpoint must be set.");

            var baseUrl = Connect.UrlProvider.GetNationRootUrl(options.NationSlug);

            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new InvalidOperationException("No root nation address specified.");

            if (!baseUrl.EndsWith("/")) baseUrl += "/";

            endpoint = endpoint.TrimStart('/');

            return baseUrl + endpoint;
        }

        protected virtual HttpClient GetHttpClient()
        {
            var client = new HttpClient
            {
                Timeout = Options.Timeout.Value
            };
 
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        protected virtual HttpContent GetJsonContent(object content, bool isContentAlreadyJson)
        {
            if (content == null) return null;

            var json = !isContentAlreadyJson
                ? JsonConvert.SerializeObject(content, DefaultSerializerSettings)
                : (string) content;

            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private async Task ThrowIfApiFailAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) return;
            var errorDetails = await GetErrorResponseAsync(response);
            throw new ApiCallFailedException(new ApiResponse(response.StatusCode,
                ApiRateLimitDetails.CreateFromResponse(response), errorDetails));
        }

        protected static void ThrowIfApiFail(ApiResponse response, bool throwIfNotFound)
        {
            if (response.HttpStatusCode.IsSuccess()) return;
            if (!throwIfNotFound && response.HttpStatusCode == HttpStatusCode.NotFound) return;
            throw new ApiCallFailedException(response);
        }

        protected virtual async Task<ApiErrorDetails> GetErrorResponseAsync(HttpResponseMessage response)
        {
            return GetErrorResponse(await response.Content.ReadAsStringAsync());
        }

        protected virtual ApiErrorDetails GetErrorResponse(HttpResponseMessage response)
        {
            return GetErrorResponse(response.Content.ReadAsStringAsync().Result);
        }

        protected virtual ApiErrorDetails GetErrorResponse(string response)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApiErrorDetails>(response) ?? new ApiErrorDetails();
            }
            catch
            {
                return new ApiErrorDetails();
            }
        }
    }
}