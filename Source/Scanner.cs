namespace IOutils
{
    using System;
    using System.Text;
    using System.Globalization;
    using System.IO;

    /// <summary>
    /// Java-like Scanner for C#, based on Svetlin Nakov solution (Nakov.IO.Cin)
    /// allows reading from console and file (only ASCII-like encodings at the moment)
    /// </summary>
    /// 
    /// <copyright>
    /// (c) Svetlin Nakov, 2011 - http://www.nakov.com
    /// (c) Victor Scherevskiy, 2022 - https://github.com/kolbacer
    /// </copyright>
    /// 
    /// <example>
    /// ```
    /// Scanner consoleScanner = new Scanner();
    /// int? x = consoleScanner.NextInt();
    /// double? y = consoleScanner.NextDouble();
    /// ```
    /// </example>
    /// 
    public class Scanner
    {
        private Func<int> Read;

        /// <summary>
        /// Console scanner
        /// </summary>
        public Scanner()
        {
            Read = Console.Read;
        }

        /// <summary>
        /// File scanner (ASCII-like encodings only)
        /// </summary>
        public Scanner(FileStream source)
        {
            Read = source.ReadByte;
        }

        /// <summary>
        /// Reads a string token, skipping any leading and trailing whitespace.
        /// Returns null if no token was reached.
        /// </summary>
        public string? NextToken()
        {
            StringBuilder tokenChars = new StringBuilder();
            bool tokenFinished = false;
            bool skipWhiteSpaceMode = true;
            while (!tokenFinished)
            {
                int nextChar = Read();
                if (nextChar == -1)
                {
                    // End of stream reached
                    tokenFinished = true;
                }
                else
                {
                    char ch = (char)nextChar;
                    if (char.IsWhiteSpace(ch))
                    {
                        // Whitespace reached (' ', '\r', '\n', '\t') -->
                        // skip it if it is a leading whitespace
                        // or stop reading anymore if it is trailing
                        if (!skipWhiteSpaceMode)
                        {
                            tokenFinished = true;
                            if (ch == '\r' && (Environment.NewLine == "\r\n"))
                            {
                                // Reached '\r' in Windows --> skip the next '\n'
                                Read();
                            }
                        }
                    }
                    else
                    {
                        // Character reached --> append it to the output
                        skipWhiteSpaceMode = false;
                        tokenChars.Append(ch);
                    }
                }
            }

            if (tokenChars.Length == 0) return null;

            string token = tokenChars.ToString();
            return token;
        }

        /// <summary>
        /// Reads an integer number, skipping any leading and trailing whitespace.
        /// Returns null if no token was reached.
        /// </summary>
        public int? NextInt()
        {
            string? token = NextToken();
            if (token == null) return null;

            return int.Parse(token);
        }

        /// <summary>
        /// Reads a floating-point number, skipping any leading and trailing whitespace.
        /// Returns null if no token was reached.
        /// </summary>
        /// <param name="acceptAnyDecimalSeparator">
        /// Specifies whether to accept any decimal separator
        /// ("." and ",") or the system's default separator only.
        /// </param>
        public double? NextDouble(bool acceptAnyDecimalSeparator = true)
        {
            string? token = NextToken();
            if (token == null) return null;

            if (acceptAnyDecimalSeparator)
            {
                token = token.Replace(',', '.');
                double result = double.Parse(token, CultureInfo.InvariantCulture);
                return result;
            }
            else
            {
                double result = double.Parse(token);
                return result;
            }
        }

        /// <summary>
        /// Reads a decimal number, skipping any leading and trailing whitespace.
        /// Returns null if no token was reached.
        /// </summary>
        /// <param name="acceptAnyDecimalSeparator">
        /// Specifies whether to accept any decimal separator
        /// ("." and ",") or the system's default separator only.
        /// </param>
        public decimal? NextDecimal(bool acceptAnyDecimalSeparator = true)
        {
            string? token = NextToken();

            if (token == null) return null;

            if (acceptAnyDecimalSeparator)
            {
                token = token.Replace(',', '.');
                decimal result = decimal.Parse(token, CultureInfo.InvariantCulture);
                return result;
            }
            else
            {
                decimal result = decimal.Parse(token);
                return result;
            }
        }
    }
}
