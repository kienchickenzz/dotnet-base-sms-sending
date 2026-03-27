namespace BaseSmsSending.Application.Common.ApplicationServices.Sms;


public interface ISmsService
{
    Task SendAsync(ISmsMessage message, CancellationToken cancellationToken = default);
}
