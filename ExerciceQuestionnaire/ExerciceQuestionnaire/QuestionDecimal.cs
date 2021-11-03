using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciceQuestionnaire
{
    public class QuestionDecimal : Question
    {
        // ** Champs ** //
        private decimal m_reponse;
        private decimal m_reponseParticipant;


        // ** Propriétés ** //
        public decimal Reponse => m_reponse;

        // ** Constructeur ** //
        public QuestionDecimal(string p_question, int p_point, decimal p_reponse) : base(p_question, p_point)
        {
            // Précondition (Aucun, car la réponse peut être un décimal de tout type)
            m_reponse = p_reponse;
        }


        // ** Méthodes ** //
        public override bool AjouterReponse(string p_reponse)
        {
            if(p_reponse == null)
            {
                throw new ArgumentNullException("Ne peut pas être null", "p_reponse");
            }

            try
            {
                m_reponseParticipant = decimal.Parse(p_reponse);
                return true;
            }

            catch
            {
                return false;
            }
        }

        public override bool CorrigerQuestion()
        {
            if(m_reponse == m_reponseParticipant)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
