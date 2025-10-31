using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertManagmentSystem
{
    public abstract class Building
    {
       

        int Id { get; init; }
        string Name { get; set; }
        protected Building(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public abstract decimal CalculateMonthlyFee();
        public virtual void ShowInfo()
        {
            Console.WriteLine($"ID : {Id}  , Name : { Name}" );  
        }
    }
}
