﻿/*
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
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace NationBuilderConnect.Client.Utilities.Cursors
{
    internal class AsyncCursorEnumerableAdapter<TDocument> : IEnumerable<TDocument>
    {
        private readonly CancellationToken _cancellationToken;
        private readonly IAsyncCursor<TDocument> _cursor;
        private bool _hasBeenEnumerated;

        public AsyncCursorEnumerableAdapter(IAsyncCursor<TDocument> cursor, CancellationToken cancellationToken)
        {
            if (cursor == null) throw new ArgumentNullException(nameof(cursor));
            _cursor = cursor;
            _cancellationToken = cancellationToken;
        }

        public IEnumerator<TDocument> GetEnumerator()
        {
            if (_hasBeenEnumerated)
            {
                throw new InvalidOperationException("An IAsyncCursor can only be enumerated once.");
            }
            _hasBeenEnumerated = true;
            return new AsyncCursorEnumerator<TDocument>(_cursor, _cancellationToken);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}