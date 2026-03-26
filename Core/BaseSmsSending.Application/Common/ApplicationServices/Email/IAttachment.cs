// /**
//  * Contract for email attachment.
//  *
//  * <p>Defines the structure for file attachments in email messages.
//  * Infrastructure layer provides concrete implementation.</p>
//  */

// namespace BaseMailSending.Application.Common.ApplicationServices.Email;

// /// <summary>
// /// Represents an email attachment contract.
// /// Uses byte[] for easy serialization (outbox pattern compatibility).
// /// </summary>
// public interface IAttachment
// {
//     /// <summary>
//     /// Name of the attachment file (e.g., "report.pdf").
//     /// </summary>
//     string FileName { get; }

//     /// <summary>
//     /// Binary content of the attachment.
//     /// </summary>
//     byte[] Content { get; }
// }
