using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KebPOS
{
    internal class Validation
    {
        public static bool IsValidIdInput(string input)
        {

            if (!int.TryParse(input, out int parsedInput))
            {
                return false;
            }

            return parsedInput > 0;
        }
    }
}
