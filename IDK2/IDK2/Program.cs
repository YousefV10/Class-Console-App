using IDK2;

 static bool AskForCheck(string checkName)
{
    Console.Write($"{checkName} is true ?  ");
    return Console.ReadLine()?.Trim().ToLower() == "y";
}


    var carService = new CarService();

    Console.WriteLine("Please Choose one ");

    if (AskForCheck("Oil "))
    {
        carService.ServiceChain += carService.CheckOil;
    }

    if (AskForCheck("Brake "))
    {
        carService.ServiceChain += carService.CheckBrakes;
    }

    if (AskForCheck("Engine "))
    {
        carService.ServiceChain += carService.CheckEngine;
    }

    if (AskForCheck("Lights"))
    {
        carService.ServiceChain += carService.CheckLights;
    }

    carService.PerformService();

    Console.ReadLine();

