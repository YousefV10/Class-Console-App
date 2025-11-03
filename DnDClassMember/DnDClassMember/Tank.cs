class Tank : Character
{
    public Tank(string name) : base(name, "Tank", 150, 6) { }

    public void Protect(Character ally)
    {
        Console.WriteLine($"{Name} {ally.Name}-i qoruyur ve onun yerine hasari  alir!");
    }
}