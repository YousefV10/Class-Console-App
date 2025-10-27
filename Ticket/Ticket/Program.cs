using Ticket;

public class Program
{
    
    private static Theatre[] _theaters = new Theatre[0];
    private static Genre[] _genres = new Genre[0];
    private static Movie[] _allMovies = new Movie[0];

    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        RunMainMenu();
    }

        private static T[] AddToArray<T>(T[] sourceArray, T newElement)
    {
        int newSize = sourceArray.Length + 1;
        T[] newArray = new T[newSize];
        Array.Copy(sourceArray, newArray, sourceArray.Length);
        newArray[newSize - 1] = newElement;
        return newArray;
    }

        private static void RunMainMenu()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("==================================");
            Console.WriteLine("           ANA MENYU");
            
            Console.WriteLine("1. Yeni Teatr Yarat");
            Console.WriteLine("2. Yeni Janr Yarat");
            Console.WriteLine("3. Yeni Film Yarat");
            Console.WriteLine("4. Teatra Daxil Ol");
            Console.WriteLine("5. Proqramdan Çıx");
            Console.Write("Seçiminizi daxil edin (1-5): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1: CreateNewTheater(); break;
                    case 2: CreateNewGenre(); break;
                    case 3: CreateNewMovie(); break;
                    case 4: EnterTheaterMenu(); break;
                    case 5: isRunning = false; Console.WriteLine("Proqram dayandırılır. Xudahafiz!"); break;
                    default: Console.WriteLine("\n!!! Səhv seçim. Zəhmət olmasa, 1-5 aralığında rəqəm daxil edin."); break;
                }
            }
            else
            {
                Console.WriteLine("\n!!! Yanlış giriş formatı. Zəhmət olmasa, rəqəm daxil edin.");
            }
        }
    }

    
    private static void CreateNewTheater()
    {
        Console.Write("\nTeatrın adını daxil edin: ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("!!! Teatr adı boş ola bilməz.");
            return;
        }

        Theatre newTheater = new Theatre(name);

        
        _theaters = AddToArray(_theaters, newTheater);

        Console.WriteLine($"\n--- Uğurlu: '{newTheater.Name}' teatrı yaradıldı! (ID: {newTheater.Id})");
    }

    
    private static void CreateNewGenre()
    {
        Console.Write("\nJanrın adını daxil edin: ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("!!! Janr adı boş ola bilməz.");
            return;
        }

        Genre newGenre = new Genre(name);

        
        _genres = AddToArray(_genres, newGenre);

        Console.WriteLine($"\n--- Uğurlu: '{newGenre.Name}' janrı yaradıldı! (ID: {newGenre.Id})");
    }

        private static void CreateNewMovie()
    {
        
        if (_genres.Length == 0)
        {
            Console.WriteLine("\n!!! Janr yaratmadan film yaradıla bilməz. Əvvəlcə janr yaradın.");
            return;
        }

        
        Console.Write("\nFilmin adını daxil edin: ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) { Console.WriteLine("!!! Film adı boş ola bilməz."); return; }

        Console.Write("Rejissorun adını daxil edin: ");
        string director = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(director)) { Console.WriteLine("!!! Rejissor adı boş ola bilməz."); return; }

        
        Console.WriteLine("\nMövcud Janrlar:");
        foreach (var genre in _genres)         
        {
            Console.WriteLine(genre.ToString());
        }

        Console.Write("Janrın ID-sini seçin: ");
        if (!int.TryParse(Console.ReadLine(), out int genreId))
        {
            Console.WriteLine("!!! Yanlış ID formatı.");
            return;
        }

        
        Genre selectedGenre = _genres.FirstOrDefault(g => g.Id == genreId);
        if (selectedGenre == null)
        {
            Console.WriteLine("!!! Daxil edilən ID-yə uyğun janr tapılmadı.");
            return;
        }

        string ageLimit = SelectAgeLimit();
        if (ageLimit == null) return;

        Movie newMovie = new Movie(name, director, selectedGenre, ageLimit);

        
        _allMovies = AddToArray(_allMovies, newMovie);

        Console.WriteLine($"\n--- Uğurlu: '{newMovie.Name}' filmi yaradıldı! (ID: {newMovie.Id})");
    }   

    private static string SelectAgeLimit()
    {
       
        string[] validLimits = { "13", "16", "18+" };
        while (true)
        {
            Console.Write("Filmin AgeLimitini daxil edin (13, 16, 18+): ");
            string limit = Console.ReadLine().Trim();

            if (validLimits.Contains(limit))
            {
                return limit;
            }
            Console.WriteLine("!!! Yanlış yaş məhdudiyyəti. Zəhmət olmasa, 13, 16 və ya 18+ daxil edin.");
        }
    }

    private static void EnterTheaterMenu()
    {
        
        if (_theaters.Length == 0)
        {
            Console.WriteLine("\n!!! Hələ heç bir teatr yaradılmayıb. Əvvəlcə teatr yaradın.");
            return;
        }

        Console.WriteLine("\nMövcud Teatrlar:");
        foreach (var theater in _theaters) 
        {
            Console.WriteLine(theater.ToString());
        }

        Console.Write("Daxil olmaq istədiyiniz teatrın ID-sini seçin: ");
        if (!int.TryParse(Console.ReadLine(), out int theaterId))
        {
            Console.WriteLine("!!! Yanlış ID formatı.");
            return;
        }

        Theatre selectedTheater = _theaters.FirstOrDefault(t => t.Id == theaterId);
        if (selectedTheater == null)
        {
            Console.WriteLine("!!! Daxil edilən ID-yə uyğun teatr tapılmadı.");
            return;
        }

        RunTheaterMenu(selectedTheater);
    }

  
}