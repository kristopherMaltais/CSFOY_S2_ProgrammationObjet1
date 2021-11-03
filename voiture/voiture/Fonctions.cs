using System;
using System.Collections.Generic;
using System.Text;

namespace voiture
{
    public class Fonctions
    {
        public static void AfficherMenu()
        {
            Console.WriteLine("MENU PRINCIPAL VOITURE");
            Console.WriteLine("[1] Créer une nouvelle voiture");
            Console.WriteLine("[2] Démarrer la voiture");
            Console.WriteLine("[3] Arrêter la voiture");
            Console.WriteLine("[4] Accélérer");
            Console.WriteLine("[5] Freiner");
            Console.WriteLine("[6] Afficher l'état");
            Console.WriteLine("[7] Quitter");
            Console.WriteLine();
        }

        public static int ChoixUtilisateur(bool voitureCree)
        {
            int choix;
            Console.WriteLine();

            do
            {
                Console.Write("Que voulez-vous faire (choix doit être en 1 et 7 et voiture doit être initiliasé pour utiliser): ");
                choix = int.Parse(Console.ReadLine());
            } while ((choix < 1 || choix > 7) || (voitureCree == false && (choix > 1 && choix < 7)));
            

            return choix;
        }
    }
}
