using System;
using System.Collections.Generic;
using System.Text;

namespace Facture
{
    public class LigneFacture
    {
        //** PROPRIÉTÉS
        public int Quantite { get; set; }
        public Article Article { get; set; }
        public decimal TotalHorsTaxes { get; set; }
        public decimal MontantTaxes { get; set; }
        public decimal TotalTaxesIncluses { get; set; }

        //** CONSTRUCTEURS **//
        public LigneFacture(Article article, int quantite)
        {
            Article = article;
            Quantite = quantite;
        }

        //** METHODES **//
        public void AjouterArticle(int quantite)
        {
            // Précondition
            if(quantite < 1)
            {
                throw new ArgumentException("quantite ne peut pas être inférieur à 1", "quantite");
            }

            // Seulement ajuster la quantité pour les lignesFactures déjà présente
            if (TotalTaxesIncluses != 0)
            {
                Quantite += quantite;
            }

            // Ajuster les montants de la ligneFacture
            TotalHorsTaxes += Article.PrixUnitaire * quantite;
            MontantTaxes = TotalHorsTaxes * Article.TauxTaxes;
            TotalTaxesIncluses = TotalHorsTaxes + MontantTaxes;
        }

        public override string ToString()
        {
            return $"{Quantite} X {Article.Nom} | Prix Hors taxes [{Math.Round(TotalHorsTaxes, 2)}]$  Taxes [{Math.Round(MontantTaxes, 2)}]$  Total[{Math.Round(TotalTaxesIncluses, 2)}]$";
        }
    }
}
