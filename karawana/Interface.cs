using System;
using System.Collections.Generic;
using System.IO;

namespace karawana
{
    class Interface
    {
        //Klasa iterface służy do wyświetlania komunikatów, pobierania decyzji od gracza i przekazywania ich dalej
        public static int Play(List<Choice> choices, int range, string scPath)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"scenes\", scPath + ".txt")));
            if (range != 0) choices.ForEach(x => Console.WriteLine("[" + choices.IndexOf(x) + "] " +      //zabezpieczenie - jeśli jedynim wyjściem ze sceny jest cofnięcie czasu, po prostu odgrywa się kolejna
                File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"scenes\", x.Path + ".txt"))));
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                return -1;
            }
            Console.ForegroundColor = ConsoleColor.White;
            return GetDecision(range);
        }

        public static void WriteFile(string path)
        {
            Write(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"scenes\", path + ".txt")));
        }

        public static void Write (string line)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static int PlayHubOptions(string menuScPath)
        {
            WriteFile(menuScPath);
            int decision = GetDecision(6064);
            while (decision > 5 & decision != 6064)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Taka wartość nie jest możliwa do wyboru. Spróbuj ponownieXX.");
                Console.ForegroundColor = ConsoleColor.White;
                decision = GetDecision(6064);
            }
            Console.ForegroundColor = ConsoleColor.White;
            return decision;
        }

        public static void PlayShopWelcome(string shopScPath, int birdPrice, int armPrice)
        {
            WriteFile(shopScPath);
            Write("Sokół pocztowy kosztuje " + birdPrice + " paczek kryształu, a uzbrojenie żołnierza " + armPrice + " paczek.");
        }


        public static Dictionary<string, int> PackResources (Resources youHaveNow)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Dictionary<string, int> result = new();
            Console.WriteLine("Podaj, ile paczek kryształu chcesz wysłać: ");
            result.Add("Resources", GetDecision(youHaveNow.ResourcesNum));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Podaj, ilu kupców chcesz wysłać: ");
            result.Add("Merchants", GetDecision(youHaveNow.MerchantsNum));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("W pierwszej kolejności będą wysyłani uzbrojeni kupcy. Jeżeli masz jakieś ptaki pocztowe, też zostaną wysłane.");
            Console.ForegroundColor = ConsoleColor.White;
            return result;
        }

        public static void ShowChoiceEffect(Effect e, Resources r)
        {
            if (e.Hint != null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Pozyskano wskazówkę: " + e.Hint);
                Console.ForegroundColor = ConsoleColor.White;
                ShowHints(r);
            }
            if (e.MerchantsDmg > 0 | e.PostalBirdDmg > 0 | e.ResourcesDmg > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (e.ResourcesDmg > 0) Console.WriteLine("Straciłeś paczki kryształu");
                if (e.MerchantsDmg > 0) Console.WriteLine("Straciłeś kupców");
                if (e.PostalBirdDmg == -1) Console.WriteLine("Przyleciał do was czerwony sokół i przyłączył się do wyprawy");
                Console.ForegroundColor = ConsoleColor.White;

                ShowResources(r);
            }
            
        }

        public static void ShowHints(Resources r)
        {
            if(r.Hints != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Wskazówki: ");
                r.Hints.ForEach(x => Console.WriteLine(x));
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void ShowResources(Resources r)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Zasoby: \nPaczki Kryształu: " + r.ResourcesNum +
                "\nKupcy: " + r.MerchantsNum + "\nW tym uzbrojonych: " + r.ArmedMerchantsNum + "\nPtaków pocztowych: " + r.PostalBirdsNum + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Results (Resources r)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Nie zostały Ci żadne paczki kryształu do wysłana w drogę. Tyle zasobów póki co dotarło do Twojego ludu: ");
            ShowResources(r);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ale czy wszystkie tajemnice zostały już odkryte?");
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static int GetDecision(int range)
        {
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    int decision = int.Parse(Console.ReadLine());
                    if (decision <= range && decision >= 0) return decision;
                }

                catch (System.FormatException) { }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Taka wartość nie jest możliwa do wyboru. Spróbuj ponownie.");
                Console.ForegroundColor = ConsoleColor.White;

            }

        }

    }
}
