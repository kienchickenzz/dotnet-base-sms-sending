namespace BaseSmsSending.Application.Common.ApplicationServices.Sms;

public interface ISmsMessageFactory
{
    ISmsMessage Create(string phoneNumber, string message);

    /// <summary>
    /// Creates SMS message using default ToNumber from settings (for dev/testing).
    /// </summary>
    ISmsMessage CreateWithDefaultRecipient(string message);
}
