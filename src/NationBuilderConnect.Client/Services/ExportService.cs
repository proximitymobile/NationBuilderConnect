using System.Threading;
using System.Threading.Tasks;
using NationBuilderConnect.Client.Services.Parameters;
using NationBuilderConnect.Client.Utilities;

namespace NationBuilderConnect.Client.Services
{
    public class ExportService : NationBuilderService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExportService" /> class
        /// </summary>
        /// <param name="options">
        ///     Options to use for each request issued from this instance of the service. Overrides default
        ///     values provided while initializing the client.
        /// </param>
        public ExportService(RequestOptions options = null) : base(options)
        {
        }

        /// <summary>
        ///     Creates and enqueues an export of people from your nation from an existing custom list syncronously
        /// </summary>
        /// <param name="listId">The ID of the list to export</param>
        /// <param name="context">The context of the export (people or households).</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The export that was created</returns>
        public Export Create(int listId, ExportContext context,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1ExportCreateUrl(listId);
            var request = new CreateExportRequest(new CreateExportParameters(context));
            return PostJson<CreateExportResponse>(url, request, cancellationToken).Payload.Export;
        }

        /// <summary>
        ///     Creates and enqueues an export of people from your nation from an existing custom list asyncronously
        /// </summary>
        /// <param name="listId">The ID of the list to export</param>
        /// <param name="context">The context of the export (people or households).</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The export that was created</returns>
        public async Task<Export> CreateAsync(int listId, ExportContext context,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1ExportCreateUrl(listId);
            var request = new CreateExportRequest(new CreateExportParameters(context));
            return (await PostJsonAsync<CreateExportResponse>(url, request, cancellationToken)).Payload.Export;
        }

        /// <summary>
        ///     Retrieves information about an export syncronously
        /// </summary>
        /// <param name="exportId">The ID of the export</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The export</returns>
        public Export Show(int exportId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1ExportShowUrl(exportId);
            return GetJson<ShowExportResponse>(url, cancellationToken).Payload.Export;
        }

        /// <summary>
        ///     Retrieves information about an export asyncronously
        /// </summary>
        /// <param name="exportId">The ID of the export</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The export</returns>
        public async Task<Export> ShowAsync(int exportId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1ExportShowUrl(exportId);
            return (await GetJsonAsync<ShowExportResponse>(url, cancellationToken)).Payload.Export;
        }

        /// <summary>
        /// Deletes an export syncronously
        /// </summary>
        /// <param name="exportId">The ID of the export to delete</param>
        /// <param name="throwOnNotFound">Whether to throw an exception if the export is not found</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public void Delete(int exportId, bool throwOnNotFound = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1ExportDeleteUrl(exportId);
            var response = DeleteJson(url, cancellationToken, throwOnNotFound);
            ThrowIfApiFail(response, throwOnNotFound);
        }

        /// <summary>
        /// Deletes an export asyncronously
        /// </summary>
        /// <param name="exportId">The ID of the export to delete</param>
        /// <param name="throwOnNotFound">Whether to throw an exception if the export is not found</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public async Task DeleteAsync(int exportId, bool throwOnNotFound = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1ExportDeleteUrl(exportId);
            var response = await DeleteJsonAsync(url, cancellationToken);
            ThrowIfApiFail(response, throwOnNotFound);
        }
    }
}