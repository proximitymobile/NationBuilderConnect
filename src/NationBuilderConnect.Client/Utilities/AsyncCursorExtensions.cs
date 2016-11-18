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
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NationBuilderConnect.Client.Utilities.Cursors;

namespace NationBuilderConnect.Client.Utilities
{
    /// <summary>
    ///     Extensions to use when working with AsyncCursor
    /// </summary>
    public static class AsyncCursorExtensions
    {
        /// <summary>
        ///     Determines whether the cursor contains any items.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="cursor">The cursor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>True if the cursor contains any items.</returns>
        public static bool Any<TItem>(this IAsyncCursor<TItem> cursor,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (cursor)
            {
                if (cursor.Limit == null || cursor.Limit > 1) cursor.SetLimit(1);
                return cursor.MoveNext(cancellationToken);
            }
        }

        /// <summary>
        ///     Determines whether the cursor contains any items.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="cursor">The cursor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task whose result is true if the cursor contains any items.</returns>
        public static async Task<bool> AnyAsync<TItem>(this IAsyncCursor<TItem> cursor,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (cursor)
            {
                if (cursor.Limit == null || cursor.Limit > 1) cursor.SetLimit(1);
                return await cursor.MoveNextAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        ///     Returns the first item of a cursor.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="cursor">The cursor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The first item.</returns>
        public static TItem First<TItem>(this IAsyncCursor<TItem> cursor,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (cursor)
            {
                if (cursor.Limit == null || cursor.Limit > 1) cursor.SetLimit(1);
                var items = new List<TItem>();
                if (cursor.MoveNext(cancellationToken)) items.Add(cursor.Current);
                return items.First();
            }
        }

        /// <summary>
        ///     Returns the first item of a cursor.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="cursor">The cursor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task whose result is the first item.</returns>
        public static async Task<TItem> FirstAsync<TItem>(this IAsyncCursor<TItem> cursor,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (cursor)
            {
                if (cursor.Limit == null || cursor.Limit > 1) cursor.SetLimit(1);
                var items = new List<TItem>();
                if (await cursor.MoveNextAsync(cancellationToken).ConfigureAwait(false)) items.Add(cursor.Current);
                return items.First();
            }
        }

        /// <summary>
        ///     Returns the first item of a cursor, or a default value if the cursor contains no items.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="cursor">The cursor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The first item of the cursor, or a default value if the cursor contains no items.</returns>
        public static TItem FirstOrDefault<TItem>(this IAsyncCursor<TItem> cursor,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (cursor)
            {
                if (cursor.Limit == null || cursor.Limit > 1) cursor.SetLimit(1);
                return cursor.MoveNext(cancellationToken) ? cursor.Current : default(TItem);
            }
        }

        /// <summary>
        ///     Returns the first item of the cursor, or a default value if the cursor contains no items.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="cursor">The cursor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task whose result is the first item of the cursor, or a default value if the cursor contains no items.</returns>
        public static async Task<TItem> FirstOrDefaultAsync<TItem>(this IAsyncCursor<TItem> cursor,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (cursor)
            {
                if (cursor.Limit == null || cursor.Limit > 1) cursor.SetLimit(1);
                return await cursor.MoveNextAsync(cancellationToken).ConfigureAwait(false)
                    ? cursor.Current
                    : default(TItem);
            }
        }

        /// <summary>
        ///     Calls a delegate for each item returned by the cursor.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="processor">The processor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that completes when all the items have been processed.</returns>
        public static Task ForEachAsync<TItem>(this IAsyncCursor<TItem> source, Func<TItem, Task> processor,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return ForEachAsync(source, (doc, _) => processor(doc), cancellationToken);
        }

        /// <summary>
        ///     Calls a delegate for each item returned by the cursor.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="processor">The processor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that completes when all the items have been processed.</returns>
        public static async Task ForEachAsync<TItem>(this IAsyncCursor<TItem> source, Func<TItem, int, Task> processor,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (processor == null) throw new ArgumentNullException(nameof(processor));

            // yes, we are taking ownership... assumption being that they've
            // exhausted the thing and don't need it anymore.
            using (source)
            {
                var index = 0;
                while (await source.MoveNextAsync(cancellationToken).ConfigureAwait(false))
                {
                    await processor(source.Current, index++).ConfigureAwait(false);
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }
        }

        /// <summary>
        ///     Calls a delegate for each item returned by the cursor.
        /// </summary>
        /// <remarks>
        ///     If your delegate is going to take a long time to execute or is going to block
        ///     consider using a different overload of ForEachAsync that uses a delegate that
        ///     returns a Task instead.
        /// </remarks>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="processor">The processor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that completes when all the items have been processed.</returns>
        public static Task ForEachAsync<TItem>(this IAsyncCursor<TItem> source, Action<TItem> processor,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return ForEachAsync(source, (doc, _) => processor(doc), cancellationToken);
        }

        /// <summary>
        ///     Calls a delegate for each item returned by the cursor.
        /// </summary>
        /// <remarks>
        ///     If your delegate is going to take a long time to execute or is going to block
        ///     consider using a different overload of ForEachAsync that uses a delegate that
        ///     returns a Task instead.
        /// </remarks>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="processor">The processor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that completes when all the items have been processed.</returns>
        public static async Task ForEachAsync<TItem>(this IAsyncCursor<TItem> source, Action<TItem, int> processor,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (processor == null) throw new ArgumentNullException(nameof(processor));

            using (source)
            {
                var index = 0;
                while (await source.MoveNextAsync(cancellationToken).ConfigureAwait(false))
                {
                    processor(source.Current, index++);
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }
        }

        /// <summary>
        ///     Returns the only item of a cursor. This method throws an exception if the cursor does not contain exactly one item.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="cursor">The cursor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The only item of a cursor.</returns>
        public static TItem Single<TItem>(this IAsyncCursor<TItem> cursor,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (cursor)
            {
                if (cursor.Limit == null || cursor.Limit > 2) cursor.SetLimit(2);

                var items = new List<TItem>();
                if (cursor.MoveNext(cancellationToken)) items.Add(cursor.Current);
                else return items.Single();

                if (cursor.MoveNext(cancellationToken)) items.Add(cursor.Current);
                return items.Single();
            }
        }

        /// <summary>
        ///     Returns the only item of a cursor. This method throws an exception if the cursor does not contain exactly one item.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="cursor">The cursor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task whose result is the only item of a cursor.</returns>
        public static async Task<TItem> SingleAsync<TItem>(this IAsyncCursor<TItem> cursor,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (cursor)
            {
                if (cursor.Limit == null || cursor.Limit > 2) cursor.SetLimit(2);

                var items = new List<TItem>();
                if (await cursor.MoveNextAsync(cancellationToken).ConfigureAwait(false)) items.Add(cursor.Current);
                else return items.Single();

                if (await cursor.MoveNextAsync(cancellationToken).ConfigureAwait(false)) items.Add(cursor.Current);
                return items.Single();
            }
        }

        /// <summary>
        ///     Returns the only item of a cursor, or a default value if the cursor contains no items.
        ///     This method throws an exception if the cursor contains more than one item.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="cursor">The cursor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The only item of a cursor, or a default value if the cursor contains no items.</returns>
        public static TItem SingleOrDefault<TItem>(this IAsyncCursor<TItem> cursor,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (cursor)
            {
                if (cursor.Limit == null || cursor.Limit > 2) cursor.SetLimit(2);

                if (!cursor.MoveNext(cancellationToken)) return default(TItem);
                var items = new List<TItem> {cursor.Current};
                if (!cursor.MoveNext(cancellationToken)) return items.SingleOrDefault();
                items.Add(cursor.Current);
                return items.SingleOrDefault();
            }
        }

        /// <summary>
        ///     Returns the only item of a cursor, or a default value if the cursor contains no items.
        ///     This method throws an exception if the cursor contains more than one item.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="cursor">The cursor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task whose result is the only item of a cursor, or a default value if the cursor contains no items.</returns>
        public static async Task<TItem> SingleOrDefaultAsync<TItem>(this IAsyncCursor<TItem> cursor,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (cursor)
            {
                if (cursor.Limit == null || cursor.Limit > 2) cursor.SetLimit(2);

                if (!await cursor.MoveNextAsync(cancellationToken).ConfigureAwait(false)) return default(TItem);
                var items = new List<TItem> {cursor.Current};
                if (!await cursor.MoveNextAsync(cancellationToken).ConfigureAwait(false))
                    return items.SingleOrDefault();
                items.Add(cursor.Current);
                return items.SingleOrDefault();
            }
        }

        /// <summary>
        ///     Wraps a cursor in an IEnumerable that can be enumerated one time.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="cursor">The cursor.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An IEnumerable</returns>
        public static IEnumerable<TItem> ToEnumerable<TItem>(this IAsyncCursor<TItem> cursor,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return new AsyncCursorEnumerableAdapter<TItem>(cursor, cancellationToken);
        }

        /// <summary>
        ///     Returns a list containing all the items returned by a cursor.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The list of items.</returns>
        public static List<TItem> ToList<TItem>(this IAsyncCursor<TItem> source,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var list = new List<TItem>();

            using (source)
            {
                while (source.MoveNext(cancellationToken))
                {
                    list.Add(source.Current);
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }
            return list;
        }

        /// <summary>
        ///     Returns a list containing all the items returned by a cursor.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task whose value is the list of items.</returns>
        public static async Task<List<TItem>> ToListAsync<TItem>(this IAsyncCursor<TItem> source,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var list = new List<TItem>();

            using (source)
            {
                while (await source.MoveNextAsync(cancellationToken).ConfigureAwait(false))
                {
                    list.Add(source.Current);
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }
            return list;
        }
    }
}