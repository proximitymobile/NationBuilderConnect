using System.Threading;
using System.Threading.Tasks;
using NationBuilderConnect.Client.Model;
using NationBuilderConnect.Client.Model.Requests;
using NationBuilderConnect.Client.Model.Responses;
using NationBuilderConnect.Client.Services.Parameters;
using NationBuilderConnect.Client.Utilities;
using NationBuilderConnect.Client.Utilities.Cursors;
using NationBuilderConnect.Model;

namespace NationBuilderConnect.Client.Services
{
    /// <summary>
    ///     Access to the NationBuilder Contacts API
    /// </summary>
    public class ContactService : NationBuilderApiService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactService" /> class
        /// </summary>
        /// <param name="options">
        ///     Options to use for each request issued from this instance of the service. Overrides default
        ///     values provided while initializing the client.
        /// </param>
        public ContactService(RequestOptions options = null) : base(options)
        {
        }

        public async Task<ResultsPage<Contact>> GetIndexPageAsync(int personId, short pageSize, PagingTokens pagingTokens,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1ContactIndexUrl(personId, pageSize, pagingTokens);
            return (await GetJsonAsync<ResultsPage<Contact>>(url, cancellationToken)).Payload;
        }

        public ResultsPage<Contact> GetIndexPage(int personId, short pageSize, PagingTokens pagingTokens,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1ContactIndexUrl(personId, pageSize, pagingTokens);
            return GetJson<ResultsPage<Contact>>(url, cancellationToken).Payload;
        }

        /// <summary>
        ///     Retrieves a list of a person's contacts
        /// </summary>
        /// <param name="personId">The ID of the person whose contacts to return</param>
        /// <param name="pageSize">The size of the pages of results to return from the server. If null it will use the default value.</param>
        /// <returns>A cursor that can be used to iterate through the contacts either syncronously or asyncronously</returns>
        public IAsyncCursor<Contact> GetIndex(int personId, short? pageSize = null)
        {
            Ensure.IsValidExplicitPageSize(pageSize);
            var actualPageSize = GetPageSize(pageSize);
            return new AsyncPagedEntityCursor<Contact>(GetIndexAsPages(personId, actualPageSize));
        }

        /// <summary>
        ///     Retrieves a list of a person's contacts as pages of results
        /// </summary>
        /// <param name="personId">The ID of the person whose contacts to return</param>
        /// <param name="pageSize">The size of the pages of results to return from the server. If null it will use the default value.</param>
        /// <returns>A cursor that can be used to iterate through the contacts either syncronously or asyncronously</returns>
        public IAsyncCursor<ResultsPage<Contact>> GetIndexAsPages(int personId, short? pageSize = null)
        {
            Ensure.IsValidExplicitPageSize(pageSize);
            var actualPageSize = GetPageSize(pageSize);
            return new AsyncPageCursor<Contact>(
                (size, tokens, token) => GetIndexPage(personId, size, tokens, token),
                async (size, tokens, token) => await GetIndexPageAsync(personId, size, tokens, token),
                actualPageSize);
        }

        /// <summary>
        ///     Records a contact for a person syncronously
        /// </summary>
        /// <param name="personId">The ID of the person that was contacted</param>
        /// <param name="parameters">Options for the contact</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The contact that was created</returns>
        public Contact Create(int personId, CreateContactParameters parameters,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(parameters, nameof(parameters));

            var url = UrlProvider.GetV1ContactCreateUrl(personId);
            var request = new CreateContactRequest(parameters);
            return PostJson<CreateContactResponse>(url, request, cancellationToken).Payload.Contact;
        }

        /// <summary>
        ///     Records a contact for a person asyncronously
        /// </summary>
        /// <param name="personId">The ID of the person that was contacted</param>
        /// <param name="parameters">Options for the contact.</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled.</param>
        /// <returns>The contact that was created.</returns>
        public async Task<Contact> CreateAsync(int personId, CreateContactParameters parameters,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(parameters, nameof(parameters));

            var url = UrlProvider.GetV1ContactCreateUrl(personId);
            var request = new CreateContactRequest(parameters);
            return (await PostJsonAsync<CreateContactResponse>(url, request, cancellationToken)).Payload.Contact;
        }
    }
}