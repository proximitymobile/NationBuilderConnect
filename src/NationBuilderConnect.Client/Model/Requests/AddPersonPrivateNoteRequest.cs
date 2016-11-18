using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    /// <summary>
    ///     Request sent to the API to add a private note to a person
    /// </summary>
    public class AddPersonPrivateNoteRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AddPersonPrivateNoteRequest" /> class
        /// </summary>
        /// <param name="content">The note content</param>
        public AddPersonPrivateNoteRequest(string content)
        {
            Note = new AddPersonNoteRequestNote(content);
        }

        /// <summary>
        ///     The note details
        /// </summary>
        [JsonProperty("note")]
        public AddPersonNoteRequestNote Note { get; private set; }

        /// <summary>
        ///     The note details
        /// </summary>
        public class AddPersonNoteRequestNote
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="AddPersonNoteRequestNote" /> class
            /// </summary>
            /// <param name="content">The note content</param>
            public AddPersonNoteRequestNote(string content)
            {
                Content = content;
            }

            /// <summary>
            ///     The note content
            /// </summary>
            [JsonProperty("content")]
            public string Content { get; private set; }
        }
    }
}