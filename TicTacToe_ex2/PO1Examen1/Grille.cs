using System;
using System.Collections.Generic;
using System.Text;

namespace PO1Examen1
{
    public class Grille
    {
        // Champs privé
        private char[,] m_grille;
        private int m_largeur = 3;

        // Propriétés
        public int Largeur => m_largeur;

        // Constructeur
        public Grille()
        {
            m_grille = new char[m_largeur, m_largeur];

            // Loop qui initialise les cases vides d'une nouvelle partie
            for (int y = 0; y < m_largeur; y++)
            {
                for (int x = 0; x < m_largeur; x++)
                {
                    m_grille[y, x] = '_';
                }
            }

        }

        // Méthode
        public char ObtenirCaractere(int y, int x)
        {
            // Précondition
            if (x < 0 || x > 3 || y < 0 || y > 3)
            {
                throw new ArgumentException("le paramètre x et y doivent être entre 0 et 3 inclusivement");
            }

            char caractere = m_grille[y, x];
            return caractere;
        }

        public void placerCaractere(char c, int y, int x)
        {
            // Précondition
            if (x < 0 || x > 3 || y < 0 || y > 3)
            {
                throw new ArgumentException("le paramètre x et y doivent être entre 0 et 3 inclusivement");
            }

            if(c != 'x' && c != 'o')
            {
                throw new ArgumentException("le caractère placé doit être x ou o");
            }

            if(m_grille[y, x] == 'x' || m_grille[y, x] == 'o')
            {
                Console.WriteLine("Impossible de placer un pion, la case est déjà utilisé");
            }

            else
            {
                m_grille[y, x] = c;
            }
        }

        public char Gagnant()
        {
            char joueurTour;

            // Victoire sur la diagonale principale
            for (int tour = 0; tour < 2; tour++)
            {
                // Vérifier si le O gagne
                if (tour == 0) {joueurTour = 'o';}

                // Vérifier si le X gagne
                else {joueurTour = 'x';}

                // Victoire diago principale
                if (m_grille[0, 0] == joueurTour && m_grille[1, 1] == joueurTour && m_grille[2, 2] == joueurTour)
                {
                    return joueurTour;
                }

                // Victoire seconde diago 
                if (m_grille[0, 2] == joueurTour && m_grille[1, 1] == joueurTour && m_grille[2, 0] == joueurTour)
                {
                    return joueurTour;
                }

                // victoire sur une colonne
                for (int colonne = 0; colonne < Largeur; colonne++)
                {
                    if (m_grille[0, colonne] == joueurTour && m_grille[1, colonne] == joueurTour && m_grille[2, colonne] == joueurTour)
                    {
                        return joueurTour;
                    }
                }

                // victoire sur une ligne
                for (int ligne = 0; ligne < Largeur; ligne++)
                {
                    if (m_grille[ligne, 0] == joueurTour && m_grille[ligne, 1] == joueurTour && m_grille[ligne, 2] == joueurTour)
                    {
                        return joueurTour;
                    }
                }
          
            }

            // Si aucun gagnant retourner _
            return '_';
        }

        public override string ToString()
        {
            string grille = $"{m_grille[0, 0]}{m_grille[0, 1]}{m_grille[0, 2]} \n{m_grille[1, 0]}{m_grille[1, 1]}{m_grille[1, 2]} \n{m_grille[2, 0]}{m_grille[2, 1]}{m_grille[2, 2]}";
            return grille;
        }
    }
}
