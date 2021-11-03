using System;
using System.Collections.Generic;

namespace ContactProgramme
{
    class Program
    {
        static void Main(string[] args)
        {
            programmeContact();
    
        }

        public static void programmeContact()
        {
            // Créer une liste de contact pour la durée du programme
            List<Contact> listeContacts = new List<Contact>();

            int choixUtilisateur;
            do
            {
                // Afficher le menu
                Fonctions.afficherMenu();

                // Demander à l'utilisateur de faire un choix
                choixUtilisateur = Fonctions.ChoixUtilisateur(0, 5);

                switch (choixUtilisateur)
                {
                    case 1:
                        Console.Write("Quel est le nom du contact: ");
                        string nomContact = Console.ReadLine();
                        listeContacts.Add(new Contact(nomContact));
                        break;

                    case 2:
                        Fonctions.AfficherUnContact(listeContacts);
                        break;
                    case 3:
                        Fonctions.afficherTousLesContacts(listeContacts);
                        break;
                    case 4:

                        break;
                    case 5:
                        break;
                }

            } while (choixUtilisateur != 6);

            // Afficher le menu
            Fonctions.afficherMenu();

            // Demander à l'utilisateur de faire un choix
            Fonctions.ChoixUtilisateur(0, 5);

        }
    }
}
