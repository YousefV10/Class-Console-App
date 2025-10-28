using System;
using System.Linq;

public class GamePlayer
{
    public string PlayerName { get; private set; }
    public int Score { get; private set; }
    public int PlayerID { get; private set; }

    public static int TotalPlayers { get; private set; }
    public static int HighestScore { get; private set; }
    private static int NextID = 1;

    private static GamePlayer[] allPlayers = new GamePlayer[0];

    public GamePlayer(string name, int initialScore = 0)
    {
        this.PlayerName = name;
        this.Score = initialScore;

        this.PlayerID = NextID++;

        TotalPlayers++;

        AddPlayerToArray(this);

        CheckForNewHighestScore(this.Score);

        Console.WriteLine($"--- Yeni Oyunçu Qoşuldu ---");
        Console.WriteLine($"ID: {this.PlayerID}, Ad: {this.PlayerName}, İlkin Xal: {this.Score}");
    }

    private static void AddPlayerToArray(GamePlayer player)
    {
        GamePlayer[] newPlayers = new GamePlayer[allPlayers.Length + 1];

        Array.Copy(allPlayers, newPlayers, allPlayers.Length);

        newPlayers[newPlayers.Length - 1] = player;

        allPlayers = newPlayers;
    }


    private static void CheckForNewHighestScore(int score)
    {
        if (score > HighestScore)
        {
            HighestScore = score;
        }
    }

    public void UpdateScore(int newScore)
    {
        if (newScore < 0)
        {
            Console.WriteLine("Xal mənfi ola bilməz.");
            return;
        }

        Console.WriteLine($"*** Xal Yenilənməsi ***");
        Console.WriteLine($"{this.PlayerName} (ID: {this.PlayerID}) xalı {this.Score}-dan {newScore}-a dəyişdirildi.");

        this.Score = newScore;
        CheckForNewHighestScore(this.Score);
    }

    public override string ToString()
    {
        return $"ID: {PlayerID,-3} | Ad: {PlayerName,-15} | Xal: {Score,-5}";
    }

    public static void RemovePlayer(GamePlayer playerToRemove)
    {
        if (playerToRemove == null) return;

        int indexToRemove = -1;
        for (int i = 0; i < allPlayers.Length; i++)
        {
            if (allPlayers[i].PlayerID == playerToRemove.PlayerID)
            {
                indexToRemove = i;
                break;
            }
        }

        if (indexToRemove != -1)
        {
            Console.WriteLine($" --- Oyunçu Silindi ---");
            Console.WriteLine($"Oyunçu: {playerToRemove.PlayerName} (ID: {playerToRemove.PlayerID}) oyundan çıxarıldı.");

            TotalPlayers--;

            GamePlayer[] newPlayers = new GamePlayer[allPlayers.Length - 1];

            Array.Copy(allPlayers, 0, newPlayers, 0, indexToRemove);

            Array.Copy(allPlayers, indexToRemove + 1, newPlayers, indexToRemove, allPlayers.Length - (indexToRemove + 1));

            allPlayers = newPlayers;

            if (playerToRemove.Score == HighestScore)
            {
                ReCalculateHighestScore();
            }
        }
        else
        {
            Console.WriteLine($" Oyunçu {playerToRemove.PlayerName} siyahıda tapılmadı.");
        }
    }

    private static void ReCalculateHighestScore()
    {
        HighestScore = 0; 
        if (allPlayers.Length > 0)
        {
            HighestScore = allPlayers.Max(p => p.Score);
        }
    }

    public static GamePlayer[] GetAllPlayers()
    {
        GamePlayer[] copy = new GamePlayer[allPlayers.Length];
        Array.Copy(allPlayers, copy, allPlayers.Length);
        return copy;
    }
}