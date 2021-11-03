using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Bibliotheque_classes
{
    public class Compter
    {
        // Méthode pour convertir fichier texte de mots en tableau de mots
        public static string[] FichierTexteVersListeMot(string nomFichier)
        {
            // Préconditions
            if(nomFichier == null || nomFichier.Length == 0)
            {
                throw new ArgumentException("Le nom de fichier ne peut pas être null ou ne contenir aucun caractère");
            }
                
            // Chercher le fichier texte
            string dossierChemin = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName;
            Console.WriteLine(dossierChemin);

            // Mettre le fichier texte en string
            string fichierSource = Regex.Replace(File.ReadAllText(dossierChemin + "/" + nomFichier + ".txt").ToLower(), @"\s+", " ");

            // Créer un tableau de mots
            string[] listeMots = fichierSource.Split(" ");

            return listeMots;
        }


        // Méthodes de comptage
        public static Dictionary<string, int> CompterOccurenceMots(string[] listeMots)
        {
            // Préconditions
            if (listeMots == null || listeMots.Length == 0)
            {
                throw new ArgumentException("La liste ne peut pas être null ou vide");
            }

            // Déclaration des variables
            List<string> listeMotsEvalues = new List<string>();
            Dictionary<string, int> occurenceMots = new Dictionary<string, int>();

            
            // Boucle qui compte les occurences des mots
            for (int i = 0; i < listeMots.Length; i++)
            {   
                int compteurOccurenceMot = 0;
                if(!listeMotsEvalues.Contains(listeMots[i]) && !listeMots[i].Any(char.IsDigit))
                {
                    for (int j = 0; j < listeMots.Length; j++)
                    {
                        if (listeMots[i] == listeMots[j])
                        {
                            compteurOccurenceMot++;
                        }
                    }

                    // suivi des mots déjà évalué
                    listeMotsEvalues.Add(listeMots[i]);

                    // Ajuster le dictionnaire d'occurence des mots
                    occurenceMots.Add(listeMots[i], compteurOccurenceMot);
                }
            }

            // Retourner le dictionnaire
            return occurenceMots;
        }

        public static List<(char, int)> CompterOccurenceLettre(string chaineCaracteres)
        {
            // Préconditions
            if (chaineCaracteres == null || chaineCaracteres.Length == 0)
            {
                throw new ArgumentException("La chaine de caractère ne peut pas être null ou ne contenir aucun caractère");
            }
            // Déclaration des variables
            List<(char, int)> listeOccurenceLettre = new List<(char, int)>();
            List<char> caracteresEvalues = new List<char>();

            // Mettre la liste en miniscule
            string chaineCaracteresMinuscule = chaineCaracteres.ToLower();

            // Boucle qui compte les occurences des mots
            for (int i = 0; i < chaineCaracteresMinuscule.Length; i++)
            {
                int compteurOccurenceLettre = 0;

                if (!caracteresEvalues.Contains(chaineCaracteresMinuscule[i]))
                {
                    for (int j = 0; j < chaineCaracteres.Length; j++)
                    {
                        if (chaineCaracteresMinuscule[i] == chaineCaracteresMinuscule[j])
                        {
                            compteurOccurenceLettre++;
                        }
                    }

                    // suivi des mots déjà évalué
                    caracteresEvalues.Add(chaineCaracteresMinuscule[i]);

                    // Ajouter le tuple à la liste de tuple
                    listeOccurenceLettre.Add((chaineCaracteresMinuscule[i], compteurOccurenceLettre));
                }
            }

            return listeOccurenceLettre;
        }


        // Méthodes de tri
        public static List<(string, int)> TriAlphabétiqueDictionnaire(Dictionary<string, int> dictionnaire)
        {
            // Préconditions
            if (dictionnaire == null || dictionnaire.Count == 0)
            {
                throw new ArgumentException("Le dictionnaire ne peut pas être null ou être vide");
            }

            // Transformer dictionnaire en liste de tuple
            List<(string, int)> listeTuple = new List<(string, int)>();

            foreach (KeyValuePair<string, int> mot in dictionnaire)
            {
                listeTuple.Add((mot.Key, mot.Value));
            }

            // Retourner la liste triée
            listeTuple.Sort();
            return listeTuple;
        }

        public static List<(int, string)> TriOccurenceDictionnaire(Dictionary<string, int> dictionnaire)
        {
            // Préconditions
            if (dictionnaire == null || dictionnaire.Count == 0)
            {
                throw new ArgumentException("Le dictionnaire ne peut pas être null ou être vide");
            }

            // Transformer dictionnaire en liste de tuple
            List<(int, string)> listeTuple = new List<(int, string)>();

            foreach (KeyValuePair<string, int> mot in dictionnaire)
            {
                listeTuple.Add((mot.Value, mot.Key));
            }

            // Mettre en ordre croissant d'occurence
            listeTuple.Sort();
            return listeTuple;
        }

        public static List<(int, char)> TriOccurenceListeLettre(List<(char, int)> listeLettre)
        {
            // Préconditions
            if (listeLettre == null || listeLettre.Count == 0)
            {
                throw new ArgumentException("Le liste ne peut pas être null ou ne contenir aucun caractère");
            }
            // Nouvelle liste de tuple inversé
            List<(int, char)> listeTupleInverse = new List<(int, char)>();
            foreach((char, int) lettre in listeLettre)
            {
                listeTupleInverse.Add((lettre.Item2, lettre.Item1));
            }



            listeTupleInverse.Sort();
            return listeTupleInverse;
        }
    }
}
