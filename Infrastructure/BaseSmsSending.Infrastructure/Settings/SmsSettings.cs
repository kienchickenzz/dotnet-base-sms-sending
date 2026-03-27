namespace BaseSmsSending.Infrastructure.Settings;

public class SmsSettings
{
    public const string SectionName = "SmsSettings";

    public SmsProvider Provider { get; set; } = SmsProvider.Fake;

    /// <summary>
    /// Default recipient phone number for development/testing.
    /// Used when Twilio trial account only allows verified numbers.
    /// </summary>
    public string ToNumber { get; set; } = string.Empty;

    public TwilioSettings Twilio { get; set; } = new();
}

public class TwilioSettings
{
    public string AccountSId { get; set; } = string.Empty;
    public string AuthToken { get; set; } = string.Empty;
    public string FromNumber { get; set; } = string.Empty;
}

public enum SmsProvider
{
    Fake = 0,
    Twilio = 1
}
