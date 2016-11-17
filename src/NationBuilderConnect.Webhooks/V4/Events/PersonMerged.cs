using NationBuilderConnect.Webhooks.V4.Events.Payloads;

namespace NationBuilderConnect.Webhooks.V4.Events
{
    /// <summary>
    ///     Event that is sent to our server from NationBuilder when 2 person records are merged
    /// </summary>
    public class PersonMerged : NationBuilderWebhookEvent<PersonMergedPayload>
    {
    }
}