using System;
using System.Collections.Generic;
using System.Text;

namespace Facture
{
    public class Fonctions
    {
        public static void AfficherMenu()
        {
            Console.WriteLine("Sytème de facture MÉTRO MON ÉPICIER");
            Console.WriteLine("[1] Nouvelle facture");
            Console.WriteLine("[2] Scanner un article");
            Console.WriteLine("[3] Afficher facture");
            Console.WriteLine("[4] Quitter");
        }

        public static int SaisirChoixutilisateur(int nombreChoix)
        {
            // Précondition
            if(nombreChoix <= 0)
            {
                throw new ArgumentException("le nombre de choix ne peut pas être égal ou inférieur à 0", "nombreChoix");
            }

            try
            {
                int choixUtilisateur = int.Parse(Console.ReadLine());

                // Boucle qui contrôle le choix de l'utilisateur dans les limites permises
                while (choixUtilisateur < 1 || choixUtilisateur > nombreChoix)
                {
                    Console.Write("Entrée invalide, recommencez: ");
                    choixUtilisateur = int.Parse(Console.ReadLine());
                }

                return choixUtilisateur;
            }

            catch
            {
                Console.WriteLine("Erreur...");
                Console.WriteLine("");
                return -1;
            }
            
        }

        public static void AfficherArticles(List<Article> inventaire)
        {
            // Préconditions
            if (inventaire == null)
            {
                throw new ArgumentException("La liste d'article ne peut pas être vide", "inventaire");
            }

            for (int index = 0; index < inventaire.Count; index++)
            {
                Console.WriteLine(inventaire[index].ToString());
            }
        }

        public static void AfficherFacture(Facture factureAfficher)
        {
            // Préconditions
            if(factureAfficher == null)
            {
                throw new ArgumentException("La facture ne peut pas être null", "factureAfficher");
            }

            Console.WriteLine("");
            Console.WriteLine("*********************************");
            Console.WriteLine("**  FACTURE MÉTRO MON ÉPICIER  **");
            Console.WriteLine("*********************************");

            for (int index = 0; index < factureAfficher.LignesFacture.Count; index++)
            {
                Console.WriteLine($"[{index + 1}] - {factureAfficher.LignesFacture[index].ToString()}");
            }

            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine(factureAfficher.ToString());
            Console.WriteLine("");
        }
    }
}
