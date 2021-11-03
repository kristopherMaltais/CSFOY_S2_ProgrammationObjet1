using System;

namespace Bibliotheque_Classes
{
    public abstract class Joueur
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public string Nom { get; set; }

        // ** Constructeur ** //
        public Joueur(string p_Nom)
        {
            // Préconditions
            if (p_Nom == null)
            {
                throw new ArgumentNullException("p_Nom", "Le nom ne peut pas être null");
            }

            if (p_Nom.Length == 0)
            {
                throw new ArgumentException("p_Nom", "Le nom ne peut pas être vide");
            }

            Nom = p_Nom;
        }

        public override string ToString()
        {
            return Nom;
        }


        // ** Méthode ** //
    }
}
