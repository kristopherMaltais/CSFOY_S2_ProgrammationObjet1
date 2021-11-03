using System;
using System.Collections.Generic;
using System.Text;
using Facture;

namespace Facture
{
    public class Facture
    {
        // ** PROPRIÉTÉ ** //
        public  List<LigneFacture> LignesFacture { get; set; }
        public int NombreArticles { get; set; }
        public decimal TotalHorsTaxes { get; set; }
        public decimal MontantTaxes { get; set; }
        public decimal TotalTaxesIncluses { get; set; }

        // ** CONSTRUCTEUR ** //
        public Facture()
        {
            LignesFacture = new List<LigneFacture>();
        }

        // ** METHODE ** //
        public void AjouterArticle(Article article, int quantite)
        {
            // Préconditions
            if(article == null)
            {
                throw new ArgumentException("l'article ne peut pas être null", "article");
            }

            if(quantite < 1)
            {
                throw new ArgumentException("Ne peut pas avoir une quantité inférieur à 1", "quantite");
            }

            // Vérifier si l'article est déjà dans la facture
            LigneFacture nouvelleLigneFacture = chercherlignefacture(article.Identifiant);

            // Ajouter une nouvelle ligneFacture si article n'est pas déjà dans la facture
            if(nouvelleLigneFacture == null)
            {
                nouvelleLigneFacture = new LigneFacture(article, quantite);

                nouvelleLigneFacture.AjouterArticle(quantite);
                LignesFacture.Add(nouvelleLigneFacture);
            }

            // Ajuster les montants en fonction de la quantité si l'article est déjà dans la facture
            else
            {
                nouvelleLigneFacture.AjouterArticle(quantite);
            }

            // Ajuster montants totaux de la facture
            NombreArticles += quantite;
            TotalHorsTaxes += article.PrixUnitaire * quantite;
            MontantTaxes = TotalHorsTaxes * article.TauxTaxes;
            TotalTaxesIncluses = TotalHorsTaxes + MontantTaxes;
        }

        public LigneFacture chercherlignefacture(string identifiantArticle)
        {
            // Précondition
            if (identifiantArticle == null)
            {
                throw new ArgumentException("identifiant ne peut pas être null", "identifiantArticle");
            }

            // Comparer chacun des identifiants des article à l'identifiant passé en paramètre
            for (int index = 0; index < LignesFacture.Count; index++)
            {
                if(LignesFacture[index].Article.Identifiant.Contains(identifiantArticle))
                {
                    //Retourner la ligneFacture trouvée
                    return LignesFacture[index];
                }
            }

            // Si aucune ligneFacture trouvée retourner null
            return null;
        }

        public override string ToString()
        {
            return $"Nombre article Total [{NombreArticles}] | Total hors taxes [{Math.Round(TotalHorsTaxes, 2)}]$ | Taxes [{Math.Round(MontantTaxes, 2)}]$ | Grand total [{Math.Round(TotalTaxesIncluses, 2)}]$";
        }


    }

}
