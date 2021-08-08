using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ShortURLBuilder
    {
        public static string BuildShortURL(string baseURL, string encoded)
        {
            if(string.IsNullOrEmpty(baseURL) || string.IsNullOrEmpty(encoded))
            {
                throw new ArgumentNullException();
            }

            return $"{baseURL.TrimEnd('/')}/{encoded}";
        }
    }
}
