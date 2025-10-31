using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertManagmentSystem
{
    static class Extension
    {
        public static string ToCurrencyText(this decimal d)
        {
            return $"{d:N2} AZN";
        }
    }
}
