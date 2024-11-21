
using System;
using System.Collections.Generic;

namespace Exercice7_enumeration
{
    class Program
    {
        // Enumération pour représenter les chiffres hexadécimaux
        enum HexDigits
        {
            Zero = 0, Un, Deux, Trois, Quatre, Cinq, Six, Sept, Huit, Neuf,
            A = 10, B, C, D, E, F
        }

        static void Main(string[] args)
        {
            List<(int number, string hexValue)> conversions = new List<(int, string)>();

            while (true)
            {
                Console.Write("Entrez un entier positif (ou -1 pour quitter) : ");
                if (int.TryParse(Console.ReadLine(), out int number) && number >= 0)
                {
                    string hexValue = ConvertToHex(number);
                    conversions.Add((number, hexValue));
                    Console.WriteLine($"L'entier {number} en hexadécimal est : {hexValue}");
                }
                else if (number == -1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Veuillez entrer un entier positif valide.");
                }
            }

            // Afficher la liste des conversions
            Console.WriteLine("\nListe des conversions effectuées :");
            foreach (var conversion in conversions)
            {
                Console.WriteLine($"{conversion.number} -> {conversion.hexValue}");
            }
        }

        static string ConvertToHex(int number)
        {
            List<string> hexDigits = new List<string>();

            do
            {
                int remainder = number % 16;
                hexDigits.Add(((HexDigits)remainder).ToString());
                number /= 16;
            } while (number > 0);

            hexDigits.Reverse();
            return string.Join("", hexDigits);
        }
    }
}
