using ApplicationCore.Models.BasketAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public sealed class BasketWithItemsSpecification : BaseSpecification<Basket>
    {
        public BasketWithItemsSpecification(int basketId)
            : base(b => b.Id == basketId)
        {
            AddInclude(b => b.Items);
        }
        public BasketWithItemsSpecification(string buyerId)
            : base(b => b.BuyerId == buyerId)
        {
            AddInclude(b => b.Items);
        }
    }
}
