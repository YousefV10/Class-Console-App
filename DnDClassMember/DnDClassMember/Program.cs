Console.WriteLine("=== Welcome To DnD Game! ===");
List<Character> players = new List<Character>();

// === Oyunçular əlavə olunur ===
while (true)
{
    Console.Write("Oyuncu adı daxil et (ve ya 'start' yaz): ");
    string name = Console.ReadLine();
    if (name.ToLower() == "start") break;

    Console.WriteLine("Sinif seç:");
    Console.WriteLine("1 - Archer");
    Console.WriteLine("2 - Warior ");
    Console.WriteLine("3 - Mage");
    Console.WriteLine("4 - Tank");
    Console.Write("Seçim: ");
    string choice = Console.ReadLine();

    Character player = choice switch
    {
        "1" => new Archer(name),
        "2" => new Warrior(name),
        "3" => new Mage(name),
        "4" => new Tank(name),
        _ => null
    };

    if (player != null)
    {
        players.Add(player);
        Console.WriteLine($"{name} ({player.ClassName}) elave edildi!\n");
    }
    else
        Console.WriteLine("Yanlıs seçim!\n");
}

if (players.Count == 0)
{
    Console.WriteLine("Oyunçu yoxdur!");
    return;
}

// === Düşmən yaradılır (Dungeon Master tərəfindən) ===
Console.Write("\n Enemy  adını daxil et: ");
string enemyName = Console.ReadLine();
Console.Write("Enemy HP : ");
int enemyHP = int.Parse(Console.ReadLine());
Console.Write("Enemy   AD : ");
int enemyDamage = int.Parse(Console.ReadLine());

Enemy enemy = new Enemy(enemyName, enemyHP, enemyDamage);
Console.WriteLine($"\n Monster  meydana çıxır: {enemy.Name} (HP: {enemy.HP})\n");

int round = 1;
while (enemy.IsAlive() && players.Exists(p => p.IsAlive()))
{
    Console.WriteLine($"\n===== Raund {round} =====");

    // === Oyunçuların növbəsi ===
    foreach (var player in players)
    {
        if (!player.IsAlive()) continue;

        Console.WriteLine($"\n{player.Name} ({player.ClassName}) növbəsi!");
        Console.WriteLine("1 - Attack ");
        if (player is Mage) Console.WriteLine("2 -  Heal ");
        if (player is Tank) Console.WriteLine("3 - Guard ");
        Console.WriteLine("0 - Pass");
        Console.Write("Choice : ");
        string action = Console.ReadLine();

        switch (action)
        {
            case "1":
                player.Attack(enemy, manual: true);
                break;
            case "2" when player is Mage mage:
                Character target = ChooseTeammate(players);
                if (target != null) mage.Heal(target, manual: true);
                break;
            case "3" when player is Tank tank:
                Character ally = ChooseTeammate(players);
                if (ally != null) tank.Protect(ally);
                break;
            default:
                Console.WriteLine($"{player.Name} bu turda heç nə etmədi.");
                break;
        }

        if (!enemy.IsAlive())
        {
            Console.WriteLine($" Monster  is Defeated !");
            break;
        }
    }

    // === Düşmənin növbəsi ===
    if (enemy.IsAlive())
    {
        Character target = ChooseAlivePlayer(players);
        if (target == null) break;

        Console.WriteLine($"\nDungeon Master, indi {enemy.Name} ücün zer at!");
        enemy.Attack(target, manual: true);
    }

    round++;
    Thread.Sleep(800);
}

Console.WriteLine("\n=== Game Over ! ===");
if (enemy.IsAlive())
    Console.WriteLine($" Player is Defeated . Enemy Still Standing (I am stil standin ) : {enemy.HP} HP");
else
    Console.WriteLine(" Win! Enemy Defeated !");
        

        static Character ChooseTeammate(List<Character> players)
{
    Console.WriteLine("Choice one Player");
    for (int i = 0; i < players.Count; i++)
        Console.WriteLine($"{i + 1}. {players[i].Name} ({players[i].ClassName}) - HP: {players[i].HP}");

    Console.Write("Choice :  ");
    if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= players.Count)
        return players[index - 1];

    Console.WriteLine("Wrong Choice ");
    return null;
}

static Character ChooseAlivePlayer(List<Character> players)
{
    var alivePlayers = players.FindAll(p => p.IsAlive());
    if (alivePlayers.Count == 0) return null;

    Console.WriteLine("Dungeon Master, Monster  kime hücum etsin?");
    for (int i = 0; i < alivePlayers.Count; i++)
        Console.WriteLine($"{i + 1}. {alivePlayers[i].Name} ({alivePlayers[i].ClassName}) - HP: {alivePlayers[i].HP}");

    Console.Write("Choice : ");
    if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= alivePlayers.Count)
        return alivePlayers[index - 1];

    Console.WriteLine("Wrong Coice ! Monster  tesadufi hucum edecek.");
    return alivePlayers[new Random().Next(alivePlayers.Count)];
}