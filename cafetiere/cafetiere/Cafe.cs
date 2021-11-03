using System;
using System.Collections.Generic;
using System.Text;

namespace cafetiere
{
    public class Cafe
    {
        public string NomCafe { get; set; }
        public decimal PrixCafe { get; set; }

        //** CONSTRUCTOR **//
        public Cafe(string nomCafe, decimal prixCafe)
        {
            NomCafe = nomCafe;
            PrixCafe = prixCafe;
        }
    }
}
