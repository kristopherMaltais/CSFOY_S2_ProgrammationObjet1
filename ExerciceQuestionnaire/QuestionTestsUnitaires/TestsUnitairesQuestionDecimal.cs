using System;
using System.Collections.Generic;
using Xunit;
using ExerciceQuestionnaire;
using System.Text;

namespace QuestionTestsUnitaires
{
    public class TestsUnitairesQuestionDecimal
    {
        // Constructeur

        [Fact]
        public void Constructeur_AjouteReponseCorrectement_AssertEqual()
        {
            // Arrange
            decimal reponse = 7.5m;
            decimal reponseAttendue = 7.5m;

            // Act
            QuestionDecimal nouvelleQuestion = new QuestionDecimal("Combien fait 3 multiplier par 2,5?", 4, reponse);

            // Assert
            Assert.Equal(nouvelleQuestion.Reponse, reponseAttendue);
        }


        // AjouterReponse

        [Fact]
        public void AjouterReponse_PreconditionNull_ThrowException()
        {
            // Ararnge
            string reponse = null;
            QuestionDecimal nouvelleQuestion = new QuestionDecimal("Combien fait 3 multiplier par 2,5?", 4, 7.5m);


            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => {nouvelleQuestion.AjouterReponse(reponse); });
        }

        [Fact]
        public void AjouterReponse_AjouteReponseCorrecte_ValeurRetourTrue()
        {
            // Ararnge
            string reponseParticipant = "3,5";
            QuestionDecimal nouvelleQuestion = new QuestionDecimal("Combien fait 3 multiplier par 2,5?", 4, 7.5m);


            // Act
            bool valeurRetournee = nouvelleQuestion.AjouterReponse(reponseParticipant);

            // Assert
            Assert.True(valeurRetournee);
        }

        [Fact]
        public void AjouterReponse_AjouteReponseIncorrecte_ValeurRetourFalse()
        {
            // Ararnge
            string reponseParticipant = "3.5";
            QuestionDecimal nouvelleQuestion = new QuestionDecimal("Combien fait 3 multiplier par 2,5?", 4, 7.5m);


            // Act
            bool valeurRetournee = nouvelleQuestion.AjouterReponse(reponseParticipant);

            // Assert
            Assert.False(valeurRetournee);
        }

        

        // CorrigerQuestion
        [Fact]
        public void CorrigerQuestion_ReponseCorrecte_True()
        {
            // Arrange
            QuestionDecimal nouvelleQuestion = new QuestionDecimal("Combien fait 3 multiplier par 2,5?", 4, 7.5m);
            string reponseParticipant = "7,5";
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
            QuestionDecimal nouvelleQuestion = new QuestionDecimal("Combien fait 3 multiplier par 2,5?", 4, 7.5m);
            string reponseParticipant = "7,4";
            nouvelleQuestion.AjouterReponse(reponseParticipant);

            // Act
            bool reponseExacte = nouvelleQuestion.CorrigerQuestion();

            // Assert
            Assert.False(reponseExacte);
        }
    }
}
