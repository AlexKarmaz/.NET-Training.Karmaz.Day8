using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Contains the information about customer.
    /// </summary>
    public class Customer : IFormattable
    {
        #region Properties
        public string Name { get; private set; }
        public string ContactPhone { get; private set; } 
        public decimal Revenue { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public Customer() : this(string.Empty, string.Empty, default(decimal))
        {
        }

        /// <summary>
        /// Constructor with parameters of class Customer
        /// </summary>
        /// <param name="name">Customer's name</param>
        /// <param name="contactPhone">Customer's contact phone</param>
        /// <param name="revenue">Customer's  revenue</param>
        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Returns string representation of Customer
        /// </summary>
        /// <returns>String representation of Customer</returns>
        public override string ToString() => this.ToString("G", CultureInfo.CurrentCulture);

        /// <summary>
        /// Returns string representation of Customer
        /// </summary>
        /// <param name="format">A format string for Customer object</param>
        /// <returns>String representation of Customer</returns>
        /// <exception cref="FormatException">The format string is invalid</exception>
        public string ToString(string format) => this.ToString(format, CultureInfo.CurrentCulture);

        /// <summary>
        /// Returns string representation of Customer
        /// </summary>
        /// <param name="format">A format string for Customer object</param>
        /// <param name="formatProvider">An object that supplies specific formatting information</param>
        /// <returns>String representation of Customer</returns>
        /// <exception cref="FormatException">The format string is invalid</exception>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                format = "G";
            if (formatProvider == null)
                formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G":
                case "A":
                    return $"Customer record: {Name}, {Revenue.ToString("F2", formatProvider)}, {ContactPhone}";
                case "B":
                    return $"Customer record: {Name}, {Revenue.ToString("F2", formatProvider)}";
                case "D":
                    return $"Customer record: {Name}, {ContactPhone}";
                case "N":
                    return $"Customer record: {Name}";
                case "R":
                    return $"Customer record: {Revenue.ToString("F2", formatProvider)}";
                case "C":
                    return $"Customer record: {ContactPhone}";
                default:
                    throw new FormatException();
            }
        }
        #endregion
    }
}
