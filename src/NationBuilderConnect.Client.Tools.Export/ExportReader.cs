using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using NationBuilderConnect.Client.Services;
using NationBuilderConnect.Client.Utilities;
using NationBuilderConnect.Model;

namespace NationBuilderConnect.Client.Tools.Export
{
    public class ExportReader : IDisposable
    {
        private readonly ExportService _exportService;
        private readonly HttpClient _httpClient;
        private static readonly TimeSpan TimeToWaitOnExportBeforeTryingAgain = TimeSpan.FromSeconds(30);

        public ExportReader(RequestOptions requestOptions = null)
        {
            _httpClient = new HttpClient();
            _exportService = new ExportService(requestOptions);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
            _exportService.Dispose();
        }

        private void DownloadFile(string url, string filePath, CancellationToken cancellationToken)
        {
            using (var response = _httpClient.GetAsync(url, cancellationToken).Result)
            {
                response.EnsureSuccessStatusCode();
                using (var responseStream = response.Content.ReadAsStreamAsync().Result)
                {
                    using (var fileStream = File.Open(filePath, FileMode.Create))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
            }
        }

        private async Task DownloadFileAsync(string url, string filePath, CancellationToken cancellationToken)
        {
            using (var response = await _httpClient.GetAsync(url, cancellationToken))
            {
                response.EnsureSuccessStatusCode();
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    using (var fileStream = File.Open(filePath, FileMode.Create))
                    {
                        await responseStream.CopyToAsync(fileStream);
                    }
                }
            }
        }

        public Task<CsvFileEnumerable<ExportedPerson>> ExportAndGetPeopleFromListAsync(int listId,
            TimeSpan? exportTimeout = null, string downloadDir = null, Func<int, string> createFileName = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return ExportAndGetRecordsFromListAsync<ExportedPerson>(listId, downloadDir, ExportContext.People,
                createFileName, exportTimeout, cancellationToken);
        }

        public Task<CsvFileEnumerable<ExportedHousehold>> ExportAndGetHouseholdsFromListAsync(int listId,
            TimeSpan? exportTimeout = null, string downloadDir = null, Func<int, string> createFileName = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return ExportAndGetRecordsFromListAsync<ExportedHousehold>(listId, downloadDir, ExportContext.Households,
                createFileName, exportTimeout, cancellationToken);
        }

        public CsvFileEnumerable<ExportedPerson> ExportAndGetPeopleFromList(int listId,
            TimeSpan? exportTimeout = null, string downloadDir = null, Func<int, string> createFileName = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return ExportAndGetRecordsFromList<ExportedPerson>(listId, downloadDir, ExportContext.People,
                createFileName, exportTimeout, cancellationToken);
        }

        public CsvFileEnumerable<ExportedHousehold> ExportAndGetHouseholdsFromList(int listId,
            TimeSpan? exportTimeout = null, string downloadDir = null, Func<int, string> createFileName = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return ExportAndGetRecordsFromList<ExportedHousehold>(listId, downloadDir, ExportContext.Households,
                createFileName, exportTimeout, cancellationToken);
        }

        private async Task<bool> WaitForExportToFinishAsync(int exportId, TimeSpan timeToWaitForExport,
            CancellationToken cancellationToken)
        {
            var whenStart = DateTime.UtcNow;

            while (true)
            {
                ConnectClient.Logger.Trace($"ExportReader-WaitForExportToFinish: Export {exportId} - waiting {TimeToWaitOnExportBeforeTryingAgain}");
                await Task.Delay(TimeToWaitOnExportBeforeTryingAgain, cancellationToken);
                var waitedAlready = DateTime.UtcNow - whenStart;
                ConnectClient.Logger.Trace($"ExportReader-WaitForExportToFinish: Export {exportId} - waited already {waitedAlready}");
                if (waitedAlready > timeToWaitForExport) return false;
                ConnectClient.Logger.Trace($"ExportReader-WaitForExportToFinish: Check export {exportId}");
                var export = await _exportService.ShowAsync(exportId, cancellationToken);
                ConnectClient.Logger.Trace($"ExportReader-WaitForExportToFinish: Export {exportId} is {export?.Status}");
                if (export != null && export.Status == ExportStatus.Completed) return true;
                ConnectClient.Logger.Trace($"ExportReader-WaitForExportToFinish: Export {exportId} not done: {export?.Status}");
            }
        }

        private bool WaitForExportToFinish(int exportId, TimeSpan timeToWaitForExport,
            CancellationToken cancellationToken)
        {
            var whenStart = DateTime.UtcNow;

            while (true)
            {
                ConnectClient.Logger.Trace($"ExportReader-WaitForExportToFinish: Export {exportId} - waiting {TimeToWaitOnExportBeforeTryingAgain}");
                Task.Delay(TimeToWaitOnExportBeforeTryingAgain, cancellationToken).Wait(cancellationToken);
                var waitedAlready = DateTime.UtcNow - whenStart;
                ConnectClient.Logger.Trace($"ExportReader-WaitForExportToFinish: Export {exportId} - waited already {waitedAlready}");
                if (waitedAlready > timeToWaitForExport) return false;
                ConnectClient.Logger.Trace($"ExportReader-WaitForExportToFinish: Check export {exportId}");
                var export = _exportService.Show(exportId, cancellationToken);
                ConnectClient.Logger.Trace($"ExportReader-WaitForExportToFinish: Export {exportId} is {export?.Status}");
                if (export != null && export.Status == ExportStatus.Completed) return true;
                ConnectClient.Logger.Trace($"ExportReader-WaitForExportToFinish: Export {exportId} not done: {export?.Status}");
            }
        }

        private CsvFileEnumerable<TRecord> ExportAndGetRecordsFromList<TRecord>(int listId,
            string downloadDir, ExportContext context, Func<int, string> createFileName, TimeSpan? exportTimeout,
            CancellationToken cancellationToken) where TRecord : CsvRecord
        {
            int? exportId = null;
            var exportTimeoutNotNull = exportTimeout ?? TimeSpan.FromMinutes(5);

            try
            {
                var export = _exportService.Create(listId, context, cancellationToken);

                ConnectClient.Logger.Trace($"ExportReader-ExportAndGetRecordsFromList: Export {export.Id} created");

                exportId = export.Id;

                var isReady = WaitForExportToFinish(exportId.Value, exportTimeoutNotNull, cancellationToken);

                if (!isReady)
                {
                    ConnectClient.Logger.Trace($"ExportReader-ExportAndGetRecordsFromList: Export {exportId} not ready in time");
                    throw new ExportIsNotCompleteException(exportId.Value);
                }

                ConnectClient.Logger.Trace($"ExportReader-ExportAndGetRecordsFromList: Export {exportId} ready");

                return GetExportedRecords<TRecord>(exportId.Value, downloadDir,
                    createFileName?.Invoke(exportId.Value), cancellationToken);
            }
            finally
            {
                if (exportId.HasValue)
                    _exportService.Delete(exportId.Value, false, cancellationToken);
            }
        }

        private async Task<CsvFileEnumerable<TRecord>> ExportAndGetRecordsFromListAsync<TRecord>(int listId,
            string downloadDir,
            ExportContext context, Func<int, string> createFileName, TimeSpan? exportTimeout,
            CancellationToken cancellationToken) where TRecord : CsvRecord
        {
            int? exportId = null;
            var exportTimeoutNotNull = exportTimeout ?? TimeSpan.FromMinutes(5);

            try
            {
                var export = await _exportService.CreateAsync(listId, context, cancellationToken);

                ConnectClient.Logger.Trace($"ExportReader-ExportAndGetRecordsFromListAsync: Export {export.Id} created");

                exportId = export.Id;
                var isReady = await WaitForExportToFinishAsync(exportId.Value, exportTimeoutNotNull, cancellationToken);
                if (!isReady)
                {
                    ConnectClient.Logger.Trace($"ExportReader-ExportAndGetRecordsFromListAsync: Export {exportId} not ready in time");
                    throw new ExportIsNotCompleteException(exportId.Value);
                }

                ConnectClient.Logger.Trace($"ExportReader-ExportAndGetRecordsFromListAsync: Export {exportId} ready");

                return await GetExportedRecordsAsync<TRecord>(exportId.Value, downloadDir,
                        createFileName?.Invoke(exportId.Value), cancellationToken);
            }
            finally
            {
                if (exportId.HasValue)
                    await _exportService.DeleteAsync(exportId.Value, false, cancellationToken);
            }
        }

        private static CsvConfiguration GetCsvConfiguration<TRecord>() where TRecord : CsvRecord
        {
            if (typeof(TRecord) == typeof(ExportedHousehold))
            {
                var householdConfig = new CsvConfiguration {HasHeaderRecord = true, DetectColumnCountChanges = false};
                householdConfig.RegisterClassMap<ExportedHouseholdMap>();
                return householdConfig;
            }

            var personConfig = new CsvConfiguration {HasHeaderRecord = true, DetectColumnCountChanges = false};
            personConfig.RegisterClassMap<ExportedPersonMap>();
            return personConfig;
        }

        public Task<CsvFileEnumerable<ExportedPerson>> GetExportedPeopleAsync(int exportId, string downloadDir,
            string fileName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetExportedRecordsAsync<ExportedPerson>(exportId, downloadDir, fileName, cancellationToken);
        }

        public Task<CsvFileEnumerable<ExportedHousehold>> GetExportedHouseholdsAsync(int exportId, string downloadDir,
            string fileName = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetExportedRecordsAsync<ExportedHousehold>(exportId, downloadDir, fileName, cancellationToken);
        }

        private async Task<CsvFileEnumerable<TRecord>> GetExportedRecordsAsync<TRecord>(int exportId,
            string downloadDir, string fileName, CancellationToken cancellationToken) where TRecord : CsvRecord
        {
            downloadDir = downloadDir ?? Path.GetTempPath();

            Ensure.IsNotNullOrWhitespace(downloadDir, nameof(downloadDir));
            if (!Directory.Exists(downloadDir)) throw new ArgumentException("Download directory does not exist");

            var export = await _exportService.ShowAsync(exportId, cancellationToken);

            if (export == null) throw new ExportDoesNotExistException(exportId);
            if (export.Status != ExportStatus.Completed) throw new ExportIsNotCompleteException(exportId);

            fileName = !string.IsNullOrWhiteSpace(fileName)
                ? fileName
                : GetDefaultCsvFileName(exportId);

            var filePath = Path.Combine(downloadDir, fileName);

            if (File.Exists(filePath)) throw new InvalidOperationException($"File already exists: {filePath}");

            await DownloadFileAsync(export.DownloadUrl, filePath, cancellationToken);
            var configuration = GetCsvConfiguration<TRecord>();
            return new CsvFileEnumerable<TRecord>(filePath, configuration, cancellationToken);
        }

        public CsvFileEnumerable<ExportedPerson> GetExportedPeople(int exportId, string downloadDir,
            string fileName = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetExportedRecords<ExportedPerson>(exportId, downloadDir, fileName, cancellationToken);
        }

        public CsvFileEnumerable<ExportedHousehold> GetExportedHouseholds(int exportId, string downloadDir,
            string fileName = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetExportedRecords<ExportedHousehold>(exportId, downloadDir, fileName, cancellationToken);
        }

        private CsvFileEnumerable<TRecord> GetExportedRecords<TRecord>(int exportId, string downloadDir,
            string fileName, CancellationToken cancellationToken) where TRecord : CsvRecord
        {
            downloadDir = downloadDir ?? Path.GetTempPath();

            Ensure.IsNotNullOrWhitespace(downloadDir, nameof(downloadDir));
            if (!Directory.Exists(downloadDir)) throw new ArgumentException("Download directory does not exist");

            var export = _exportService.Show(exportId, cancellationToken);

            if (export == null) throw new ExportDoesNotExistException(exportId);
            if (export.Status != ExportStatus.Completed) throw new ExportIsNotCompleteException(exportId);

            fileName = !string.IsNullOrWhiteSpace(fileName)
                ? fileName
                : GetDefaultCsvFileName(exportId);

            var filePath = Path.Combine(downloadDir, fileName);

            ConnectClient.Logger.Trace($"ExportReader-GetExportedRecords: Export {exportId} - getting records from {filePath}");

            if (File.Exists(filePath)) throw new InvalidOperationException($"File already exists: {filePath}");

            DownloadFile(export.DownloadUrl, filePath, cancellationToken);
            var configuration = GetCsvConfiguration<TRecord>();
            return new CsvFileEnumerable<TRecord>(filePath, configuration, cancellationToken);
        }

        private static string GetDefaultCsvFileName(int exportId)
        {
            return $"NB-{exportId}-{DateTime.UtcNow:yyyyMMddHHmm}-{Guid.NewGuid()}.csv";
        }
    }
}