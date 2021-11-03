using System;
using System.Collections.Generic;
using System.Text;

namespace cafetiere
{
    public class Fonctions
    {
        public static void AfficherCafes(List<Cafe> p_cafeListe)
        {
            if (p_cafeListe == null)
            {
                throw new ArgumentException("La liste de café ne peut pas être null", "p_cafeListe");
            }

            for (int index = 0; index < p_cafeListe.Count; index++)
            {
                Console.WriteLine($"[{index + 1}] Type: {p_cafeListe[index].NomCafe} | Prix: {p_cafeListe[index].PrixCafe}");
            }
        }

        public static int ChoixCafe(List<Cafe> p_listeCafe)
        {
            if (p_listeCafe == null)
            {
                throw new ArgumentException("La liste de café ne peut pas être null", "p_listeCafe");
            }
            int choixUtilisateur;

            do
            {
                Console.WriteLine();
                Console.Write("Quel café voulez-vous acheter: ");
                choixUtilisateur = int.Parse(Console.ReadLine());
            } while (choixUtilisateur < 0 || choixUtilisateur > p_listeCafe.Count);

            return choixUtilisateur;
        }

        public static void AfficherInformation(Cafe p_cafe, MonnayeurCafetiere p_cafetiere)
        {
            if (p_cafe == null)
            {
                throw new ArgumentException("La liste de café ne peut pas être null", "p_listeCafe");
            }

            if (p_cafetiere == null)
            {
                throw new ArgumentException("L'objet p_cafetiere ne peut pas être null", "p_cafetiere");
            }


            // Afficher informations pertinentes au client
            Console.WriteLine();
            Console.WriteLine("Vous avez insérez assez d'argent pour votre café!");
            Console.WriteLine($"Total monnaie : {p_cafetiere.MontantDonneParClient}$");
            Console.WriteLine($"Votre {p_cafe.NomCafe} est prêt!");
            Console.WriteLine($"Retour monnaie: {p_cafetiere.RendreMonnaie(p_cafe.PrixCafe)}");

            // Confirmer la vente
            p_cafetiere.ConfirmerVente(p_cafe.PrixCafe);
            Console.WriteLine();

            // Afficher montant caisse machine à café
            p_cafetiere.AfficherEtat();
            Console.WriteLine();
        }
    }
}
