[![](https://img.shields.io/nuget/v/Soenneker.Messages.Base.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Messages.Base/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.messages.base/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.messages.base/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Messages.Base.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Messages.Base/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.messages.base/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.messages.base/actions/workflows/codeql.yml)

# Soenneker.Messages.Base

Represents the base contract for a Service Bus message envelope.

## Install

```bash
dotnet add package Soenneker.Messages.Base
```

## What you get

- `Message` — Represents the base contract for a Service Bus message envelope.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `Message.Type` | Gets the stable message type identifier. | This value should remain stable across refactors and version changes (for example, `"user.created.v1"`). It is typically used by consumers to determine how the message should be processed. |
| `Message.Id` | Gets the unique identifier for this message instance. | This identifier is intended to be globally unique and stable for the lifetime of the message. It may be mapped to the underlying transport's message identifier (for example, Azure Service Bus `MessageId`) to support deduplication and tracing. |
| `Message.Queue` | Gets the logical or physical queue name associated with this message. | This value is required and is used for routing or validation within the messaging infrastructure. |
| `Message.Sender` | Gets the identifier of the originating service or machine. | This value identifies the source of the message and may represent a service name, application instance, or machine identifier depending on the hosting environment. |
| `Message.NewtonsoftSerialize` | Gets a value indicating whether this message should be serialized using Newtonsoft.Json instead of System.Text.Json. | This flag exists for interoperability scenarios where certain payloads are not compatible with System.Text.Json. It is optional and defaults to `false` if not specified. |
| `Message.CreatedAt` | Gets the UTC timestamp indicating when the message was created. | This value is required and should represent the original creation time of the message for auditing, ordering, and replay purposes. |

## Important behavior

- `Message`: This type defines the required metadata for routing, identity, and auditing within the messaging infrastructure. It is serializer-agnostic and supports both System.Text.Json and Newtonsoft.Json. All required properties must be supplied during object initialization or deserialization. No defaults are applied within this type.
- `Message.Type`: This value should remain stable across refactors and version changes (for example, `"user.created.v1"`). It is typically used by consumers to determine how the message should be processed.
- `Message.Id`: This identifier is intended to be globally unique and stable for the lifetime of the message. It may be mapped to the underlying transport's message identifier (for example, Azure Service Bus `MessageId`) to support deduplication and tracing.
- `Message.Queue`: This value is required and is used for routing or validation within the messaging infrastructure.
- `Message.Sender`: This value identifies the source of the message and may represent a service name, application instance, or machine identifier depending on the hosting environment.
- `Message.NewtonsoftSerialize`: This flag exists for interoperability scenarios where certain payloads are not compatible with System.Text.Json. It is optional and defaults to `false` if not specified.
- `Message.CreatedAt`: This value is required and should represent the original creation time of the message for auditing, ordering, and replay purposes.
