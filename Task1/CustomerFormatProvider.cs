using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class CustomerFormatProvider : IFormatProvider, ICustomFormatter
    {
        private readonly IFormatProvider parentProvider;

        public CustomerFormatProvider() : this(CultureInfo.CurrentCulture) { }

        public CustomerFormatProvider(IFormatProvider parent)
        {
            parentProvider = parent;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            Customer customer = arg as Customer;
            if (customer == null)
                throw new ArgumentException("Wrong argument type");

            try
            {
                string result = customer.ToString(format, formatProvider);
                return result;
            }
            catch (FormatException)
            {
                switch (format.ToUpperInvariant())
                {
                    case "E":
                        return $"Customer record: {customer.Name} Revenue: {customer.Revenue} Contact phone: {customer.ContactPhone}";
                    default:
                        throw new FormatException();
                }
            }
        }
    }
}
