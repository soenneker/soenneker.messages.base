using System;
using System.Text.Json.Serialization;
using Ardalis.SmartEnum.SystemTextJson;
using Newtonsoft.Json;
using Soenneker.Enums.ServiceBusQueue;
using Soenneker.Utils.Environment;

namespace Soenneker.Messages.Base;

/// <summary>
/// A fundamental Azure Service Bus message class <para/>
/// Messages are specific to a particular bus
/// </summary>
public abstract class Message
{
    [JsonPropertyName("queue")]
    [JsonProperty("queue")]
    [System.Text.Json.Serialization.JsonConverter(typeof(SmartEnumNameConverter<ServiceBusQueue, int>))]
    [Newtonsoft.Json.JsonConverter(typeof(Ardalis.SmartEnum.JsonNet.SmartEnumNameConverter<ServiceBusQueue, int>))]
    public ServiceBusQueue Queue { get; set; }

    /// <summary>
    /// Defaults to machine name
    /// </summary>
    [JsonPropertyName("sender")]
    [JsonProperty("sender")]
    public string Sender { get; set; }

    /// <summary>
    /// Defaults to false, but should be true with things that can't handle system.text.json yet (i.e. AdaptiveCards)
    /// </summary>
    [JsonPropertyName("newtonsoftSerialize")]
    [JsonProperty("newtonsoftSerialize")]
    public bool NewtonsoftSerialize { get; set; }

    [JsonPropertyName("createdAt")]
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }

    protected Message(ServiceBusQueue queue)
    {
        Queue = queue;
        NewtonsoftSerialize = false;
        Sender = EnvironmentUtil.GetMachineName();
        CreatedAt = DateTime.UtcNow;
    }
}