using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciceQuestionnaire
{
    public class QuestionChoixMultiple : Question
    {
        // ** Champs ** //
        private List<int> m_reponse;
        private List<int> m_reponseParticipant;
        private List<string> m_choixReponse;

        // ** Propriétés ** //
        public List<string> ChoixReponse => m_choixReponse;
        public List<int> Reponse => m_reponse;

        // ** Constructeur ** //
        public QuestionChoixMultiple(string p_question, int p_point, List<int> p_reponse, List<string> p_choixReponse) : base(p_question, p_point)
        {
            // Préconditions
            if(p_reponse == null)
            {
                throw new ArgumentNullException("Ne peut pas être null", "p_reponse");
            }

            if(p_choixReponse == null)
            {
                throw new ArgumentNullException("Ne peut pas être null", "P_choixReponse");
            }

            if(p_reponse.Count < 2 || p_reponse.Count > p_choixReponse.Count)
            {
                throw new ArgumentOutOfRangeException("doit avoir au minimum 2 réponses et inférieur au choix de réponse possible", "p_reponse");
            }

            if(p_choixReponse.Count < 2 || p_choixReponse.Count < p_reponse.Count)
            {
                throw new ArgumentOutOfRangeException("Doit avoir au moins 2 choix de réponses et supérieur ou égal à la réponse", "p_choixReponse");
            }

            m_reponse = p_reponse;
            m_choixReponse = p_choixReponse;
            m_reponseParticipant = new List<int>();
        }


        // ** Méthodes ** //
        public override bool AjouterReponse(string p_reponse)
        {
            // Créer une liste vide pour stocker les choix de réponse du participant
            List<int> reponseParticipant = new List<int>();

            // Évaluer chaque entrée de l'utilisateur
            foreach(char lettre in p_reponse)
            {
                try
                {
                    // Precondition
                    if ((int)Char.GetNumericValue(lettre) < 0 || (int)Char.GetNumericValue(lettre) > p_reponse.Length)
                    {
                        throw new ArgumentException("Les choix doivent être supérieur à 0 et inférieur à la taille de la liste", "p_reponse");
                    }

                    // Ajouter le choix du participant dans la liste de choix
                    m_reponseParticipant.Add((int)Char.GetNumericValue(lettre));
                }

                catch
                {
                    return false;
                }
                 
            }
            
            // Retourner true si tous les choix ont été ajouté avec succès
            return true;
        }
        public override bool CorrigerQuestion()
        {
            foreach(int reponse in m_reponse)
            {
                if(m_reponseParticipant.IndexOf(reponse) == -1)
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder choixReponse = new StringBuilder();

            for (int choix = 0; choix < m_choixReponse.Count; choix++)
            {
                choixReponse.AppendLine();
                choixReponse.Append(m_choixReponse[choix]);
            }

            return base.ToString() + choixReponse.ToString();
        }
    }
}
