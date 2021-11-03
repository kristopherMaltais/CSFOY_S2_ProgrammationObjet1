using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Linq;

namespace Bibliotheque_classes
{
    public class CompterLinq
    {
        // Méthode pour convertir fichier texte de mots en tableau de mots
        public static string[] FichierTexteVersListeMot(string nomFichier)
        {
            // Chercher le fichier texte
            string dossierChemin = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName;

            // Mettre le fichier texte en string
            string fichierSource = Regex.Replace(File.ReadAllText(dossierChemin + "/" + nomFichier + ".txt").ToLower(), @"\s+", " ");

            // Créer un tableau de mots
            string[] listeMots = fichierSource.Split(" ");

            return listeMots;
        }


        // Méthodes de comptage
        public static Dictionary<string, int> CompterOccurenceMotsCroissantMot(string[] listeMots)
        {
            // Précondition
            if(listeMots == null || listeMots.Length == 0)
            {
                throw new ArgumentException("Le tableau de mots ne peut pas être null ou vide");
            }

            Dictionary<string, int> occurenceMots = listeMots.GroupBy(mot => mot).OrderBy(mot => mot.Key).ToDictionary(mot => mot.Key, mot => mot.Count());

            return occurenceMots;
        }

        public static List<(char, int)> CompterOccurenceLettreCroissantLettre(string chaineCaracteres)
        {
            // Précondition
            if (chaineCaracteres == null || chaineCaracteres.Length == 0)
            {
                throw new ArgumentException("La chaine de caractère ne peut pas être null ou vide");
            }

            string chaineCaractereMinuscule = chaineCaracteres.ToLower();

            var occurenceLettre = chaineCaractereMinuscule.GroupBy(lettre => lettre).OrderBy(lettre => lettre.Key).Select(g => (g.Key, g.Count())).ToList();

            return occurenceLettre;
        }

        public static Dictionary<string, int> CompterOccurenceMotsDecroissantOccurence(string[] listeMots)
        {
            // Précondition
            if (listeMots == null || listeMots.Length == 0)
            {
                throw new ArgumentException("Le tableau de mots ne peut pas être null ou vide");
            }

            Dictionary<string, int> occurenceMots = listeMots.GroupBy(mot => mot).OrderByDescending(mot => mot.Count()).ToDictionary(mot => mot.Key, mot => mot.Count());

            return occurenceMots;
        }

        public static List<(char, int)>  CompterOccurenceLettreDecroissantOccurence(string chaineCaracteres)
        {
            // Précondition
            if (chaineCaracteres == null || chaineCaracteres.Length == 0)
            {
                throw new ArgumentException("La chaine de caractère ne peut pas être null ou vide");
            }

            string chaineCaractereMinuscule = chaineCaracteres.ToLower();

            var occurenceLettre = chaineCaractereMinuscule.GroupBy(lettre => lettre).OrderByDescending(lettre => lettre.Count()).Select(g => (g.Key, g.Count())).ToList();

            return occurenceLettre;
        }

    }
}
