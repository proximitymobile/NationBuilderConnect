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

        public Task<CsvFileEnumerable<ExportedPerson>> ExportAndGetPeopleFromListAsync(int listId, string downloadDir,
            Func<int, string> createFileName, TimeSpan timeToWaitForExport,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return ExportAndGetRecordsFromListAsync<ExportedPerson>(listId, downloadDir, ExportContext.People,
                createFileName, timeToWaitForExport, cancellationToken);
        }

        public Task<CsvFileEnumerable<ExportedHousehold>> ExportAndGetHouseholdsFromListAsync(int listId,
            string downloadDir, Func<int, string> createFileName, TimeSpan timeToWaitForExport,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return ExportAndGetRecordsFromListAsync<ExportedHousehold>(listId, downloadDir, ExportContext.Households,
                createFileName, timeToWaitForExport, cancellationToken);
        }

        public CsvFileEnumerable<ExportedPerson> ExportAndGetPeopleFromList(int listId, string downloadDir,
            Func<int, string> createFileName, TimeSpan timeToWaitForExport,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return ExportAndGetRecordsFromList<ExportedPerson>(listId, downloadDir, ExportContext.People,
                createFileName, timeToWaitForExport, cancellationToken);
        }

        public CsvFileEnumerable<ExportedHousehold> ExportAndGetHouseholdsFromList(int listId, string downloadDir,
            Func<int, string> createFileName, TimeSpan timeToWaitForExport,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return ExportAndGetRecordsFromList<ExportedHousehold>(listId, downloadDir, ExportContext.Households,
                createFileName, timeToWaitForExport, cancellationToken);
        }

        private static Task DelayAsync(TimeSpan timeSpan)
        {
            var tcs = new TaskCompletionSource<object>();
            new Timer(_ => tcs.SetResult(null)).Change((int) timeSpan.TotalMilliseconds, -1);
            return tcs.Task;
        }

        private async Task<bool> WaitForExportToFinishAsync(int exportId, TimeSpan timeToWaitForExport,
            CancellationToken cancellationToken)
        {
            var whenStart = DateTime.UtcNow;

            while (true)
            {
                await DelayAsync(TimeSpan.FromSeconds(5));
                var waitedAlready = DateTime.UtcNow - whenStart;
                if (waitedAlready > timeToWaitForExport) return false;
                var export = await _exportService.ShowAsync(exportId, cancellationToken);
                if ((export != null) && (export.Status == ExportStatus.Completed)) return true;
            }
        }

        private bool WaitForExportToFinish(int exportId, TimeSpan timeToWaitForExport,
            CancellationToken cancellationToken)
        {
            var whenStart = DateTime.UtcNow;

            while (true)
            {
                DelayAsync(TimeSpan.FromSeconds(5)).Wait(cancellationToken);
                var waitedAlready = DateTime.UtcNow - whenStart;
                if (waitedAlready > timeToWaitForExport) return false;
                var export = _exportService.Show(exportId, cancellationToken);
                if ((export != null) && (export.Status == ExportStatus.Completed)) return true;
            }
        }

        private CsvFileEnumerable<TRecord> ExportAndGetRecordsFromList<TRecord>(int listId,
            string downloadDir,
            ExportContext context, Func<int, string> createFileName, TimeSpan timeToWaitForExport,
            CancellationToken cancellationToken) where TRecord : CsvRecord
        {
            int? exportId = null;

            try
            {
                var export = _exportService.Create(listId, context, cancellationToken);
                exportId = export.Id;
                var isReady = WaitForExportToFinish(exportId.Value, timeToWaitForExport, cancellationToken);
                if (!isReady) throw new ExportIsNotCompleteException(exportId.Value);
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
            ExportContext context, Func<int, string> createFileName, TimeSpan timeToWaitForExport,
            CancellationToken cancellationToken) where TRecord : CsvRecord
        {
            int? exportId = null;

            try
            {
                var export = await _exportService.CreateAsync(listId, context, cancellationToken);
                exportId = export.Id;
                var isReady = await WaitForExportToFinishAsync(exportId.Value, timeToWaitForExport, cancellationToken);
                if (!isReady) throw new ExportIsNotCompleteException(exportId.Value);
                return await
                    GetExportedRecordsAsync<TRecord>(exportId.Value, downloadDir,
                        createFileName?.Invoke(exportId.Value), cancellationToken);
            }
            finally
            {
                if (exportId.HasValue)
                    await _exportService.DeleteAsync(exportId.Value, false, cancellationToken);
            }
        }

        private static CsvConfiguration GetCsvConfiguration<TRecord>()
        {
            if (typeof(TRecord) == typeof(ExportedHousehold))
            {
                var householdCOnfig = new CsvConfiguration {HasHeaderRecord = true, DetectColumnCountChanges = false};
                householdCOnfig.RegisterClassMap<ExportedHouseholdMap>();
                return householdCOnfig;
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

        private async Task<CsvFileEnumerable<TRecord>> GetExportedRecordsAsync<TRecord>(int exportId, string downloadDir,
            string fileName, CancellationToken cancellationToken) where TRecord : CsvRecord
        {
            Ensure.IsNotNullOrWhitespace(downloadDir, nameof(downloadDir));
            if (!Directory.Exists(downloadDir)) throw new ArgumentException("Download directory does not exist");

            var export = await _exportService.ShowAsync(exportId, cancellationToken);

            if (export == null) throw new ExportDoesNotExistException(exportId);
            if (export.Status != ExportStatus.Completed) throw new ExportIsNotCompleteException(exportId);

            fileName = !string.IsNullOrWhiteSpace(fileName)
                ? fileName
                : DateTime.UtcNow.ToString($"NB-{exportId}-yyyyMMddHHmm-{Guid.NewGuid()}.csv");

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
            Ensure.IsNotNullOrWhitespace(downloadDir, nameof(downloadDir));
            if (!Directory.Exists(downloadDir)) throw new ArgumentException("Download directory does not exist");

            var export = _exportService.Show(exportId, cancellationToken);

            if (export == null) throw new ExportDoesNotExistException(exportId);
            if (export.Status != ExportStatus.Completed) throw new ExportIsNotCompleteException(exportId);

            fileName = !string.IsNullOrWhiteSpace(fileName)
                ? fileName
                : DateTime.UtcNow.ToString($"NB-{exportId}-yyyyMMddHHmm-{Guid.NewGuid()}.csv");

            var filePath = Path.Combine(downloadDir, fileName);

            if (File.Exists(filePath)) throw new InvalidOperationException($"File already exists: {filePath}");

            DownloadFile(export.DownloadUrl, filePath, cancellationToken);

            var configuration = GetCsvConfiguration<TRecord>();
            return new CsvFileEnumerable<TRecord>(filePath, configuration, cancellationToken);
        }
    }
}