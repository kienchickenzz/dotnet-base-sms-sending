namespace BaseSmsSending.Application.Common.ApplicationServices.Sms;


public interface ISmsMessage
{
    string PhoneNumber { get; }
    string Message { get; }
}
