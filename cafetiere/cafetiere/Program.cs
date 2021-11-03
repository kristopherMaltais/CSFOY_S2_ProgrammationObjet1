using System;
using System.Collections.Generic;

namespace cafetiere
{
    class Program
    {
        static void Main(string[] args)
        {
            Cafetiere();
        }

        public static void Cafetiere()
        {
            // Type de café présent dans la machine à café
            Cafe cafe1 = new Cafe("Espresso", 2.50m);
            Cafe cafe2 = new Cafe("Latté", 4.50m);
            Cafe cafe3 = new Cafe("Moka", 1.50m);
            Cafe cafe4 = new Cafe("Filtre", 1.0m);
            Cafe cafe5 = new Cafe("Americano", 4.50m);

            // Créer une liste contenant tous les types de café à l'intérieur
            List<Cafe> listeCafe = new List<Cafe> { cafe1, cafe2, cafe3, cafe4, cafe5 };

            // Instanciation machine à café
            MonnayeurCafetiere machine1 = new MonnayeurCafetiere();
            machine1.Initialiser();

            // Simulation de la machine à café
            while (true)
            {
                // Afficher les types de café disponible dans la machine à café + choix utilisateur
                Fonctions.AfficherCafes(listeCafe);

                // Saisie utilisateur pour le choix du café
                int choixUtilisateur = Fonctions.ChoixCafe(listeCafe);

                // Ajouter les pièces d'argent dans la machine
                decimal monnaie;
                do
                {
                    Console.Write("Entrez votre pièce de monnaie: ");
                    monnaie = decimal.Parse(Console.ReadLine());
                    machine1.RecevoirPiece(monnaie);
                } while (machine1.MontantDonneParClient < listeCafe[choixUtilisateur].PrixCafe);

                // Afficher informations sur l'achat du café
                Fonctions.AfficherInformation(listeCafe[choixUtilisateur], machine1);
               
            }
        }

    }
}
