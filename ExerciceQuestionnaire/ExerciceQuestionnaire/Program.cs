using System;
using System.Collections.Generic;

namespace ExerciceQuestionnaire
{
    class Program
    {
        static void Main(string[] args)
        {   
            //Créer les questions présentes dans le questionnaire (SERAIT MIEUX DE LE FAIRE AVEC UN FICHIER .CSV)
            QuestionDecimal question1 = new QuestionDecimal("Combien fait 5 divisé par 2?", 1, 2.5m);
            QuestionMot question2 = new QuestionMot("Qui est le professeur du cours POO?", 1, "denis");

            List<string> choixReponse3 = new List<string>() { "[0] Ottawa", "[1] Québec", "[2] Montréal"};
            QuestionChoix question3 = new QuestionChoix("Quel est la capital du Canada?", 1, 0, choixReponse3);

            QuestionDecimal question4 = new QuestionDecimal("Combien fait 3 multiplier par 2,5?", 4, 7.5m);
            QuestionMot question5 = new QuestionMot("Je suis jaune et je transport des étudiants?", 8, "autobus");

            List<string> choixReponse6 = new List<string>() { "[0] banane", "[1] steak", "[2] ballon", "[3] pomme" };
            List<int> reponse6 = new List<int>() {0, 1, 3};
            QuestionChoixMultiple question6 = new QuestionChoixMultiple("Qu'est-ce qui est de la nourriture dans les choses suivantes?", 2, reponse6, choixReponse6);

            QuestionMot question7 = new QuestionMot("Comment se nomme l'étoile de notre système solaire?", 3, "soleil");


            // Créer la liste de question
            List<Question> questions = new List<Question>() { question1, question2, question3, question4, question5, question6, question7};
            bool reponseAjoutee;

            // Créer le questionnaire
            Console.Write("Quel est votre nom: ");
            string nomCandidat = Console.ReadLine();
            Console.WriteLine();
            Questionnaire quiz1 = new Questionnaire("Quiz mi-session", nomCandidat, questions);


            // Poser les questions au candidat
            foreach(Question question in quiz1.Questions)
            {
                do
                {
                    Console.WriteLine(question.ToString());
                    string reponse = Console.ReadLine();
                    reponseAjoutee = question.AjouterReponse(reponse);
                } while (!reponseAjoutee);
                
                question.CorrigerQuestion();
            }

            
            // Afficher le questionnaire avec toutes les questions et le résultat
            quiz1.CalculResultat();
            Console.WriteLine(quiz1.ToString());
        }
    }
}
