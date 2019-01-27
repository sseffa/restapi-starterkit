using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Models.BuyerAggregate
{
    public class PaymentMethod : BaseModel
    {
        public string Alias { get; set; }
        public string CardId { get; set; } // actual card data must be stored in a PCI compliant system, like Stripe
        public string Last4 { get; set; }
    }
}
