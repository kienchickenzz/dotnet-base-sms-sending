namespace BaseSmsSending.Infrastructure.Sms.TwilioSmsService;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

using BaseSmsSending.Application.Common.ApplicationServices.Sms;
using BaseSmsSending.Infrastructure.Settings;


public class TwilioSmsService : ISmsService
{
    private readonly TwilioSettings _settings;
    private readonly ILogger<TwilioSmsService> _logger;

    public TwilioSmsService(
        IOptions<SmsSettings> options,
        ILogger<TwilioSmsService> logger)
    {
        _settings = options.Value.Twilio;
        _logger = logger;
    }

    public async Task SendAsync(ISmsMessage smsMessage, CancellationToken cancellationToken = default)
    {
        TwilioClient.Init(_settings.AccountSId, _settings.AuthToken);

        var message = await MessageResource.CreateAsync(
            body: smsMessage.Message,
            from: new PhoneNumber(_settings.FromNumber),
            to: new PhoneNumber(smsMessage.PhoneNumber));

        if (!string.IsNullOrWhiteSpace(message?.Sid))
        {
            _logger.LogInformation(
                "SMS sent successfully. SID: {Sid}, To: {PhoneNumber}",
                message.Sid,
                smsMessage.PhoneNumber);
        }
        else
        {
            _logger.LogWarning(
                "SMS send failed. ErrorCode: {ErrorCode}, ErrorMessage: {ErrorMessage}",
                message?.ErrorCode,
                message?.ErrorMessage);
        }
    }
}
