using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NationBuilderConnect.Client.Model;
using NationBuilderConnect.Client.Utilities;
using NationBuilderConnect.Client.Utilities.Auth;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Services
{
    /// <summary>
    ///     Base class for all NationBuilder API services
    /// </summary>
    public abstract class NationBuilderApiService : IDisposable
    {
        private static readonly JsonSerializerSettings DefaultSerializerSettings = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            Formatting = Formatting.None,
            TypeNameHandling = TypeNameHandling.None
        };

        /// <summary>
        ///     Initializes a new instance of the <see cref="NationBuilderApiService" /> class
        /// </summary>
        /// <param name="options">
        ///     Options to use for each request issued from this instance of the service. Overrides default
        ///     values provided while initializing the client.
        /// </param>
        protected NationBuilderApiService(RequestOptions options)
        {
            EnsureInitialized();
            Options = RequestOptions.Combine(ConnectClient.DefaultRequestOptions, options);
            // ReSharper disable once VirtualMemberCallInContructor
            Client = GetHttpClient();
        }

        /// <summary>
        ///     The client used to make HTTP requests
        /// </summary>
        private HttpClient Client { get; }

        /// <summary>
        ///     Options to use for each request issued from this instance of the service. Overrides default
        ///     values provided while initializing the client.
        /// </summary>
        private RequestOptions Options { get; }

        /// <summary>
        ///     The provider of the URLs used for API requests
        /// </summary>
        protected static IUrlProvider UrlProvider => ConnectClient.UrlProvider;

        /// <inheritDoc />
        public void Dispose()
        {
            Client?.Dispose();
        }

        /// <summary>
        ///     Gets the page size for the results from the server. Will either use explicit value passed in or default from
        ///     request options.
        /// </summary>
        /// <param name="explicitPageSize">The explicit value to use. If null the default from the request options will be used</param>
        /// <returns>The number of results to return per page of results</returns>
        protected short GetPageSize(short? explicitPageSize)
        {
            return explicitPageSize ?? Options?.ResultsPageSize ?? 20;
        }

        /// <summary>
        ///     Makes an HTTP POST request with a JSON body asyncronously
        /// </summary>
        /// <param name="relativeUrl">
        ///     The URL to the endpoint, relative to the base nation URL
        ///     (https://{nationSlug}.nationbuilder.com)
        /// </param>
        /// <param name="content">The content for the body of the request</param>
        /// <param name="cancellationToken">Token allowing request to be cancelled</param>
        /// <param name="isContentAlreadyJson">Whether or not the content has already been serialized to JSON</param>
        /// <returns>Details about the response from the API</returns>
        protected virtual Task<ApiResponse> PostJsonAsync(string relativeUrl, object content,
            CancellationToken cancellationToken = default(CancellationToken),
            bool isContentAlreadyJson = false)
        {
            return SendJsonNoResponseAsync(relativeUrl, HttpMethod.Post, content, cancellationToken,
                isContentAlreadyJson,
                true);
        }

        /// <summary>
        ///     Makes an HTTP POST request with a JSON body syncronously
        /// </summary>
        /// <param name="relativeUrl">
        ///     The URL to the endpoint, relative to the base nation URL
        ///     (https://{nationSlug}.nationbuilder.com)
        /// </param>
        /// <param name="content">The content for the body of the request</param>
        /// <param name="cancellationToken">Token allowing request to be cancelled</param>
        /// <param name="isContentAlreadyJson">Whether or not the content has already been serialized to JSON</param>
        /// <returns>Details about the response from the API</returns>
        protected virtual ApiResponse PostJson(string relativeUrl, object content,
            CancellationToken cancellationToken = default(CancellationToken),
            bool isContentAlreadyJson = false)
        {
            return
                SendJsonNoResponseAsync(relativeUrl, HttpMethod.Post, content, cancellationToken, isContentAlreadyJson,
                    true).Result;
        }

        /// <summary>
        ///     Makes an HTTP POST request with a JSON body asyncronously, with JSON content returned
        /// </summary>
        /// <typeparam name="TResponse">The response content type</typeparam>
        /// <param name="relativeUrl">
        ///     The URL to the endpoint, relative to the base nation URL
        ///     (https://{nationSlug}.nationbuilder.com)
        /// </param>
        /// <param name="content">The content for the body of the request</param>
        /// <param name="cancellationToken">Token allowing request to be cancelled</param>
        /// <param name="isContentAlreadyJson">Whether or not the content has already been serialized to JSON</param>
        /// <returns>Details about the response from the API</returns>
        protected virtual Task<ApiResponse<TResponse>> PostJsonAsync<TResponse>(string relativeUrl, object content,
            CancellationToken cancellationToken = default(CancellationToken), bool isContentAlreadyJson = false)
            where TResponse : class
        {
            return SendJsonAsync<TResponse>(relativeUrl, HttpMethod.Post, content, cancellationToken,
                isContentAlreadyJson, true);
        }

        /// <summary>
        ///     Makes an HTTP POST request with a JSON body syncronously, with JSON content returned
        /// </summary>
        /// <typeparam name="TResponse">The response content type</typeparam>
        /// <param name="relativeUrl">
        ///     The URL to the endpoint, relative to the base nation URL
        ///     (https://{nationSlug}.nationbuilder.com)
        /// </param>
        /// <param name="content">The content for the body of the request</param>
        /// <param name="cancellationToken">Token allowing request to be cancelled</param>
        /// <param name="isContentAlreadyJson">Whether or not the content has already been serialized to JSON</param>
        /// <returns>Details about the response from the API</returns>
        protected virtual ApiResponse<TResponse> PostJson<TResponse>(string relativeUrl, object content,
            CancellationToken cancellationToken = default(CancellationToken), bool isContentAlreadyJson = false)
            where TResponse : class
        {
            return
                SendJsonAsync<TResponse>(relativeUrl, HttpMethod.Post, content, cancellationToken, isContentAlreadyJson,
                    true).Result;
        }

        /// <summary>
        ///     Makes an HTTP DELETE request with a JSON body asyncronously, with JSON content returned
        /// </summary>
        /// <typeparam name="TResponse">The response content type</typeparam>
        /// <param name="relativeUrl">
        ///     The URL to the endpoint, relative to the base nation URL
        ///     (https://{nationSlug}.nationbuilder.com)
        /// </param>
        /// <param name="throwOnFailureCodes">Whether to throw an exception if a failure response is returned from the server</param>
        /// <param name="content">The content for the body of the request</param>
        /// <param name="cancellationToken">Token allowing request to be cancelled</param>
        /// <returns>Details about the response from the API</returns>
        protected virtual Task<ApiResponse<TResponse>> DeleteJsonAsync<TResponse>(string relativeUrl,
            CancellationToken cancellationToken = default(CancellationToken), bool throwOnFailureCodes = true,
            object content = null)
            where TResponse : class
        {
            return SendJsonAsync<TResponse>(relativeUrl, HttpMethod.Delete, content, cancellationToken, false,
                throwOnFailureCodes);
        }

        /// <summary>
        ///     Makes an HTTP DELETE request with a JSON body syncronously, with JSON content returned
        /// </summary>
        /// <typeparam name="TResponse">The response content type</typeparam>
        /// <param name="relativeUrl">
        ///     The URL to the endpoint, relative to the base nation URL
        ///     (https://{nationSlug}.nationbuilder.com)
        /// </param>
        /// <param name="throwOnFailureCodes">Whether to throw an exception if a failure response is returned from the server</param>
        /// <param name="content">The content for the body of the request</param>
        /// <param name="cancellationToken">Token allowing request to be cancelled</param>
        /// <returns>Details about the response from the API</returns>
        protected virtual ApiResponse<TResponse> DeleteJson<TResponse>(string relativeUrl,
            CancellationToken cancellationToken = default(CancellationToken), bool throwOnFailureCodes = true,
            object content = null)
            where TResponse : class
        {
            return
                SendJsonAsync<TResponse>(relativeUrl, HttpMethod.Delete, content, cancellationToken, false,
                    throwOnFailureCodes).Result;
        }

        /// <summary>
        ///     Makes an HTTP DELETE request with a JSON body asyncronously
        /// </summary>
        /// <param name="relativeUrl">
        ///     The URL to the endpoint, relative to the base nation URL
        ///     (https://{nationSlug}.nationbuilder.com)
        /// </param>
        /// <param name="throwOnFailureCodes">Whether to throw an exception if a failure response is returned from the server</param>
        /// <param name="content">The content for the body of the request</param>
        /// <param name="cancellationToken">Token allowing request to be cancelled</param>
        /// <returns>Details about the response from the API</returns>
        protected virtual Task<ApiResponse> DeleteJsonAsync(string relativeUrl,
            CancellationToken cancellationToken = default(CancellationToken), bool throwOnFailureCodes = true,
            object content = null)
        {
            return SendJsonNoResponseAsync(relativeUrl, HttpMethod.Delete, content, cancellationToken, false,
                throwOnFailureCodes);
        }

        /// <summary>
        ///     Makes an HTTP DELETE request with a JSON body syncronously
        /// </summary>
        /// <param name="relativeUrl">
        ///     The URL to the endpoint, relative to the base nation URL
        ///     (https://{nationSlug}.nationbuilder.com)
        /// </param>
        /// <param name="throwOnFailureCodes">Whether to throw an exception if a failure response is returned from the server</param>
        /// <param name="content">The content for the body of the request</param>
        /// <param name="cancellationToken">Token allowing request to be cancelled</param>
        /// <returns>Details about the response from the API</returns>
        protected virtual ApiResponse DeleteJson(string relativeUrl,
            CancellationToken cancellationToken = default(CancellationToken), bool throwOnFailureCodes = true,
            object content = null)
        {
            return
                SendJsonNoResponseAsync(relativeUrl, HttpMethod.Delete, content, cancellationToken, false,
                    throwOnFailureCodes)
                    .Result;
        }

        /// <summary>
        ///     Makes an HTTP PUT request with a JSON body asyncronously
        /// </summary>
        /// <param name="relativeUrl">
        ///     The URL to the endpoint, relative to the base nation URL
        ///     (https://{nationSlug}.nationbuilder.com)
        /// </param>
        /// <param name="content">The content for the body of the request</param>
        /// <param name="cancellationToken">Token allowing request to be cancelled</param>
        /// <param name="isContentAlreadyJson">Whether or not the content has already been serialized to JSON</param>
        /// <returns>Details about the response from the API</returns>
        protected virtual Task<ApiResponse> PutJsonAsync(string relativeUrl, object content,
            CancellationToken cancellationToken = default(CancellationToken),
            bool isContentAlreadyJson = false)
        {
            return SendJsonNoResponseAsync(relativeUrl, HttpMethod.Put, content, cancellationToken, isContentAlreadyJson,
                true);
        }

        /// <summary>
        ///     Makes an HTTP PUT request with a JSON body syncronously
        /// </summary>
        /// <param name="relativeUrl">
        ///     The URL to the endpoint, relative to the base nation URL
        ///     (https://{nationSlug}.nationbuilder.com)
        /// </param>
        /// <param name="content">The content for the body of the request</param>
        /// <param name="cancellationToken">Token allowing request to be cancelled</param>
        /// <param name="isContentAlreadyJson">Whether or not the content has already been serialized to JSON</param>
        /// <returns>Details about the response from the API</returns>
        protected virtual ApiResponse PutJson(string relativeUrl, object content,
            CancellationToken cancellationToken = default(CancellationToken),
            bool isContentAlreadyJson = false)
        {
            return
                SendJsonNoResponseAsync(relativeUrl, HttpMethod.Put, content, cancellationToken, isContentAlreadyJson,
                    true)
                    .Result;
        }

        /// <summary>
        ///     Makes an HTTP PUT request with a JSON body asyncronously, with JSON content returned
        /// </summary>
        /// <typeparam name="TResponse">The response content type</typeparam>
        /// <param name="relativeUrl">
        ///     The URL to the endpoint, relative to the base nation URL
        ///     (https://{nationSlug}.nationbuilder.com)
        /// </param>
        /// <param name="content">The content for the body of the request</param>
        /// <param name="cancellationToken">Token allowing request to be cancelled</param>
        /// <param name="isContentAlreadyJson">Whether or not the content has already been serialized to JSON</param>
        /// <returns>Details about the response from the API</returns>
        protected virtual Task<ApiResponse<TResponse>> PutJsonAsync<TResponse>(string relativeUrl, object content,
            CancellationToken cancellationToken = default(CancellationToken),
            bool isContentAlreadyJson = false) where TResponse : class
        {
            return SendJsonAsync<TResponse>(relativeUrl, HttpMethod.Put, content, cancellationToken,
                isContentAlreadyJson, true);
        }

        /// <summary>
        ///     Makes an HTTP PUT request with a JSON body syncronously, with JSON content returned
        /// </summary>
        /// <typeparam name="TResponse">The response content type</typeparam>
        /// <param name="relativeUrl">
        ///     The URL to the endpoint, relative to the base nation URL
        ///     (https://{nationSlug}.nationbuilder.com)
        /// </param>
        /// <param name="content">The content for the body of the request</param>
        /// <param name="cancellationToken">Token allowing request to be cancelled</param>
        /// <param name="isContentAlreadyJson">Whether or not the content has already been serialized to JSON</param>
        /// <returns>Details about the response from the API</returns>
        protected virtual ApiResponse<TResponse> PutJson<TResponse>(string relativeUrl, object content,
            CancellationToken cancellationToken = default(CancellationToken),
            bool isContentAlreadyJson = false) where TResponse : class
        {
            return SendJsonAsync<TResponse>(relativeUrl, HttpMethod.Put, content, cancellationToken,
                isContentAlreadyJson, true).Result;
        }

        /// <summary>
        ///     Makes an HTTP GET request with a JSON body asyncronously, with JSON content returned
        /// </summary>
        /// <typeparam name="TResponse">The response content type</typeparam>
        /// <param name="relativeUrl">
        ///     The URL to the endpoint, relative to the base nation URL
        ///     (https://{nationSlug}.nationbuilder.com)
        /// </param>
        /// <param name="cancellationToken">Token allowing request to be cancelled</param>
        /// <param name="throwOnFailureCodes">Whether to throw an exception if a failure response is returned from the server</param>
        /// <returns>Details about the response from the API</returns>
        protected virtual Task<ApiResponse<TResponse>> GetJsonAsync<TResponse>(string relativeUrl,
            CancellationToken cancellationToken = default(CancellationToken),
            bool throwOnFailureCodes = true) where TResponse : class
        {
            return SendJsonAsync<TResponse>(relativeUrl, HttpMethod.Get, null, cancellationToken, false,
                throwOnFailureCodes);
        }

        /// <summary>
        ///     Makes an HTTP GET request with a JSON body syncronously, with JSON content returned
        /// </summary>
        /// <typeparam name="TResponse">The response content type</typeparam>
        /// <param name="relativeUrl">
        ///     The URL to the endpoint, relative to the base nation URL
        ///     (https://{nationSlug}.nationbuilder.com)
        /// </param>
        /// <param name="cancellationToken">Token allowing request to be cancelled</param>
        /// <param name="throwOnFailureCodes">Whether to throw an exception if a failure response is returned from the server</param>
        /// <returns>Details about the response from the API</returns>
        protected virtual ApiResponse<TResponse> GetJson<TResponse>(string relativeUrl,
            CancellationToken cancellationToken = default(CancellationToken),
            bool throwOnFailureCodes = true) where TResponse : class
        {
            return
                SendJsonAsync<TResponse>(relativeUrl, HttpMethod.Get, null, cancellationToken, false,
                    throwOnFailureCodes)
                    .Result;
        }

        /// <summary>
        ///     Adds our credentials to the URL
        /// </summary>
        /// <param name="url">The URL to add to</param>
        /// <returns>The updated URL</returns>
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

        /// <summary>
        ///     Sends the HTTP request to the server
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="relativeUrl">
        ///     The URL to the endpoint, relative to the base nation URL
        ///     (https://{nationSlug}.nationbuilder.com)
        /// </param>
        /// <param name="method">The HTTP method (verb) to use for the request</param>
        /// <param name="content">The content for the body of the request</param>
        /// <param name="cancellationToken">Token allowing request to be cancelled</param>
        /// <param name="isContentAlreadyJson">Whether or not the content has already been serialized to JSON</param>
        /// <param name="throwOnFailureCodes">Whether to throw an exception if a failure response is returned from the server</param>
        /// <param name="isNoResponse">Whether we can ignore the response body</param>
        /// <returns>Details about the response from the API</returns>
        private async Task<ApiResponse<TResponse>> SendJsonAsync<TResponse>(string relativeUrl, HttpMethod method,
            object content, CancellationToken cancellationToken, bool isContentAlreadyJson, bool throwOnFailureCodes,
            bool isNoResponse = false) where TResponse : class
        {
            var endpoint = AddCredentialsToUrl(relativeUrl);
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
            if (!ConnectClient.IsInitialized)
                throw new InvalidOperationException(
                    "NationBuilderClient must be initialized (NationBuilderClient.Initialize()).");
        }

        private static string GetFullEndpointUrl(RequestOptions options, string endpoint)
        {
            if (string.IsNullOrWhiteSpace(options.NationSlug))
                throw new InvalidOperationException("NationSlug must be set.");
            if (string.IsNullOrWhiteSpace(endpoint))
                throw new InvalidOperationException("Endpoint must be set.");

            var baseUrl = ConnectClient.UrlProvider.GetNationRootUrl(options.NationSlug);

            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new InvalidOperationException("No root nation address specified.");

            if (!baseUrl.EndsWith("/")) baseUrl += "/";

            endpoint = endpoint.TrimStart('/');

            return baseUrl + endpoint;
        }

        /// <summary>
        ///     Gets the client to use to send HTTP requests
        /// </summary>
        /// <returns></returns>
        private HttpClient GetHttpClient()
        {
            var client = new HttpClient
            {
                // This will always have a value
                // ReSharper disable once PossibleInvalidOperationException
                Timeout = Options.Timeout.Value
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        /// <summary>
        ///     Gets the JSON content for a request
        /// </summary>
        /// <param name="content">The initial content</param>
        /// <param name="isContentAlreadyJson">Whether or not the content has already been serialized to JSON</param>
        /// <returns>The content for the request</returns>
        private static HttpContent GetJsonContent(object content, bool isContentAlreadyJson)
        {
            if (content == null) return null;

            var json = !isContentAlreadyJson
                ? JsonConvert.SerializeObject(content, DefaultSerializerSettings)
                : (string) content;

            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static async Task ThrowIfApiFailAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) return;
            var errorDetails = await GetErrorResponseAsync(response);
            throw new ApiCallFailedException(new ApiResponse(response.StatusCode,
                ApiRateLimitDetails.CreateFromResponse(response), errorDetails));
        }

        /// <summary>
        ///     Throws an exception if there was a failure response from the server
        /// </summary>
        /// <param name="response">The response from the server</param>
        /// <param name="throwIfNotFound">Whether to throw an exception if it is a not found response (404)</param>
        protected static void ThrowIfApiFail(ApiResponse response, bool throwIfNotFound)
        {
            if (response.HttpStatusCode.IsSuccess()) return;
            if (!throwIfNotFound && response.HttpStatusCode == HttpStatusCode.NotFound) return;
            throw new ApiCallFailedException(response);
        }

        private static async Task<ApiErrorDetails> GetErrorResponseAsync(HttpResponseMessage response)
        {
            return GetErrorResponse(await response.Content.ReadAsStringAsync());
        }

        private static ApiErrorDetails GetErrorResponse(string response)
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