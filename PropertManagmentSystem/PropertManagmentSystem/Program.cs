using PropertManagmentSystem;

static void Main()
{
    Console.WriteLine("Bina -----------------------------------");
    Property prop = new Property(1, "Baki ", 120, 10, true);
    Console.WriteLine($"Property created {prop.Adress}");
}