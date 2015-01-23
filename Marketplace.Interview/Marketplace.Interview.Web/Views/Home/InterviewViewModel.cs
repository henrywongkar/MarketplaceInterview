using System.Collections.Generic;
using Marketplace.Interview.Business.Basket;
using Marketplace.Interview.Business.Shipping;

namespace Marketplace.Interview.Web.Views.Home
{
    public class InterviewViewModel
    {
        public Dictionary<string, ShippingBase> ShippingOptions { get; set; }
        public Basket Basket { get; set; }
    }
}