using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Marketplace.Interview.Business.Basket;

namespace Marketplace.Interview.Business.Shipping
{
    [KnownType("KnownTypes")]
    public abstract class ShippingBase
    {
        public static IEnumerable<Type> KnownTypes()
        {
            return new[] {typeof (FlatRateShipping), typeof (PerRegionShipping)};
        }
        
        public abstract string GetDescription(LineItem lineItem, Basket.Basket basket);

        public abstract decimal GetAmount(LineItem lineItem, Basket.Basket basket);
    }
}