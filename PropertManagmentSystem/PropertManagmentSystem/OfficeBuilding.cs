using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertManagmentSystem
{
    internal class OfficeBuilding : Building
    {

        public decimal  NumberOfOffice { get; set;  }
        public decimal RentPerOffice { get; set;  }

        public OfficeBuilding( int id, string name , decimal numberoffice , decimal rentoffice ) : base (id , name )
        {
            NumberOfOffice = numberoffice;
            RentPerOffice = rentoffice; 
        }
        public override decimal  CalculateMonthlyFee()
        {
            return NumberOfOffice * RentPerOffice; 
            
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Number of Office : {NumberOfOffice} , Rent per Office : {RentPerOffice }");
            Console.WriteLine($"Monthly Fee {CalculateMonthlyFee()}");
        }

        public decimal GetRent()
        {
            return CalculateMonthlyFee();
        }

        public string GetContractInfo()
        {
            return $"Office building rent contract: {NumberOfOffice} offices, each {RentPerOffice} ";
        }
    }
}
