// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IpTests.cs" company="Philipsen IT">
//  Copyright 2019 Philipsen IT  
// </copyright>
// <summary>
//   Defines Tests for the IP utils class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Rphil.Utils.Tests
{
    using System.Net;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RPhil.Utils;

    /// <summary> The ip tests. </summary>
    [TestClass]
    public class IpTests
    {
        /// <summary> Tests the lookup for the broadcast address. </summary>
        [TestMethod]
        public void TestBroadCastLookup()
        {
            var testIp = new IPAddress(new byte[] { 192, 168, 0, 1 });
            var subNet = new IPAddress(new byte[] { 255, 255, 255, 0 });
            var calculatedBroadcastAddress = testIp.GetBroadcastAddress(subNet);
            var expectedBroadcastAddress = new IPAddress(new byte[] { 192, 168, 0, 255 });

            Assert.IsTrue(calculatedBroadcastAddress.Equals(expectedBroadcastAddress));
        }

        /// <summary> Tests the subnet check  </summary>
        [TestMethod]
        public void TestSubnetCheck()
        {
            var testIp1 = new IPAddress(new byte[] { 1, 1, 1, 1 });
            var testIp2 = new IPAddress(new byte[] { 1, 1, 1, 2 });
            var testIp3 = new IPAddress(new byte[] { 1, 1, 2, 1 });
            var subnet = new IPAddress(new byte[] { 255, 255, 255, 0 });

            Assert.IsTrue(IpAddressExtensions.IsInSameSubnet(testIp1, testIp2, subnet));
            Assert.IsFalse(IpAddressExtensions.IsInSameSubnet(testIp1, testIp3, subnet));
        }
    }
}
