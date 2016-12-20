using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using CsvHelper.Configuration;
using NationBuilderConnect.Client.Utilities;

namespace NationBuilderConnect.Client.Tools.Export
{
    /// <summary>
    ///     Class allowing a CSV file to be iterated
    /// </summary>
    /// <typeparam name="TItem">The record type in the file</typeparam>
    public class CsvFileEnumerable<TItem> : IEnumerable<TItem> where TItem : CsvRecord
    {
        private readonly CancellationToken _cancellationToken;
        private readonly CsvConfiguration _configuration;
        private bool _hasBeenEnumerated;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CsvFileEnumerable{TItem}" /> class
        /// </summary>
        /// <param name="filePath">The full path to the CSV file</param>
        /// <param name="configuration">The configuration to use for reading the CSV file</param>
        /// <param name="cancellationToken">The cancellation token</param>
        [CLSCompliant(false)]
        public CsvFileEnumerable(string filePath, CsvConfiguration configuration,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNullOrWhitespace(filePath, nameof(filePath));
            Ensure.IsNotNull(configuration, nameof(configuration));
            FilePath = filePath;
            _configuration = configuration;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        ///     The full path to the file being iterated
        /// </summary>
        public string FilePath { get; }

        /// <inheritDoc/>
        public IEnumerator<TItem> GetEnumerator()
        {
            if (_hasBeenEnumerated)
            {
                throw new InvalidOperationException("An IAsyncCursor can only be enumerated once.");
            }
            _hasBeenEnumerated = true;
            return new CsvFileEnumerator<TItem>(FilePath, _configuration, _cancellationToken);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}