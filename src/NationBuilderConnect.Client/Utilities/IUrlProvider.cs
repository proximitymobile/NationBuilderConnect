using NationBuilderConnect.Client.Model;
using NationBuilderConnect.Client.Services.Parameters;
using NationBuilderConnect.Model;

namespace NationBuilderConnect.Client.Utilities
{
    /// <summary>
    ///     Provides URLs to API service endpoints
    /// </summary>
    public interface IUrlProvider
    {
        /// <summary>
        ///     Gets the relative URL for the oauth authorize method
        /// </summary>
        /// <param name="responseType">The desired response type (defaults to code)</param>
        /// <param name="clientId">The client ID</param>
        /// <param name="redirectUri">Where to redirect the response to</param>
        /// <returns>The relative URL for the oauth authorize method</returns>
        string GetOAuthAuthorizeUrl(string clientId, string redirectUri, string responseType = "code");

        /// <summary>
        ///     Gets the relative URL for the oauth token method
        /// </summary>
        /// <returns>The relative URL for the oauth token method</returns>
        string GetOAuthTokenUrl();

        /// <summary>
        ///     Gets the base URL for a nation (ie https://{nationSlug}.nationbuilder.com)
        /// </summary>
        /// <param name="nationSlug">The nation slug</param>
        /// <returns>The base URL for a nation</returns>
        string GetNationRootUrl(string nationSlug);

        /// <summary>
        ///     Gets the relative URL for the people index method
        /// </summary>
        /// <param name="pageSize">The number of items to return from the server per page of results</param>
        /// <param name="pagingTokens">Paging values</param>
        /// <returns>The relative URL for the people index method</returns>
        string GetV1PersonIndexUrl(short pageSize, PagingTokens pagingTokens);

        /// <summary>
        ///     Gets the relative URL for the people count method
        /// </summary>
        /// <returns>The relative URL for the people count method</returns>
        string GetV1PersonCountUrl();

        /// <summary>
        ///     Gets the relative URL for the people show method
        /// </summary>
        /// <param name="personId">The person ID</param>
        /// <param name="idType">The type of ID to search on</param>
        /// <returns>The relative URL for the people show method</returns>
        string GetV1PersonShowUrl(int personId, PersonIdType idType);

        /// <summary>
        ///     Gets the relative URL for the people match method
        /// </summary>
        /// <param name="personParameters">The values to match on</param>
        /// <returns>The relative URL for the people match method</returns>
        string GetV1PersonMatchUrl(MatchPersonParameters personParameters);

        /// <summary>
        ///     Gets the relative URL for the people search method
        /// </summary>
        /// <param name="pageSize">The number of items to return from the server per page of results</param>
        /// <param name="pagingTokens">Paging values</param>
        /// <param name="parameters">The values to search on</param>
        /// <returns>Tthe relative URL for the people search method</returns>
        string GetV1PersonSearchUrl(short pageSize, PagingTokens pagingTokens, SearchPeopleParameters parameters);

        /// <summary>
        ///     Gets the relative URL for the people nearby method
        /// </summary>
        /// <param name="pageSize">The number of items to return from the server per page of results</param>
        /// <param name="pagingTokens">Paging values</param>
        /// <param name="parameters">The values to search on</param>
        /// <returns>Tthe relative URL for the people nearby method</returns>
        string GetV1PersonNearbyUrl(short pageSize, PagingTokens pagingTokens, GetNearbyPeopleParameters parameters);

        /// <summary>
        ///     Gets the relative URL for the people add tags method
        /// </summary>
        /// <param name="personId">The person ID</param>
        /// <returns>The relative URL for the people add tags method</returns>
        string GetV1PersonAddTagUrl(int personId);

        /// <summary>
        ///     Gets the relative URL for the people remove tags method
        /// </summary>
        /// <param name="personId">The person ID</param>
        /// <returns>The relative URL for the people remove tags method</returns>
        string GetV1PersonRemoveTagsUrl(int personId);

        /// <summary>
        ///     Gets the relative URL for the people add private note method
        /// </summary>
        /// <param name="personId">The person ID</param>
        /// <returns>The relative URL for the people add private note method</returns>
        string GetV1PersonAddPrivateNoteUrl(int personId);

        /// <summary>
        ///     Gets the relative URL for the people create method
        /// </summary>
        /// <returns>The relative URL for the people create method</returns>
        string GetV1PersonCreateUrl();

        /// <summary>
        ///     Gets the relative URL for the people update method
        /// </summary>
        /// <param name="personId">The person ID to update</param>
        /// <returns>The relative URL for the people update method</returns>
        string GetV1PersonUpdateUrl(int personId);

        /// <summary>
        ///     Gets the relative URL for the people push method
        /// </summary>
        /// <returns>The relative URL for the people push method</returns>
        string GetV1PersonPushUrl();

        /// <summary>
        ///     Gets the relative URL for the people add method
        /// </summary>
        /// <returns>The relative URL for the people add method</returns>
        string GetV1PersonAddUrl();

        /// <summary>
        ///     Gets the relative URL for the people destroy method
        /// </summary>
        /// <param name="personId">The person ID to remote</param>
        /// <returns>The relative URL for the people destroy method</returns>
        string GetV1PersonDestroyUrl(int personId);

        /// <summary>
        ///     Gets the relative URL for the people me method
        /// </summary>
        /// <returns>The relative URL for the people me method</returns>
        string GetV1PersonMeUrl();

        /// <summary>
        ///     Gets the relative URL for the contact create method
        /// </summary>
        /// <param name="personId">The ID of the person to create the contact for</param>
        /// <returns>The relative URL for the contact create method</returns>
        string GetV1ContactCreateUrl(int personId);

        /// <summary>
        ///     Gets the relative URL for the contact index method
        /// </summary>
        /// <param name="personId">The ID of the person for which to return contacts</param>
        /// <param name="pageSize">The number of items to return from the server per page of results</param>
        /// <param name="pagingTokens">Paging values</param>
        /// <returns>The relative URL for the contact index method</returns>
        string GetV1ContactIndexUrl(int personId, short pageSize, PagingTokens pagingTokens);

        /// <summary>
        ///     Gets the relative URL for the custom list index method
        /// </summary>
        /// <param name="pageSize">The number of items to return from the server per page of results</param>
        /// <param name="pagingTokens">Paging values</param>
        /// <returns>The relative URL for the custom list index method</returns>
        string GetV1ListIndexUrl(short pageSize, PagingTokens pagingTokens);

        /// <summary>
        ///     Gets the relative URL for the custom list people index method
        /// </summary>
        /// <param name="listId">The list ID</param>
        /// <param name="pageSize">The number of items to return from the server per page of results</param>
        /// <param name="pagingTokens">Paging values</param>
        /// <returns>The relative URL for the custom list people index method</returns>
        string GetV1ListPeopleIndexUrl(int listId, short pageSize, PagingTokens pagingTokens);

        /// <summary>
        ///     Gets the relative URL for the custom list create method
        /// </summary>
        /// <returns>The relative URL for the custom list create method</returns>
        string GetV1ListCreateUrl();

        /// <summary>
        ///     Gets the relative URL for the custom list update method
        /// </summary>
        /// <param name="listId">The list ID</param>
        /// <returns>The relative URL for the custom list update method</returns>
        string GetV1ListUpdateUrl(int listId);

        /// <summary>
        ///     Gets the relative URL for the custom list delete method
        /// </summary>
        /// <param name="listId">The list ID</param>
        /// <returns>The relative URL for the custom list delete method</returns>
        string GetV1ListDeleteUrl(int listId);

        /// <summary>
        ///     Gets the relative URL for the custom list add people method
        /// </summary>
        /// <param name="listId">The list ID</param>
        /// <returns>The relative URL for the custom list add people method</returns>
        string GetV1ListAddPeopleUrl(int listId);

        /// <summary>
        ///     Gets the relative URL for the custom list remove people method
        /// </summary>
        /// <param name="listId">The list ID</param>
        /// <returns>The relative URL for the custom list remove people method</returns>
        string GetV1ListRemovePeopleUrl(int listId);

        /// <summary>
        ///     Gets the relative URL for the custom list add people tag method
        /// </summary>
        /// <param name="listId">The list ID</param>
        /// <param name="tagName">The name of the tag to add to the people</param>
        /// <returns>The relative URL for the custom list add people tag method</returns>
        string GetV1ListAddTagUrl(int listId, string tagName);

        /// <summary>
        ///     Gets the relative URL for the custom list remove people tag method
        /// </summary>
        /// <param name="listId">The list ID</param>
        /// <param name="tagName">The name of the tag to remove from the people</param>
        /// <returns>The relative URL for the custom list remove people tag method</returns>
        string GetV1ListRemoveTagUrl(int listId, string tagName);

        /// <summary>
        ///     Gets the relative URL for the export create / run method
        /// </summary>
        /// <param name="listId">The ID of the list to export</param>
        /// <returns>The relative URL for the export create / run method</returns>
        string GetV1ExportCreateUrl(int listId);

        /// <summary>
        ///     Gets the relative URL for the export show method
        /// </summary>
        /// <param name="exportId">The export ID</param>
        /// <returns>The relative URL for the export show method</returns>
        string GetV1ExportShowUrl(int exportId);

        /// <summary>
        ///     Gets the relative URL for the export delete method
        /// </summary>
        /// <param name="exportId">The export ID</param>
        /// <returns>The relative URL for the export delete method</returns>
        string GetV1ExportDeleteUrl(int exportId);
    }
}