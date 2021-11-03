using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;


namespace Bibliotheque_Classes
{
    public class Code
    {
        // ** Champs ** //
        private int[] m_Code;
        private int m_NbCouleur;
        private int m_LongueurCode;
        private (int, int) m_LongueurCodePossible = (4, 5);
        private (int, int) m_NbCouleurPossible = (4, 6);

        // ** Propriétés ** //
        public int NbCouleur => m_NbCouleur;
        public int LongueurCode => m_LongueurCode;
        public int[] CodeSecret => m_Code;
        
        

        // ** Constructeur ** //
        public Code(int[] p_codeCouleur, int p_NbCouleur = 4)
        {
            // Précondition
            if (p_codeCouleur == null)
            {
                throw new ArgumentNullException("p_codeCouleur", "Le tableau ne peut pas être null");
            }
            if (p_codeCouleur.Length < m_LongueurCodePossible.Item1 || p_codeCouleur.Length > m_LongueurCodePossible.Item2)
            {
                throw new ArgumentOutOfRangeException("p_codeCouleur", "Le code doit être une combinaison de 4 ou 5 chiffre");
            }
            if (p_NbCouleur < m_NbCouleurPossible.Item1 || p_NbCouleur > m_NbCouleurPossible.Item2)
            {
                throw new ArgumentOutOfRangeException("p_NbCouleur", "Le nombre de chiffre possible doit être entre 4 et 6 inclusivement");
            }
            foreach(int couleur in p_codeCouleur)
            {
                if(couleur < 0 || couleur > p_NbCouleur - 1)
                {
                    throw new ArgumentOutOfRangeException("p_codeCouleur", "les couleurs passé dans le tableau doivent être entre 0 et p_NbCouleur - 1");
                }
            }

            // Attribuer les valeurs aux champs
            m_Code = p_codeCouleur;
            m_NbCouleur = p_NbCouleur;
            m_LongueurCode = p_codeCouleur.Length;
        }

        public Code(int p_LongueurCode, int p_NbCouleur = 4)
        {
            // Précondition
            if (p_LongueurCode < m_LongueurCodePossible.Item1 || p_LongueurCode > m_LongueurCodePossible.Item2)
            {
                throw new ArgumentOutOfRangeException("Le code doit être une combinaison de 4 ou 5 chiffre");
            }

            if (p_NbCouleur < m_NbCouleurPossible.Item1 || p_NbCouleur > m_NbCouleurPossible.Item2)
            {
                throw new ArgumentOutOfRangeException("Le nombre de chiffre possible doit être entre 4 et 6 inclusivement");
            }

            // Générer un code aléatoire selon la longueur et le nombre de couleur passé en paramètre
            int[] codeCouleur = new int[p_LongueurCode];
            Random nombreAleatoire = new Random();
            codeCouleur = codeCouleur.Select(x => nombreAleatoire.Next(p_NbCouleur)).ToArray();

            // Attribuer les valeurs aux champs
            m_Code = codeCouleur;
            m_NbCouleur = p_NbCouleur;
            m_LongueurCode = p_LongueurCode;
        }


        // ** Méthodes ** //
        public (int, int) Compare(Code p_Autre) // Autre c'est un drôle de nom de variable non?
        {
            // Précondition
            if (p_Autre == null)
            {
                throw new ArgumentNullException("p_Autre", "le code passé en paramètre ne peut pas être null");
            }

            // Évaluer si le joueur a trouvé la solution
            if (this.Equals(p_Autre))
            {
                (int, int) resultat = p_Autre.LongueurCode == m_LongueurCodePossible.Item1 ? (m_LongueurCodePossible.Item1, 0) : (m_LongueurCodePossible.Item2, 0);
                return resultat;
            }

            // Bonne couleur et bonne place
            var ficheNoire = p_Autre.m_Code.Zip(m_Code, (a, c) => a == c).Count(x => x);

            // Bonne couleur et mauvais endroit
            Dictionary<int, int> codeSecretCompte = m_Code.GroupBy(mot => mot).ToDictionary(mot => mot.Key, mot => mot.Count());
            Dictionary<int, int> codeTentativeCompte = p_Autre.CodeSecret.GroupBy(mot => mot).ToDictionary(mot => mot.Key, mot => mot.Count());

            int ficheBlanche = 0;
            foreach(KeyValuePair<int, int> couleur in codeSecretCompte)
            {
                if(codeTentativeCompte.ContainsKey(couleur.Key))
                {
                    ficheBlanche += couleur.Value <= codeTentativeCompte[couleur.Key] ? couleur.Value : codeTentativeCompte[couleur.Key];
                }
            }

            // Isoler le compte des fiches blanches de celui des fiches noires
            return (ficheNoire, ficheBlanche - ficheNoire);
        }

        public override bool Equals(object objet)
        {
            // Precondition
            if(objet == null)
            {
                throw new ArgumentNullException("objet", "le paremètre objet ne peut pas être null" );
            }

            if(this.GetHashCode() == objet.GetHashCode())
            {
                return true;
            }

            return false;
        }
        public override int GetHashCode()
        {
            return ((IStructuralEquatable)m_Code).GetHashCode(EqualityComparer<int>.Default);
        }

        public override string ToString()
        {
            StringBuilder codeSecretDevoile = new StringBuilder();
            foreach(int nombre in CodeSecret)
            {
                codeSecretDevoile.Append(nombre.ToString() + " ");
            }

            return codeSecretDevoile.ToString();
        }
    }
}
