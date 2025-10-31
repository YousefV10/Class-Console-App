using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertManagmentSystem
{
    internal interface IRentable
    {
        decimal GetRent();
        string GetContractInfo();
    }
}
