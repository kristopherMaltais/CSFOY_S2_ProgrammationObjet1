using System;
using System.Collections.Generic;
using System.Text;

namespace Bibliotheque_Classes
{
    public class Codeur : Joueur
    {
        // ** Champs ** //


        // ** Propriétés ** //
        public Code Secret;

        // ** Constructeur ** //
        public Codeur(string p_Nom, int p_Longueur) : base(p_Nom)
        {
            Secret = new Code(p_Longueur);
        }

        public Codeur(string p_Nom, Code p_Solution) : base(p_Nom)
        {
            Secret = p_Solution;
        }

        // ** Méthode ** //
        public override string ToString()
        {
            return base.Nom;
        }
    }
}
