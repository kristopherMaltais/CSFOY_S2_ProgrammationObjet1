using System;
using System.Collections.Generic;
using System.Text;

namespace ContactProgramme
{
    public class Contact
    {
        // champs static (appartient à la classe vers objet)
        private static int prochainId = 1;

        // champs non-static
        private int m_id;
        private string m_nom;
        private List<string> m_listeTelephone;
        private List<string> m_listeCourriels;

        // Propriétés
        public int Id => m_id;
        public string Nom
        {
            get => m_nom; 

            set
            {
                if(value == null || value.Trim().Length < 1)
                {
                    throw new ArgumentException("Le nom ne peut pas être null ou contenir moins de 1 caractère");
                }
               
                m_nom = value;
            }
        }
        public int NbTelephones => m_listeTelephone.Count;
        public int NbCourriels => m_listeCourriels.Count;

        // Constructeur
        public Contact(string p_nom)
        {
           
            // Ajouter le nom passé en paramètre au field m_nom en passant par la propriété Nom
            this.Nom = p_nom;

            // Ajouter le prochainId au field m_id 
            m_id = prochainId;
            prochainId++;

            // Initialiser la liste de téléphones et de courriels
            m_listeTelephone = new List<string>();
            m_listeCourriels = new List<string>();
        }

        // Méthodes
        public void AjouterTelephone(string p_telephone)
        {
            // Précondition
            if (p_telephone == null || p_telephone.Trim().Length != 10)
            {
                throw new ArgumentException(" Le numéro ne peut pas être null et doit contenir 10 chiffres");
            }

            // Ajouter le téléphone passé en paramètre
            m_listeTelephone.Add(p_telephone);
        }

        public void AjouterCourriel(string p_courriel)
        {
            // Précondition
            if (p_courriel == null)
            {
                throw new ArgumentException("Le courriel ne peut pas être null");
            }

            // Ajouter le courriel passé en paramètre
            m_listeCourriels.Add(p_courriel);
        }

        public void EnleverTelephone(string p_telephone)
        {
            // Préconditon
            if (p_telephone == null && p_telephone.Trim().Length != 10)
            {
                throw new ArgumentException("Le telephone ne peut pas être null et doit contenir 10 numéros");
            }
                
            // Supprimer le numéro de téléphone passé en paramètre
            m_listeTelephone.Remove(p_telephone);
        }

        public void EnleverCourriel(string p_courriel)
        {
            // Précondition
            if (p_courriel == null)
            {
                throw new ArgumentException("Le courriel ne peut pas être null");
            }
            
            // Supprimer le courriel passé en paramètre
            m_listeCourriels.Remove(p_courriel);
            
        }

        public string ObtenirTelephone(int p_indexTelephone)
        {
            // Précondition
            if(p_indexTelephone < 0 || p_indexTelephone >= m_listeTelephone.Count)
            {
                throw new ArgumentOutOfRangeException("p_indexTelephone doit être plus grand que zéro et plus petit que la taille de la liste");
            }

            //Retourner le numéro de téléphone de l'index passé en paramètre
            return m_listeTelephone[p_indexTelephone];
        }

        public string ObtenirCourriel(int p_indexCourriel)
        {
            // Précondition
            if (p_indexCourriel < 0 || p_indexCourriel >= m_listeTelephone.Count)
            {
                throw new ArgumentOutOfRangeException("p_indexCourriel doit être plus grand que zéro et plus petit que la taille de la liste");
            }

            // Retourner le courriel de l'index passé en paramètre
            return m_listeCourriels[p_indexCourriel];
        }

        // Méthodes override
        public override string ToString()
        {
            string tostring = $"Id: {m_id}, Nom: {m_nom}, Nb tel: {m_listeTelephone.Count}, Nb Courriel: {m_listeCourriels.Count}";
            return tostring;
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }

            if(!(obj is Contact))
            {
                return false;
            }

            return this.m_id == ((Contact)obj).m_id;
        }

        public override int GetHashCode()
        {
            return this.m_id.GetHashCode();
        }


    }
}
