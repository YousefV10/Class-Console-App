using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertManagmentSystem
{
    static  class Registry
    {
        private static int _totalBuildings;
        public static int TotalBuildings => _totalBuildings;

        static Registry()
        {
            Console.WriteLine("Registry initialized. Tracking all building registrations...");
        }

        public static void Register(Building building )
        {
            _totalBuildings++;
            
            building.ShowInfo();
            Console.WriteLine($"New building registered (Total: {_totalBuildings})");
        }
    }
}
