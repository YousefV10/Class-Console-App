using Task.HomeTask;

public class PremiumCard : Card
{
    private double monthlyLimit = 5000;
    private double usedThisMonth = 0;

    public PremiumCard(string cardNumber, string ownerName, double balance, double annualFee)
        : base(cardNumber, ownerName, balance, annualFee) { }

    public override void Withdraw(double amount)
    {
        if (usedThisMonth + amount > monthlyLimit)
        {
            Console.WriteLine("Aylıq limit keçildi!");
            return;
        }

        if (Balance >= amount)
        {
            double cashback = amount * 0.03;
            Balance = Balance - amount + cashback;
            usedThisMonth += amount;

            Console.WriteLine($"PremiumCard: {amount} AZN çıxıldı. Cashback: {cashback} AZN");
            Console.WriteLine($"Limit istifadəsi: {usedThisMonth}/{monthlyLimit}");
            Console.WriteLine($"Balans: {Balance} AZN");
        }
        else
        {
            Console.WriteLine("Insufficient balance");
        }
    }
}
