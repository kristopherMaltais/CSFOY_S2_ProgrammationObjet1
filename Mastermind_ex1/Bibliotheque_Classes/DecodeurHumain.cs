using System;
using System.Linq;
using System.Collections.Generic;

namespace Bibliotheque_Classes
{
    public class DecodeurHumain : Decodeur
    {
        // ** Champs ** //
        

        // ** Propriété ** //

        // ** Constructeur ** //
        public DecodeurHumain(string p_Nom) : base(p_Nom) { }

        // ** méthode ** //
        public override Code ObtenirCode(int p_NbCouleur, int p_Longueur)
        {
            // Déclaration des variables
            int longueurCode;
            bool contientCouleurHorsLimites = false;
            List<int> listeCouleurs = new List<int>();

            do
            {
                contientCouleurHorsLimites = false;

                // Demander à l'utilisateur de saisir son code
                Console.Write($"{this.Nom}, entrez votre code: ");
                string codeSaisi = Console.ReadLine();

                // Enregistrer la longueur du code
                longueurCode = codeSaisi.Length;

                try
                {
                    // Enregistrer chacune des couleurs sous forme de liste
                    var couleursJoueur = codeSaisi.Select(x => int.Parse(x.ToString()));

                    // Vérifier s'il y a des couleurs hors limites
                    listeCouleurs = couleursJoueur.Select(x => x >= p_NbCouleur ? -1 : x).ToList();
                    contientCouleurHorsLimites = listeCouleurs.Contains(-1) ? true : false;
                }

                catch {contientCouleurHorsLimites = true;}

            } while (longueurCode != p_Longueur || contientCouleurHorsLimites);

            // Ajouter le code saisie par l'humain à un objet code
            int[] tableauCouleurs = listeCouleurs.ToArray();
            Code codeHumain = new Code(tableauCouleurs, p_Longueur);

            // Mettre le code dans le champs
            base.Tentative = codeHumain;

            return codeHumain;
            
        }
    }
}
