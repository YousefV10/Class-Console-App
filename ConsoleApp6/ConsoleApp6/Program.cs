using ConsoleApp6;

Manager<Product> productManager = new Manager<Product>();

Console.WriteLine(" Yeni Məhsul Əlavə Etmə ");
Product product1 = new Product(1, "Laptop", 1500.00m);
productManager.Add(product1);

Product product2 = new Product(2, "Monitor", 350.50m);
productManager.Add(product2);

Product product1_duplicate = new Product(1, "Mouse", 15.00m);
productManager.Add(product1_duplicate); 

Console.WriteLine(" Bütün Məhsullar ");
List<Product> allProducts = productManager.GetAll();
if (allProducts.Count > 0)
{
    foreach (var product in allProducts)
    {
        Console.WriteLine(product);
    }
}

Console.WriteLine("Məhsulu Id ilə Tapmaq (Id: 2)");
Product foundProduct = productManager.GetById(2);
if (foundProduct != null)
{
    Console.WriteLine($"Axtarış nəticəsi: {foundProduct}");
}

Console.WriteLine(" Məhsulu Yeniləmək (Id: 1)");
Product updatedProduct1 = new Product(1, "Oyunçu Laptopu", 2200.00m);
productManager.Update(updatedProduct1);

productManager.Update(new Product(5, "Klaviatura", 50.00m)); 

Console.WriteLine(" Yenilənmədən Sonra Bütün Məhsullar ");
foreach (var product in productManager.GetAll())
{
    Console.WriteLine(product);
}

Console.WriteLine("\n--- Məhsulu Silmək (Id: 2) ---");
productManager.Remove(2);

productManager.Remove(99); 

Console.WriteLine(" Silinmədən Sonra Bütün Məhsullar ");
foreach (var product in productManager.GetAll())
{
    Console.WriteLine(product);
}