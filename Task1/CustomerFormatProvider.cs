using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Provides additional format for Customer objects
    /// </summary>
    public class CustomerFormatProvider : IFormatProvider, ICustomFormatter
    {
        private readonly IFormatProvider parentProvider;

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomerFormatProvider() : this(CultureInfo.CurrentCulture) { }

        /// <summary>
        /// Constructor with parameters of class CustomerFormatProvider
        /// </summary>
        public CustomerFormatProvider(IFormatProvider parent)
        {
            parentProvider = parent;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Returns an object that provides formatting services for the Customer type
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return.</param>
        /// <returns>Object that provides formatting services for the Customer type</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        /// <summary>
        /// Converts customer object to an equivalent string representation using specified format and specific formatting information.
        /// </summary>
        /// <param name="format">A format string containing formatting specifications</param>
        /// <param name="arg">Instance of the Customer</param>
        /// <param name="formatProvider">An object that supplies format information about the current instance.</param>
        /// <returns>The string representation of Customer object, formatted as specified by format and formatProvider</returns>
        /// <exception cref="FormatException">The format string is invalid</exception>
        /// <exception cref="ArgumentException">Object reference doesn't refer to Customer instance</exception>
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
        #endregion
    }
}
