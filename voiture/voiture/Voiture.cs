using System;
using System.Collections.Generic;
using System.Text;

namespace voiture
{
    public class Voiture
    {
        public string Marque { get; set; }
        public string Modele { get; set; }
        public double Vitesse { get; set; }
        public bool EstDemaree { get; set; }

        public void Initialiser(string marque, string modele)
        {
            this.Marque = marque;
            this.Modele = modele;
            this.Vitesse = 0.0;
            this.EstDemaree = false;
            Console.WriteLine("La voiture est initialisée");
        }

        public void Demarrer()
        {
            if(this.EstDemaree == true)
            {
                Console.WriteLine("La voiture est déjà démaré...");
                Console.WriteLine();
            }

            else
            {
                this.EstDemaree = true;
                Console.WriteLine("La voiture est démarée");
            }
        }

        public void Arreter()
        {
            if (this.Vitesse >= 5)
            {
                Console.WriteLine("Impossible d'arrêter la voiture, la vitesse doit être inférieur à 5km/h...");
                Console.WriteLine();
            }

            else if(this.EstDemaree == false)
            {
                Console.WriteLine("La voiture est déjà arrêté...");
            }

            else
            {
                this.EstDemaree = false;
                this.Vitesse = 0;
                Console.WriteLine("La voiture est éteinte");
            }
        }

        public void Accelerer(double p_augmenterVitesse)
        {
            if((this.Vitesse + p_augmenterVitesse) > 230)
            {
                Console.WriteLine($"La voiture ne peut pas aller plus vite que 230km/h. Vous êtes actuellement à {this.Vitesse}km/h...");
            }

            else if(this.EstDemaree == false)
            {
                Console.WriteLine("Vous devez d'abord démarrer votre voiture...");
            }
            else
            {
                this.Vitesse += p_augmenterVitesse;
                Console.WriteLine($"Vous roulez maintenant à {this.Vitesse}km/h");
            }
        }

        public void Freiner(double p_diminuerVitesse)
        {
            if (this.EstDemaree == false)
            {
                Console.WriteLine("La voiture doit être démarée pour pouvoir freiner");
            }

            else if((this.Vitesse - p_diminuerVitesse) < 0)
            {
                Console.WriteLine($"La voiture ne peut pas avoir une vitesse inférieur à 0km/h. Vous êtes actuellement à {this.Vitesse}km/h");
            }
            else
            {
                this.Vitesse -= p_diminuerVitesse;
                Console.WriteLine($"vous roulez maintenant à {this.Vitesse}km/h");
            }
        }

        public override string ToString()
        {
            string demaree;
            if (this.EstDemaree == true)
            {
                demaree = "oui";
            }

            else
            {
                demaree = "non";
            }
            return ($"État de la voiture: Marque[{this.Marque}] | Modèle[{this.Modele}] | Vitesse[{this.Vitesse}] | En marche[{demaree}]");
        }

    }
}
