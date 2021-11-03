using System;
using System.Collections.Generic;

namespace Facture
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgrammeFacture();
        }

        public static void ProgrammeFacture()
        {
            // Déclaration des variables qui existeront tout le long du programme
            decimal taxe = 0.15m;  // TAXES //

            int choixUtilisateurMenu; // CHOIX UTILISATUER ARTICLE //
            int choixUtilisateurArticle; // CHOIX UTILISATEUR ARTICLE //
            int choixUtilisateurQuantite; // CHOIX UTILISATEUR QUANTITE //
            
            Article pomme = new Article("1", "pomme", 1.00m, taxe);
            Article pain = new Article("2", "pain", 2.00m, taxe);
            Article carotte = new Article("3", "carotte", 1.50m, taxe);
            Article cereales = new Article("4", "céréales", 5.00m, taxe);
            Article fromage = new Article("5", "fromage", 6.00m, taxe);
            Article patate = new Article("6", "patate", 3.50m, taxe);
            Article lait = new Article("7", "lait", 3.50m, taxe);
            Article sucre = new Article("8", "sucre", 7.00m, taxe);
            Article sel = new Article("9", "sel", 8.00m, taxe);
            Article beurre = new Article("10", "beurre", 4.00m, taxe);
            List<Article> inventaireMagasin = new List<Article>() { pomme, pain, carotte, cereales, fromage, patate, lait, sucre, sel, beurre}; // INVENTAIRE DE L'ÉPICERIE //

            // Créer une nouvelle facture
            Facture factureVide = new Facture();

            do
            {
                // Afficher le menu
                Fonctions.AfficherMenu();

                // saisir choix utilisateur pour option menu
                Console.WriteLine("");
                Console.Write("Que voulez-vous faire: ");
                choixUtilisateurMenu = Fonctions.SaisirChoixutilisateur(4);
                switch (choixUtilisateurMenu)
                {
                    case 1:
                        factureVide = new Facture();
                        Console.WriteLine("Nouvelle facture créé!");
                        Console.WriteLine("");
                        break;
                    case 2:
                        Fonctions.AfficherArticles(inventaireMagasin);
                        Console.WriteLine("");

                        // Saisir un article parmis l'inventaire
                        Console.Write("Quel article voulez-vous scanner (1 à 10): ");
                        choixUtilisateurArticle = Fonctions.SaisirChoixutilisateur(10) - 1;

                        // Saisir le nombre de fois que l'article est acheté
                        Console.Write("Combien de fois voulez-vous cet article: ");
                        choixUtilisateurQuantite = Fonctions.SaisirChoixutilisateur(100);

                        // Ajouter l'article + ajuster les prix
                        if(choixUtilisateurArticle != -1 && choixUtilisateurQuantite != -1)
                        {
                            factureVide.AjouterArticle(inventaireMagasin[choixUtilisateurArticle], choixUtilisateurQuantite);
                        }
                        break;
                    case 3:

                        // Affichier la facture en console
                        Fonctions.AfficherFacture(factureVide);
                        break;
                }
            } while (choixUtilisateurMenu != 4);


        }
    }
}
