using System;
using NationBuilderConnect.Utilities;
using NationBuilderConnect.Utilities.Auth;

namespace NationBuilderConnect
{
    /// <summary>
    ///     Static class that allows you to get/set information about the client
    /// </summary>
    public static class Connect
    {
        /// <summary>
        ///     Whether or not the client has been initialized
        /// </summary>
        public static bool IsInitialized { get; private set; }

        /// <summary>
        ///     The default options that are used for each request if they are not overridden when the service instance is created
        /// </summary>
        internal static RequestOptions DefaultRequestOptions { get; private set; }

        /// <summary>
        ///     The URL provider that is used for each request
        /// </summary>
        internal static IUrlProvider UrlProvider { get; private set; }

        /// <summary>
        ///     Initializes the client
        /// </summary>
        /// <param name="action">The configuration action</param>
        public static void Initialize(Action<IClientConfiguration> action)
        {
            var clientConfiguration = new ClientConfiguration();

            action?.Invoke(clientConfiguration);

            DefaultRequestOptions = clientConfiguration.RequestOptions;

            UrlProvider = clientConfiguration.UrlProvider ?? new UrlProvider();

            IsInitialized = true;
        }

        /// <summary>
        ///     Updates the credential used by default for each request if not overridden when the service instance is created
        /// </summary>
        /// <param name="credentials">The default credentials to use</param>
        public static void UpdateDefaultCredentials(ICredentials credentials)
        {
            if (!IsInitialized) throw new InvalidOperationException("Must first call Initialize()");
            DefaultRequestOptions.Credentials = credentials;
        }
    }
}