using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDK2
{
    internal class CarService
    {
        public delegate void ServiceDelegate();

        public ServiceDelegate ServiceChain;

        public void PerformService()
        {
            ServiceChain?.Invoke();

            if (ServiceChain == null)
            {
                Console.WriteLine(" Please choose operation");
            }

            Console.WriteLine("Car check ended ");
        }

        public void CheckOil()
        {
            Console.WriteLine("Oil checked");
        }

        public void CheckBrakes()
        {
            Console.WriteLine(" Brake Checked");
        }

        public void CheckEngine()
        {
            Console.WriteLine("Engine Checked ");
        }

        public void CheckLights()
        {
            Console.WriteLine("  Lights Checked ");
        }
    }
}

