using System.Collections.Generic;
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
    ///     Access to the NationBuilder Lists API
    /// </summary>
    public class ListService : NationBuilderApiService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ListService" /> class
        /// </summary>
        /// <param name="options">
        ///     Options to use for each request issued from this instance of the service. Overrides default
        ///     values provided while initializing the client.
        /// </param>
        public ListService(RequestOptions options = null) : base(options)
        {
        }

        private async Task<ResultsPage<CustomList>> GetIndexPageAsync(short pageSize,
            PagingTokens pagingTokens, CancellationToken cancellationToken)
        {
            var url = UrlProvider.GetV1ListIndexUrl(pageSize, pagingTokens);
            return (await GetJsonAsync<ResultsPage<CustomList>>(url, cancellationToken)).Payload;
        }

        private ResultsPage<CustomList> GetIndexPage(short pageSize, PagingTokens pagingTokens,
            CancellationToken cancellationToken)
        {
            var url = UrlProvider.GetV1ListIndexUrl(pageSize, pagingTokens);
            return GetJson<ResultsPage<CustomList>>(url, cancellationToken).Payload;
        }

        /// <summary>
        ///     Retrieves a list of created custom lists
        /// </summary>
        /// <param name="pageSize">
        ///     The size of the pages of results to return from the server. If null it will use the default
        ///     value.
        /// </param>
        /// <returns>A cursor that can be used to iterate through the lists either syncronously or asyncronously</returns>
        public IAsyncCursor<CustomList> GetIndex(short? pageSize = null)
        {
            Ensure.IsValidExplicitPageSize(pageSize);
            var actualPageSize = GetPageSize(pageSize);
            return new AsyncPagedEntityCursor<CustomList>(GetIndexAsPages(actualPageSize));
        }

        /// <summary>
        ///     Retrieves a list of created custom lists as pages of results
        /// </summary>
        /// <param name="pageSize">The size of the pages of results to return from the server</param>
        /// <returns>A cursor that can be used to iterate through the lists either syncronously or asyncronously</returns>
        public IAsyncCursor<ResultsPage<CustomList>> GetIndexAsPages(short? pageSize = null)
        {
            Ensure.IsValidExplicitPageSize(pageSize);
            var actualPageSize = GetPageSize(pageSize);
            return new AsyncPageCursor<CustomList>(GetIndexPage, GetIndexPageAsync, actualPageSize);
        }

        private async Task<ResultsPage<AbbreviatedPerson>> GetPeoplePageAsync(int listId,
            short pageSize, PagingTokens pagingTokens, CancellationToken cancellationToken)
        {
            var url = UrlProvider.GetV1ListPeopleIndexUrl(listId, pageSize, pagingTokens);
            return (await GetJsonAsync<ResultsPage<AbbreviatedPerson>>(url, cancellationToken)).Payload;
        }

        private ResultsPage<AbbreviatedPerson> GetPeoplePage(int listId, short pageSize, PagingTokens pagingTokens,
            CancellationToken cancellationToken)
        {
            var url = UrlProvider.GetV1ListPeopleIndexUrl(listId, pageSize, pagingTokens);
            return GetJson<ResultsPage<AbbreviatedPerson>>(url, cancellationToken).Payload;
        }

        /// <summary>
        ///     Retrieves people stored in a custom list
        /// </summary>
        /// <param name="listId">The ID of the custom list</param>
        /// <param name="pageSize">
        ///     The size of the pages of results to return from the server. If null it will use the default
        ///     value.
        /// </param>
        /// <returns>A cursor that can be used to iterate through the people either syncronously or asyncronously</returns>
        public IAsyncCursor<AbbreviatedPerson> GetPeople(int listId, short? pageSize = null)
        {
            Ensure.IsValidExplicitPageSize(pageSize);
            return new AsyncPagedEntityCursor<AbbreviatedPerson>(GetPeopleAsPages(listId, pageSize));
        }

        /// <summary>
        ///     Retrieves people stored in a custom list as pages of results
        /// </summary>
        /// <param name="listId">The ID of the custom list</param>
        /// <param name="pageSize">
        ///     The size of the pages of results to return from the server. If null it will use the default
        ///     value.
        /// </param>
        /// <returns>A cursor that can be used to iterate through the people either syncronously or asyncronously</returns>
        public IAsyncCursor<ResultsPage<AbbreviatedPerson>> GetPeopleAsPages(int listId, short? pageSize = null)
        {
            Ensure.IsValidExplicitPageSize(pageSize);
            var actualPageSize = GetPageSize(pageSize);
            return new AsyncPageCursor<AbbreviatedPerson>(
                (size, tokens, token) => GetPeoplePage(listId, actualPageSize, tokens, token),
                async (size, tokens, token) => await GetPeoplePageAsync(listId, actualPageSize, tokens, token),
                actualPageSize);
        }

        /// <summary>
        ///     Creates a custom list syncronously
        /// </summary>
        /// <param name="parameters">The options to use while creating the list</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The list that was created</returns>
        public CustomList Create(CreateListParameters parameters,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(parameters, nameof(parameters));

            var request = new CreateListRequest(parameters);
            var url = UrlProvider.GetV1ListCreateUrl();
            return PostJson<CreateListResponse>(url, request, cancellationToken).Payload.List;
        }

        /// <summary>
        ///     Creates a custom list asyncronously
        /// </summary>
        /// <param name="parameters">The options to use while creating the list</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The list that was created</returns>
        public async Task<CustomList> CreateAsync(CreateListParameters parameters,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(parameters, nameof(parameters));

            var request = new CreateListRequest(parameters);
            var url = UrlProvider.GetV1ListCreateUrl();
            return (await PostJsonAsync<CreateListResponse>(url, request, cancellationToken)).Payload.List;
        }

        /// <summary>
        ///     Updates a custom list syncronously
        /// </summary>
        /// <param name="listId">The ID of the list to update</param>
        /// <param name="parameters">The options to use while updating the list</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The updated list</returns>
        public CustomList Update(int listId, UpdateListParameters parameters,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(parameters, nameof(parameters));

            var request = new UpdateListRequest(parameters);
            var url = UrlProvider.GetV1ListUpdateUrl(listId);
            return PutJson<UpdateListResponse>(url, request, cancellationToken).Payload.List;
        }

        /// <summary>
        ///     Updates a custom list asyncronously
        /// </summary>
        /// <param name="listId">The ID of the list to update</param>
        /// <param name="parameters">The options to use while updating the list</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The updated list</returns>
        public async Task<CustomList> UpdateAsync(int listId, UpdateListParameters parameters,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(parameters, nameof(parameters));

            var request = new UpdateListRequest(parameters);
            var url = UrlProvider.GetV1ListUpdateUrl(listId);
            return (await PutJsonAsync<UpdateListResponse>(url, request, cancellationToken)).Payload.List;
        }

        /// <summary>
        ///     Deletes a custom list syncronously
        /// </summary>
        /// <param name="listId">The ID of the list to delete</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The updated list</returns>
        public void Delete(int listId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1ListDeleteUrl(listId);
            DeleteJson(url, cancellationToken);
        }

        /// <summary>
        ///     Deletes a custom list asyncronously
        /// </summary>
        /// <param name="listId">The ID of the list to delete</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The updated list</returns>
        public Task DeleteAsync(int listId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1ListDeleteUrl(listId);
            return DeleteJsonAsync(url, cancellationToken);
        }

        /// <summary>
        ///     Adds people to a custom list syncronously
        /// </summary>
        /// <param name="listId">The ID of the list to add people to</param>
        /// <param name="peopleIds">The IDs of the people to add to the list</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public void AddPeople(int listId, List<int> peopleIds,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(peopleIds, nameof(peopleIds));

            var url = UrlProvider.GetV1ListAddPeopleUrl(listId);
            var request = new AddListPeopleRequest(peopleIds);
            PostJson(url, request, cancellationToken);
        }

        /// <summary>
        ///     Adds people to a custom list asyncronously
        /// </summary>
        /// <param name="listId">The ID of the list to add people to</param>
        /// <param name="peopleIds">The IDs of the people to add to the list</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public Task AddPeopleAsync(int listId, List<int> peopleIds,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(peopleIds, nameof(peopleIds));

            var url = UrlProvider.GetV1ListAddPeopleUrl(listId);
            var request = new AddListPeopleRequest(peopleIds);
            return PostJsonAsync(url, request, cancellationToken);
        }

        /// <summary>
        ///     Removes people from the custom list syncronously
        /// </summary>
        /// <param name="listId">The ID of the list to remove people from</param>
        /// <param name="peopleIds">The IDs of the people to remove from the list</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public void RemovePeople(int listId, List<int> peopleIds,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(peopleIds, nameof(peopleIds));

            var url = UrlProvider.GetV1ListRemovePeopleUrl(listId);
            var request = new RemoveListPeopleRequest(peopleIds);
            DeleteJson(url, cancellationToken, content: request);
        }

        /// <summary>
        ///     Removes people from the custom list asyncronously
        /// </summary>
        /// <param name="listId">The ID of the list to remove people from</param>
        /// <param name="peopleIds">The IDs of the people to remove from the list</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public Task RemovePeopleAsync(int listId, List<int> peopleIds,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(peopleIds, nameof(peopleIds));

            var url = UrlProvider.GetV1ListRemovePeopleUrl(listId);
            var request = new RemoveListPeopleRequest(peopleIds);
            return DeleteJsonAsync(url, cancellationToken, content: request);
        }

        /// <summary>
        ///     Adds a tag to all of the people in the list syncronously. Note: this method will return immediately but the tag is
        ///     not applied immediately. For larger lists, this operation takes many minutes.
        /// </summary>
        /// <param name="listId">The ID of the list</param>
        /// <param name="tagName">The name of the tag to add</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public void AddTag(int listId, string tagName, CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNullOrWhitespace(tagName, nameof(tagName));

            var url = UrlProvider.GetV1ListAddTagUrl(listId, tagName);
            PostJson(url, null, cancellationToken);
        }

        /// <summary>
        ///     Adds a tag to all of the people in the list asyncronously. Note: this method will return immediately but the tag is
        ///     not applied immediately. For larger lists, this operation takes many minutes.
        /// </summary>
        /// <param name="listId">The ID of the list</param>
        /// <param name="tagName">The name of the tag to add</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public Task AddTagAsync(int listId, string tagName,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNullOrWhitespace(tagName, nameof(tagName));

            var url = UrlProvider.GetV1ListAddTagUrl(listId, tagName);
            return PostJsonAsync(url, null, cancellationToken);
        }

        /// <summary>
        ///     Removes a tag from all of the people in the list syncronously. Note: this method will return immediately but the
        ///     tag is not removed immediately. For larger lists, this operation takes many minutes.
        /// </summary>
        /// <param name="listId">The ID of the list</param>
        /// <param name="tagName">The name of the tag to remove</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public void RemoveTag(int listId, string tagName,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNullOrWhitespace(tagName, nameof(tagName));

            var url = UrlProvider.GetV1ListRemoveTagUrl(listId, tagName);
            DeleteJson(url, cancellationToken);
        }

        /// <summary>
        ///     Removes a tag from all of the people in the list asyncronously. Note: this method will return immediately but the
        ///     tag is not removed immediately. For larger lists, this operation takes many minutes.
        /// </summary>
        /// <param name="listId">The ID of the list</param>
        /// <param name="tagName">The name of the tag to remove</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public Task RemoveTagAsync(int listId, string tagName,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNullOrWhitespace(tagName, nameof(tagName));

            var url = UrlProvider.GetV1ListRemoveTagUrl(listId, tagName);
            return DeleteJsonAsync(url, cancellationToken);
        }
    }
}