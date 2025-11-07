using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDK
{
    internal class EmailService
    {
        public void SendEmail(string message)
        {
            Console.WriteLine($"Email Sended: {message}");
        }
    }
}
