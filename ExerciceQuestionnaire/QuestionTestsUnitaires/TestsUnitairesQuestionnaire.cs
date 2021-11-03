using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ExerciceQuestionnaire;

namespace QuestionTestsUnitaires
{
    public class TestsUnitairesQuestionnaire
    {
        [Fact]
        public void Constructeur_PreconditionTitreNull_ThrowException()
        {
            // Arrange
            string titre = null;
            string nom = "kristopher";

            QuestionDecimal question1 = new QuestionDecimal("Combien fait 5 divisé par 2?", 1, 2.5m);
            QuestionMot question2 = new QuestionMot("Qui est le professeur du cours POO?", 1, "denis");
            List<Question> questions = new List<Question>() { question1, question2 };
            Questionnaire quiz1 = new Questionnaire(titre, nom, questions);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Questionnaire quiz1 = new Questionnaire(titre, nom, questions); });
        }
    }
}
