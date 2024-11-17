
using System;
using System.Collections.Generic;

namespace Exercice5_gestion_exception
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Étape 3 : Demander les bornes
                Console.Write("Entrez la borne inférieure : ");
                int lowerBound = int.Parse(Console.ReadLine());

                Console.Write("Entrez la borne supérieure : ");
                int upperBound = int.Parse(Console.ReadLine());

                if (lowerBound >= upperBound)
                {
                    throw new ArgumentException("La borne inférieure doit être strictement inférieure à la borne supérieure.");
                }

                // Génération du nombre aléatoire
                Random random = new Random();
                int target = random.Next(lowerBound, upperBound + 1);

                // Variables pour le jeu
                List<int> attempts = new List<int>();
                int attemptsCount = 0;
                bool hasWon = false;

                Console.WriteLine($"Trouvez le nombre entre {lowerBound} et {upperBound} !");

                while (!hasWon)
                {
                    try
                    {
                        Console.Write("Choisissez un nombre : ");
                        int guess = int.Parse(Console.ReadLine());

                        // Vérification de la validité de l'entrée
                        if (guess < lowerBound || guess > upperBound)
                        {
                            throw new ArgumentOutOfRangeException(nameof(guess), $"Saisissez un nombre entre [{lowerBound}, {upperBound}].");
                        }

                        // Ajouter le choix au tableau
                        attempts.Add(guess);
                        attemptsCount++;

                        // Vérification du résultat
                        if (guess == target)
                        {
                            Console.WriteLine("Vous avez gagné !");
                            hasWon = true;
                        }
                        else
                        {
                            Console.WriteLine("Vous avez perdu, essayez encore.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Erreur : Vous devez entrer un nombre valide.");
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine($"Erreur : {ex.Message}");
                    }
                }

                // Calcul de la note
                double score = (double)(upperBound - lowerBound + 1) / attemptsCount;
                Console.WriteLine($"Vous avez trouvé le nombre après {attemptsCount} tentatives.");
                Console.WriteLine($"Vos choix : {string.Join(", ", attempts)}");
                Console.WriteLine($"Votre note : {score:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
            }
        }
    }
}
