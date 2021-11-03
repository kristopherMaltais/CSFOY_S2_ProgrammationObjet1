using System;
using System.Collections.Generic;
using Xunit;
using ExerciceQuestionnaire;
using System.Text;

namespace QuestionTestsUnitaires
{
    public class TestUnitairesQuestionChoix
    {
        // Constructeur
        [Fact]
        public void Constructeur_PreconditionReponseOutOfRange_throwException()
        {
            // Arrange
            string question = "Quel et la capital du Canada";
            int nbPoint = 1;
            int reponse = 10;
            List<string> choixReponse = new List<string>() { "[0] Ottawa", "[1] Québec", "[2] Montréal" };


            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => {QuestionChoix nouvelleQuestion = new QuestionChoix(question, nbPoint, reponse, choixReponse); });
        }

        [Fact]

        public void Constructeur_PreconditionChoixReponseNull_throwException()
        {
            // Arrange
            string question = "Quel et la capital du Canada";
            int nbPoint = 1;
            int reponse = 3;
            List<string> choixReponse = null;


            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { QuestionChoix nouvelleQuestion = new QuestionChoix(question, nbPoint, reponse, choixReponse); });
        }

        [Fact]
        public void Constructeur_PreconditionChoixReponseOutOfRange_throwException()
        {
            // Arrange
            string question = "Quel et la capital du Canada";
            int nbPoint = 1;
            int reponse = 3;
            List<string> choixReponse = new List<string>() { "[0] Ottawa", "[1] Québec", "[2] Montréal", "[4] Ottawa", "[5] Québec", "[6] Montréal", "[7] Ottawa", "[8] Québec", "[9] Montréal", "[10] Ottawa", "[11] Québec"};


            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { QuestionChoix nouvelleQuestion = new QuestionChoix(question, nbPoint, reponse, choixReponse); });
        }

        [Fact]
        public void Constructeur_ValeurExacteLorsConstruction_AssertEqual()
        {
            // Arrange
            string question = "Quel et la capital du Canada";
            int nbPoint = 1;
            int reponse = 0;
            List<string> choixReponse = new List<string>() { "[0] Ottawa", "[1] Québec", "[2] Montréal"};

            string questionPoseeAttendue = "Quel et la capital du Canada";
            int nbPointAttendu = 1;
            int reponseAttendue = 0;
            List<string> choixReponseAttendue = new List<string>() { "[0] Ottawa", "[1] Québec", "[2] Montréal" };

            // Act
            QuestionChoix nouvelleQuestion = new QuestionChoix(question, nbPoint, reponse, choixReponse);

            // Assert
            Assert.Equal(nouvelleQuestion.Point, nbPointAttendu);
            Assert.Equal(nouvelleQuestion.questionPosee, questionPoseeAttendue);
            Assert.Equal(nouvelleQuestion.Reponse, reponseAttendue);
            Assert.Equal(nouvelleQuestion.ChoixReponse, choixReponseAttendue);
        }

        // AjouterReponse
        [Fact]
        public void AjouterReponse_PreconditionNull_ThrowException()
        {
            // Arrange
            string question = "Quel et la capital du Canada";
            int nbPoint = 1;
            int reponse = 0;
            List<string> choixReponse = new List<string>() { "[0] Ottawa", "[1] Québec", "[2] Montréal"};
            string reponseParticipant = null;

            QuestionChoix nouvelleQuestion = new QuestionChoix(question, nbPoint, reponse, choixReponse);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { nouvelleQuestion.AjouterReponse(reponseParticipant); });
        }

        [Fact]
        public void AjouterReponse_ReponseAjouteCorrectement_ValeurRetourneeTrue()
        {
            // Arrange
            string question = "Quel et la capital du Canada";
            int nbPoint = 1;
            int reponse = 0;
            List<string> choixReponse = new List<string>() { "[0] Ottawa", "[1] Québec", "[2] Montréal" };
            QuestionChoix nouvelleQuestion = new QuestionChoix(question, nbPoint, reponse, choixReponse);

            string reponseParticipant = "0";

            // Act
            bool valeurRetourneeVrai = nouvelleQuestion.AjouterReponse(reponseParticipant);

            // Assert
            Assert.True(valeurRetourneeVrai);
        }

        [Fact]
        public void AjouterReponse_ValeurHorsLimites_ValeurRetourneeFalse()
        {
            // Arrange
            string question = "Quel et la capital du Canada";
            int nbPoint = 1;
            int reponse = 0;
            List<string> choixReponse = new List<string>() { "[0] Ottawa", "[1] Québec", "[2] Montréal" };
            QuestionChoix nouvelleQuestion = new QuestionChoix(question, nbPoint, reponse, choixReponse);

            string reponseParticipant = "3";

            // Act
            bool valeurRetourneeFaux = nouvelleQuestion.AjouterReponse(reponseParticipant);

            // Assert
            Assert.False(valeurRetourneeFaux);
        }

        [Fact]
        public void AjouterReponse_EntrerValeurTexte_ValeurRetourneeFalse()
        {
            // Arrange
            string question = "Quel et la capital du Canada";
            int nbPoint = 1;
            int reponse = 0;
            List<string> choixReponse = new List<string>() { "[0] Ottawa", "[1] Québec", "[2] Montréal" };
            QuestionChoix nouvelleQuestion = new QuestionChoix(question, nbPoint, reponse, choixReponse);

            string reponseParticipant = "salut";

            // Act
            bool valeurRetourneeFaux = nouvelleQuestion.AjouterReponse(reponseParticipant);

            // Assert
            Assert.False(valeurRetourneeFaux);
        }


        // CorrigerQuestion
        [Fact]
        public void CorrigerQuestion_ReponseCorrecte_True()
        {
            // Arrange
            string question = "Quel et la capital du Canada";
            int nbPoint = 1;
            int reponse = 0;
            List<string> choixReponse = new List<string>() { "[0] Ottawa", "[1] Québec", "[2] Montréal" };
            QuestionChoix nouvelleQuestion = new QuestionChoix(question, nbPoint, reponse, choixReponse);
            string reponseParticipant = "0";
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
            string question = "Quel et la capital du Canada";
            int nbPoint = 1;
            int reponse = 0;
            List<string> choixReponse = new List<string>() { "[0] Ottawa", "[1] Québec", "[2] Montréal" };
            QuestionChoix nouvelleQuestion = new QuestionChoix(question, nbPoint, reponse, choixReponse);

            string reponseParticipant = "2";
            nouvelleQuestion.AjouterReponse(reponseParticipant);

            // Act
            bool reponseExacte = nouvelleQuestion.CorrigerQuestion();

            // Assert
            Assert.False(reponseExacte);
        }
    }
}
