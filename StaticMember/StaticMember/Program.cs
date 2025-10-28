public class Program
{
    private static GamePlayer[] currentPlayers = new GamePlayer[0];

    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Title = "GamePlayer Tətbiqi (Array)";

        new GamePlayer("Elvin", 150);
        new GamePlayer("Nigar", 200);
        new GamePlayer("Fərid", 80);

        UpdateLocalPlayers(); 
        DisplayStatus();

        while (true)
        {
            Console.WriteLine("\n------------------------------------------------------");
            Console.WriteLine("Əmrlər: add (yeni oyunçu), update (xal dəyiş), remove (sil), exit (çıxış)");
            Console.Write("Əmri daxil edin: ");
            string command = Console.ReadLine()?.ToLower();

            if (command == "exit")
            {
                break;
            }
            else if (command == "add")
            {
                AddPlayerPrompt();
            }
            else if (command == "update")
            {
                UpdateScorePrompt();
            }
            else if (command == "remove")
            {
                RemovePlayerPrompt();
            }
            else
            {
                Console.WriteLine("Yanlış əmr. Zəhmət olmasa düzgün əmr daxil edin.");
            }

            UpdateLocalPlayers(); 
            DisplayStatus();
        }
    }

    private static void UpdateLocalPlayers()
    {
        currentPlayers = GamePlayer.GetAllPlayers();
    }


    private static void AddPlayerPrompt()
    {
        Console.Write("Yeni oyunçunun adını daxil edin: ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Ad boş qala bilməz.");
            return;
        }

        Console.Write("İlkin xal daxil edin (enter ilə 0): ");
        if (!int.TryParse(Console.ReadLine(), out int score))
        {
            score = 0;
        }

        new GamePlayer(name, score);
    }

    private static void UpdateScorePrompt()
    {
        Console.Write("Xalını dəyişmək istədiyiniz oyunçunun ID-sini daxil edin: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Yanlış ID formatı.");
            return;
        }

        GamePlayer playerToUpdate = currentPlayers.FirstOrDefault(p => p.PlayerID == id);

        if (playerToUpdate == null)
        {
            Console.WriteLine($"ID {id} olan oyunçu tapılmadı.");
            return;
        }

        Console.Write($"'{playerToUpdate.PlayerName}' üçün yeni xalı daxil edin: ");
        if (!int.TryParse(Console.ReadLine(), out int newScore))
        {
            Console.WriteLine("Yanlış xal formatı.");
            return;
        }

        playerToUpdate.UpdateScore(newScore);
    }

    private static void RemovePlayerPrompt()
    {
        Console.Write("Silmək istədiyiniz oyunçunun ID-sini daxil edin: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Yanlış ID formatı.");
            return;
        }

        GamePlayer playerToRemove = currentPlayers.FirstOrDefault(p => p.PlayerID == id);

        if (playerToRemove == null)
        {
            Console.WriteLine($"ID {id} olan oyunçu tapılmadı.");
            return;
        }

        GamePlayer.RemovePlayer(playerToRemove);
    }

    private static void DisplayStatus()
    {
        Console.WriteLine(" ====================== OYUN STATUSU ======================");

        if (currentPlayers.Length == 0)
        {
            Console.WriteLine("Hazırda heç bir oyunçu yoxdur.");
        }
        else
        {
            Console.WriteLine("--- Oyunçular ---");
            var sortedPlayers = currentPlayers.OrderByDescending(p => p.Score);
            foreach (var player in sortedPlayers)
            {
                Console.WriteLine(player.ToString());
            }
        }

       

        Console.WriteLine($"Ümumi Oyunçu Sayı: {GamePlayer.TotalPlayers}");

        Console.WriteLine($"Ən Yüksək Xal: {GamePlayer.HighestScore}");
        
    }
}