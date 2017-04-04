using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using System.Collections;

namespace Task1.Tests
{
    [TestFixture]
    class CustomerTest
    {
        private  static Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);

        class TestDatas : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new TestCaseData("A", CultureInfo.InvariantCulture).Returns($"Customer record: Jeffrey Richter, 1000000.00, +1 (425) 555-0100");
                yield return new TestCaseData("C", CultureInfo.InvariantCulture).Returns($"Customer record: +1 (425) 555-0100");
                yield return new TestCaseData("B", CultureInfo.InvariantCulture).Returns($"Customer record: Jeffrey Richter, 1000000.00");
                yield return new TestCaseData("N", CultureInfo.InvariantCulture).Returns($"Customer record: Jeffrey Richter");
                yield return new TestCaseData("R", CultureInfo.InvariantCulture).Returns($"Customer record: 1000000.00");
                yield return new TestCaseData("D", CultureInfo.InvariantCulture).Returns($"Customer record: Jeffrey Richter, +1 (425) 555-0100");
                yield return new TestCaseData("", CultureInfo.InvariantCulture).Returns($"Customer record: Jeffrey Richter, 1000000.00, +1 (425) 555-0100");

            }
        }

        [Test, TestCaseSource(typeof(TestDatas))]
        public static string ToString_PositiveTest(string format, IFormatProvider formatProvider)
        {
            return customer.ToString(format, formatProvider);
        }

        [Test]
        public static void ToString_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => customer.ToString("E", CultureInfo.InvariantCulture));
        }
    }
}
