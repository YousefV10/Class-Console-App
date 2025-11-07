using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDK
{
    internal class SMSService
    {
        public void SendSMS(string message)
        {
            Console.WriteLine($" SMS Sended: {message}");
        }
    }
}
