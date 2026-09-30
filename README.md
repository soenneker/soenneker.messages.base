# Soenneker.Messages.Base
[![](https://img.shields.io/nuget/v/Soenneker.Messages.Base.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Messages.Base/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.messages.base/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.messages.base/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Messages.Base.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Messages.Base/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.messages.base/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.messages.base/actions/workflows/codeql.yml)

Defines shared envelope metadata for application messages serialized with System.Text.Json.

## Installation

```bash
dotnet add package Soenneker.Messages.Base
```

## Define a message

Derive the application payload from `Message` and give the type a stable, versioned identifier:

```csharp
using Soenneker.Messages.Base;
using System.Text.Json.Serialization;
using System.Text.Json;

public sealed class UserCreatedMessage : Message
{
    [JsonPropertyName("userId")]
    public required string UserId { get; set; }
}

var message = new UserCreatedMessage
{
    Type = "user.created.v1",
    Id = Guid.NewGuid().ToString("N"),
    Queue = "users",
    Sender = "accounts-api",
    CreatedAt = DateTimeOffset.UtcNow,
    UserId = userId
};
```

The base metadata uses the same JSON names with System.Text.Json:

```json
{
  "type": "user.created.v1",
  "id": "...",
  "queue": "users",
  "sender": "accounts-api",
  "createdAt": "2026-08-30T12:00:00+00:00",
  "userId": "..."
}
```

## Contract semantics

- `Type` identifies the payload contract. Change the version when consumers cannot read the new shape.
- `Id` is the message instance identifier and can be copied to a transport message ID for tracing or deduplication.
- `Queue` and `Sender` are envelope metadata; this package does not route or authenticate a message.
- `CreatedAt` should be the original UTC creation time, including when a message is retried.

C# `required` members provide compile-time initialization guidance, but deserializers and reflection can still produce missing or empty values. Validate messages at the trust boundary before routing or processing them.
