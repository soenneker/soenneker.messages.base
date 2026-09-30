using System;
using System.Text.Json.Serialization;

namespace Soenneker.Messages.Base;

/// <summary>
/// Represents the base contract for a Service Bus message envelope.
/// </summary>
/// <remarks>
/// This type defines the required metadata for routing, identity, and auditing
/// within the messaging infrastructure. It supports
/// System.Text.Json.
/// 
/// All required properties must be supplied during object initialization or
/// deserialization. No defaults are applied within this type.
/// </remarks>
public abstract class Message
{
    /// <summary>
    /// Gets the stable message type identifier.
    /// </summary>
    /// <remarks>
    /// This value should remain stable across refactors and version changes
    /// (for example, <c>"user.created.v1"</c>). It is typically used by
    /// consumers to determine how the message should be processed.
    /// </remarks>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// Gets the unique identifier for this message instance.
    /// </summary>
    /// <remarks>
    /// This identifier is intended to be globally unique and stable for the
    /// lifetime of the message. It may be mapped to the underlying transport's
    /// message identifier (for example, Azure Service Bus <c>MessageId</c>)
    /// to support deduplication and tracing.
    /// </remarks>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Gets the logical or physical queue name associated with this message.
    /// </summary>
    /// <remarks>
    /// This value is required and is used for routing or validation within
    /// the messaging infrastructure.
    /// </remarks>
    [JsonPropertyName("queue")]
    public required string Queue { get; set; }

    /// <summary>
    /// Gets the identifier of the originating service or machine.
    /// </summary>
    /// <remarks>
    /// This value identifies the source of the message and may represent a
    /// service name, application instance, or machine identifier depending
    /// on the hosting environment.
    /// </remarks>
    [JsonPropertyName("sender")]
    public required string Sender { get; set; }

    /// <summary>
    /// Gets the UTC timestamp indicating when the message was created.
    /// </summary>
    /// <remarks>
    /// This value is required and should represent the original creation time
    /// of the message for auditing, ordering, and replay purposes.
    /// </remarks>
    [JsonPropertyName("createdAt")]
    public required DateTimeOffset CreatedAt { get; set; }
}