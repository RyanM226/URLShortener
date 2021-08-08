using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /// <summary>
    /// Class to represent the encoding and decoding of a numerical ID. Utilises a bijective function to map numbers in an ID to a corresponding set of characters.
    /// </summary>
    public class IDEncoder
    {
        private static readonly string Alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly int Base = Alphabet.Length;

        /// <summary>
        /// Function to transform an integer ID field into a corresponding string value
        /// </summary>
        /// <param name="i"> The integer ID we want to encode </param>
        /// <returns></returns>
        public static string Encode(int i)
        {
            if (i == 0) return Alphabet[0].ToString();

            var s = string.Empty;

            while (i > 0)
            {
                s += Alphabet[i % Base];
                i = i / Base;
            }

            return string.Join(string.Empty, s.Reverse());
        }

        /// <summary>
        /// Function to transform an encoded string back into our integer ID field
        /// </summary>
        /// <param name="s"> Encoded string to be decoded </param>
        /// <returns></returns>
        public static int Decode(string s)
        {
            if(String.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException("S"); 
            }

            var i = 0;

            foreach (var c in s)
            {
                i = (i * Base) + Alphabet.IndexOf(c);
            }

            return i;
        }
    }
}
