using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Customer : IFormattable
    {
        public string Name { get; private set; }
        public string ContactPhone { get; private set; } 
        public decimal Revenue { get; private set; }

        public Customer() : this(string.Empty, string.Empty, default(decimal))
        {
        }

        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        public override string ToString() => this.ToString("G", CultureInfo.CurrentCulture);

        public string ToString(string format) => this.ToString(format, CultureInfo.CurrentCulture);

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
    }
}
