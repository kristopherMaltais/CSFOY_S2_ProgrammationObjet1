using System;
using System.Collections.Generic;
using System.Text;

namespace Facture
{
    public class Article
    {
        // ** PROPRIÉTÉS **//
        public string Identifiant { get; set; }
        public string Nom { get; set; }
        public decimal PrixUnitaire { get; set; }
        public decimal TauxTaxes { get; set; }

        // ** CONSTRUCTEUR ** //
        public Article(string identifiant, string nom, decimal prixUnitaire, decimal tauxTaxes)
        {
            Identifiant = identifiant;
            Nom = nom;
            PrixUnitaire = prixUnitaire;
            TauxTaxes = tauxTaxes;
        }

        // ** METHODE **//
        public override string ToString()
        {
            return $" ID [{Identifiant}] | NOM [{Nom}] | PRIX [{PrixUnitaire}] | TAXES [{TauxTaxes}]";
        }

    }
}
