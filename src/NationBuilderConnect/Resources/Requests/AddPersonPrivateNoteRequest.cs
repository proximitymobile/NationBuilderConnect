using Newtonsoft.Json;

namespace NationBuilderConnect.Resources.Requests
{
    public class AddPersonPrivateNoteRequest
    {
        public AddPersonPrivateNoteRequest(string content)
        {
            Note = new AddPersonNoteRequestNote(content);
        }

        [JsonProperty("note")]
        public AddPersonNoteRequestNote Note { get; private set; }

        public class AddPersonNoteRequestNote
        {
            public AddPersonNoteRequestNote(string content)
            {
                Content = content;
            }

            [JsonProperty("content")]
            public string Content { get; private set; }
        }
    }
}