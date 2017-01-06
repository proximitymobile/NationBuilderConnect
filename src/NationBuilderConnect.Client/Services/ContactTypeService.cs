using System.Threading;
using System.Threading.Tasks;
using NationBuilderConnect.Client.Model;
using NationBuilderConnect.Client.Utilities;
using NationBuilderConnect.Client.Utilities.Cursors;
using NationBuilderConnect.Model;

namespace NationBuilderConnect.Client.Services
{
    public class ContactTypeService : NationBuilderApiService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactTypeService" /> class
        /// </summary>
        /// <param name="options">
        ///     Options to use for each request issued from this instance of the service. Overrides default
        ///     values provided while initializing the client.
        /// </param>
        public ContactTypeService(RequestOptions options = null) : base(options)
        {
        }

        public async Task<ResultsPage<ContactType>> GetIndexPageAsync(short pageSize, PagingTokens pagingTokens,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1ContactTypeIndexUrl(pageSize, pagingTokens);
            return (await GetJsonAsync<ResultsPage<ContactType>>(url, cancellationToken)).Payload;
        }

        public ResultsPage<ContactType> GetIndexPage(short pageSize, PagingTokens pagingTokens,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1ContactTypeIndexUrl(pageSize, pagingTokens);
            return GetJson<ResultsPage<ContactType>>(url, cancellationToken).Payload;
        }

        /// <summary>
        ///     Retrieves the list of contact types. The results are of type <see cref="ContactType" />
        /// </summary>
        /// <param name="pageSize">
        ///     The size of the pages of results to return from the server. If null it will use the default
        ///     value.
        /// </param>
        /// <returns>A cursor that can be used to iterate through the results either syncronously or asyncronously</returns>
        public IAsyncCursor<ContactType> GetIndex(short? pageSize = null)
        {
            return new AsyncPagedEntityCursor<ContactType>(GetIndexAsPages(pageSize));
        }

        /// <summary>
        ///     Retrieves the list of contact types as pages of results. The results are of type
        ///     <see cref="ContactType" />
        /// </summary>
        /// <param name="pageSize">
        ///     The size of the pages of results to return from the server. If null it will use the default
        ///     value.
        /// </param>
        /// <returns>A cursor that can be used to iterate through the results either syncronously or asyncronously</returns>
        public IAsyncCursor<ResultsPage<ContactType>> GetIndexAsPages(short? pageSize = null)
        {
            Ensure.IsValidExplicitPageSize(pageSize);
            var actualPageSize = GetPageSize(pageSize);
            return new AsyncPageCursor<ContactType>(GetIndexPage, GetIndexPageAsync, actualPageSize);
        }
    }
}