using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.HomeTask
{
    internal class Card
    {
       
        
            public string CardNumber { get; }
            public string OwnerName { get; set; }
            public double Balance { get; protected set; }
            public double AnnualFee { get; set; }

            public Card(string cardNumber, string ownerName, double balance, double annualFee)
            {
                CardNumber = cardNumber;
                OwnerName = ownerName;
                Balance = balance;
                AnnualFee = annualFee;
            }

            public void Deposit(double amount)
            {
                Balance += amount;
                Console.WriteLine($"{amount} AZN artırıldı. Balans: {Balance} AZN");
            }

            public virtual void Withdraw(double amount)
            {
                if (Balance >= amount)
                {
                    Balance -= amount;
                    Console.WriteLine($"{amount} AZN çıxarıldı. Balans: {Balance} AZN");
                }
                else
                {
                    Console.WriteLine("Insufficient balance");
                }
            }
        


    }
}
