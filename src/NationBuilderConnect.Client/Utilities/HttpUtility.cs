using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NationBuilderConnect.Client.Model;

namespace NationBuilderConnect.Client.Utilities
{
    /// <summary>
    ///     Utility methods used for HTTP requests
    /// </summary>
    public static class HttpUtility
    {
        /// <summary>
        ///     Adds a query string value to an existing URI
        /// </summary>
        /// <param name="uri">The URI to add the value to</param>
        /// <param name="key">The query string value key</param>
        /// <param name="value">The query string value</param>
        /// <returns>The updated URI</returns>
        public static string AddQueryStringValueToUri(string uri, string key, string value)
        {
            if (string.IsNullOrWhiteSpace(uri)) return null;
            var parts = uri.Split('?');
            if (parts.Length > 2) throw new InvalidOperationException("Invalid URI");

            var path = parts[0];
            var queryString = parts.Length == 2 ? parts[1] : "";

            var queryValues = ParseQueryString(queryString);
            queryValues.Add(key, value);

            return string.Concat(path, "?", queryValues.ToString());
        }

        /// <summary>
        ///     Gets the query string pprtion of the URI without the question mark
        /// </summary>
        /// <param name="uri">The URI</param>
        /// <returns>The query string portion of the URI</returns>
        public static string GetQueryString(string uri)
        {
            var parts = uri.Split('?');
            if (parts.Length > 2) throw new InvalidOperationException("Invalid URI");
            return parts.Length == 2 ? parts[1] : string.Empty;
        }

        /// <summary>
        ///     Parses the query string of the URI
        /// </summary>
        /// <param name="query">The query string to parse</param>
        /// <returns>The parsed query string values</returns>
        public static QueryStringValues ParseQueryString(string query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            return new QueryStringValues(query);
        }
    }

    /// <summary>
    ///     A value in a query string
    /// </summary>
    public sealed class QueryStringValue
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="QueryStringValue" /> class
        /// </summary>
        /// <param name="key">The key for the value</param>
        /// <param name="value">The value</param>
        public QueryStringValue(string key, string value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        ///     The key for the value
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        ///     The value
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    ///     A collection of query string values
    /// </summary>
    public class QueryStringValues : Collection<QueryStringValue>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="QueryStringValues" /> class
        /// </summary>
        /// <param name="query">The query string to initialize the collection with</param>
        public QueryStringValues(string query = null)
        {
            FillFromString(query);
        }

        /// <summary>
        ///     Gets the string value associated with the key
        /// </summary>
        /// <param name="key">The key for the value</param>
        /// <returns>The value as a string</returns>
        public string this[string key]
        {
            get { return this.First(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).Value; }
            set { this.First(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).Value = value; }
        }

        private void FillFromString(string query)
        {
            if (string.IsNullOrEmpty(query)) return;
            if (query.StartsWith("?")) query = query.Substring(1);

            var groups = query.Split('&');

            foreach (var parts in groups.Where(g => !string.IsNullOrWhiteSpace(g)).Select(@group => @group.Split('=')))
            {
                if (parts.Length != 2) throw new InvalidOperationException("Invalid query string");
                Add(Uri.UnescapeDataString(parts[0]), Uri.UnescapeDataString(parts[1]));
            }
        }

        /// <summary>
        ///     Adds a value to the collection
        /// </summary>
        /// <param name="key">The key to add</param>
        /// <param name="value">The value to add</param>
        /// <returns>The updated collection</returns>
        public QueryStringValues Add(string key, string value)
        {
            Add(new QueryStringValue(key, value));
            return this;
        }

        /// <summary>
        ///     Adds a value to the collection if the value isn't null or empty
        /// </summary>
        /// <param name="key">The key to add</param>
        /// <param name="value">The value to add</param>
        /// <returns>The updated collection</returns>
        public QueryStringValues AddIfValueNotNullOrEmpty(string key, string value)
        {
            if (string.IsNullOrEmpty(value)) return this;
            Add(new QueryStringValue(key, value));
            return this;
        }

        /// <summary>
        ///     Adds paging tokens to the collection
        /// </summary>
        /// <param name="pagingTokens">The paging tokens</param>
        /// <returns>The updated collection</returns>
        public QueryStringValues AddPagingTokens(PagingTokens pagingTokens)
        {
            if (pagingTokens == null) return this;
            Add("__nonce", pagingTokens.Nonce);
            Add("__token", pagingTokens.Token);
            return this;
        }

        /// <inheritDoc />
        public override string ToString()
        {
            return ToString(false);
        }

        /// <summary>
        ///     Converts the collection to a query string
        /// </summary>
        /// <param name="addQuestionMarkIfAnyValues">
        ///     Whether to add a question mark to the start if there are any values in the
        ///     collection
        /// </param>
        /// <param name="excludeKeys">Any keys to exclude from the string represenation</param>
        /// <returns>The query string</returns>
        public virtual string ToString(bool addQuestionMarkIfAnyValues, IDictionary excludeKeys = null)
        {
            if (Count == 0) return string.Empty;

            excludeKeys = excludeKeys ?? new Dictionary<string, string>();

            var builder = new StringBuilder();

            if (addQuestionMarkIfAnyValues) builder.Append("?");

            foreach (var item in this.Where(i => !string.IsNullOrWhiteSpace(i.Key) && !excludeKeys.Contains(i.Key)))
            {
                var key = Uri.EscapeDataString(item.Key);
                var value = Uri.EscapeDataString(item.Value ?? "");

                if (builder.Length > 0)
                    builder.Append('&');

                builder.Append(key).Append("=").Append(value);
            }

            return builder.ToString();
        }
    }
}