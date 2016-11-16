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
using NationBuilderConnect.Resources.Entities;

namespace NationBuilderConnect.Utilities.Cursors
{
    public class AsyncPageCursor<TItem> : AsyncCursor<ResultsPage<TItem>>
    {
        public delegate Task<ResultsPage<TItem>> GetPageAsyncDelegate(
            int pageSize, PagingTokens pagingTokens, CancellationToken cancellationToken);

        public delegate ResultsPage<TItem> GetPageDelegate(
            int pageSize, PagingTokens pagingTokens, CancellationToken cancellationToken);

        private readonly GetPageDelegate _getPage;
        private readonly GetPageAsyncDelegate _getPageAsync;
        private readonly int _pageSize;
        private ResultsPage<TItem> _current;
        private PagingTokens _nextPageTokens;
        private int _pageNumber;

        public AsyncPageCursor(GetPageDelegate getPage, GetPageAsyncDelegate getPageAsync, int pageSize)
        {
            if (getPage == null) throw new ArgumentNullException(nameof(getPage));
            if (getPageAsync == null) throw new ArgumentNullException(nameof(getPageAsync));
            _getPage = getPage;
            _getPageAsync = getPageAsync;
            _pageSize = pageSize;
        }

        protected override ResultsPage<TItem> CurrentProtected => _current;

        protected override bool MoveNextProtected(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_pageNumber > 0 && _nextPageTokens == null) return false;
            var result = _getPage(_pageSize, _nextPageTokens, cancellationToken);
            return HandleResults(result);
        }

        protected override async Task<bool> MoveNextProtectedAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_pageNumber > 0 && _nextPageTokens == null) return false;
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

            _nextPageTokens = result.GetNextPagingValues();

            _current = result;

            return true;
        }
    }
}