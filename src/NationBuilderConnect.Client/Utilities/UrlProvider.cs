using System;
using System.Collections.Generic;
using System.Linq;
using NationBuilderConnect.Client.Services.Parameters;
using System.Reflection;
using NationBuilderConnect.Client.Model;
using NationBuilderConnect.Model;

namespace NationBuilderConnect.Client.Utilities
{
    /// <inheritDoc/>
    public class UrlProvider : IUrlProvider
    {
        /// <inheritDoc/>
        public virtual string GetV1PersonIndexUrl(short pageSize, PagingTokens pagingTokens)
        {
            var queryValues = CreateQueryStringValues(pageSize, pagingTokens);
            return "api/v1/people" + queryValues.ToString(true);
        }

        /// <inheritDoc/>
        public virtual string GetV1PersonCountUrl()
        {
            return "api/v1/people/count";
        }

        /// <inheritDoc/>
        public string GetV1PersonShowUrl(int personId, PersonIdType idType)
        {
            var queryValues = new QueryStringValues();
            if (idType == PersonIdType.External) queryValues.Add("id_type", "external");
            return $"api/v1/people/{personId}" + queryValues.ToString(true);
        }

        /// <inheritDoc/>
        public string GetV1PersonMatchUrl(MatchPersonParameters personParameters)
        {
            var queryValues = CreateQueryStringValues(parameters: personParameters);
            return "api/v1/people/match" + queryValues.ToString(true);
        }

        /// <inheritDoc/>
        public string GetV1PersonSearchUrl(short pageSize, PagingTokens pagingTokens, SearchPeopleParameters parameters)
        {
            var queryValues = CreateQueryStringValues(pageSize, pagingTokens, parameters);
            PopulateQueryStringWithCustomValues(queryValues, parameters.CustomValues);
            return "api/v1/people/search" + queryValues.ToString(true);
        }

        /// <inheritDoc/>
        public string GetV1PersonNearbyUrl(short pageSize, PagingTokens pagingTokens, GetNearbyPeopleParameters parameters)
        {
            var queryValues = CreateQueryStringValues(pageSize, pagingTokens, parameters);
            return "api/v1/people/nearby" + queryValues.ToString(true);
        }

        /// <inheritDoc/>
        public string GetV1PersonAddTagUrl(int personId)
        {
            return $"api/v1/people/{personId}/taggings";
        }

        /// <inheritDoc/>
        public string GetV1PersonRemoveTagsUrl(int personId)
        {
            return $"api/v1/people/{personId}/taggings";
        }

        /// <inheritDoc/>
        public string GetV1PersonAddPrivateNoteUrl(int personId)
        {
            return $"api/v1/people/{personId}/notes";
        }

        /// <inheritDoc/>
        public string GetV1PersonCreateUrl()
        {
            return "api/v1/people";
        }

        /// <inheritDoc/>
        public string GetV1PersonUpdateUrl(int personId)
        {
            return $"api/v1/people/{personId}";
        }

        /// <inheritDoc/>
        public string GetV1PersonPushUrl()
        {
            return "api/v1/people/push";
        }

        /// <inheritDoc/>
        public string GetV1PersonAddUrl()
        {
            return "api/v1/people/add";
        }

        /// <inheritDoc/>
        public string GetV1PersonDestroyUrl(int personId)
        {
            return $"api/v1/people/{personId}";
        }

        /// <inheritDoc/>
        public string GetV1PersonMeUrl()
        {
            return "api/v1/people/me";
        }

        /// <inheritDoc/>
        public string GetV1ContactCreateUrl(int personId)
        {
            return $"api/v1/people/{personId}/contacts";
        }

        /// <inheritDoc/>
        public string GetV1ContactIndexUrl(int personId, short pageSize, PagingTokens pagingTokens)
        {
            var queryValues = CreateQueryStringValues(pageSize, pagingTokens);
            return $"api/v1/people/{personId}/contacts" + queryValues.ToString(true);
        }

        /// <inheritDoc/>
        public string GetV1ListIndexUrl(short pageSize, PagingTokens pagingTokens)
        {
            var queryValues = CreateQueryStringValues(pageSize, pagingTokens);
            return "api/v1/lists" + queryValues.ToString(true);
        }

        /// <inheritDoc/>
        public string GetV1ListPeopleIndexUrl(int listId, short pageSize, PagingTokens pagingTokens)
        {
            var queryValues = CreateQueryStringValues(pageSize, pagingTokens);
            return $"api/v1/lists/{listId}/people" + queryValues.ToString(true);
        }

        /// <inheritDoc/>
        public string GetV1ListCreateUrl()
        {
            return "api/v1/lists";
        }

        /// <inheritDoc/>
        public string GetV1ListUpdateUrl(int listId)
        {
            return $"api/v1/lists/{listId}";
        }

        /// <inheritDoc/>
        public string GetV1ListDeleteUrl(int listId)
        {
            return $"api/v1/lists/{listId}";
        }

        /// <inheritDoc/>
        public string GetV1ListAddPeopleUrl(int listId)
        {
            return $"api/v1/lists/{listId}/people";
        }

        /// <inheritDoc/>
        public string GetV1ListRemovePeopleUrl(int listId)
        {
            return $"api/v1/lists/{listId}/people";
        }

        /// <inheritDoc/>
        public string GetV1ListAddTagUrl(int listId, string tagName)
        {
            return $"api/v1/lists/{listId}/tag/" + Uri.EscapeDataString(tagName);
        }

        /// <inheritDoc/>
        public string GetV1ListRemoveTagUrl(int listId, string tagName)
        {
            return $"api/v1/lists/{listId}/tag/" + Uri.EscapeDataString(tagName);
        }

        /// <inheritDoc/>
        public string GetV1ExportCreateUrl(int listId)
        {
            return $"api/v1/lists/{listId}/exports";
        }

        /// <inheritDoc/>
        public string GetV1ExportShowUrl(int exportId)
        {
            return $"api/v1/exports/{exportId}";
        }

        /// <inheritDoc/>
        public string GetV1ExportDeleteUrl(int exportId)
        {
            return $"api/v1/exports/{exportId}";
        }

        /// <inheritDoc/>
        public virtual string GetOAuthAuthorizeUrl(string clientId, string redirectUri, string responseType = "code")
        {
            var queryStringValues = new QueryStringValues()
                .Add("response_type", responseType)
                .Add("client_id", clientId)
                .Add("redirect_uri", redirectUri);

            return "oauth/authorize" + queryStringValues.ToString(true);
        }

        /// <inheritDoc/>
        public virtual string GetOAuthTokenUrl()
        {
            return "oauth/token";
        }

        /// <inheritDoc/>
        public virtual string GetNationRootUrl(string nationSlug)
        {
            return $"https://{nationSlug}.nationbuilder.com";
        }

        private static QueryStringValues CreateQueryStringValues(short? pageSize = null,
            PagingTokens pagingTokens = null, object parameters = null)
        {
            var queryValues = new QueryStringValues()
                .Add("limit", pageSize?.ToString())
                .AddPagingTokens(pagingTokens);

            PopulateQueryStringWithParameters(queryValues, parameters);

            return queryValues;
        }

        private static void PopulateQueryStringWithParameters(QueryStringValues queryStringValues, object parameters)
        {
            if (parameters == null) return;

#if NET40
            var properties = parameters.GetType().GetProperties();
#else
            var properties = parameters.GetType().GetTypeInfo().DeclaredProperties;
#endif

            foreach (var property in properties)
            {
                var attribute = property.GetAttribute<QueryStringParameterAttribute>();
                var name = attribute?.Key;
                if (string.IsNullOrWhiteSpace(name)) continue;
                var value = property.GetValue(parameters, null);
                if (value == null) continue;
                var valueText = value.ToString();
                queryStringValues.AddIfValueNotNullOrEmpty(name, valueText);
            }
        }

        private static void PopulateQueryStringWithCustomValues(QueryStringValues queryStringValues, Dictionary<string, string> customValues)
        {
            if (customValues == null) return;

            if (customValues.Any(v => v.Key.Contains("[") || v.Key.Contains("]")))
                throw new InvalidOperationException(
                    "The client does not support custom values with names containing the following chars: []");

            foreach (var customValue in customValues)
            {
                queryStringValues.AddIfValueNotNullOrEmpty($"custom_values[{customValue.Key}]", customValue.Value);
            }
        }
    }
}