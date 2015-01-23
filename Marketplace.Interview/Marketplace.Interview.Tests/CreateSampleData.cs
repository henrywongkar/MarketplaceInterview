using System.Collections.Generic;
using System.IO;
using System.Linq;
using Marketplace.Interview.Business.Core;
using Marketplace.Interview.Web;
using Marketplace.Interview.Web.IoC;
using NUnit.Framework;
using Marketplace.Interview.Business.Shipping;

namespace Marketplace.Interview.Tests
{
    [TestFixture]
    public class CreateSampleData
    {
        [Test]
        public void CreateSampleShippingOptions()
        {
            var shippings = new Dictionary<string, ShippingBase>
            {
                {
                    "FlatRate", new FlatRateShipping
                    {
                        FlatRate = 1.5m
                    }
                },
                {
                    "PerRegion", new PerRegionShipping
                    {
                        PerRegionCosts = new List<RegionShippingCost>
                        {
                            new RegionShippingCost{DestinationRegion = RegionShippingCost.Regions.UK, Amount = .5m},
                            new RegionShippingCost{DestinationRegion = RegionShippingCost.Regions.Europe, Amount = 1m},
                            new RegionShippingCost{DestinationRegion = RegionShippingCost.Regions.RestOfTheWorld, Amount = 2m},
                        }
                    }
                }
            };

            var ser = SerializationHelper.DataContractSerialize(shippings);

            using (var fileWriter = new StreamWriter(@"..\..\..\Marketplace.Interview.Web\App_Data\Shipping.xml", false))
            {
                fileWriter.Write(ser);
            }
        }

        [Test]
        public void RegistrationTest()
        {
            ObjectFactory.WindsorContainer.Install(new WindsorInstaller());
        }

        [Test]
        public void GetConstants()
        {
            var constants = ReflectionHelpers.GetConstants(typeof (RegionShippingCost.Regions));

            Assert.That(constants.Count(), Is.EqualTo(3));
        }
    }
}
