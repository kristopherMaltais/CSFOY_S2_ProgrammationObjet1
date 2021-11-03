using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciceQuestionnaire
{
    public class QuestionMot : Question
    {
        // ** Champs ** //
        private string m_reponse;
        private string m_reponseParticipant;


        // ** Propriétés ** //
        public string Reponse => m_reponse;

        // ** Constructeur ** //
        public QuestionMot(string p_question, int p_point, string p_reponse) : base(p_question, p_point)
        {
            // Precondition
            if(p_reponse == null)
            {
                throw new ArgumentNullException("Ne peut pas être null", "p_reponse");
            }

            m_reponse = p_reponse.ToLower();
        }


        // ** Méthodes ** //
        public override bool AjouterReponse(string p_reponse)
        {
            // Préconditon
            if(p_reponse == null)
            {
                throw new ArgumentNullException("Ne peut pas être null", "p_reponse");
            }

            m_reponseParticipant = p_reponse.ToLower();
            return true;

            // Aucun try catch ici, car on passe d'un string vers un string donc aucune conversion.

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
    }
}
