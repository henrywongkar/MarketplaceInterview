using System.Linq;

namespace Marketplace.Interview.Business.Basket
{
    public interface IShippingCalculator
    {
        decimal CalculateShipping(Basket basket);
    }

    public class ShippingCalculator : IShippingCalculator
    {
        public decimal CalculateShipping(Basket basket)
        {
            foreach (var lineItem in basket.LineItems)
            {
                lineItem.ShippingAmount = lineItem.Shipping.GetAmount(lineItem, basket);
                lineItem.ShippingDescription = lineItem.Shipping.GetDescription(lineItem, basket);
                if (basket.LineItems.FirstOrDefault(x => x.Shipping.GetType() == typeof(Shipping.PerRegionExtendedShipping) && x.SupplierId == lineItem.SupplierId && x.DeliveryRegion == lineItem.DeliveryRegion && x != lineItem) != null)
                {
                    lineItem.ShippingAmount = lineItem.ShippingAmount - lineItem.Shipping.GetDiscount;
                }
            }

            return basket.LineItems.Sum(li => li.ShippingAmount);
        }
    }
}