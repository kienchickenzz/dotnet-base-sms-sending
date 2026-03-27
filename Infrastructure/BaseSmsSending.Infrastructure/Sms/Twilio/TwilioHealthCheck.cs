namespace BaseSmsSending.Infrastructure.Sms.TwilioSmsService;

using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010;

using BaseSmsSending.Infrastructure.Settings;


public class TwilioHealthCheck : IHealthCheck
{
    private readonly TwilioSettings _settings;

    public TwilioHealthCheck(IOptions<SmsSettings> options)
    {
        _settings = options.Value.Twilio;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            TwilioClient.Init(_settings.AccountSId, _settings.AuthToken);

            var account = await AccountResource.FetchAsync();

            return account?.Status == AccountResource.StatusEnum.Active
                ? HealthCheckResult.Healthy("Twilio account is active")
                : HealthCheckResult.Degraded($"Twilio account status: {account?.Status}");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy("Twilio connection failed", ex);
        }
    }
}
