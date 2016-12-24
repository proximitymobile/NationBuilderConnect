using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using CsvHelper;
using CsvHelper.Configuration;
using NationBuilderConnect.Client.Utilities;

namespace NationBuilderConnect.Client.Tools.Export
{
    internal class CsvFileEnumerator<TItem> : IEnumerator<TItem> where TItem : CsvRecord
    {
        private readonly CancellationToken _cancellationToken;
        private readonly CsvConfiguration _configuration;
        private readonly string _filePath;
        private TItem _current;
        private bool _disposed;
        private bool _finished;
        private CsvReader _reader;
        private bool _started;
        private List<string> _unmappedHeaders;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CsvFileEnumerator{TItem}" /> class
        /// </summary>
        /// <param name="filePath">The full path to the CSV file</param>
        /// <param name="configuration">The configuration to use for reading the CSV file</param>
        /// <param name="cancellationToken">The cancellation token</param>
        public CsvFileEnumerator(string filePath, CsvConfiguration configuration,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNullOrWhitespace(filePath, nameof(filePath));
            Ensure.IsNotNull(configuration, nameof(configuration));
            _filePath = filePath;
            _configuration = configuration;
            _cancellationToken = cancellationToken;
        }

        public TItem Current
        {
            get
            {
                ThrowIfDisposed();
                if (!_started)
                {
                    throw new InvalidOperationException("Enumeration has not started. Call MoveNext.");
                }
                if (_finished)
                {
                    throw new InvalidOperationException("Enumeration already finished.");
                }
                return _current;
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            _reader?.Dispose();
            if(!string.IsNullOrWhiteSpace(_filePath) && File.Exists(_filePath)) File.Delete(_filePath);
        }

        public bool MoveNext()
        {
            ThrowIfDisposed();
            _cancellationToken.ThrowIfCancellationRequested();
            _started = true;
            InitializeReaderIfNeeded();

            if (!_reader.Read())
            {
                _current = null;
                _finished = true;
                return false;
            }

            _current = _reader.GetRecord<TItem>();

            if (_current == null)
            {
                _current = null;
                _finished = true;
                return false;
            }

            // Now read the extra gubbins...
            if (_unmappedHeaders == null)
                _unmappedHeaders = GetUnmappedHeaders(_reader);

            foreach (var header in _unmappedHeaders)
            {
                Current.SetCustomField(header, _reader.GetField(header));
            }

            return true;
        }

        public void Reset()
        {
            ThrowIfDisposed();
            throw new NotSupportedException();
        }

        private void InitializeReaderIfNeeded()
        {
            if (_reader != null) return;
            if (!File.Exists(_filePath)) throw new InvalidOperationException($"File does not exist: {_filePath}");
            if (!string.Equals(Path.GetExtension(_filePath), ".csv", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException($"File must be .csv: {_filePath}");
            _reader = new CsvReader(File.OpenText(_filePath), _configuration);
        }

        private static List<string> GetUnmappedHeaders(ICsvReader reader)
        {
            var map = reader.Configuration.Maps.Find<TItem>();
            return
                reader.FieldHeaders.Where(h => map.PropertyMaps.All(pm => !pm.Data.Names.Names.Contains(h)))
                    .Distinct()
                    .ToList();
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
    }
}