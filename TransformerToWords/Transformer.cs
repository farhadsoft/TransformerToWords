using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TransformerToWords
{
    /// <summary>
    /// Implements transformer class.
    /// </summary>
    public class Transformer
    {
        /// <summary>
        /// Transforms each element of source array into its 'word format'.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of 'word format' of elements of source array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <example>
        /// new[] { 2.345, -0.0d, 0.0d, 0.1d } => { "Two point three four five", "Minus zero", "Zero", "Zero point one" }.
        /// </example>
        public string[] Transform(double[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Thrown when array is empty.");
            }

            List<string> str = new List<string>();

            for (int i = 0; i < source.Length; i++)
            {
                if (CheckNumber(source[i], out var value))
                {
                    str.Add(value);
                }
                else
                {
                    str.Add(Trans(source[i]));
                }
            }

            return str.ToArray();
        }

        public static bool CheckNumber(double number, out string value)
        {
            switch (number)
            {
                case double.NaN:
                    value = "Not a Number";
                    return true;
                case double.Epsilon:
                    value = "Double Epsilon";
                    return true;
                case double.NegativeInfinity:
                    value = "Negative Infinity";
                    return true;
                case double.PositiveInfinity:
                    value = "Positive Infinity";
                    return true;
                default:
                    value = null;
                    return false;
            }
        }

        public static string Trans(double number)
        {
            StringBuilder sb = new StringBuilder();
            var num = number.ToString(CultureInfo.CurrentCulture);
            for (int j = 0; j < num.Length; j++)
            {
                switch (num[j])
                {
                    case '-':
                        sb.Append("minus");
                        break;
                    case '+':
                        sb.Append("plus");
                        break;
                    case 'E':
                        sb.Append("E");
                        break;
                    case '0':
                        sb.Append("zero");
                        break;
                    case '1':
                        sb.Append("one");
                        break;
                    case '2':
                        sb.Append("two");
                        break;
                    case '3':
                        sb.Append("three");
                        break;
                    case '4':
                        sb.Append("four");
                        break;
                    case '5':
                        sb.Append("five");
                        break;
                    case '6':
                        sb.Append("six");
                        break;
                    case '7':
                        sb.Append("seven");
                        break;
                    case '8':
                        sb.Append("eight");
                        break;
                    case '9':
                        sb.Append("nine");
                        break;
                    case ',':
                    case '.':
                        sb.Append("point");
                        break;
                }

                if (j < num.Length - 1)
                {
                    sb.Append(" ");
                }
            }

            string result = sb.ToString();
            return char.ToUpper(result[0], CultureInfo.CurrentCulture) + result[1..];
        }
    }
}
