using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Services.PaymentService;

namespace Ticketz.Infrastructure.ExternalServices.Payment;

public class DummyPaymentService : IPaymentService
{
    private readonly Random _random = new Random();
    private readonly List<string> _validCardNumbers = new List<string>
    {
        "4111111111111111", 
        "5555555555554444", 
        "378282246310005",  
        "6011111111111117"  
    };

    public async Task<PaymentResult> ProcessPayment(
        string cardNumber,
        string cardHolderName,
        string expirationDate,
        string cvv,
        decimal amount,
        CancellationToken cancellationToken)
    {
        await Task.Delay(1000, cancellationToken);

        if (!IsValidCardNumber(cardNumber))
        {
            return new PaymentResult
            {
                IsSuccessful = false,
                ErrorMessage = "Geçersiz kart numarası.",
                PaymentDate = DateTime.Now
            };
        }

        if (!IsValidExpirationDate(expirationDate))
        {
            return new PaymentResult
            {
                IsSuccessful = false,
                ErrorMessage = "Geçersiz son kullanma tarihi. Format: MM/YY",
                PaymentDate = DateTime.Now
            };
        }

        if (!IsValidCvv(cvv))
        {
            return new PaymentResult
            {
                IsSuccessful = false,
                ErrorMessage = "Geçersiz CVV kodu.",
                PaymentDate = DateTime.Now
            };
        }

        if (string.IsNullOrWhiteSpace(cardHolderName))
        {
            return new PaymentResult
            {
                IsSuccessful = false,
                ErrorMessage = "Kart sahibi adı gereklidir.",
                PaymentDate = DateTime.Now
            };
        }

        if (amount <= 0)
        {
            return new PaymentResult
            {
                IsSuccessful = false,
                ErrorMessage = "Geçersiz ödeme tutarı.",
                PaymentDate = DateTime.Now
            };
        }

        bool isSuccessful = _random.Next(100) < 90;

        if (!isSuccessful)
        {
            return new PaymentResult
            {
                IsSuccessful = false,
                ErrorMessage = "Ödeme işlemi banka tarafından reddedildi. Lütfen bankanızla iletişime geçin.",
                PaymentDate = DateTime.Now
            };
        }
       
        return new PaymentResult
        {
            IsSuccessful = true,
            PaymentId = GeneratePaymentId(),
            PaymentDate = DateTime.Now
        };
    }

    private bool IsValidCardNumber(string cardNumber)
    {
        return !string.IsNullOrWhiteSpace(cardNumber) &&
               _validCardNumbers.Contains(cardNumber.Replace(" ", "").Replace("-", ""));
    }

    private bool IsValidExpirationDate(string expirationDate)
    {
        if (string.IsNullOrWhiteSpace(expirationDate) || !expirationDate.Contains('/'))
            return false;

        string[] parts = expirationDate.Split('/');
        if (parts.Length != 2)
            return false;

        if (!int.TryParse(parts[0], out int month) || !int.TryParse(parts[1], out int year))
            return false;

        if (month < 1 || month > 12)
            return false;

        if (parts[1].Length != 2)
            return false;

        int currentYear = DateTime.Now.Year % 100; // Son 2 hane
        int currentMonth = DateTime.Now.Month;

        return (year > currentYear) || (year == currentYear && month >= currentMonth);
    }

    private bool IsValidCvv(string cvv)
    {
        return !string.IsNullOrWhiteSpace(cvv) &&
               (cvv.Length == 3 || cvv.Length == 4) &&
               cvv.All(char.IsDigit);
    }

    private string GeneratePaymentId()
    {
        return $"PAY-{DateTime.Now:yyyyMMddHHmmss}-{_random.Next(1000, 9999)}";
    }
}