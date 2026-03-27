namespace BaseSmsSending.Infrastructure.Sms;

using Microsoft.Extensions.Options;

using BaseSmsSending.Application.Common.ApplicationServices.Sms;
using BaseSmsSending.Infrastructure.Settings;

public class SmsMessageFactory : ISmsMessageFactory
{
    private readonly SmsSettings _settings;

    public SmsMessageFactory(IOptions<SmsSettings> options)
    {
        _settings = options.Value;
    }

    public ISmsMessage Create(string phoneNumber, string message)
    {
        return new SmsMessage(phoneNumber, message);
    }

    public ISmsMessage CreateWithDefaultRecipient(string message)
    {
        if (string.IsNullOrWhiteSpace(_settings.ToNumber))
        {
            throw new InvalidOperationException(
                "ToNumber is not configured in SmsSettings. " +
                "Please set SmsSettings:ToNumber in appsettings.json for development.");
        }

        return new SmsMessage(_settings.ToNumber, message);
    }
}
