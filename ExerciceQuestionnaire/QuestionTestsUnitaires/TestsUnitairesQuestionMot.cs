using System;
using Xunit;
using ExerciceQuestionnaire;

namespace QuestionTestsUnitaires
{
    public class TestsUnitairesQuestionMot
    {
        // Constructeur
        [Fact]
        public void Constructeur_InitialiseLesChamps_AssertEqual()
        {
            // Arrange
            string questionPoseeAttendue = "Qui est le premier ministre du québec?";
            int pointAttendu = 2;
            string reponseAttendue = "francois legault";
            QuestionMot questionAttendue = new QuestionMot(questionPoseeAttendue, pointAttendu, reponseAttendue);


            // Act
            QuestionMot nouvelleQuestion = new QuestionMot("Qui est le premier ministre du québec?", 2, "francois legault");

            // Assert
            Assert.Equal(questionPoseeAttendue, nouvelleQuestion.questionPosee);
            Assert.Equal(reponseAttendue,nouvelleQuestion.Reponse);
            Assert.Equal(pointAttendu, nouvelleQuestion.Point);
        }

        [Fact]
        public void Constructeur_PreconditionNull_ThrowException()
        {
            // Arrange
            string reponseNull = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { QuestionMot nouvelleQuestion = new QuestionMot("Qui est le premier ministre du québec", 2, reponseNull); });
        }


        // AjouterReponse
        [Fact]
        public void AjouterReponse_PreconditionNull_ThrowException()
        {
            // Arrange
            string reponseNull = null;
            QuestionMot nouvelleQuestion = new QuestionMot("Qui est le premier ministre du québec", 2, "francois legault");


            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => {nouvelleQuestion.AjouterReponse(reponseNull); });
        }

        [Fact]
        public void AjouterReponse_ValeurRetourEstTrue_True()
        {
            // Arrange
            QuestionMot nouvelleQuestion = new QuestionMot("Qui est le premier ministre du québec", 2, "francois legault");

            // Act
            bool retourneTrue = nouvelleQuestion.AjouterReponse("francois legault");

            // Assert
            Assert.True(retourneTrue);
        }

        // CorrigerQuestion
        [Fact]
        public void CorrigerQuestion_ReponseCorrecte_True()
        {
            // Arrange
            QuestionMot nouvelleQuestion = new QuestionMot("Qui est le premier ministre du québec", 2, "francois legault");
            string reponseParticipant = "francois legault";
            nouvelleQuestion.AjouterReponse(reponseParticipant);

            // Act
            bool reponseExacte = nouvelleQuestion.CorrigerQuestion();

            // Assert
            Assert.True(reponseExacte);
        }

        [Fact]
        public void CorrigerQuestion_ReponseCorrecteAvecLettreMajuscule_True()
        {
            // Arrange
            QuestionMot nouvelleQuestion = new QuestionMot("Qui est le premier ministre du québec", 2, "Francois Legault");
            string reponseParticipant = "francois legault";
            nouvelleQuestion.AjouterReponse(reponseParticipant);

            // Act
            bool reponseExacte = nouvelleQuestion.CorrigerQuestion();

            // Assert
            Assert.True(reponseExacte);
        }

        [Fact]
        public void CorrigerQuestion_ReponseIncorrecte_False()
        {
            // Arrange
            QuestionMot nouvelleQuestion = new QuestionMot("Qui est le premier ministre du québec", 2, "francois legault");
            string reponseParticipant = "Denis Rinfret";
            nouvelleQuestion.AjouterReponse(reponseParticipant);

            // Act
            bool reponseExacte = nouvelleQuestion.CorrigerQuestion();

            // Assert
            Assert.False(reponseExacte);
        }
    }
}
