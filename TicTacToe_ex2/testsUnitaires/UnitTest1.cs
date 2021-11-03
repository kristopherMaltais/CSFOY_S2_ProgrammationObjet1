using System;
using Xunit;
using PO1Examen1;

namespace testsUnitaires
{
    public class UnitTest1
    {
        // 1. PlacerCaractere
        [Fact]
        public void PlacerCaractere_preconditions1_throwException()
        {
            // Arrange
            Grille jeu = new Grille();
            
            // Act Assert
            Assert.Throws<ArgumentException>(() => { jeu.placerCaractere('z', 3, 3); });
        }

        [Fact]
        public void PlacerCaractere_preconditions2_throwException()
        {
            // Arrange
            Grille jeu = new Grille();

            // Act Assert
            Assert.Throws<ArgumentException>(() => { jeu.placerCaractere('o', 4, 4); });
        }

        [Fact]
        public void PlacerCaractere_PlacerCaractereCorrectement_assertEqual()
        {
            // Arrange
            Grille jeu = new Grille();
            jeu.placerCaractere('o', 0, 0);
            char caractereAttendu = 'o';

            // Act
            char caractereObtenu = jeu.ToString()[0];

            // Assert
            Assert.Equal(caractereObtenu, caractereAttendu);
        }

        [Fact]
        public void PlacerCaractere_PlacerCaractereSurCaseOccupe_assertEqual()
        {
            // Arrange
            Grille jeu = new Grille();
            jeu.placerCaractere('x', 0, 0);
            jeu.placerCaractere('o', 0, 0);
            char caractereAttendu = 'x';

            // Act
            char caractereObtenu = jeu.ToString()[0];

            // Assert
            Assert.Equal(caractereObtenu, caractereAttendu);
        }


        // 2. Évaluer s'il y a un gagnant ou non

        // victoire de 'o' sur une colonne (n’importe quelle colonne à votre choix)
        [Fact]
        public void Gagnant_GagnantOSurColonne_AssertEqual()
        {
            // Arrange
            Grille nouvelleGrille = new Grille();
            nouvelleGrille.placerCaractere('o', 0, 1);
            nouvelleGrille.placerCaractere('o', 1, 1);
            nouvelleGrille.placerCaractere('o', 2, 1);

            char gagnantAttendu = 'o';


            // Act
            char gagnantObtenu = nouvelleGrille.Gagnant();

            // Assert
            Assert.Equal(gagnantAttendu, gagnantObtenu);
        }

        // victoire de 'x' sur une ligne(n’importe quelle ligne à votre choix)
        [Fact]
        public void Gagnant_GagnantOSurLigne_AssertEqual()
        {
            // Arrange
            Grille nouvelleGrille = new Grille();
            nouvelleGrille.placerCaractere('x', 1, 0);
            nouvelleGrille.placerCaractere('x', 1, 1);
            nouvelleGrille.placerCaractere('x', 1, 2);

            char gagnantAttendu = 'x';


            // Act
            char gagnantObtenu = nouvelleGrille.Gagnant();

            // Assert
            Assert.Equal(gagnantAttendu, gagnantObtenu);
        }

        // victoire de 'X' sur la diagonale principale
        [Fact]
        public void Gagnant_Gagnantxdiago_AssertEqual()
        {
            // Arrange
            Grille nouvelleGrille = new Grille();
            nouvelleGrille.placerCaractere('x', 0, 0);
            nouvelleGrille.placerCaractere('x', 1, 1);
            nouvelleGrille.placerCaractere('x', 2, 2);

            char gagnantAttendu = 'x';


            // Act
            char gagnantObtenu = nouvelleGrille.Gagnant();

            // Assert
            Assert.Equal(gagnantAttendu, gagnantObtenu);
        }

        // victoire de 'O' sur la deuxième diagonale
        [Fact]
        public void Gagnant_GagnantDeuxiemeDiago_AssertEqual()
        {
            // Arrange
            Grille nouvelleGrille = new Grille();
            nouvelleGrille.placerCaractere('o', 0, 2);
            nouvelleGrille.placerCaractere('o', 1, 1);
            nouvelleGrille.placerCaractere('o', 2, 0);

            char gagnantAttendu = 'o';

            // Act
            char gagnantObtenu = nouvelleGrille.Gagnant();

            // Assert
            Assert.Equal(gagnantAttendu, gagnantObtenu);
        }

        // s'il n'y a aucun gagnant
        [Fact]
        public void Gagnant_AucunGagnant_AssertEqual()
        {
            // Arrange
            Grille nouvelleGrille = new Grille();
            nouvelleGrille.placerCaractere('x', 0, 2);
            nouvelleGrille.placerCaractere('o', 1, 1);
            nouvelleGrille.placerCaractere('o', 2, 0);

            char gagnantAttendu = '_';

            // Act
            char gagnantObtenu = nouvelleGrille.Gagnant();

            // Assert
            Assert.Equal(gagnantAttendu, gagnantObtenu);
        }

    }
}
