using System.Collections.Generic;
using System.Net;
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
    ///     Access to the NationBuilder People API
    /// </summary>
    public class PersonService : NationBuilderApiService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PersonService" /> class
        /// </summary>
        /// <param name="options">
        ///     Options to use for each request issued from this instance of the service. Overrides default
        ///     values provided while initializing the client.
        /// </param>
        public PersonService(RequestOptions options = null) : base(options)
        {
        }

        private async Task<ResultsPage<AbbreviatedPerson>> GetIndexPageAsync(short pageSize, PagingTokens pagingTokens,
            CancellationToken cancellationToken)
        {
            var url = UrlProvider.GetV1PersonIndexUrl(pageSize, pagingTokens);
            return (await GetJsonAsync<ResultsPage<AbbreviatedPerson>>(url, cancellationToken)).Payload;
        }

        private ResultsPage<AbbreviatedPerson> GetIndexPage(short pageSize, PagingTokens pagingTokens,
            CancellationToken cancellationToken)
        {
            var url = UrlProvider.GetV1PersonIndexUrl(pageSize, pagingTokens);
            return GetJson<ResultsPage<AbbreviatedPerson>>(url, cancellationToken).Payload;
        }

        /// <summary>
        ///     Retrieves the list of people in a nation. The results are of type <see cref="AbbreviatedPerson" />, to get a full
        ///     represenation of a person (<see cref="Person" />) use the Show/ShowAsync methods.
        /// </summary>
        /// <param name="pageSize">The size of the pages of results to return from the server. If null it will use the default value.</param>
        /// <returns>A cursor that can be used to iterate through the people either syncronously or asyncronously</returns>
        public IAsyncCursor<AbbreviatedPerson> GetIndex(short? pageSize = null)
        {
            return new AsyncPagedEntityCursor<AbbreviatedPerson>(GetIndexAsPages(pageSize));
        }

        /// <summary>
        ///     Retrieves the list of people in a nation as pages of results. The results are of type
        ///     <see cref="AbbreviatedPerson" />, to get a full represenation of a person (<see cref="Person" />) use the
        ///     Show/ShowAsync methods.
        /// </summary>
        /// <param name="pageSize">The size of the pages of results to return from the server. If null it will use the default value.</param>
        /// <returns>A cursor that can be used to iterate through the people either syncronously or asyncronously</returns>
        public IAsyncCursor<ResultsPage<AbbreviatedPerson>> GetIndexAsPages(short? pageSize = null)
        {
            Ensure.IsValidExplicitPageSize(pageSize);
            var actualPageSize = GetPageSize(pageSize);
            return new AsyncPageCursor<AbbreviatedPerson>(GetIndexPage, GetIndexPageAsync, actualPageSize);
        }

        /// <summary>
        ///     Get a total count of all the people in the nation asyncronously
        /// </summary>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The total number of people in the nation</returns>
        public async Task<int> GetCountAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1PersonCountUrl();
            var result = await GetJsonAsync<CountPeopleResponse>(url, cancellationToken);
            return result.Payload.Count;
        }

        /// <summary>
        ///     Get a total count of all the people in the nation syncronously
        /// </summary>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The total number of people in the nation</returns>
        public int GetCount(CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1PersonCountUrl();
            var result = GetJson<CountPeopleResponse>(url, cancellationToken);
            return result.Payload.Count;
        }

        /// <summary>
        ///     Returns the full representation of a person asyncronously
        /// </summary>
        /// <param name="personId">The ID of the person</param>
        /// <param name="throwOnNotFound">
        ///     Whether to throw an exception if the person is not found. If false, null will be returned
        ///     if the person is not found.
        /// </param>
        /// <param name="idType">Type of id to use, set to 'External' to find the person based on their external id</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>A <see cref="ShowPersonResponse" /> which contains the full person representation and their precinct.</returns>
        public async Task<ShowPersonResponse> ShowAsync(int personId, bool throwOnNotFound = false,
            PersonIdType idType = PersonIdType.NationBuilder,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1PersonShowUrl(personId, idType);
            var result = await GetJsonAsync<ShowPersonResponse>(url, cancellationToken, throwOnNotFound);
            ThrowIfApiFail(result, throwOnNotFound);
            return result.Payload;
        }

        /// <summary>
        ///     Returns the full representation of a person syncronously
        /// </summary>
        /// <param name="personId">The ID of the person</param>
        /// <param name="throwOnNotFound">
        ///     Whether to throw an <see cref="ApiCallFailedException" /> if the person is not found. If
        ///     false, null will be returned if the person is not found.
        /// </param>
        /// <param name="idType">Type of id to use, set to 'External' to find the person based on their external id</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The full person representation and their precinct</returns>
        public ShowPersonResponse Show(int personId, bool throwOnNotFound = false,
            PersonIdType idType = PersonIdType.NationBuilder,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1PersonShowUrl(personId, idType);
            var result = GetJson<ShowPersonResponse>(url, cancellationToken, throwOnNotFound);
            ThrowIfApiFail(result, throwOnNotFound);
            return result.Payload;
        }

        /// <summary>
        ///     Finds a person with certain attributes asyncronously. If more than one matching person is found, an
        ///     <see cref="ApiCallFailedException" /> will be thrown. If no match is found either an
        ///     <see cref="ApiCallFailedException" /> will be thrown or null will be returned depending on the throwOnNotFound
        ///     parameter.
        /// </summary>
        /// <param name="parameters">The attributes with which to attempt to find a matching person</param>
        /// <param name="throwOnNotFound">
        ///     Whether to throw an <see cref="ApiCallFailedException" /> if a match is not found. If
        ///     false, null will be returned if a match is not found.
        /// </param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The full person representation and their precinct</returns>
        public async Task<MatchPersonResponse> MatchAsync(MatchPersonParameters parameters, bool throwOnNotFound = false,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1PersonMatchUrl(parameters);
            var result = await GetJsonAsync<MatchPersonResponse>(url, cancellationToken, throwOnNotFound);
            ThrowIfApiFail(result, throwOnNotFound);
            return result.Payload;
        }

        /// <summary>
        ///     Gets the person whose credentials are currently being used to access to API syncronously
        /// </summary>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The full person representation and their precinct</returns>
        public MePersonResponse GetMe(CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1PersonMeUrl();
            var result = GetJson<MePersonResponse>(url, cancellationToken);
            return result.Payload;
        }

        /// <summary>
        ///     Gets the person whose credentials are currently being used to access to API asyncronously
        /// </summary>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The full person representation and their precinct</returns>
        public async Task<MePersonResponse> GetMeAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1PersonMeUrl();
            var result = await GetJsonAsync<MePersonResponse>(url, cancellationToken);
            return result.Payload;
        }

        /// <summary>
        ///     Finds a person with certain attributes syncronously. If more than one matching person is found, an
        ///     <see cref="ApiCallFailedException" /> will be thrown. If no match is found either an
        ///     <see cref="ApiCallFailedException" /> will be thrown or null will be returned depending on the throwOnNotFound
        ///     parameter.
        /// </summary>
        /// <param name="parameters">The attributes with which to attempt to find a matching person</param>
        /// <param name="throwOnNotFound">
        ///     Whether to throw an <see cref="ApiCallFailedException" /> if a match is not found. If
        ///     false, null will be returned if a match is not found.
        /// </param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The full person representation and their precinct</returns>
        public MatchPersonResponse Match(MatchPersonParameters parameters, bool throwOnNotFound = false,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1PersonMatchUrl(parameters);
            var result = GetJson<MatchPersonResponse>(url, cancellationToken, throwOnNotFound);
            ThrowIfApiFail(result, throwOnNotFound);
            return result.Payload;
        }

        private async Task<ResultsPage<AbbreviatedPerson>> GetSearchPageAsync(short pageSize, PagingTokens pagingTokens,
            SearchPeopleParameters parameters, CancellationToken cancellationToken)
        {
            var url = UrlProvider.GetV1PersonSearchUrl(pageSize, pagingTokens, parameters);
            return (await GetJsonAsync<ResultsPage<AbbreviatedPerson>>(url, cancellationToken)).Payload;
        }

        private ResultsPage<AbbreviatedPerson> GetSearchPage(short pageSize, PagingTokens pagingTokens,
            SearchPeopleParameters parameters, CancellationToken cancellationToken)
        {
            var url = UrlProvider.GetV1PersonSearchUrl(pageSize, pagingTokens, parameters);
            return GetJson<ResultsPage<AbbreviatedPerson>>(url, cancellationToken).Payload;
        }

        /// <summary>
        ///     Searches for people with specific attributes as pages of results
        /// </summary>
        /// <param name="parameters">The attributes used to search for people</param>
        /// <param name="pageSize">The size of the pages of results to return from the server. If null it will use the default value.</param>
        /// <returns>A cursor that can be used to iterate through the pages of people either syncronously or asyncronously</returns>
        public IAsyncCursor<ResultsPage<AbbreviatedPerson>> SearchAsPages(SearchPeopleParameters parameters,
            short? pageSize = null)
        {
            Ensure.IsNotNull(parameters, nameof(parameters));
            Ensure.IsValidExplicitPageSize(pageSize);

            var actualPageSize = GetPageSize(pageSize);

            return new AsyncPageCursor<AbbreviatedPerson>(
                (size, tokens, token) => GetSearchPage(actualPageSize, tokens, parameters, token),
                async (size, tokens, token) => await GetSearchPageAsync(actualPageSize, tokens, parameters, token),
                actualPageSize);
        }

        /// <summary>
        ///     Searches for people with specific attributes
        /// </summary>
        /// <param name="parameters">The attributes used to search for people</param>
        /// <param name="pageSize">The size of the pages of results to return from the server. If null it will use the default value.</param>
        /// <returns>A cursor that can be used to iterate through the people either syncronously or asyncronously</returns>
        public IAsyncCursor<AbbreviatedPerson> Search(SearchPeopleParameters parameters, short? pageSize = null)
        {
            return new AsyncPagedEntityCursor<AbbreviatedPerson>(SearchAsPages(parameters, pageSize));
        }

        private async Task<ResultsPage<Person>> GetNearbyPageAsync(short pageSize, PagingTokens pagingTokens,
            GetNearbyPeopleParameters parameters, CancellationToken cancellationToken)
        {
            Ensure.IsValidPageSize(pageSize);

            var url = UrlProvider.GetV1PersonNearbyUrl(pageSize, pagingTokens, parameters);
            return (await GetJsonAsync<ResultsPage<Person>>(url, cancellationToken)).Payload;
        }

        private ResultsPage<Person> GetNearbyPage(short pageSize, PagingTokens pagingTokens,
            GetNearbyPeopleParameters parameters, CancellationToken cancellationToken)
        {
            Ensure.IsValidPageSize(pageSize);

            var url = UrlProvider.GetV1PersonNearbyUrl(pageSize, pagingTokens, parameters);
            return GetJson<ResultsPage<Person>>(url, cancellationToken).Payload;
        }

        /// <summary>
        ///     Searches for people near a location defined by latitude and longitude as pages of results
        /// </summary>
        /// <param name="parameters">The attributes used to search for people</param>
        /// <param name="pageSize">The size of the pages of results to return from the server. If null it will use the default value.</param>
        /// <returns>A cursor that can be used to iterate through the pages of people either syncronously or asyncronously</returns>
        public IAsyncCursor<ResultsPage<Person>> GetNearbyAsPages(GetNearbyPeopleParameters parameters,
            short? pageSize = null)
        {
            Ensure.IsNotNull(parameters, nameof(parameters));
            Ensure.IsValidExplicitPageSize(pageSize);

            var actualPageSize = GetPageSize(pageSize);

            return new AsyncPageCursor<Person>(
                (size, tokens, token) => GetNearbyPage(actualPageSize, tokens, parameters, token),
                async (size, tokens, token) => await GetNearbyPageAsync(actualPageSize, tokens, parameters, token),
                actualPageSize);
        }

        /// <summary>
        ///     Searches for people near a location defined by latitude and longitude
        /// </summary>
        /// <param name="parameters">The attributes used to search for people</param>
        /// <param name="pageSize">The size of the pages of results to return from the server. If null it will use the default value.</param>
        /// <returns>A cursor that can be used to iterate through the people either syncronously or asyncronously</returns>
        public IAsyncCursor<Person> GetNearby(GetNearbyPeopleParameters parameters, short? pageSize = null)
        {
            return new AsyncPagedEntityCursor<Person>(GetNearbyAsPages(parameters, pageSize));
        }

        /// <summary>
        ///     Adds one or more tags to a person syncronously
        /// </summary>
        /// <param name="personId">The ID of the person</param>
        /// <param name="tagNames">The list of tags to add</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public void AddTags(int personId, List<string> tagNames,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.DoesNotContainNullOrWhitespace(tagNames, nameof(tagNames));

            var request = new AddPersonTagsRequest(tagNames);
            var url = UrlProvider.GetV1PersonAddTagUrl(personId);
            PutJson(url, request, cancellationToken);
        }

        /// <summary>
        ///     Adds one or more tags to a person asyncronously
        /// </summary>
        /// <param name="personId">The ID of the person</param>
        /// <param name="tagNames">The list of tags to add</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public Task AddTagsAsync(int personId, List<string> tagNames,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.DoesNotContainNullOrWhitespace(tagNames, nameof(tagNames));

            var request = new AddPersonTagsRequest(tagNames);
            var url = UrlProvider.GetV1PersonAddTagUrl(personId);
            return PutJsonAsync(url, request, cancellationToken);
        }

        /// <summary>
        ///     Removes one or more tags from a person syncronously
        /// </summary>
        /// <param name="personId">The ID of the person</param>
        /// <param name="tagNames">The list of tags to remove</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public void RemoveTags(int personId, List<string> tagNames,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.DoesNotContainNullOrWhitespace(tagNames, nameof(tagNames));

            var url = UrlProvider.GetV1PersonRemoveTagsUrl(personId);
            var request = new RemovePersonTagsRequest(tagNames);
            DeleteJson(url, cancellationToken, content: request);
        }

        /// <summary>
        ///     Removes one or more tags from a person asyncronously
        /// </summary>
        /// <param name="personId">The ID of the person</param>
        /// <param name="tagNames">The list of tags to remove</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public Task RemoveTagsAsync(int personId, List<string> tagNames,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.DoesNotContainNullOrWhitespace(tagNames, nameof(tagNames));

            var url = UrlProvider.GetV1PersonRemoveTagsUrl(personId);
            var request = new RemovePersonTagsRequest(tagNames);
            return DeleteJsonAsync(url, cancellationToken, content: request);
        }

        /// <summary>
        ///     Adds a private note to a person syncronously
        /// </summary>
        /// <param name="personId">The ID of the person</param>
        /// <param name="noteContent">The content of the note</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public void AddPrivateNote(int personId, string noteContent,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNullOrWhitespace(noteContent, nameof(noteContent));

            var url = UrlProvider.GetV1PersonAddPrivateNoteUrl(personId);
            var request = new AddPersonPrivateNoteRequest(noteContent);
            PostJson(url, request, cancellationToken);
        }

        /// <summary>
        ///     Adds a private note to a person asyncronously
        /// </summary>
        /// <param name="personId">The ID of the person</param>
        /// <param name="noteContent">The content of the note</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public Task AddPrivateNoteAsync(int personId, string noteContent,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNullOrWhitespace(noteContent, nameof(noteContent));

            var url = UrlProvider.GetV1PersonAddPrivateNoteUrl(personId);
            var request = new AddPersonPrivateNoteRequest(noteContent);
            return PostJsonAsync(url, request, cancellationToken);
        }

        /// <summary>
        ///     Creates a person syncronously. 
        /// </summary>
        /// <param name="update">The values used to create the person</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The full represenation of the created person and their precinct</returns>
        public CreatePersonResponse Create(PersonUpdate update, CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(update, nameof(update));

            var url = UrlProvider.GetV1PersonCreateUrl();
            var content = ObjectChangesJsonSerializer.SerializeChangesToJson(null, new CreatePersonRequest(update));
            return PostJson<CreatePersonResponse>(url, content, cancellationToken, true).Payload;
        }

        /// <summary>
        ///     Creates a person asyncronously. 
        /// </summary>
        /// <param name="update">The values used to create the person</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The full represenation of the created person and their precinct</returns>
        public async Task<CreatePersonResponse> CreateAsync(PersonUpdate update, CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(update, nameof(update));

            var url = UrlProvider.GetV1PersonCreateUrl();
            var content = ObjectChangesJsonSerializer.SerializeChangesToJson(null, new CreatePersonRequest(update));
            return (await PostJsonAsync<CreatePersonResponse>(url, content, cancellationToken, true)).Payload;
        }

        /// <summary>
        ///     Updates a person with the provided id to have the provided data syncronously. It returns a full representation of
        ///     the updated person.
        /// </summary>
        /// <param name="personId">The ID of the person to update</param>
        /// <param name="update">The values to update</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The full represenation of the updated person and their precinct</returns>
        public UpdatePersonResponse Update(int personId, PersonUpdate update,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(update, nameof(update));

            var url = UrlProvider.GetV1PersonUpdateUrl(personId);
            var content = ObjectChangesJsonSerializer.SerializeChangesToJson(null, new UpdatePersonRequest(update));
            return PutJson<UpdatePersonResponse>(url, content, cancellationToken, true).Payload;
        }

        /// <summary>
        ///     Updates a person with the provided id to have the provided data asyncronously. It returns a full representation of
        ///     the updated person.
        /// </summary>
        /// <param name="personId">The ID of the person to update</param>
        /// <param name="update">The values to update</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The full represenation of the updated person and their precinct</returns>
        public async Task<UpdatePersonResponse> UpdateAsync(int personId, PersonUpdate update,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(update, nameof(update));

            var url = UrlProvider.GetV1PersonUpdateUrl(personId);
            var content = ObjectChangesJsonSerializer.SerializeChangesToJson(null, new UpdatePersonRequest(update));
            return (await PutJsonAsync<UpdatePersonResponse>(url, content, cancellationToken, true)).Payload;
        }

        /// <summary>
        ///     Attempts to match the input person resource to a person already in the nation syncronously.
        ///     If a match is found, the matched person is updated (with overriding data).
        ///     If a match is not found, a new person is created. Matches are found using one of the following IDs:
        ///     CiviCrmId, CountyFileId, CatalistId, ExternalId, Email, FacebookUsername, NgpId, SalesForceId, TwitterLogin, VanId.
        /// </summary>
        /// <param name="update">The values to update / match on</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The full represenation of the updated person, their precinct and whether they were created or updated</returns>
        public PushPersonResponse Push(PersonUpdate update,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(update, nameof(update));

            var url = UrlProvider.GetV1PersonPushUrl();
            var content = ObjectChangesJsonSerializer.SerializeChangesToJson(null, new UpdatePersonRequest(update));
            var response = PutJson<PushPersonResponse>(url, content, cancellationToken, true);
            response.Payload.WasNewPersonCreated = response.HttpStatusCode == HttpStatusCode.Created;
            return response.Payload;
        }

        /// <summary>
        ///     Attempts to match the input person resource to a person already in the nation asyncronously.
        ///     If a match is found, the matched person is updated (with overriding data).
        ///     If a match is not found, a new person is created. Matches are found using one of the following IDs:
        ///     CiviCrmId, CountyFileId, CatalistId, ExternalId, Email, FacebookUsername, NgpId, SalesForceId, TwitterLogin, VanId.
        /// </summary>
        /// <param name="update">The values to update / match on</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The full represenation of the updated person, their precinct and whether they were created or updated</returns>
        public async Task<PushPersonResponse> PushAsync(PersonUpdate update,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(update, nameof(update));

            var url = UrlProvider.GetV1PersonPushUrl();
            var content = ObjectChangesJsonSerializer.SerializeChangesToJson(null, new UpdatePersonRequest(update));
            var response = await PutJsonAsync<PushPersonResponse>(url, content, cancellationToken, true);
            response.Payload.WasNewPersonCreated = response.HttpStatusCode == HttpStatusCode.Created;
            return response.Payload;
        }

        /// <summary>
        ///     Attempts to match the input person resource to a person already in the nation syncronously.
        ///     If a match is found, the matched person is updated (without overriding data).
        ///     If a match is not found, a new person is created. Matches are found using one of the following IDs:
        ///     CiviCrmId, CountyFileId, CatalistId, ExternalId, Email, FacebookUsername, NgpId, SalesForceId, TwitterLogin, VanId.
        /// </summary>
        /// <param name="update">The values to update / match on</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The full represenation of the updated person, their precinct and whether they were created or updated</returns>
        public AddPersonResponse Add(PersonUpdate update,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(update, nameof(update));

            var url = UrlProvider.GetV1PersonAddUrl();
            var content = ObjectChangesJsonSerializer.SerializeChangesToJson(null, new UpdatePersonRequest(update));
            var response = PutJson<AddPersonResponse>(url, content, cancellationToken, true);
            response.Payload.WasNewPersonCreated = response.HttpStatusCode == HttpStatusCode.Created;
            return response.Payload;
        }

        /// <summary>
        ///     Attempts to match the input person resource to a person already in the nation asyncronously.
        ///     If a match is found, the matched person is updated (without overriding data).
        ///     If a match is not found, a new person is created. Matches are found using one of the following IDs:
        ///     CiviCrmId, CountyFileId, CatalistId, ExternalId, Email, FacebookUsername, NgpId, SalesForceId, TwitterLogin, VanId.
        /// </summary>
        /// <param name="update">The values to update / match on</param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        /// <returns>The full represenation of the updated person, their precinct and whether they were created or updated</returns>
        public async Task<AddPersonResponse> AddAsync(PersonUpdate update,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(update, nameof(update));

            var url = UrlProvider.GetV1PersonAddUrl();
            var content = ObjectChangesJsonSerializer.SerializeChangesToJson(null, new UpdatePersonRequest(update));
            var response = await PutJsonAsync<AddPersonResponse>(url, content, cancellationToken, true);
            response.Payload.WasNewPersonCreated = response.HttpStatusCode == HttpStatusCode.Created;
            return response.Payload;
        }

        /// <summary>
        ///     Removes a person syncronously
        /// </summary>
        /// <param name="personId">The ID of the pserson</param>
        /// <param name="throwOnNotFound"> Whether to throw an exception if the person is not found. </param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public void Destroy(int personId, bool throwOnNotFound = true,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1PersonDestroyUrl(personId);
            var result = DeleteJson(url, cancellationToken, throwOnNotFound);
            ThrowIfApiFail(result, throwOnNotFound);
        }

        /// <summary>
        ///     Removes a person asyncronously
        /// </summary>
        /// <param name="personId">The ID of the pserson</param>
        /// <param name="throwOnNotFound"> Whether to throw an exception if the person is not found. </param>
        /// <param name="cancellationToken">Token allowing the request to be cancelled</param>
        public async Task DestroyAsync(int personId, bool throwOnNotFound = true,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var url = UrlProvider.GetV1PersonDestroyUrl(personId);
            var result = await DeleteJsonAsync(url, cancellationToken, throwOnNotFound);
            ThrowIfApiFail(result, throwOnNotFound);
        }
    }
}