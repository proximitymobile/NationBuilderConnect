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
using System.Threading;
using System.Threading.Tasks;

namespace NationBuilderConnect.Utilities.Cursors
{
    public abstract class AsyncCursor<TDocument> : IAsyncCursor<TDocument>
    {
        private bool _isDisposed;

        protected abstract TDocument CurrentProtected { get; }

        public bool MoveNext(CancellationToken cancellationToken = default(CancellationToken))
        {
            ThrowIfDisposed();
            HasBeenUsed = true;
            return MoveNextProtected(cancellationToken);
        }

        public Task<bool> MoveNextAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ThrowIfDisposed();
            HasBeenUsed = true;
            return MoveNextProtectedAsync(cancellationToken);
        }

        public bool HasBeenUsed { get; private set; }

        public TDocument Current
        {
            get
            {
                ThrowIfDisposed();
                return CurrentProtected;
            }
        }

        public virtual void Dispose()
        {
            _isDisposed = true;
        }

        protected abstract bool MoveNextProtected(CancellationToken cancellationToken = default(CancellationToken));

        protected abstract Task<bool> MoveNextProtectedAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        private void ThrowIfDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
    }
}