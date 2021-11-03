using System;
using System.Collections.Generic;
using System.Text;

namespace Bibliotheque_Classes
{
    public abstract class Decodeur : Joueur 
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public Code Tentative = null;

        // ** Constructeur ** //
        public Decodeur(string p_Nom) : base(p_Nom) { }


        // ** Méthode ** //
        public abstract Code ObtenirCode(int p_NbCouleur, int p_Longueur);

        public override string ToString()
        {
            return base.Nom;
        }

    }
}
