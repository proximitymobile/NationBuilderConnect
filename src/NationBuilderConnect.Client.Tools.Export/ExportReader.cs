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
    public class ExportReader
    {
        private static async Task DownloadFileAsync(string url, string filePath, CancellationToken cancellationToken)
        {
            using (var client = new HttpClient())
            using (var response = await client.GetAsync(url, cancellationToken))
            {
                response.EnsureSuccessStatusCode();
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = File.Open(filePath, FileMode.Create))
                {
                    await responseStream.CopyToAsync(fileStream);
                }
            }
        }

        public async Task<CsvFileEnumerable<ExportedPerson>> GetExportedPeopleAsync(int exportId, string downloadDir,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNullOrWhitespace(downloadDir, nameof(downloadDir));
            if (!Directory.Exists(downloadDir)) throw new ArgumentException("Download directory does not exist");

            NationBuilderConnect.Model.Export export;

            using (var service = new ExportService())
            {
                export = await service.ShowAsync(exportId, cancellationToken);
            }

            if (export == null) throw new ExportDoesNotExistException(exportId);
            if (export.Status != ExportStatus.Completed) throw new ExportIsNotCompleteException(exportId);

            var configuration = new CsvConfiguration {HasHeaderRecord = true, DetectColumnCountChanges = false};
            configuration.RegisterClassMap<ExportedPersonMap>();

            var filePath = Path.Combine(downloadDir,
                DateTime.UtcNow.ToString($"NB-{exportId}-yyyyMMddHHmm-{Guid.NewGuid()}.csv"));

            if (File.Exists(filePath)) throw new InvalidOperationException($"File already exists: {filePath}");

            await DownloadFileAsync(export.DownloadUrl, filePath, cancellationToken);

            return new CsvFileEnumerable<ExportedPerson>(filePath, configuration, cancellationToken);
        }
    }
}