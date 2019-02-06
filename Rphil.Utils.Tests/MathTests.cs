// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MathTests.cs" company="Philipsen IT">
//    Copyright 2019 Philipsen IT
// </copyright>
// <author>Ronald Philipsen</author>
// <summary>
//   Defines the MathTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Rphil.Utils.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RPhil.Utils;

    /// <summary> Defines tests for several math extensions </summary>
    [TestClass]
    public class MathTests
    {
        /// <summary> Tests the between method </summary>
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

        /// <summary> Tests the is bit set method </summary>
        [TestMethod]
        public void TestIsBitSet()
        {
            for (var i = 0; i < 8; i++)
            {
                var val = 1 << i;
                Assert.IsTrue(val.IsBitSet(i));
                Assert.IsFalse(val.IsBitSet(i - 1));
            }
        }

        /// <summary> Tests the set bit method </summary>
        [TestMethod]
        public void TestSetBit()
        {
            const int Value = 0;

            for (var i = 0; i < 8; i++)
            {
                var res = Value.SetBit(i);
                Assert.IsTrue(res == (1 << i));
            }
        }

        /// <summary> Tests for the toggle bit </summary>
        [TestMethod]
        public void TestToggleBit()
        {
            const int Value = 0;
            for (var i = 0; i < 8; i++)
            {
                var res = Value.ToggleBit(i);
                Assert.IsTrue(res == (1 << i));
                var res2 = res.ToggleBit(i);
                Assert.IsFalse(res2 == (1 << i));
            }
        }

        /// <summary> Tests for the unset bit method </summary>
        [TestMethod]
        public void TestUnsetBit()
        {
            const byte Value = 255;

            for (var i = 0; i < 8; i++)
            {
                var res = Value.UnsetBit(i);
                Assert.IsTrue(res == 255 - (1 << i));
            }
        }
    }
}
