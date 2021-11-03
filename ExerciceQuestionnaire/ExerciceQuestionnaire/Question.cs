using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciceQuestionnaire
{
    public abstract class Question
    {
        // ** Champs ** //
        private string m_questionPosee;
        private int m_point;


        // ** Propriétés ** //
        public int Point => m_point;
        public string questionPosee => m_questionPosee;


        // ** Constructeur ** //
        public Question(string p_questionPosee, int p_point)
        {
            // Préconditions
            if(p_questionPosee.Length < 1)
            {
                throw new ArgumentException("Doit au moins contenir une lettre", "p_questionPosee");
            }

            if (p_point <= 0)
            {
                throw new ArgumentException("Le nombre de point doit être strictement positif", "p_questionPosee");
            }

            m_questionPosee = p_questionPosee;
            m_point = p_point;
        }



        // ** Méthodes ** //
        public abstract bool AjouterReponse(string p_reponse);
        public abstract bool CorrigerQuestion();
        
        public override string ToString()
        {
            return $"{m_questionPosee} {m_point} point(s)";
        }

    }
}
