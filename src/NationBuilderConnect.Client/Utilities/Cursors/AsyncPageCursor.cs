/*
* A significant portion of this code was taken from the MongoDB C# driver (https://github.com/mongodb/mongo-csharp-driver)
* so I am preserving their copyright notice.
*/

/* Copyright 2013-2015 MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NationBuilderConnect.Client.Model;
using NationBuilderConnect.Model;

namespace NationBuilderConnect.Client.Utilities.Cursors
{
    /// <summary>
    ///     Allows pages of results to be iterated both syncronously and asyncronously
    /// </summary>
    /// <typeparam name="TItem">The type of item in the pages</typeparam>
    public class AsyncPageCursor<TItem> : AsyncCursor<ResultsPage<TItem>>
    {
        /// <summary>
        ///     Delegate for retrieving a page of results asyncronously
        /// </summary>
        /// <param name="pageSize">The number of results to return per page</param>
        /// <param name="pagingTokens">The paging values</param>
        /// <param name="cancellationToken">Token which allows cancelling the operation</param>
        /// <returns>A page of results</returns>
        public delegate Task<ResultsPage<TItem>> GetPageAsyncDelegate(
            short pageSize, PagingTokens pagingTokens, CancellationToken cancellationToken);

        /// <summary>
        ///     Delegate for retrieving a page of results syncronously
        /// </summary>
        /// <param name="pageSize">The number of results to return per page</param>
        /// <param name="pagingTokens">The paging values</param>
        /// <param name="cancellationToken">Token which allows cancelling the operation</param>
        /// <returns>A page of results</returns>
        public delegate ResultsPage<TItem> GetPageDelegate(
            short pageSize, PagingTokens pagingTokens, CancellationToken cancellationToken);

        private readonly GetPageDelegate _getPage;
        private readonly GetPageAsyncDelegate _getPageAsync;
        private ResultsPage<TItem> _current;
        private PagingTokens _nextPageTokens;
        private int _pageNumber;
        private short _pageSize;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AsyncPageCursor&lt;TItem&gt;" /> class
        /// </summary>
        /// <param name="getPage">Method to retrieve a page of results syncronously</param>
        /// <param name="getPageAsync">Method to retrieve a page of results asyncronously</param>
        /// <param name="pageSize">The number of results to return per page</param>
        public AsyncPageCursor(GetPageDelegate getPage, GetPageAsyncDelegate getPageAsync, short pageSize)
        {
            if (getPage == null) throw new ArgumentNullException(nameof(getPage));
            if (getPageAsync == null) throw new ArgumentNullException(nameof(getPageAsync));
            _getPage = getPage;
            _getPageAsync = getPageAsync;
            _pageSize = pageSize;
        }

        /// <inheritDoc />
        protected override ResultsPage<TItem> CurrentProtected => _current;

        private bool IsLimitReachedBeforeMovingNext
        {
            get
            {
                var limit = Limit;
                return limit != null && _pageNumber >= limit.Value;
            }
        }

        /// <inheritDoc />
        protected override bool MoveNextProtected(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_pageNumber > 0 && _nextPageTokens == null) return false;
            if (IsLimitReachedBeforeMovingNext) return false;
            var result = _getPage(_pageSize, _nextPageTokens, cancellationToken);
            return HandleResults(result);
        }

        /// <inheritDoc />
        protected override async Task<bool> MoveNextProtectedAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_pageNumber > 0 && _nextPageTokens == null) return false;
            if (IsLimitReachedBeforeMovingNext) return false;
            var result = await _getPageAsync(_pageSize, _nextPageTokens, cancellationToken);
            return HandleResults(result);
        }

        private bool HandleResults(ResultsPage<TItem> result)
        {
            if (result.Results == null || !result.Results.Any()) return false;

            _pageNumber++;

            var recordNumberStart = (_pageNumber - 1)*_pageSize + 1;
            var recordNumberEnd = recordNumberStart + result.Results.Count - 1;
            result.SetInformationKnownByClient(_pageNumber, recordNumberStart, recordNumberEnd);

            _nextPageTokens = result.GetNextPagingTokens();

            _current = result;

            return true;
        }

        internal void ShrinkForTotalRecordLimitIfNeeded(int totalRecordLimit)
        {
            if (HasBeenUsed) throw new InvalidOperationException("Cursor has already been used");
            if (totalRecordLimit >= _pageSize) return;

            _pageSize = (short) totalRecordLimit;
            Limit = 1;
        }
    }
}