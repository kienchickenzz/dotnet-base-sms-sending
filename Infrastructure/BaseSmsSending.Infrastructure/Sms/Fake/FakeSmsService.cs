namespace BaseSmsSending.Infrastructure.Sms.FakeSmsService;

using Microsoft.Extensions.Logging;

using BaseSmsSending.Application.Common.ApplicationServices.Sms;


public class FakeSmsService : ISmsService
{
    private readonly ILogger<FakeSmsService> _logger;

    public FakeSmsService(ILogger<FakeSmsService> logger)
    {
        _logger = logger;
    }

    public Task SendAsync(ISmsMessage message, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation(
            "[FAKE SMS] To: {PhoneNumber}, Message: {Message}",
            message.PhoneNumber,
            message.Message);

        return Task.CompletedTask;
    }
}
