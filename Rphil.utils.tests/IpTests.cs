using System.Net;

namespace Rphil.Utils.tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RPhil.Utils;

    [TestClass]
    public class IpTests
    {
        [TestMethod]
        public void TestBroadCastLookup()
        {
            var testIp = new IPAddress(new byte[] { 192, 168, 0, 1 });
            var subNet = new IPAddress(new byte[] { 255, 255, 255, 0 });
            var calculatedBroadcastAddress = testIp.GetBroadcastAddress(subNet);
            var expectedBroadcastAddress = new IPAddress(new byte[] { 192, 168, 0, 255 });

            Assert.IsTrue(calculatedBroadcastAddress.Equals(expectedBroadcastAddress));
        }

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
