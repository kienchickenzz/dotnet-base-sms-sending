namespace BaseSmsSending.Application.Common.Exceptions;

using System.Net;

using BaseSmsSending.Domain.Common;


public class InternalServerException : DomainException
{
    public InternalServerException(string message, List<Error>? errors = default)
        : base(message, errors, HttpStatusCode.InternalServerError)
    {
    }
}
