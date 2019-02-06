namespace Rphil.Utils.tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RPhil.Utils;

    [TestClass]
    public class MathTests
    {
        [TestMethod]
        public void TestBetween()
        {
            var min = 0;
            var max = 10;
            var test = 1;
            var test2 = 11;
            var test3 = -1;
            var test4 = int.MaxValue;

            Assert.IsTrue(test.Between(min, max));
            Assert.IsFalse(test2.Between(min, max));
            Assert.IsFalse(test3.Between(min, max));
            Assert.IsFalse(test4.Between(min, max));
        }

        [TestMethod]
        public void TestIsBitSet()
        {
            for (var i = 0; i < 8; i++)
            {
                var val = (1 << i);
                Assert.IsTrue(val.IsBitSet(i));
                Assert.IsFalse(val.IsBitSet(i-1));
            }
        }

        [TestMethod]
        public void TestSetBit()
        {
            for (var i = 0; i < 8; i++)
            {
                var value = 0;
                var res = value.SetBit(i);
                Assert.IsTrue(res == (1 << i));
            }
        }

        [TestMethod]
        public void TestToggleBit()
        {
            for (var i = 0; i < 8; i++)
            {
                var value = 0;
                var res = value.ToggleBit(i);
                Assert.IsTrue(res == (1 << i));
                var res2 = res.ToggleBit(i);
                Assert.IsFalse(res2 == (1 << i));
            }
        }

        [TestMethod]
        public void TestUnsetBit()
        {
            for (var i = 0; i < 8; i++)
            {
                byte value = 255;
                var res = value.UnsetBit(i);
                Assert.IsTrue(res == 255 - (1 << i));
            }
        }
    }
}
