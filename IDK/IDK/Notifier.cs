using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDK
{
    internal class Notifier
    {
        public delegate void NotificationHandler(string message);

        public NotificationHandler NotificationSent;

        public void SendNotification(string message)
        {
            Console.WriteLine($" Not Sending: '{message}' ");
            NotificationSent?.Invoke(message);
        }
    }
}
