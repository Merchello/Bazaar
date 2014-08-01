﻿namespace Merchello.Tests.Avalara.Integration.Tax
{
    using System.Linq;
    using System.Runtime.Remoting;

    using Merchello.Core.Models;
    using Merchello.Plugin.Taxation.Avalara;
    using Merchello.Plugin.Taxation.Avalara.Models;
    using Merchello.Plugin.Taxation.Avalara.Models.Address;
    using Merchello.Plugin.Taxation.Avalara.Models.Tax;
    using Merchello.Tests.Avalara.Integration.TestBase;

    using NUnit.Framework;

    [TestFixture]
    public class TaxApiTests : AvaTaxTestBase
    {
        /// <summary>
        /// Test verifies that the tax API can be pinged and we get a successful result
        /// </summary>
        [Test]
        public void Can_Ping_The_Tax_Api()
        {
            //// Arrange

            //// Act
            var result = AvaTaxService.Ping();

            //// Assert
            Assert.NotNull(result);
            Assert.AreEqual(result.ResultCode, SeverityLevel.Success);
            Assert.IsTrue(result.TaxDetails.Any());
        }

        /// <summary>
        /// Test confirms that taxes can be estimated based off a lat long
        /// </summary>
        [Test]
        public void Can_Estimate_Tax_Based_On_Geo_Data()
        {
            //// Arrange
            // Mindfly lat/long
            var latitude = 48.751413M;
            var longitude = -122.478071M;
            var salesPrice = 10;

            //// Act
            var result = AvaTaxService.EstimateTax(latitude, longitude, salesPrice);

            //// Assert
            Assert.NotNull(result);
            Assert.AreEqual(result.ResultCode, SeverityLevel.Success);
            Assert.IsTrue(result.TaxDetails.Any());
        }

        /// <summary>
        /// Test confirms that a tax result can be retrieved from AvaTax using example data
        /// in their example library
        /// </summary>
        [Test]
        public void Can_Get_Tax_Result_With_Simple_Mock_Data()
        {
            //// Arrange
            var storeAddress = new Address()
                {
                    Name = "Mindfly, Inc.",
                    Address1 = "114 W. Magnolia St. Suite 300",
                    Locality = "Bellingham",
                    Region = "WA",
                    PostalCode = "98225",
                    CountryCode = "US"
                };

            var taxRequest = Invoice.AsTaxRequest(storeAddress.ToTaxAddress());
            Assert.NotNull(taxRequest);
 
            //// Assert
            
        
        }
    }
}