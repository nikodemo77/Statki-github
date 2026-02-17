int wybor;
Console.WriteLine("1. Rozpocznij gre w statki");
Console.WriteLine("2. Zakoncz program");
wybor = Convert.ToInt32(Console.ReadLine());

if (wybor != 1)
{
    Console.WriteLine("Zakonczono program");
    Console.ReadKey();
    return;
}

Console.WriteLine("Wybierz poziom trudnosci:");
Console.WriteLine("1. Latwy (30 prob)");
Console.WriteLine("2. Normalny (20 prob)");
Console.WriteLine("3. Trudny (15 prob)");
int poziom = Convert.ToInt32(Console.ReadLine());

int proby;
if (poziom == 1) proby = 30;
else if (poziom == 3) proby = 15;
else proby = 20;

Console.Clear();
Console.WriteLine("=== WITAJ W GRZE W STATKI ===");
Console.WriteLine("Masz " + proby + " prob.");
Console.WriteLine("Nacisnij Enter aby zaczac...");
Console.ReadLine();
Console.Clear();

List<(int x, int y)> statki = new List<(int, int)>();
string[,] plansza = new string[10, 10];
for (int i = 0; i < 10; i++)
    for (int j = 0; j < 10; j++)
        plansza[i, j] = ".";


void DodajStatekUzytkownika(int dlugosc)
{
    bool dodany = false;
    while (!dodany)
    {
        Console.Clear();
        Console.WriteLine("=== Ustaw swoj statek długości " + dlugosc + " ===");
        Console.WriteLine("Plansza:");
        Console.Write("  ");
        for (int k = 1; k <= 10; k++) Console.Write(k + " ");
        Console.WriteLine();
        for (int i = 0; i < 10; i++)
        {
            Console.Write((i + 1).ToString().PadRight(3));
            for (int j = 0; j < 10; j++)
            {
                Console.Write(plansza[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.Write("Podaj X startowe (1-10): ");
        int startX = Convert.ToInt32(Console.ReadLine());
        Console.Write("Podaj Y startowe (1-10): ");
        int startY = Convert.ToInt32(Console.ReadLine());
        Console.Write("Kierunek (0 = poziomo, 1 = pionowo): ");
        int kierunek = Convert.ToInt32(Console.ReadLine());

        List<(int x, int y)> tymczasowe = new List<(int x, int y)>();
        bool poprawny = true;

        for (int i = 0; i < dlugosc; i++)
        {
            int x = startX;
            int y = startY;
            if (kierunek == 0) x += i;
            else y += i;

            if (x < 1 || x > 10 || y < 1 || y > 10 || statki.Contains((x, y)))
            {
                poprawny = false;
                break;
            }
            tymczasowe.Add((x, y));
        }

        if (poprawny)
        {
            statki.AddRange(tymczasowe);
            foreach (var s in tymczasowe)
                plansza[s.y - 1, s.x - 1] = "#"; 
            dodany = true;
        }
        else
        {
            Console.WriteLine("Niepoprawna pozycja statku! Nacisnij Enter i sprobuj ponownie...");
            Console.ReadLine();
        }
    }
}


DodajStatekUzytkownika(4);
DodajStatekUzytkownika(3);
DodajStatekUzytkownika(3);
DodajStatekUzytkownika(2);
DodajStatekUzytkownika(2);
DodajStatekUzytkownika(2);
DodajStatekUzytkownika(1);
DodajStatekUzytkownika(1);
DodajStatekUzytkownika(1);
DodajStatekUzytkownika(1);


List<(int x, int y)> statkiKomputer = new List<(int, int)>();
string[,] planszaKomputer = new string[10, 10];
string[,] planszaStrzalow = new string[10, 10];
Random rnd = new Random();


for (int i = 0; i < 10; i++)
    for (int j = 0; j < 10; j++)
    {
        planszaKomputer[i, j] = ".";
        planszaStrzalow[i, j] = ".";
    }


void DodajStatekKomputera(int dlugosc)
{
    bool dodany = false;
    while (!dodany)
    {
        int startX = rnd.Next(1, 11);
        int startY = rnd.Next(1, 11);
        int kierunek = rnd.Next(0, 2);

        List<(int x, int y)> tymczasowe = new List<(int x, int y)>();
        bool poprawny = true;

        for (int i = 0; i < dlugosc; i++)
        {
            int x = startX;
            int y = startY;
            if (kierunek == 0) x += i;
            else y += i;

            if (x < 1 || x > 10 || y < 1 || y > 10 || statkiKomputer.Contains((x, y)))
            {
                poprawny = false;
                break;
            }
            tymczasowe.Add((x, y));
        }

        if (poprawny)
        {
            statkiKomputer.AddRange(tymczasowe);
            foreach (var s in tymczasowe)
                planszaKomputer[s.y - 1, s.x - 1] = "#"; 
            dodany = true;
        }
    }
}


DodajStatekKomputera(4);
DodajStatekKomputera(3);
DodajStatekKomputera(3);
DodajStatekKomputera(2);
DodajStatekKomputera(2);
DodajStatekKomputera(2);
DodajStatekKomputera(1);
DodajStatekKomputera(1);
DodajStatekKomputera(1);
DodajStatekKomputera(1);


Console.Clear();
Console.WriteLine("=== Twoja plansza (statki gracza) ===");
Console.Write("  ");
for (int k = 1; k <= 10; k++) Console.Write(k + " ");
Console.WriteLine();
for (int i = 0; i < 10; i++)
{
    Console.Write((i + 1).ToString().PadRight(3));
    for (int j = 0; j < 10; j++)
    {
        Console.Write(plansza[i, j] + " ");
    }
    Console.WriteLine();
}

Console.WriteLine("Nacisnij Enter, aby kontynuowac...");
Console.ReadLine();
Console.Clear();


for (int i = 0; i < 10; i++)
    for (int j = 0; j < 10; j++)
        if (plansza[i, j] == "#")
            plansza[i, j] = ".";

int liczbaTrafien = 0;
int liczbaPudel = 0;
List<(int x, int y)> strzalyKomputera = new List<(int x, int y)>(); 

while (proby > 0 && statki.Count > 0)
{
    Console.Clear();
   
    Console.WriteLine("=== Twoja plansza (komputer strzela) ===     === Plansza przeciwnika (Twoje strzały) ===");
    Console.Write("  ");
    for (int k = 1; k <= 10; k++) Console.Write(k + " ");
    Console.Write("          ");
    for (int k = 1; k <= 10; k++) Console.Write(k + " ");
    Console.WriteLine();
    for (int i = 0; i < 10; i++)
    {
        Console.Write((i + 1).ToString().PadRight(3));
        for (int j = 0; j < 10; j++)
            Console.Write(plansza[i, j] + " ");
        Console.Write("     ");
        Console.Write((i + 1).ToString().PadRight(3));
        for (int j = 0; j < 10; j++)
            Console.Write(planszaStrzalow[i, j] + " ");
        Console.WriteLine();
    }

    Console.WriteLine("---------------------------");
    Console.WriteLine("Pozostale proby: " + proby);
    Console.WriteLine("---------------------------");

    Console.Write("Podaj X (1-10): ");
    int x = Convert.ToInt32(Console.ReadLine());
    Console.Write("Podaj Y (1-10): ");
    int y = Convert.ToInt32(Console.ReadLine());

    if (x < 1 || x > 10 || y < 1 || y > 10)
    {
        Console.WriteLine("Bledne wspolrzedne!");
        Console.ReadKey();
        continue;
    }

  
    if (statki.Contains((x, y)))
    {
        Console.WriteLine("TRAFIONY!");
        liczbaTrafien++;
        plansza[y - 1, x - 1] = "X";
        statki.Remove((x, y));
    }
    else
    {
        Console.WriteLine("PUDLO!");
        liczbaPudel++;
        plansza[y - 1, x - 1] = "O";
    }

   
    if (statkiKomputer.Contains((x, y)))
    {
        planszaStrzalow[y - 1, x - 1] = "X";
        statkiKomputer.Remove((x, y));
    }
    else
    {
        planszaStrzalow[y - 1, x - 1] = "O";
    }

    List<(int x, int y)> wolnePola = new List<(int x, int y)>();
    for (int i = 1; i <= 10; i++)
        for (int j = 1; j <= 10; j++)
            if (!strzalyKomputera.Contains((i, j)))
                wolnePola.Add((i, j));

    if (wolnePola.Count > 0)
    {
        int idx = rnd.Next(wolnePola.Count);
        int cx = wolnePola[idx].x;
        int cy = wolnePola[idx].y;

        strzalyKomputera.Add((cx, cy)); 

        if (statki.Contains((cx, cy)))
        {
            Console.WriteLine($"BOT TRAFIA w ({cx},{cy})!");
            plansza[cy - 1, cx - 1] = "X";
            statki.Remove((cx, cy));
        }
        else
        {
            Console.WriteLine($"BOT PUDŁUJE w ({cx},{cy})!");
            plansza[cy - 1, cx - 1] = "O";
        }
    }

    proby--;
    Console.WriteLine("Nacisnij Enter, aby kontynuowac...");
    Console.ReadLine();
}

if (statki.Count == 0)
{
    Console.WriteLine("GRATULACJE! Zatopiles wszystkie statki!");
}
else
{
    Console.WriteLine("KONIEC GRY - Skonczyly sie proby!");
}

Console.WriteLine("Statystyki:");
Console.WriteLine("Trafienia: " + liczbaTrafien);
Console.WriteLine("Pudla: " + liczbaPudel);
Console.WriteLine("Nacisnij dowolny klawisz aby wyjsc...");
Console.ReadKey();
