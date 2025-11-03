abstract class Character
{
    public string Name { get; set; }
    public string ClassName { get; set; }
    public int HP { get; set; }
    public int BaseDamage { get; set; }

    public Character(string name, string className, int hp, int baseDamage)
    {
        Name = name;
        ClassName = className;
        HP = hp;
        BaseDamage = baseDamage;
    }

    protected int RollDice(bool manual = false)
    {
        if (manual)
        {
            Console.Write($"{Name} ucun 1-20 arası zer at: ");
            int roll;
            while (!int.TryParse(Console.ReadLine(), out roll) || roll < 1 || roll > 20)
                Console.Write("Yanlıs deyer! 1-20 arası eded daxil et: ");
            return roll;
        }
        else
        {
            return new Random().Next(1, 21);
        }
    }

    protected double GetEffectMultiplier(int roll)
    {
        if (roll <= 5) return 0.0;
        if (roll <= 14) return 1.0;
        if (roll <= 19) return 1.5;
        return 2.0;
    }

    public virtual void Attack(Character target, bool manual = false)
    {
        int roll = RollDice(manual);
        double multiplier = GetEffectMultiplier(roll);
        int damage = (int)(BaseDamage * multiplier);

        if (damage == 0)
            Console.WriteLine($"{Name} ({ClassName}) hucum etdi, amma hedefi qaçırdı! (zer: {roll})");
        else
        {
            Console.WriteLine($"{Name} ({ClassName}) {target.Name} ({target.ClassName})-ə {damage} hasar vurdu! (zər: {roll})");
            target.TakeDamage(damage);
        }
    }

    public virtual void TakeDamage(int amount)
    {
        int roll = new Random().Next(1, 21);
        if (roll >= 17)
        {
            Console.WriteLine($"{Name} dodge bacarıgı ilə zerbedən qurtuldu! (zər: {roll})");
            return;
        }

        HP -= amount;
        Console.WriteLine($"{Name} {amount} hasar aldı. Qalan HP: {HP}");
    }

    public bool IsAlive() => HP > 0;
}