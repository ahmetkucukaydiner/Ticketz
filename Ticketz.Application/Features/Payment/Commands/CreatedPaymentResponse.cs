using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Application.Features.Payment.Commands;

public class CreatedPaymentResponse
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string CardNumber { get; set; } // Maskelenmiş kart numarası
    public string CardHolderName { get; set; }
    public string ExpirationDate { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedDate { get; set; }
    
    // Ödeme sağlayıcısından gelen bilgiler
    public string PaymentId { get; set; }
    public DateTime PaymentDate { get; set; }
    public bool IsSuccessful { get; set; }
}
