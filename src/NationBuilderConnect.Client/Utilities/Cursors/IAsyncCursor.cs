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
using System.Threading;
using System.Threading.Tasks;

namespace NationBuilderConnect.Client.Utilities.Cursors
{
    /// <summary>
    ///     Allows iterating a collection of items asynconously
    /// </summary>
    /// <typeparam name="TItem">The type of element in the collection</typeparam>
    public interface IAsyncCursor<out TItem> : IDisposable
    {
        /// <summary>
        ///     Whether or not any records have been read from this cursor
        /// </summary>
        bool HasBeenUsed { get; }

        /// <summary>
        ///     The current element
        /// </summary>
        TItem Current { get; }

        /// <summary>
        ///     The total number of records to retrieve. If null then all records are retrieved.
        /// </summary>
        int? Limit { get; }

        /// <summary>
        ///     Moves to the next element syncronously
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>Whether any more elements are available</returns>
        bool MoveNext(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Moves to the next element asyncronously
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>Whether any more elements are available</returns>
        Task<bool> MoveNextAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Sets the total number of records to retrieve
        /// </summary>
        /// <param name="limit">The number of records to retrieve</param>
        IAsyncCursor<TItem> SetLimit(int limit);
    }
}