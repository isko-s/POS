using ProductsPdc;

public static class ListSistem
{
    public static void List()
    {
        do
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("1. Products");
            Console.WriteLine("2. Izlaz");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.Write("Izbor: ");
            string unos = Console.ReadLine();
            switch (unos)
            {
                case "1":
                    ListProducts();
                    break;

                case "2":
                    Popis();
                    return;
            }
            Console.Clear();
        } while (true);
    }

    public static void Popis()
    {
        if (File.Exists("art.txt"))
        {
            File.Delete("art.txt");
        }
        Product._products.ForEach(art => File.AppendAllText("art.txt", art.ZaFajl()));
    }

    public static void ListProducts()
    {
        Console.Clear();
        Console.WriteLine("1. Unos artikla");
        Console.WriteLine("2. Promena cene artikla");
        Console.WriteLine("3. Prikaz");
        Console.WriteLine("4. Nazad");
        Console.Write("Izbor: ");
        string unos = Console.ReadLine();
        switch (unos)
        {
            case "1":
                UnosArtikla();
                break;

            case "2":
                PromenaCene();
                break;

            case "3":
                PrikazProducta();
                break;

            case "4":
                return;
        }
    }

    public static void PrikazProducta()
    {
        Product._products.ForEach(art => Console.WriteLine(art));
        Console.ReadKey();
    }

    public static void PromenaCene()
    {
        Console.Clear();
        Console.Write("Unesite sifru artikla: ");
        string sifra = Console.ReadLine();

        Product a = Product._products.Where(art => art._sifra == sifra).FirstOrDefault();
        if (a is not null)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"Nadjen Product {a._naziv}");
            Console.Write("Marza ili izlazna (m/i)?");
            string promena = Console.ReadLine();
            switch (promena)
            {
                case "m":
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("Unesite marzu: ");
                    int marza = int.Parse(Console.ReadLine());
                    if (marza is > 10 and < 100)
                    {
                        a._marzaProc = marza;
                        a._izlazna = a._ulazna * (1 + (marza / 100M));
                        a._izlaznaPorez = a._izlazna * (1 + (a._porezProc / 100M));
                    }
                    else
                    {
                        Console.WriteLine("Jok marza");
                    }
                    break;

                case "i":
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("Unesite izlaznu: ");
                    decimal icena = decimal.Parse(Console.ReadLine());
                    if (icena > a._ulazna)
                    {
                        a._izlazna = icena;
                        a._marzaProc = (int)(((icena / a._ulazna) - 1) * 100);
                        a._izlaznaPorez = a._izlazna * (1 + (a._porezProc / 100M));
                    }
                    else
                    {
                        Console.WriteLine("Jok izlazna");
                    }
                    break;
            }
        }
        else
        {
            Console.WriteLine("Joook");
        }
        Console.ReadKey();
    }

    public static void UnosArtikla()
    {
        Product a = new();
        Console.Write("Unesi sifru: ");
        a._sifra = Console.ReadLine();

        if (Product._products.Where(art => a._sifra == art._sifra).Any())
        {
            Console.WriteLine("Jooook");
        }
        else
        {
            Console.Write("Unesi naziv: ");
            a._naziv = Console.ReadLine();
            Console.Write("Unesi kolicina: ");
            a._kolicina = int.Parse(Console.ReadLine());
            Console.Write("Unesi ucenu: ");
            a._ulazna = decimal.Parse(Console.ReadLine());
            Console.Write("Unesi porez");
            a._porezProc = int.Parse(Console.ReadLine());
            if (a._kolicina >= 0 && a._ulazna > 0 && a._porezProc >= 0)
            {
                Product._products.Add(a);
            }
            else
            {
                Console.WriteLine("Nis' ne valja");
                return;
            }
        }
    }
}