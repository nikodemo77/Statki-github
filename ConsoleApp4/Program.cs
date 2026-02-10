using System;

// 1 etap //

namespace GraWStatki
{
    class Program
    {
        static int rozmiar = 5;
        static char[,]
        planszaGracza = new char[rozmiar, rozmiar];
        static char[,]
        planszaKomputera = new char[rozmiar, rozmiar];
        static char[,]
        widokKomputeraDlaGracza = new char[rozmiar, rozmiar];

        static int graczStatekX, graczStatekY;
        static int kompStaekX, kompStaekY;

        static void Main(string[] args)
        {
            InicjalizujGre();

            bool koniecGry = false;

            while (!koniecGry)
            {
                RysujEkrany();
            }

        }
    }
}

// 2 etap //
// ---Twoja Kolej--- //

Console.WriteLine("\nTWOJA KOLEJ");

if (StrzalGracza())
{
    RysujEkrany();

    Console.WriteLine("Zatopiles statek przeciwnika");
    break;
}

// ---Kolej Przeciwnika--- //

Console.WriteLine("\nNacisnij klawisz aby przeciwnik strzelil");
Console.ReadLine();

if (StrzalPrzeciwnika())
{
    RysujEkran();
    Console.WriteLine("Przeciwnik zatopil twoj statek");
    break;
}












