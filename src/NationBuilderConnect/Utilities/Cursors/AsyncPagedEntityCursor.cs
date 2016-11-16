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
    public class AsyncPagedEntityCursor<TItem> : AsyncCursor<TItem>
    {
        private readonly IAsyncCursor<ResultsPage<TItem>> _pageCursor;

        private int _currentEntityIndex = -1;
        private TItem _currentItem;

        public AsyncPagedEntityCursor(IAsyncCursor<ResultsPage<TItem>> pageCursor)
        {
            if (pageCursor == null) throw new ArgumentNullException(nameof(pageCursor));
            _pageCursor = pageCursor;
        }

        protected override TItem CurrentProtected => _currentItem;

        private bool MoveToNextEntityOnCurrentPage()
        {
            if (!_pageCursor.HasBeenUsed || _pageCursor.Current == null ||
                _currentEntityIndex >= _pageCursor.Current.Results.Count - 1)
                return false;

            _currentEntityIndex++;
            _currentItem = _pageCursor.Current.Results[_currentEntityIndex];
            return true;
        }

        protected override bool MoveNextProtected(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (MoveToNextEntityOnCurrentPage()) return true;
            var hasPage = _pageCursor.MoveNext(cancellationToken);
            return hasPage && HandleNewPage(_pageCursor.Current);
        }

        protected override async Task<bool> MoveNextProtectedAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (MoveToNextEntityOnCurrentPage()) return true;
            var hasPage = await _pageCursor.MoveNextAsync(cancellationToken);
            return hasPage && HandleNewPage(_pageCursor.Current);
        }

        private bool HandleNewPage(ResultsPage<TItem> result)
        {
            if (result == null || !result.Results.Any()) return false;

            _currentItem = result.Results.First();
            _currentEntityIndex = 0;

            return true;
        }
    }
}