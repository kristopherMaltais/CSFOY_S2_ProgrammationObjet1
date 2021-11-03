using System;
using Xunit;
using Bibliotheque_classes;
using System.IO;
using System.Collections.Generic;

namespace ExerciceBloc4_testsUnitaires
{
    public class UnitTest1
    {
        // FichierTexteVersListeMot
        [Fact]
        public void FichierTexteVersListeMot_Precondition_ThrowException()
        {
            // Arrange
            string nomFichierVide = "";

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Compter.FichierTexteVersListeMot(nomFichierVide);});
        }
        [Fact]
        public void FichierTexteVersListeMot_RenvoieListeExacte_AssertEqual()
        {
            // Arrange
            string[] tableauMotsAttendu = new string[] {"bonjour", "salu5", "jean", "crevette", "pineapple", "jus-de-légumes", "salutation", "salut", "carotte", "voiture", "bonjour", "salut", "salut"};

            // Act
            string[] tableauMotsObtenu = Compter.FichierTexteVersListeMot("listeMots");

            // Assert
            Assert.Equal(tableauMotsAttendu, tableauMotsObtenu);
        }


        // CompterOccurenceMots
        [Fact]
        public void CompterOccurenceMots_Precondition_ThrowException()
        {
            // Arrange
            string[] listeMotVide = new string[0];

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Compter.CompterOccurenceMots(listeMotVide); });
        }

        [Fact]
        public void CompterOccurenceMots_RenvoieDictionnaireExacte_assertEqual()
        {
            // Arrange
            string[] tableauMots = new string[] { "bonjour", "salu5", "jean", "crevette", "pineapple", "jus-de-légumes", "salutation", "salut", "carotte", "voiture", "bonjour", "salut", "salut" };
            Dictionary<string, int> dictionnaireAttendu = new Dictionary<string, int> { ["bonjour"] = 2, ["carotte"] = 1, ["crevette"] = 1, ["jean"] = 1, ["jus-de-légumes"] = 1, ["pineapple"] = 1, ["salut"] = 3, ["salutation"] = 1, ["voiture"] = 1,};

            // Act
            Dictionary<string, int> dictionnaireObtenu = Compter.CompterOccurenceMots(tableauMots);

            // Assert
            Assert.Equal(dictionnaireAttendu, dictionnaireObtenu);
        }


        // CompterOccurenceLettre
        [Fact]
        public void CompterOccurenceLettre_Precondition_ThrowException()
        {
            // Arrange
            string motVide = "";

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Compter.CompterOccurenceLettre(motVide); });
        }

        [Fact]
        public void CompterOccurenceLettre_RenvoieListeExacte_assertEqual()
        {
            // Arrange
            List<(char, int)> listeLettreAttendue = new List<(char, int)> { ('b', 1), ('a', 1), ('l', 2), ('o', 1), ('n', 1) };

            // Act
            List<(char, int)> listeLettreObtenue = Compter.CompterOccurenceLettre("ballon");

            // Assert
            Assert.Equal(listeLettreAttendue, listeLettreObtenue);
        }


        // TriOccurenceDictionnaire
        [Fact]
        public void TriAlphabétiqueDictionnaire_Precondition_ThrowException()
        {
            // Arrange
            Dictionary<string, int> dictionnaireVide = new Dictionary<string, int> { };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Compter.TriAlphabétiqueDictionnaire(dictionnaireVide); });
        }

        [Fact]
        public void TriAlphabétiqueDictionnaire_ListeMotTrieCroissantAlphabétique_AssertEqual()
        {
            // Arrange
            Dictionary<string, int> dictionnaireATrier = new Dictionary<string, int> { ["crevette"] = 1, ["carotte"] = 1, ["bonjour"] = 2, ["jean"] = 1};
            List<(string, int)> listeMotAttendue = new List<(string, int)> { ("bonjour", 2), ("carotte", 1), ("crevette", 1), ("jean", 1)};

            // Act
            List<(string, int)> listeMotObtenue = Compter.TriAlphabétiqueDictionnaire(dictionnaireATrier);

            // Assert
            Assert.Equal(listeMotAttendue, listeMotObtenue);
        }


        // TriOccurenceDictionnaire
        [Fact]
        public void TriOccurenceDictionnaire_Precondition_ThrowException()
        {
            // Arrange
            Dictionary<string, int> dictionnaireVide = new Dictionary<string, int> { };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Compter.TriOccurenceDictionnaire(dictionnaireVide); });
        }

        [Fact]
        public void TriOccurenceDictionnaire_ListeMotTrieCroissantOccurence_AssertEqual()
        {
            // Arrange
            Dictionary<string, int> dictionnaireATrier = new Dictionary<string, int> { ["crevette"] = 1, ["carotte"] = 1, ["bonjour"] = 2, ["jean"] = 1 };
            List<(int, string)> listeMotAttendue = new List<(int, string)> { (1, "carotte"), (1, "crevette"), (1, "jean"), (2, "bonjour") };

            // Act
            List<(int, string)> listeMotObtenue = Compter.TriOccurenceDictionnaire(dictionnaireATrier);

            // Assert
            Assert.Equal(listeMotAttendue, listeMotObtenue);
        }

        [Fact]
        // TriOccurenceListeLettre
        public void TriOccurenceListeLettre_Precondition_ThrowException()
        {
            // Arrange
            List<(char, int)> listeVide = new List<(char, int)>() { };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Compter.TriOccurenceListeLettre(listeVide); });
        }

        [Fact]
        public void TriOccurenceListeLettre_ListeLettreTrieCroissantOccurence_AssertEqual()
        {
            // Arrange
            List<(char, int)> listeLettre = new List<(char, int)> { ('b', 1), ('a', 1), ('l', 2), ('o', 1), ('n', 1) };
            List<(int, char)> listeLettreAttendue = new List<(int, char)> { (1, 'a'), (1, 'b'), (1, 'n'), (1, 'o'), (2, 'l') };

            // Act
            List<(int, char)> listeLettreObtenue = Compter.TriOccurenceListeLettre(listeLettre);

            // Assert
            Assert.Equal(listeLettreAttendue, listeLettreObtenue);
        }
    }
}
