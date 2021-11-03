using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Bibliotheque_Classes
{
    public class DecodeurIA : Decodeur
    {
        // ** Champs ** //
        public List<int> codeUtilise = new List<int>();

        // ** Propriété ** //

        // ** Constructeur ** //
        public DecodeurIA(string p_Nom) : base(p_Nom) { }

        // ** méthode ** //
        public override Code ObtenirCode(int p_NbCouleur, int p_Longueur)
        {
            // Générer un code aléatoire unique
            Code codeAleatoire = new Code(p_Longueur, p_NbCouleur);
            while (codeUtilise.Contains(codeAleatoire.GetHashCode()))
            {
                codeAleatoire = new Code(p_Longueur, p_NbCouleur);
            }

            // Mettre le code dans le champs
            base.Tentative = codeAleatoire;

            // Ajouter le HashCode à la liste de code déjà sortie
            codeUtilise.Add(codeAleatoire.GetHashCode());

            return codeAleatoire;
        }
    }
}
