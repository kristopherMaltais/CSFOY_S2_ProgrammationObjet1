using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ExerciceQuestionnaire;

namespace QuestionTestsUnitaires
{
    public class TestsUnitairesQuestionChoixMultiple
    {
        // Constructeur
        [Fact]
        public void Constructeur_PreconditionReponseNull_throwException()
        {
            // Arrange
            List<string> choixReponse = new List<string>() { "[0] banane", "[1] steak", "[2] ballon", "[3] pomme" };
            List<int> reponse = null;
            string question = "Qu'est-ce qui est de la nourriture dans les choses suivantes?";
            int nbPoint = 2;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { QuestionChoixMultiple nouvelleQuestion = new QuestionChoixMultiple(question, nbPoint, reponse, choixReponse); });
        }


        [Fact]
        public void Constructeur_PreconditionChoixReponseNull_throwException()
        {
            // Arrange
            List<string> choixReponse = null;
            List<int> reponse = new List<int>() { 0, 1, 3 };
            string question = "Qu'est-ce qui est de la nourriture dans les choses suivantes?";
            int nbPoint = 2;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { QuestionChoixMultiple nouvelleQuestion = new QuestionChoixMultiple(question, nbPoint, reponse, choixReponse); });
        }


        [Fact]
        public void Constructeur_PreconditionReponseSuperieurAuNombreDeChoix_throwException()
        {
            // Arrange
            List<string> choixReponse = new List<string>() { "[0] banane", "[1] steak", "[2] ballon", "[3] pomme" };
            List<int> reponse = new List<int>() { 0, 1, 3, 2, 2};
            string question = "Qu'est-ce qui est de la nourriture dans les choses suivantes?";
            int nbPoint = 2;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { QuestionChoixMultiple nouvelleQuestion = new QuestionChoixMultiple(question, nbPoint, reponse, choixReponse); });
        }

        [Fact]
        public void Constructeur_PreconditionReponseInferieurADeux_throwException()
        {
            // Arrange
            List<string> choixReponse = new List<string>() { "[0] banane", "[1] steak", "[2] ballon", "[3] pomme" };
            List<int> reponse = new List<int>() { 0 };
            string question = "Qu'est-ce qui est de la nourriture dans les choses suivantes?";
            int nbPoint = 2;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { QuestionChoixMultiple nouvelleQuestion = new QuestionChoixMultiple(question, nbPoint, reponse, choixReponse); });
        }

        [Fact]
        public void Constructeur_PreconditionChoixReponseInferieurADeux_throwException()
        {
            // Arrange
            List<string> choixReponse = new List<string>() { "[0] banane" };
            List<int> reponse = new List<int>() { 0, 1, 3 };
            string question = "Qu'est-ce qui est de la nourriture dans les choses suivantes?";
            int nbPoint = 2;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { QuestionChoixMultiple nouvelleQuestion = new QuestionChoixMultiple(question, nbPoint, reponse, choixReponse); });
        }

        [Fact]
        public void Constructeur_PreconditionChoixReponseInferieurAReponse_throwException()
        {
            // Arrange
            List<string> choixReponse = new List<string>() { "[0] banane", "[1] steak" };
            List<int> reponse = new List<int>() { 0, 1, 3 };
            string question = "Qu'est-ce qui est de la nourriture dans les choses suivantes?";
            int nbPoint = 2;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { QuestionChoixMultiple nouvelleQuestion = new QuestionChoixMultiple(question, nbPoint, reponse, choixReponse); });
        }

        [Fact]
        public void Constructeur_ValeurExacteLorsConstruction_AssertEqual()
        {
            // Arrange
            List<string> choixReponse = new List<string>() { "[0] banane", "[1] steak", "[2] ballon", "[3] pomme" };
            List<int> reponse = new List<int>() { 0, 1, 3 };
            string question = "Qu'est-ce qui est de la nourriture dans les choses suivantes?";
            int nbPoint = 2;

            string questionPoseeAttendue = "Qu'est-ce qui est de la nourriture dans les choses suivantes?";
            int nbPointAttendu = 2;
            List<int> reponseAttendue = new List<int>() { 0, 1, 3 };
            List<string> choixReponseAttendue = new List<string>() { "[0] banane", "[1] steak", "[2] ballon", "[3] pomme" };

            // Act
            QuestionChoixMultiple nouvelleQuestion = new QuestionChoixMultiple(question, nbPoint, reponse, choixReponse);

            // Assert
            Assert.Equal(nouvelleQuestion.Point, nbPointAttendu);
            Assert.Equal(nouvelleQuestion.questionPosee, questionPoseeAttendue);
            Assert.Equal(nouvelleQuestion.Reponse, reponseAttendue);
            Assert.Equal(nouvelleQuestion.ChoixReponse, choixReponseAttendue);
        }


        // AjouterReponse
        [Fact]
        public void AjouterReponse_ReponseParticipantAjoutee_ValeurRetourTrue()
        {
            // Arrange
            List<string> choixReponse = new List<string>() { "[0] banane", "[1] steak", "[2] ballon", "[3] pomme" };
            List<int> reponse = new List<int>() { 0, 1, 3 };
            string question = "Qu'est-ce qui est de la nourriture dans les choses suivantes?";
            int nbPoint = 2;

            QuestionChoixMultiple nouvelleQuestion = new QuestionChoixMultiple(question, nbPoint, reponse, choixReponse);

            // Act
            string reponseParticipant = "123";
            bool valeurRetour = nouvelleQuestion.AjouterReponse(reponseParticipant);

            // Assert
            Assert.True(valeurRetour);
        }

        [Fact]
        public void AjouterReponse_ReponseParticipantNonAjoutee_ValeurRetourFalse()
        {
            // Arrange
            List<string> choixReponse = new List<string>() { "[0] banane", "[1] steak", "[2] ballon", "[3] pomme" };
            List<int> reponse = new List<int>() { 0, 1, 3 };
            string question = "Qu'est-ce qui est de la nourriture dans les choses suivantes?";
            int nbPoint = 2;

            QuestionChoixMultiple nouvelleQuestion = new QuestionChoixMultiple(question, nbPoint, reponse, choixReponse);

            // Act
            string reponseParticipant = "aaa";
            bool valeurRetour = nouvelleQuestion.AjouterReponse(reponseParticipant);

            // Assert
            Assert.False(valeurRetour);
        }

        [Fact]
        public void AjouterReponse_ReponseParticipantTropDeChoix_ValeurRetourFalse()
        {
            // Arrange
            List<string> choixReponse = new List<string>() { "[0] banane", "[1] steak", "[2] ballon", "[3] pomme" };
            List<int> reponse = new List<int>() { 0, 1, 3 };
            string question = "Qu'est-ce qui est de la nourriture dans les choses suivantes?";
            int nbPoint = 2;

            QuestionChoixMultiple nouvelleQuestion = new QuestionChoixMultiple(question, nbPoint, reponse, choixReponse);

            // Act
            string reponseParticipant = "235";
            bool valeurRetour = nouvelleQuestion.AjouterReponse(reponseParticipant);

            // Assert
            Assert.False(valeurRetour);
        }

        // CorrigerQuestion
        [Fact]
        public void CorrigerQuestion_ReponseCorrecte_True()
        {
            // Arrange
            List<string> choixReponse = new List<string>() { "[0] banane", "[1] steak", "[2] ballon", "[3] pomme" };
            List<int> reponse = new List<int>() { 0, 1, 3 };
            string question = "Qu'est-ce qui est de la nourriture dans les choses suivantes?";
            int nbPoint = 2;
            QuestionChoixMultiple nouvelleQuestion = new QuestionChoixMultiple(question, nbPoint, reponse, choixReponse);

            string reponseParticipant = "013";
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
            List<string> choixReponse = new List<string>() { "[0] banane", "[1] steak", "[2] ballon", "[3] pomme" };
            List<int> reponse = new List<int>() { 0, 1, 3 };
            string question = "Qu'est-ce qui est de la nourriture dans les choses suivantes?";
            int nbPoint = 2;
            QuestionChoixMultiple nouvelleQuestion = new QuestionChoixMultiple(question, nbPoint, reponse, choixReponse);

            string reponseParticipant = "01";
            nouvelleQuestion.AjouterReponse(reponseParticipant);

            // Act
            bool reponseExacte = nouvelleQuestion.CorrigerQuestion();

            // Assert
            Assert.False(reponseExacte);
        }
    }
}
