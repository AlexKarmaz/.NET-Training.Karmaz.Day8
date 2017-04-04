using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using System.Collections;

namespace Task1.Tests
{
    [TestFixture]
    class CustomerFormatProviderTests
    {
        private static Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);

        class TestDatas : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new TestCaseData(customer, "{0:A}").Returns($"Customer record: Jeffrey Richter, 1000000,00, +1 (425) 555-0100");
                yield return new TestCaseData(customer, "{0:C}").Returns($"Customer record: +1 (425) 555-0100");
                yield return new TestCaseData(customer, "{0:E}").Returns($"Customer record: Jeffrey Richter Revenue: 1000000 Contact phone: +1 (425) 555-0100");
            }
        }

        [Test, TestCaseSource(typeof(TestDatas))]
        public static string Format_PositiveTest(Customer customer, string format)
        {
            IFormatProvider fp = new CustomerFormatProvider();
            return string.Format(fp, format, customer);
        }

        [Test]
        public static void Format_ThrowsFormatException()
        {
            IFormatProvider fp = new CustomerFormatProvider();
            Assert.Throws<FormatException>(() => string.Format(fp,"{0:w}", customer));
        }
    }
}
