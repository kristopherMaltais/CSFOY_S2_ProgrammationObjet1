using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cafetiere
{
    public class MonnayeurCafetiere
    {
        public decimal MontantCaisse { get; set; }
        public decimal MontantDonneParClient { get; set; }

        public void Initialiser() 
        {
            // Mettre 50$ dans la machine lors de son initialisation
            this.MontantCaisse = 50.0m;

            this.MontantDonneParClient = 0.0m;
        }

        public void RecevoirPiece(decimal p_valeurPiece)
        {
        // Créer un array avec les pièces de monnaie existantes
        decimal[] piecesMonnaies = new decimal[] { 0.05m, 0.10m, 0.25m, 1m, 2m };

            if (piecesMonnaies.Contains(p_valeurPiece))
            {
                this.MontantDonneParClient += p_valeurPiece;
            }

            else
            {
                Console.WriteLine("Vous tentez d'insérer de l'argent qui n'existe pas, vous êtes un petit comique!");
            }
        }

        public void ConfirmerVente(decimal p_montant)
        {
            this.MontantCaisse += p_montant;
            this.MontantDonneParClient -= p_montant;
        }

        public void AfficherEtat()
        {
            Console.WriteLine($"Total machine: {this.MontantCaisse}");
        }

        public decimal RendreMonnaie(decimal p_valeurCafe)
        {
            decimal montantRendu = this.MontantDonneParClient - p_valeurCafe;
            this.MontantDonneParClient -= montantRendu;
            return montantRendu;
        }
    }
}
