class Mage : Character
{
    public Mage(string name) : base(name, "Mage", 70, 8) { }

    public void Heal(Character target, bool manual = false)
    {
        int roll = RollDice(manual);
        int healAmount = roll switch
        {
            <= 5 => 0,
            <= 14 => 15,
            <= 19 => 25,
            _ => 40
        };

        if (healAmount == 0)
            Console.WriteLine($"{Name} Heal  ugursuz oldu! (zər: {roll})");
        else
        {
            target.HP += healAmount;
            Console.WriteLine($"{Name} {target.Name}-i {healAmount} HP sagaltdı! (zer: {roll}) Qalan HP: {target.HP}");
        }
    }
}