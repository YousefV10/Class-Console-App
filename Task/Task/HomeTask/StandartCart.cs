using Task.HomeTask;

public class StandartCart : Card
{
    public StandartCart(string cardNumber, string ownerName, double balance, double annualFee)
        : base(cardNumber, ownerName, balance, annualFee) { }

    public override void Withdraw(double amount)
    {
        if (Balance >= amount)
        {
            double cashback = amount * 0.01;
            Balance = Balance - amount + cashback;

            Console.WriteLine($"StandardCard: {amount} AZN çıxıldı. 1% cashback: {cashback} AZN");
            Console.WriteLine($"Balans: {Balance} AZN");
        }
        else
        {
            Console.WriteLine("Insufficient balance");
        }
    }
}
