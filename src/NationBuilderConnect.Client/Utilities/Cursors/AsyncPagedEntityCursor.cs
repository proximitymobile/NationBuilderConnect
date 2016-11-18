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
    ///     Allows a collection of items retrieved in underlying pages to be iterated both syncronously and asyncronously
    /// </summary>
    /// <typeparam name="TItem">The type of item in the pages</typeparam>
    public class AsyncPagedEntityCursor<TItem> : AsyncCursor<TItem>
    {
        private readonly IAsyncCursor<ResultsPage<TItem>> _pageCursor;

        private int _currentEntityIndex = -1;
        private int _currentEntityIndexOnPage = -1;
        private TItem _currentItem;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AsyncPagedEntityCursor&lt;TItem&gt;" /> class.
        /// </summary>
        /// <param name="pageCursor">The cursor to iterate the underlying pages</param>
        public AsyncPagedEntityCursor(IAsyncCursor<ResultsPage<TItem>> pageCursor)
        {
            if (pageCursor == null) throw new ArgumentNullException(nameof(pageCursor));
            _pageCursor = pageCursor;
        }

        /// <inheritDoc />
        protected override TItem CurrentProtected => _currentItem;

        private bool MoveToNextEntityOnCurrentPage()
        {
            if (!_pageCursor.HasBeenUsed || _pageCursor.Current == null ||
                _currentEntityIndexOnPage >= _pageCursor.Current.Results.Count - 1)
                return false;

            _currentEntityIndex++;
            _currentEntityIndexOnPage++;
            _currentItem = _pageCursor.Current.Results[_currentEntityIndexOnPage];
            return true;
        }

        private bool IsLimitReachedBeforeMovingNext
        {
            get
            {
                var limit = Limit;
                return limit != null && _currentEntityIndex + 1 >= limit.Value;
            }
        }

        /// <inheritDoc />
        protected override bool MoveNextProtected(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsLimitReachedBeforeMovingNext) return false;
            if (MoveToNextEntityOnCurrentPage()) return true;
            var hasPage = _pageCursor.MoveNext(cancellationToken);
            return hasPage && HandleNewPage(_pageCursor.Current);
        }

        /// <inheritDoc />
        protected override async Task<bool> MoveNextProtectedAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsLimitReachedBeforeMovingNext) return false;
            if (MoveToNextEntityOnCurrentPage()) return true;
            var hasPage = await _pageCursor.MoveNextAsync(cancellationToken);
            return hasPage && HandleNewPage(_pageCursor.Current);
        }

        private bool HandleNewPage(ResultsPage<TItem> result)
        {
            if (result == null || !result.Results.Any()) return false;

            _currentItem = result.Results.First();
            _currentEntityIndexOnPage = 0;
            _currentEntityIndex++;

            return true;
        }

        /// <inheritDoc />
        public override IAsyncCursor<TItem> SetLimit(int limit)
        {
            // Reduce the size of the underlying pages if the total number of results required is less than
            // the current page size
            (_pageCursor as AsyncPageCursor<TItem>)?.ShrinkForTotalRecordLimitIfNeeded(limit);
            return base.SetLimit(limit);
        }
    }
}