using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Models.BuyerAggregate
{
    public class Buyer : BaseModel, IAggregateRoot
    {
        public string IdentityGuid { get; private set; }

        private List<PaymentMethod> _paymentMethods = new List<PaymentMethod>();

        public IEnumerable<PaymentMethod> PaymentMethods => _paymentMethods.AsReadOnly();

        private Buyer()
        {
            // required by EF
        }

        public Buyer(string identity) : this()
        {
            Guard.Against.NullOrEmpty(identity, nameof(identity));
            IdentityGuid = identity;
        }
    }
}
