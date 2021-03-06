﻿using NationBuilderConnect.Webhooks.V4.Events.Payloads;

namespace NationBuilderConnect.Webhooks.V4.Events
{
    /// <summary>
    ///     Event that is sent to our server from NationBuilder when a person is changed
    /// </summary>
    public class PersonChanged : NationBuilderWebhookEvent<PersonChangedPayload>
    {
    }
}