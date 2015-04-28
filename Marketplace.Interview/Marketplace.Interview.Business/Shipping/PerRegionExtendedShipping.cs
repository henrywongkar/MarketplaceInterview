using System.Collections.Generic;
using System.Linq;
using Marketplace.Interview.Business.Basket;

namespace Marketplace.Interview.Business.Shipping
{
    public class PerRegionExtendedShipping : ShippingBase
    {
        public IEnumerable<RegionShippingCost> PerRegionExtendedCosts { get; set; }

        public override string GetDescription(LineItem lineItem, Basket.Basket basket)
        {
            return string.Format("Extended Shipping to {0}", lineItem.DeliveryRegion);
        }

        public override decimal GetDiscount
        {
            get { return .5m;}
            set { }
        }

        public override decimal GetAmount(LineItem lineItem, Basket.Basket basket)
        {
            return
                (from c in PerRegionExtendedCosts
                 where c.DestinationRegion == lineItem.DeliveryRegion
                 select c.Amount).Single();
        }
    }
}