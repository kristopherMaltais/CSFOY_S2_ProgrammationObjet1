using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using Bibliotheque_classes;

namespace Exercice_Bloc4
{
    class Program
    {
        static void Main(string[] args)
        {
            // ENLEVER LES COMMENTAIRES POUR ROULER CHAQUE SECTION DU TP
            //OccurenceMots();
            //OccurenceLettres();
            //OccurenceMotsLinq();
            //OccurenceLettresLinq();
        }


        // Partie sans l'utilisation de LINQ
        public static void OccurenceMots()
        {
            // Créer une liste de mot à partir d'un fichier text
            string[] listeMots = Compter.FichierTexteVersListeMot("listeMots");

            // Compter le nombre d'occurence de chacun des mots et enregistrer les donnnées sous forme de dictionnaire
            Dictionary<string, int> listeMots2 = Compter.CompterOccurenceMots(listeMots);


            // Trier la liste de mots en ordre croissant des key
            List<(string, int)> listeOrdreCroissant = Compter.TriAlphabétiqueDictionnaire(listeMots2);

            // Afficher le dictionnaire en console trié selon les clés
            foreach ((string, int) mot in listeOrdreCroissant)
            {
                Console.WriteLine($"{mot.Item1} ---> {mot.Item2}");
            }



            // Trier le dictionnaire en ordre décroissant des values
            List<(int, string)> listeOrdreDecroissant = Compter.TriOccurenceDictionnaire(listeMots2);

            for (int index = listeOrdreDecroissant.Count - 1; index >= 0; index--)
            {
                Console.WriteLine($"{listeOrdreDecroissant[index].Item2} ---> {listeOrdreDecroissant[index].Item1}");
            }


        }

        public static void OccurenceLettres()
        {
            // Compter occurence des caractères contenus dans un string
            List<(char, int)> listeCaractere = Compter.CompterOccurenceLettre("prOgraaaaMmaTtion");

            // Mettre la liste de tuple en ordre croissant des caractères
            listeCaractere.Sort();

            // Afficher la liste des caractères en console
            for (int i = 0; i < listeCaractere.Count; i++)
            {
                Console.WriteLine($"{listeCaractere[i].Item2} --> {listeCaractere[i].Item1}");
            }

            // Mettre la liste en ordre décroissant occurences de caractères
            List<(int, char)> listeTupleInverse = Compter.TriOccurenceListeLettre(listeCaractere);

            // Afficher la liste des caractères en console
            for (int index = listeCaractere.Count - 1; index >= 0; index--)
            {
                Console.WriteLine($"{listeTupleInverse[index].Item2} --> {listeTupleInverse[index].Item1}");
            }

        }


        // Partie avec untilisation de LINQ
        public static void OccurenceMotsLinq()
        {
            // Créer une liste de mot à partir d'un fichier texte
            string[] listeMots = Compter.FichierTexteVersListeMot("listeMots");

            // Créer un dictionnaire en ordre croissant des mots
            Dictionary<string, int> occurenceMots1 = CompterLinq.CompterOccurenceMotsCroissantMot(listeMots);

            // Afficher le dictionnaire de mots
            foreach (KeyValuePair<string, int> mot in occurenceMots1)
            {
                Console.WriteLine($"{mot.Key} --- > {mot.Value}");
            }

            // Créer un dictionnaire en ordre décroissant des occurence
            Dictionary<string, int> occurenceMots2 = CompterLinq.CompterOccurenceMotsDecroissantOccurence(listeMots);

            // Afficher le dictionnaire de mots
            foreach (KeyValuePair<string, int> mot in occurenceMots2)
            {
                Console.WriteLine($"{mot.Key} --- > {mot.Value}");
            }


        }

        public static void OccurenceLettresLinq()
        {
            var occurenceLettres1 = CompterLinq.CompterOccurenceLettreCroissantLettre("ProgrAmMation");

            foreach (var lettre in occurenceLettres1)
            {
                Console.WriteLine($"{lettre.Item1} --- {lettre.Item2}");
            }

            var occurenceLettres2 = CompterLinq.CompterOccurenceLettreDecroissantOccurence("ProgrAmMation");

            foreach (var lettre in occurenceLettres2)
            {
                Console.WriteLine($"{lettre.Item1} --- {lettre.Item2}");
            }
        }


    }
}
