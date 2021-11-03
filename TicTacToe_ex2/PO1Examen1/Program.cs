using System;

namespace PO1Examen1
{
    class Program
    {
        static void Main(string[] args)
        {
            Jeu();
        }

        public static void Jeu()
        {
            // Déclaration des variables
            Grille jeu = new Grille();
            char joueur = 'o';

            // Boucle tant qu'il n'y a pas de gagnant
            while (jeu.Gagnant() == '_')
            {
                // Montrer en console l'état du jeu
                Console.WriteLine(jeu.ToString());
                Console.WriteLine("");

                // Demander à un jouer de prendre une position sur la grille
                Fonctions.ChoisirPosition(jeu, joueur);

                // Déterminer à qui est le tour de jouer
                joueur = Fonctions.ChangementJoueur(joueur);    

                // Évaluer s'il y a un gagnant
                Fonctions.PartieGagnant(jeu.Gagnant());

            }
            Console.WriteLine();
            Console.WriteLine(jeu.ToString());
            Console.WriteLine();
            Console.WriteLine("Fin du jeu!");
        }
    }
}
