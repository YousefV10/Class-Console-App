using Task.HomeTask;

public class BusinessCart : Card
{
    public BusinessCart(string cardNumber, string ownerName, double balance, double annualFee)
        : base(cardNumber, ownerName, balance, annualFee) { }

    public override void Withdraw(double amount)
    {
        double fee = 2;
        double total = amount + fee;

        if (Balance >= total)
        {
            double cashback = amount * 0.02;
            Balance = Balance - total + cashback;

            Console.WriteLine($"BusinessCard: {amount} AZN çıxıldı. Xidmət haqqı: {fee} AZN");
            Console.WriteLine($"Cashback: {cashback} AZN");
            Console.WriteLine($"Balans: {Balance} AZN");
        }
        else
        {
            Console.WriteLine("Insufficient balance");
        }
    }
}
