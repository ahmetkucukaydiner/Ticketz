using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ticketz.Application.Services.PaymentService;

public interface IPaymentService
{
    Task<PaymentResult> ProcessPayment(
        string cardNumber,
        string cardHolderName,
        string expirationDate,
        string cvv,
        decimal amount,
        CancellationToken cancellationToken);
}

public class PaymentResult
{
    public bool IsSuccessful { get; set; }
    public string? ErrorMessage { get; set; }
    public string? PaymentResultId { get; set; }
    public DateTime PaymentDate { get; set; }
} 