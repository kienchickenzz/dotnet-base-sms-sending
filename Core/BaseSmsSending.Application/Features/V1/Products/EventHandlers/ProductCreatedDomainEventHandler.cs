/**
 * Handler for ProductCreatedDomainEvent.
 *
 * <p>Processes the event after a product is successfully created.
 * Sends SMS notification to configured recipient.</p>
 */

namespace BaseSmsSending.Application.Features.V1.Products.EventHandlers;

using Microsoft.Extensions.Logging;

using BaseSmsSending.Application.Common.ApplicationServices.Sms;
using BaseSmsSending.Application.Common.Messaging;
using BaseSmsSending.Domain.AggregatesModels.Products.Events;


/// <summary>
/// Handles ProductCreatedDomainEvent published via outbox pattern.
/// </summary>
public sealed class ProductCreatedDomainEventHandler : IDomainEventHandler<ProductCreatedDomainEvent>
{
    private readonly ILogger<ProductCreatedDomainEventHandler> _logger;
    private readonly ISmsService _smsService;
    private readonly ISmsMessageFactory _smsMessageFactory;

    public ProductCreatedDomainEventHandler(
        ILogger<ProductCreatedDomainEventHandler> logger,
        ISmsService smsService,
        ISmsMessageFactory smsMessageFactory)
    {
        _logger = logger;
        _smsService = smsService;
        _smsMessageFactory = smsMessageFactory;
    }

    /// <summary>
    /// Sends SMS notification when a new product is created.
    /// </summary>
    public async Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "[Domain Event] ProductCreated - Name: {ProductName}, Price: {Price:C}",
            notification.ProductName,
            notification.Price);

        try
        {
            // 1. Build SMS message using factory
            var smsMessage = _smsMessageFactory.CreateWithDefaultRecipient(
                $"[New Product] {notification.ProductName} created - Price: {notification.Price:C}");

            // 2. Send SMS
            await _smsService.SendAsync(smsMessage, cancellationToken);

            _logger.LogInformation(
                "[Domain Event] ProductCreated - SMS sent for product: {ProductName}",
                notification.ProductName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "[Domain Event] ProductCreated - Failed to send SMS for product: {ProductName}",
                notification.ProductName);
        }
    }
}
