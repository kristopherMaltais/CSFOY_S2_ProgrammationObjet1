using System;
using System.Linq;
using System.Collections.Generic;
using Bibliotheque_Classes;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            // Déclaration des variables
            int nombreEssai = 10;
            int[] tableauInt = new int[] { 1, 2, 3, 3 };
            Code codeFixe = new Code(tableauInt);

            Codeur codeur1 = new Codeur("Denis Rinfret", codeFixe);
            Codeur codeur2 = new Codeur("Pierre-Francois Léon", 4);

            DecodeurHumain humain = new DecodeurHumain("Kristopher Maltais");
            DecodeurIA intelligenceArtificielle = new DecodeurIA("Marcotron");

            // Jouer au jeu avec un humain (Enlever commentaire d'un l'un ou l'autre pour jouer avec un robot ou un humain)
            //MasterMind(codeur1, intelligenceArtificielle, nombreEssai);
            MasterMind(codeur2, humain, nombreEssai);
        }

        public static void MasterMind(Codeur p_Codeur, Decodeur p_Decodeur, int NbEssai)
        {
            // Déclaration des variables
            string messageFinJeu = "";
            int essai = 0;
            (int, int) resultatTour = (0, 0);

            // Boucle de jeu
            while (essai != NbEssai && resultatTour.Item1 != 4)
            {
                
                // Comparer le code du joueur à celui du codeur
                resultatTour = p_Codeur.Secret.Compare(p_Decodeur.ObtenirCode(p_Codeur.Secret.NbCouleur, p_Codeur.Secret.LongueurCode));
                Console.WriteLine($"{p_Decodeur.Nom} fait la tentative suivante: {p_Decodeur.Tentative.ToString()}        Noir: {resultatTour.Item1} Blanc: {resultatTour.Item2} \n");
                //Console.WriteLine($"Noir: {resultatTour.Item1} Blanc: {resultatTour.Item2}");
                
                // Incrémenter le nombre d'essai
                essai++;
            }

            string messageGagnant = $"Bravo! Tu as trouvé le super code! Le code de {p_Codeur.Nom} était: {p_Codeur.Secret.ToString()}";
            string messagePerdant = $"tu as perdu la partie! - La solution: {p_Codeur.Secret.ToString()}";
            messageFinJeu = essai == NbEssai && resultatTour.Item1 != 4 ? messagePerdant : messageGagnant;

            Console.WriteLine(messageFinJeu);
        }
    }
}
