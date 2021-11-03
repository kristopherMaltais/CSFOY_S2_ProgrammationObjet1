using System;
using System.Collections.Generic;
using System.Text;

namespace PO1Examen1
{
    public class Fonctions
    {
        public static int ChoixUtilisateur(int min, int max)
        {
            // Préconditions
            if(min < 0 || max < 0)
            {
                throw new ArgumentException("Paramètre ne peut pas être null");
            }

            if (min > max)
            {
                throw new ArgumentException("Min ne peut pas être plus grand que max");
            }

            // Boucle qui demande au joueur de saisir un nombre entier tant que ne correspond pas aux critères
            string choixUtilisateur;
            int choixUtilisateurInt;
            do
            {
                Console.Write("Votre choix: ");
                choixUtilisateur = Console.ReadLine();
                bool conversionReussi = int.TryParse(choixUtilisateur, out choixUtilisateurInt);
                if (conversionReussi)
                {
                    continue;
                }

                else
                {
                    choixUtilisateurInt = -1;
                }
                
            } while (choixUtilisateurInt < min || choixUtilisateurInt > max);

            return choixUtilisateurInt - 1;
        }

        public static void ChoisirPosition(Grille jeu, char joueur)
        {
            // Précondition
            if (jeu == null)
            {
                throw new ArgumentException("le paramètre jeu ne peut pas être null");
            }

            if(joueur != 'x' && joueur != 'o')
            {
                throw new ArgumentException("le paramètre joueur doit avoir comme valeur x ou o");
            }

            //Déclaration des variables
            int y, x;

            bool finTour = false; // Bool qui détermine à qui est le tour de jeu
            while (!finTour)
            {
                // Sur quelle rangée le joueur veut se positionner
                Console.WriteLine("Sur quelle rangée voulez-vous vous placer: ");
                y = Fonctions.ChoixUtilisateur(1, jeu.Largeur);

                // Sur quelle colonne le joueur veut se postionner
                Console.WriteLine("Sur quelle colonne voulez-vous vous placer: ");
                x = Fonctions.ChoixUtilisateur(1, jeu.Largeur);

                // Évaluer si la case est déjà prise
                char caractere = jeu.ObtenirCaractere(y, x);
                if (caractere != '_')
                {
                    Console.WriteLine("Vous ne pouvez pas jouer sur cette case...");
                }

                // Placer joueur si case est libre
                else
                {
                    Console.WriteLine("Votre position a été effectué!");
                    jeu.placerCaractere(joueur, y, x);
                    finTour = true;
                }
            }
        }

        public static char ChangementJoueur(char joueur)
        {
            if(joueur != 'x' && joueur != 'o')
            {
                throw new ArgumentException("Le joueur doit avoir comme valeur x ou o");
            }

            // Si tour actuel est x changer pour o
            if (joueur == 'x')
            {
                joueur = 'o';
            }

            // Si tout actuel est o changer pour x
            else
            {
                joueur = 'x';
            }

            return joueur;
        }

        public static void PartieGagnant(char gagnant)
        {
            // Précondition
            if (gagnant != '_' && gagnant != 'o' && gagnant != 'x')
            {
                throw new ArgumentException("gagnant doit être égale à _, x ou o");
            }

            // Si aucun gagnant
            if (gagnant == '_')
            {
                Console.WriteLine("Aucun gagnant à présent");
            }

            // S'il y a un gagnant
            else
            {
                Console.WriteLine($"Le gagnant est {gagnant}!");
            }
        }
    }
}
