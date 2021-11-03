using System;
using System.Collections.Generic;

namespace voiture
{
    class Program
    {
        static void Main(string[] args)
        {
            ExerciceVoiture();
        }

        public static void ExerciceVoiture()
        {
            // Déclaration des variables
            int choixUtilisateur;
            int vitesse;
            bool voitureCree = false;
            Voiture voiture1 = new Voiture();

            //Afficher le menu
            Fonctions.AfficherMenu();

            do
            {
                // Enregistrer le choix de l'utilisateur
                choixUtilisateur = Fonctions.ChoixUtilisateur(voitureCree);

                switch (choixUtilisateur)
                {
                    case 1:
                        voiture1.Initialiser("honda", "civic");
                        voitureCree = true;
                        break;
                    case 2:
                        voiture1.Demarrer();
                        break;
                    case 3:
                        voiture1.Arreter();
                        break;
                    case 4:
                        Console.Write("Vous voulez accélerer de combien de km/h: ");
                        vitesse = int.Parse(Console.ReadLine());
                        voiture1.Accelerer(vitesse);
                        break;
                    case 5:
                        Console.Write("Vous voulez freiner de combien de km/h: ");
                        vitesse = int.Parse(Console.ReadLine());
                        voiture1.Freiner(vitesse);
                        break;
                    case 6:
                        Console.WriteLine(voiture1);
                        break;
                }


            } while (choixUtilisateur != 7);
        }
    }

    
}
