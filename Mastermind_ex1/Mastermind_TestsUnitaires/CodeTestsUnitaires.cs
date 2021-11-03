using System;
using Xunit;
using Bibliotheque_Classes;

namespace Mastermind_TestsUnitaires
{
    public class CodeTestsUnitaires
    {
        // Compare
        [Fact]
        public void Compare_PreconditionCodeNull_throwException ()
        {
            // Arrange
            int[] codeSecret = new int[] { 0, 0, 3, 2 };
            Code code = new Code(codeSecret, 4);
            Code codeNull = null;
            

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => {code.Compare(codeNull); });
        }

        [Fact]
        public void Compare_JoueurBonnesolution4_AssertEqual()
        {
            // Arrange
            int[] secret = new int[] { 0, 0, 3, 2 };
            int[] joueurEssai = new int[] { 0, 0, 3, 2 };
            Code codeSecret = new Code(secret, 4);
            Code codeJoueur = new Code(joueurEssai, 4);

            (int, int) resultatAttendu = (4, 0);

            // Act
            (int, int) resultatObtenu = codeSecret.Compare(codeJoueur);

            // Act and Assert
            Assert.Equal(resultatAttendu, resultatObtenu);

        }

        [Fact]
        public void Compare_JoueurbonneCouleurMauvaisePlace4_AssertEqual()
        {
            // Arrange
            int[] secret = new int[] { 1, 0, 0, 0 };
            int[] joueurEssai = new int[] { 2, 1, 2, 2 };
            Code codeSecret = new Code(secret, 4);
            Code codeJoueur = new Code(joueurEssai, 4);

            (int, int) resultatAttendu = (0, 1);

            // Act
            (int, int) resultatObtenu = codeSecret.Compare(codeJoueur);

            // Act and Assert
            Assert.Equal(resultatAttendu, resultatObtenu);
        }

        [Fact]
        public void Compare_JoueurBonneCouleurBonnePlace4_AssertEqual()
        {
            // Arrange
            int[] secret = new int[] { 1, 0, 0, 0 };
            int[] joueurEssai = new int[] { 1, 2, 2, 2 };
            Code codeSecret = new Code(secret, 4);
            Code codeJoueur = new Code(joueurEssai, 4);

            (int, int) resultatAttendu = (1, 0);

            // Act
            (int, int) resultatObtenu = codeSecret.Compare(codeJoueur);

            // Act and Assert
            Assert.Equal(resultatAttendu, resultatObtenu);
        }

        [Fact]
        public void Compare_JoueurAucuneBonneCouleur4_AssertEqual()
        {
            // Arrange
            int[] secret = new int[] { 0, 0, 0, 0 };
            int[] joueurEssai = new int[] { 1, 1, 1, 1 };
            Code codeSecret = new Code(secret, 4);
            Code codeJoueur = new Code(joueurEssai, 4);

            (int, int) resultatAttendu = (0, 0);

            // Act
            (int, int) resultatObtenu = codeSecret.Compare(codeJoueur);

            // Act and Assert
            Assert.Equal(resultatAttendu, resultatObtenu);
        }

        [Fact]
        public void Compare_QuantitecouleurPlusGrandeCodeSecret4_AssertEqual()
        {
            // Arrange
            int[] secret = new int[] { 1, 1, 2, 2 };
            int[] joueurEssai = new int[] { 0, 0, 0, 1 };
            Code codeSecret = new Code(secret, 4);
            Code codeJoueur = new Code(joueurEssai, 4);

            (int, int) resultatAttendu = (0, 1);

            // Act
            (int, int) resultatObtenu = codeSecret.Compare(codeJoueur);

            // Act and Assert
            Assert.Equal(resultatAttendu, resultatObtenu);
        }

        [Fact]
        public void Compare_QuantitecouleurPlusPetiteCodeSecret4_AssertEqual()
        {
            // Arrange
            int[] secret = new int[] { 1, 2, 2, 2 };
            int[] joueurEssai = new int[] { 0, 1, 1, 1 };
            Code codeSecret = new Code(secret, 4);
            Code codeJoueur = new Code(joueurEssai, 4);

            (int, int) resultatAttendu = (0, 1);

            // Act
            (int, int) resultatObtenu = codeSecret.Compare(codeJoueur);

            // Act and Assert
            Assert.Equal(resultatAttendu, resultatObtenu);
        }


        [Fact]
        public void Compare_JoueurBonnesolution5_AssertEqual()
        {
            // Arrange
            int[] secret = new int[] { 0, 0, 3, 2, 3 };
            int[] joueurEssai = new int[] { 0, 0, 3, 2, 3 };
            Code codeSecret = new Code(secret, 4);
            Code codeJoueur = new Code(joueurEssai, 4);

            (int, int) resultatAttendu = (5, 0);

            // Act
            (int, int) resultatObtenu = codeSecret.Compare(codeJoueur);

            // Act and Assert
            Assert.Equal(resultatAttendu, resultatObtenu);

        }

        [Fact]
        public void Compare_JoueurbonneCouleurMauvaisePlace5_AssertEqual()
        {
            // Arrange
            int[] secret = new int[] { 1, 0, 0, 0, 0 };
            int[] joueurEssai = new int[] { 2, 1, 2, 2, 2 };
            Code codeSecret = new Code(secret, 4);
            Code codeJoueur = new Code(joueurEssai, 4);

            (int, int) resultatAttendu = (0, 1);

            // Act
            (int, int) resultatObtenu = codeSecret.Compare(codeJoueur);

            // Act and Assert
            Assert.Equal(resultatAttendu, resultatObtenu);
        }

        [Fact]
        public void Compare_JoueurBonneCouleurBonnePlace5_AssertEqual()
        {
            // Arrange
            int[] secret = new int[] { 1, 0, 0, 0, 0 };
            int[] joueurEssai = new int[] { 1, 2, 2, 2, 2 };
            Code codeSecret = new Code(secret, 4);
            Code codeJoueur = new Code(joueurEssai, 4);

            (int, int) resultatAttendu = (1, 0);

            // Act
            (int, int) resultatObtenu = codeSecret.Compare(codeJoueur);

            // Act and Assert
            Assert.Equal(resultatAttendu, resultatObtenu);
        }

        [Fact]
        public void Compare_JoueurAucuneBonneCouleur5_AssertEqual()
        {
            // Arrange
            int[] secret = new int[] { 0, 0, 0, 0, 0 };
            int[] joueurEssai = new int[] { 1, 1, 1, 1, 1 };
            Code codeSecret = new Code(secret, 4);
            Code codeJoueur = new Code(joueurEssai, 4);

            (int, int) resultatAttendu = (0, 0);

            // Act
            (int, int) resultatObtenu = codeSecret.Compare(codeJoueur);

            // Act and Assert
            Assert.Equal(resultatAttendu, resultatObtenu);
        }

        [Fact]
        public void Compare_QuantitecouleurPlusGrandeCodeSecret5_AssertEqual()
        {
            // Arrange
            int[] secret = new int[] { 1, 1, 1, 2, 2 };
            int[] joueurEssai = new int[] { 0, 0, 0, 1, 0 };
            Code codeSecret = new Code(secret, 4);
            Code codeJoueur = new Code(joueurEssai, 4);

            (int, int) resultatAttendu = (0, 1);

            // Act
            (int, int) resultatObtenu = codeSecret.Compare(codeJoueur);

            // Act and Assert
            Assert.Equal(resultatAttendu, resultatObtenu);
        }

        [Fact]
        public void Compare_QuantitecouleurPlusPetiteCodeSecret5_AssertEqual()
        {
            // Arrange
            int[] secret = new int[] { 1, 2, 2, 2, 2 };
            int[] joueurEssai = new int[] { 0, 1, 1, 1, 0 };
            Code codeSecret = new Code(secret, 4);
            Code codeJoueur = new Code(joueurEssai, 4);

            (int, int) resultatAttendu = (0, 1);

            // Act
            (int, int) resultatObtenu = codeSecret.Compare(codeJoueur);

            // Act and Assert
            Assert.Equal(resultatAttendu, resultatObtenu);
        }

        [Fact]
        public void Compare_NombreDeCouleurACinq_AssertEqual()
        {
            // Arrange
            int[] secret = new int[] { 4, 4, 4, 4, 4 };
            int[] joueurEssai = new int[] { 4, 4, 4, 4, 4 };
            Code codeSecret = new Code(secret, 5);
            Code codeJoueur = new Code(joueurEssai, 5);

            (int, int) resultatAttendu = (5, 0);

            // Act
            (int, int) resultatObtenu = codeSecret.Compare(codeJoueur);

            // Act and Assert
            Assert.Equal(resultatAttendu, resultatObtenu);
        }

        [Fact]
        public void Compare_ValeurParDefautFonctionnelle_AssertEqual()
        {
            // Arrange
            int[] secret = new int[] { 5, 5, 5, 5, 5 };
            int[] joueurEssai = new int[] { 5, 5, 5, 5, 5 };
            Code codeSecret = new Code(secret, 6);
            Code codeJoueur = new Code(joueurEssai, 6);

            (int, int) resultatAttendu = (5, 0);

            // Act
            (int, int) resultatObtenu = codeSecret.Compare(codeJoueur);

            // Act and Assert
            Assert.Equal(resultatAttendu, resultatObtenu);
        }




        // Constructeur 1
        [Fact]
        public void Constructeur1_PreconditionTableauNull_ThrowException()
        {
            // Arrange
            int[] codeSecret = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Code code = new Code(codeSecret, 4); });
        }

        [Fact]
        public void Constructeur1_PreconditionLongueurTableauEntre4Et5_ThrowException()
        {
            // Arrange
            int[] codeSecret = new int[] { 0, 0, 1, 0, 5, 6 };
            int longueurTableauExcedent = 4;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Code code = new Code(codeSecret, longueurTableauExcedent); });
        }

        [Fact]
        public void Constructeur1_PreconditionNombreCouleurPossibleEntre4Et6_ThrowException()
        {
            // Arrange
            int[] codeSecret = new int[] { 0, 0, 1, 0 };
            int nombreChiffreExcedant = 7;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Code code = new Code(codeSecret, nombreChiffreExcedant); });
        }

        [Fact]
        public void Constructeur1_PreconditionChiffreCombinaisonExcedant_ThrowException()
        {
            // Arrange
            int[] codeSecret = new int[] { 6, 0, 1, 0 };
            int nombreChiffreExcedant = 4;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Code code = new Code(codeSecret, nombreChiffreExcedant); });
        }

        [Fact]
        public void Constructeur1_ConstructeurAjouteChampCorrectement_AssertEqual()
        {
            // Arrange
            int[] code = new int[] { 0, 2, 0, 1 };
            int nbCouleur = 5;
            int longueurCode = 4;
            int hashCodeAttendu = 2179;

            // Act
            Code codeObtenu = new Code(code, 5);

            // Assert
            Assert.Equal(codeObtenu.NbCouleur, nbCouleur);
            Assert.Equal(codeObtenu.LongueurCode, longueurCode);
            Assert.Equal(hashCodeAttendu, codeObtenu.GetHashCode());
            
        }

        [Fact]
        public void Constructeur1_ValeurParDefautFonctionnelle_AssertInRange()
        {
            // Arrange
            int[] code = new int[] { 0, 2, 0, 1 };

            // Act
            Code codeObtenu = new Code(code);

            // Assert
            Assert.InRange<int>(codeObtenu.CodeSecret[0], 0, 4);
            Assert.InRange<int>(codeObtenu.CodeSecret[1], 0, 4);
            Assert.InRange<int>(codeObtenu.CodeSecret[2], 0, 4);
            Assert.InRange<int>(codeObtenu.CodeSecret[3], 0, 4);


        }


        // Constructeur 2
        [Fact]
        public void Constructeur2_PreconditionLongueurTableauEntre4Et5_ThrowException()
        {
            // Arrange
            int longueurTableau = 6;
            int nbCouleur = 5;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Code code = new Code(longueurTableau, nbCouleur); });
        }

        [Fact]
        public void Constructeur2_PreconditionNombreCouleurExcedant_ThrowException()
        {
            // Arrange
            int longueurTableau = 4;
            int nbCouleur = 7;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Code code = new Code(longueurTableau, nbCouleur); });
        }

        [Fact]
        public void Constructeur2_CreationCodeAleatoireExactitude_AssertEqual()
        {
            // Arrange
            int longueurTableau = 4;
            int nbCouleur = 6;

            // Act
            Code codeObtenu = new Code(longueurTableau, nbCouleur);

            // Assert
            Assert.Equal(codeObtenu.LongueurCode, longueurTableau);
            Assert.InRange<int>(codeObtenu.CodeSecret[0], 0, 6);
            Assert.InRange<int>(codeObtenu.CodeSecret[1], 0, 6);
            Assert.InRange<int>(codeObtenu.CodeSecret[2], 0, 6);
            Assert.InRange<int>(codeObtenu.CodeSecret[3], 0, 6);
        }

        [Fact]
        public void Constructeur2_ConstructeurAjouteChampCorrectement_AssertEqualAssertNotNull()
        {
            // Arrange
            int longueurCode = 4;
            int nbCouleur = 5;

            // Act
            Code codeObtenu = new Code(longueurCode, 5);

            // Assert
            Assert.Equal(codeObtenu.NbCouleur, nbCouleur);
            Assert.Equal(codeObtenu.LongueurCode, longueurCode);
        }

        [Fact]
        public void Constructeur2_ValeurParDefautFonctionnelle_AssertEqual()
        {
            // Arrange
            int longueurCode = 4;

            // Act
            Code codeObtenu = new Code(longueurCode);

            // Assert
            Assert.InRange<int>(codeObtenu.CodeSecret[0], 0, 4);
            Assert.InRange<int>(codeObtenu.CodeSecret[1], 0, 4);
            Assert.InRange<int>(codeObtenu.CodeSecret[2], 0, 4);
            Assert.InRange<int>(codeObtenu.CodeSecret[3], 0, 4);


        }


        // Equals
        [Fact]
        public void Equals_PreconditionCodeNull_throwException()
        {
            // Arrange
            int[] codeSecret = new int[] { 0, 0, 3, 2 };
            Code code1 = new Code(codeSecret, 4);
            Code codeNull = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { code1.Compare(codeNull); });
        }

        [Fact]
        public void Equals_RetourneVraiSiCodeIdentique_AssertTrue()
        {
            // Arrange
            int[] codeSecret1 = new int[] { 0, 0, 3, 2 };
            int[] codeSecret2 = new int[] { 0, 0, 3, 2 };

            // Act
            Code code1 = new Code(codeSecret1, 4);
            Code code2 = new Code(codeSecret2, 4);

            // Assert
            Assert.True(code1.Equals(code2));
        }

        [Fact]
        public void Equals_RetourneFauxSiCodePasIdentique_AssertFalse()
        {
            // Arrange
            int[] codeSecret1 = new int[] { 0, 0, 2, 3 };
            int[] codeSecret2 = new int[] { 0, 0, 3, 2 };

            // Act
            Code code1 = new Code(codeSecret1, 4);
            Code code2 = new Code(codeSecret2, 4);

            // Assert
            Assert.False(code1.Equals(code2));
        }


        // GetHashCode
        [Fact]
        public void GetHashCode_RetourneHashCodeExactitude_AssertTrue()
        {
            // Arrange
            int[] code = new int[] { 0, 2, 0, 1 };
            int nbCouleur = 5;
            Code codeSecret = new Code(code, nbCouleur);
            int hashCodeAttendu = 2179;


            // Act
            int hashCodeObtenu = codeSecret.GetHashCode(); 

            // Assert
            Assert.Equal(hashCodeObtenu, hashCodeAttendu);
        }
    }
}
