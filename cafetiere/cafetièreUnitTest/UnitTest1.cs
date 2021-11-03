using System;
using Xunit;
using cafetiere;
using System.Collections.Generic;

namespace cafetièreUnitTest
{
    public class UnitTest1
    {

        //** FONCTIONS **//

        // AfficherCafes
        [Fact]
        public void AfficherCafes_Precondition1_ThrowError()
        {
            // Arrange
            List<Cafe> listeNull = null;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Fonctions.AfficherCafes(listeNull); });
        }

        // ChoixCafe
        [Fact]
        public void ChoixCafe_Preconcondition1_ThrowError()
        {
            // Arrange
            List<Cafe> listeNull = null;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Fonctions.ChoixCafe(listeNull); });
        }

        // Afficher Information
        [Fact]
        public void AfficherInformation_Precondition1_ThrowError()
        {
            // Arrange
            Cafe cafeNull = null;
            MonnayeurCafetiere cafetiere = new MonnayeurCafetiere();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Fonctions.AfficherInformation(cafeNull, cafetiere); });
        }

        [Fact]
        public void AfficherInformation_Precondition2_ThrowError()
        {
            // Arrange
            Cafe cafe = new Cafe("test", 1m);
            MonnayeurCafetiere cafetiereNull = null;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Fonctions.AfficherInformation(cafe, cafetiereNull); });
        }


        //** METHOD **//


        // Initialiser
        [Fact]
        public void Initialiser_InitialiseValeurExact_Equal()
        {
            // Arrange
            decimal MontantCaisseAttendu = 50m;
            decimal MontantDonneParClientAttendu = 0m;
            MonnayeurCafetiere cafetiere = new MonnayeurCafetiere();

            // Act
            cafetiere.Initialiser();

            // Assert
            Assert.Equal(MontantCaisseAttendu, cafetiere.MontantCaisse);
            Assert.Equal(MontantDonneParClientAttendu, cafetiere.MontantDonneParClient);
        }

        // RecevoirPiece
        [Fact]
        public void RecevoirPiece_AjouterPiece_AssertEqual()
        {
            // Arrange
            decimal pieceAjoutee = 1m;
            decimal totalAttendu = 1m;
            MonnayeurCafetiere cafetiere = new MonnayeurCafetiere();

            // Act
            cafetiere.RecevoirPiece(pieceAjoutee);

            // Assert
            Assert.Equal(totalAttendu, cafetiere.MontantDonneParClient);
        }

        [Fact]
        public void RecevoirPiece_AjouterPieceIncorect_AssertEqual()
        {
            // Arrange
            decimal pieceAjoutee = 0.23m;
            decimal totalAttendu = 0m;
            MonnayeurCafetiere cafetiere = new MonnayeurCafetiere();

            // Act
            cafetiere.RecevoirPiece(pieceAjoutee);

            // Assert
            Assert.Equal(totalAttendu, cafetiere.MontantDonneParClient);
        }

        // ConfirmerVente
        [Fact]
        public void ConfirmerVente_MontantCaisseExact_AssertEqual()
        {
            // Arrange
            decimal prixCafe = 2m;
            decimal totalAttendu = 52m;
            MonnayeurCafetiere cafetiere = new MonnayeurCafetiere();

            // Act
            cafetiere.Initialiser();
            cafetiere.ConfirmerVente(prixCafe);

            // Assert
            Assert.Equal(totalAttendu, cafetiere.MontantCaisse);
        }

        // ConfirmerVente
        [Fact]
        public void ConfirmerVente_MontantDonneClient_AssertEqual()
        {
            // Arrange
            decimal prixCafe = 2m;
            decimal montantDonneClient = 4m;
            decimal totalAttendu = 2m;
            MonnayeurCafetiere cafetiere = new MonnayeurCafetiere();

            // Act
            cafetiere.MontantDonneParClient = montantDonneClient;
            cafetiere.ConfirmerVente(prixCafe);

            // Assert
            Assert.Equal(totalAttendu, cafetiere.MontantDonneParClient);
        }

        // RendreMonnaie
        [Fact]
        public void RendreMonnaie_MontantRenduCorrect_AssertEqual()
        {
            // Arrange
            decimal prixCafe = 2m;
            decimal montantDonneClient = 4m;
            decimal monnaieRenduAttendu = 2m;
            MonnayeurCafetiere cafetiere = new MonnayeurCafetiere();

            // Act
            cafetiere.MontantDonneParClient = montantDonneClient;
            decimal monnaieRenduObtenu = cafetiere.RendreMonnaie(prixCafe);
           

            // Assert
            Assert.Equal(monnaieRenduAttendu, monnaieRenduObtenu);
        }


    }
}
