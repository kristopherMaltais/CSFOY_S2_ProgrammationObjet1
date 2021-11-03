using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExerciceQuestionnaire
{
    public class Questionnaire
    {
        // ** Champs ** //
        private string m_titre;
        private string m_nom;
        private decimal m_resultat;
        private decimal m_pointMaximum;
        private decimal m_resultatPourcentage;
        private List<Question> m_questions; 



        // ** Propriétés ** //
        public List<Question> Questions => m_questions;


        // ** Constructeurs ** //
        public Questionnaire(string p_titre, string p_nom, List<Question> p_question)
        {
            // Préconditions
            if(p_question == null || p_question.Count == 0)
            {
                throw new ArgumentOutOfRangeException("La liste de qestion ne peut pas être null et doit contenir au moins une question", "p_question");
            }

            if(p_titre == null)
            {
                throw new ArgumentNullException("Ne peut pas être null", "p_titre");
            }

            if (p_nom == null)
            {
                throw new ArgumentNullException("Ne peut pas être null", "p_nom");
            }

            m_titre = p_titre;
            m_nom = p_nom;

            // Créer une liste de question aléatoire à chaque création
            m_questions = p_question.OrderBy(question => Guid.NewGuid()).ToList();
        }


        // ** Méthodes ** //
        public void CalculResultat()
        {
           foreach(Question question in Questions)
            {
                if (question.CorrigerQuestion())
                {
                    m_resultat += question.Point;
                }

                m_pointMaximum += question.Point;
            }

            // Calculer score en pourcentage
            m_resultatPourcentage = (m_resultat * 100) / m_pointMaximum;

        }

        public override string ToString()
        {
            // Afficher le titre du questionnaire et le nom du participant
            StringBuilder questionnaireFinal = new StringBuilder();
            questionnaireFinal.Append(m_titre);
            questionnaireFinal.AppendLine();
            questionnaireFinal.Append(m_nom);
            questionnaireFinal.AppendLine();

            // Afficher toutes les questions du questionnaire
            foreach(Question question in m_questions)
            {
                // Si bonne réponse inscrire correcte
                if (question.CorrigerQuestion())
                {
                    questionnaireFinal.Append(question.questionPosee);
                    questionnaireFinal.Append($" {question.Point}/{question.Point}");
                    questionnaireFinal.AppendLine();
                }

                // Si la réponse est pas correct
                else
                {
                    questionnaireFinal.Append(question.questionPosee);
                    questionnaireFinal.Append($" 0/{question.Point}");
                    questionnaireFinal.AppendLine();
                }
                
                // Nouvelle ligne
                questionnaireFinal.AppendLine();
            }

            // Afficher le questionnaire
            return questionnaireFinal + $"Votre Score à ce questionnaire est de {m_resultat}/{m_pointMaximum} ({Math.Round(m_resultatPourcentage, 2)}%)";
        }



    }
}
