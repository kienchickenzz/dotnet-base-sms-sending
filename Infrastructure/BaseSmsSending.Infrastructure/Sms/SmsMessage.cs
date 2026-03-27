namespace BaseSmsSending.Infrastructure.Sms;

using BaseSmsSending.Application.Common.ApplicationServices.Sms;

public record SmsMessage(string PhoneNumber, string Message) : ISmsMessage;
