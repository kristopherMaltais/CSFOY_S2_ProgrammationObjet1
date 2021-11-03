using System;
using System.Collections.Generic;
using System.Text;

namespace ContactProgramme
{
    public class Fonctions
    {
        public static void afficherMenu()
        {
            Console.WriteLine("Liste de contact");
            Console.WriteLine("[1] Ajouter un contact");
            Console.WriteLine("[2] Afficher un contact");
            Console.WriteLine("[3] Afficher tous les contact");
            Console.WriteLine("[4] Modifier un contact");
            Console.WriteLine("[5] Afficher un contact");
            Console.WriteLine("[6] quitter");
            Console.WriteLine();
        }
        public static int ChoixUtilisateur(int min, int max)
        {
            try
            {
                int choixUtilisateur;
                do
                {
                    Console.Write("Que voulez-vous faire: ");
                    choixUtilisateur = int.Parse(Console.ReadLine());
                } while (choixUtilisateur < min || choixUtilisateur > max);

                return choixUtilisateur;
            }

            catch
            {
                Console.WriteLine("vous n'avez pas entré un entier, retour au menu principal...");
                return -1;
            }


        }

        public static void AfficherUnContact(List<Contact> p_listeContact)
        {
            // Afficher les noms de contact
            for (int index = 0; index < p_listeContact.Count; index++)
            {
                Console.WriteLine($"[{index + 1}] {p_listeContact[index].Nom}");
            }

            // Demander à l'utilisateur quel contact il veut afficher
            int choixUtilisateur = (ChoixUtilisateur(0, p_listeContact.Count) - 1);


            // Afficher le contact sélectionné
            Console.WriteLine(p_listeContact[choixUtilisateur].ToString());
        }

        public static void afficherTousLesContacts(List<Contact> p_listecontact)
        {

            Console.WriteLine("Voici tous les contacts de la liste");
            
            for (int index = 0; index < p_listecontact.Count; index++)
            {
                Console.WriteLine(p_listecontact[index].ToString());
            }
        }
    }
}
