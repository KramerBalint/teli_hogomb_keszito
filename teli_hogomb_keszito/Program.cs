using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, int> hogomb = new Dictionary<string, int>();

        while (true)
        {
            Console.WriteLine("Parancs (hozzáadás/megtekintés/törlés/befejezés):");
            string parancs = Console.ReadLine().ToLower();

            if (parancs == "befejezés")
                break;

            switch (parancs)
            {
                case "hozzáadás":
                    try
                    {
                        Console.WriteLine("Elem neve:");
                        string nev = Console.ReadLine();
                        if (nev == null || nev.Trim() == "")
                            throw new ArgumentException("Az elem neve nem lehet üres!");

                        Console.WriteLine("Elem száma:");
                        string darabszamBemenet = Console.ReadLine();
                        int darabszam;
                        if (!int.TryParse(darabszamBemenet, out darabszam))
                            throw new FormatException("Hibás formátum! Az elemek számát számként kell megadni.");

                        if (hogomb.ContainsKey(nev))
                            hogomb[nev] += darabszam;
                        else
                            hogomb[nev] = darabszam;

                        Console.WriteLine($"Hozzáadva: {nev} - {darabszam} db");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Hiba: {ex.Message}");
                    }
                    break;

                case "megtekintés":
                    try
                    {
                        if (hogomb.Count == 0)
                        {
                            Console.WriteLine("A hógömb üres.");
                        }
                        else
                        {
                            Console.WriteLine("A hógömb tartalma:");
                            int index = 1;
                            foreach (var elem in hogomb)
                            {
                                Console.WriteLine($"{index}. {elem.Key} - {elem.Value} db");
                                index++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Hiba: {ex.Message}");
                    }
                    break;

                case "törlés":
                    try
                    {
                        Console.WriteLine("Elem neve:");
                        string torlendo = Console.ReadLine();

                        if (torlendo == null || torlendo.Trim() == "")
                            throw new ArgumentException("Az elem neve nem lehet üres!");

                        if (hogomb.ContainsKey(torlendo))
                        {
                            hogomb.Remove(torlendo);
                            Console.WriteLine($"Eltávolítva: {torlendo}");
                        }
                        else
                        {
                            throw new KeyNotFoundException("Ez az elem nem található a hógömbben.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Hiba: {ex.Message}");
                    }
                    break;

                default:
                    Console.WriteLine("Ismeretlen parancs.");
                    break;
            }
        }

        Console.WriteLine("A program vége.");
    }
}
