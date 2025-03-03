using Core.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Domain.Entities
{
    public class Payment : Entity<int>
    {
        public int OrderId { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }
        public decimal Price { get; set; }

        public virtual Order Order { get; set; }

        public Payment()
        {
        }

        public Payment(int id, int orderId, string cardNumber, string cardHolderName, string expirationDate, string cvv) : this()
        {
            Id = id;
            OrderId = orderId;
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            ExpirationDate = expirationDate;
            Cvv = cvv;
        }
    }
}
