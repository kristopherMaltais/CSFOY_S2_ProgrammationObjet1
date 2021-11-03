using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciceQuestionnaire
{
    public class QuestionChoix : Question
    {
        // ** Champs ** //
        private int m_reponse;
        private int m_reponseParticipant;
        private List<string> m_choixReponse;

        // ** propriétés ** //
        public int Reponse => m_reponse;
        public List<string> ChoixReponse => m_choixReponse;

        // ** Constructeur ** //
        public QuestionChoix(string p_question, int p_point, int p_reponse, List<string> p_choixReponse) : base(p_question, p_point)
        {
            // Préconditons
            if(p_reponse < 0 || p_reponse > 9)
            {
                throw new ArgumentOutOfRangeException("La valeur doit être entre 0 et 9", "p_reponse");
            }

            if(p_choixReponse == null)
            {
                throw new ArgumentNullException("Ne peut pas être null", "p_choixReponse");
            }

            if(p_choixReponse.Count == 0 || p_choixReponse.Count > 9)
            {
                throw new ArgumentOutOfRangeException("Doit avoir au moins deux choix de réponse et inférieur à 9 choix", "p_choixReponse");
            }



            m_reponse = p_reponse;
            m_choixReponse = p_choixReponse;
        }


        // ** Méthodes ** //
        public override bool AjouterReponse(string p_reponse)
        {
            // Precondition
            if(p_reponse == null)
            {
                throw new ArgumentNullException("Ne peut pas être null", "p_reponse");
            }

            try
            {
                if(int.Parse(p_reponse) < 0 || int.Parse(p_reponse) >= m_choixReponse.Count)
                {
                    throw new ArgumentOutOfRangeException("Le choix de réponse doit exister dans la liste", "p_reponse");
                }

                // enregistrer la réponse du participant
                m_reponseParticipant = int.Parse(p_reponse);

                return true;
            }

            catch
            {
                return false;
            }
        }
        public override bool CorrigerQuestion()
        {
            if (m_reponse == m_reponseParticipant)
            {
                return true;
            }

            else
            {
                return false;
            }
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
