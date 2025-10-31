using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertManagmentSystem
{
    internal class ApartmentBuilding : Building
    {

        public decimal  NumberOfApartments { get; set; }
        public decimal FeePerApartment { get; }
        


        public ApartmentBuilding(int id, string name, decimal numberOfApartments, decimal feePerApartment)
       : base(id, name)
        {
            NumberOfApartments = numberOfApartments;
            FeePerApartment = feePerApartment;
        }
        public override decimal CalculateMonthlyFee()
        {
            return NumberOfApartments * FeePerApartment; 
        }


        public override void ShowInfo()
        {
         
            Console.WriteLine($"Number of Apartments: {NumberOfApartments}");
            Console.WriteLine($"Fee per Apartment: {FeePerApartment}");
            Console.WriteLine($"Total Monthly Fee: {CalculateMonthlyFee()}");
        }

        public decimal GetRent()
        {
            return CalculateMonthlyFee();
        }

        public string GetContractInfo()
        {
            return $"Apartment rent contract: {NumberOfApartments} units, each {FeePerApartment}";
        }
    }

}
