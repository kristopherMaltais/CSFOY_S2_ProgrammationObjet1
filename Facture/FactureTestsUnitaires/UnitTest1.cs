using System;
using Xunit;
using Facture;

namespace FactureTestsUnitaires
{
    public class UnitTest1
    {
        // Ajouter Article
        [Fact]
        public void AjouterArticle_Precondition1_ThrowException()
        {
            // Arrange
            Article articleNull = null;
            int quantite = 3;
            Facture.Facture facture = new Facture.Facture();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { facture.AjouterArticle(articleNull, quantite); });
        }

        [Fact]
        public void AjouterArticle_Precondition2_ThrowException()
        {
            // Arrange
            Article article = new Article("1", "pomme", 2m, 2.50m);
            int quantiteInferieureUn = 0;
            Facture.Facture facture = new Facture.Facture();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { facture.AjouterArticle(article, quantiteInferieureUn); });
        }

        [Fact]
        public void AjouterArticle_ArticleAjouterListe_AssertNotEmpty()
        {
            // Arrange
            Article nouveauArticle = new Article("1", "pomme", 5m, 0.15m);
            int quantite = 2;
            Facture.Facture facture = new Facture.Facture();


            // Act
            facture.AjouterArticle(nouveauArticle, quantite);

            // Assert
            Assert.NotEmpty(facture.LignesFacture);
        }

        [Fact]
        public void AjouterArticle_AjouteLeBonArticle_AssertSame()
        {
            // Arrange
            Article nouveauArticle = new Article("1", "pomme", 5m, 0.15m);
            int quantite = 2;
            Facture.Facture facture = new Facture.Facture();


            // Act
            facture.AjouterArticle(nouveauArticle, quantite);

            // Assert
            Assert.Same(facture.LignesFacture[0].Article, nouveauArticle);
        }

        [Fact]
        public void AjouterArticle_ArticleExistantAjouteLigneFactureExistante_AssertEqual()
        {
            // Arrange
            Article articleExistant = new Article("1", "pomme", 5m, 0.15m);
            Article nouveauArticle = new Article("1", "pomme", 5m, 0.15m);
            int quantite = 2;
            int tailleAttendu = 1;

            Facture.Facture facture = new Facture.Facture();
            LigneFacture lignefacture = new LigneFacture(articleExistant, 1);

            // Act
            facture.LignesFacture.Add(lignefacture);
            facture.AjouterArticle(nouveauArticle, quantite);

            // Assert
            Assert.Equal(facture.LignesFacture.Count, tailleAttendu);
        }

        [Fact]
        public void AjouterArticle_ArticleNonExistantAjusterMontantLigneFactureVide_AssertEqual()
        {
            // Arrange
            Article article = new Article("1", "pomme", 5m, 0.15m);
            int quantite = 3;

            Facture.Facture facture = new Facture.Facture();
            

            LigneFacture ligneFactureAttendu = new LigneFacture(article, quantite);
            ligneFactureAttendu.TotalHorsTaxes = 15m;
            ligneFactureAttendu.MontantTaxes = 2.25m;
            ligneFactureAttendu.TotalTaxesIncluses = 17.25m;

            // Act
            facture.AjouterArticle(article, quantite);

            // Assert
            Assert.Equal(facture.LignesFacture[0].Article, ligneFactureAttendu.Article);
            Assert.Equal(facture.LignesFacture[0].Quantite, ligneFactureAttendu.Quantite);
            Assert.Equal(facture.LignesFacture[0].TotalHorsTaxes, ligneFactureAttendu.TotalHorsTaxes);
            Assert.Equal(facture.LignesFacture[0].MontantTaxes, ligneFactureAttendu.MontantTaxes);
            Assert.Equal(facture.LignesFacture[0].TotalTaxesIncluses, ligneFactureAttendu.TotalTaxesIncluses);
        }

        [Fact]
        public void AjouterArticle_ArticleExistantAjusterMontantLigneFacture_AssertEqual()
        {
            // Arrange
            Article article = new Article("1", "pomme", 5m, 0.15m);
            int quantite = 3;

            Facture.Facture facture = new Facture.Facture();

            LigneFacture ligneFactureAttendu = new LigneFacture(article, 4);
            ligneFactureAttendu.TotalHorsTaxes = 20m;
            ligneFactureAttendu.MontantTaxes = 3m;
            ligneFactureAttendu.TotalTaxesIncluses = 23m;

            // Act
            facture.AjouterArticle(article, 1);
            facture.AjouterArticle(article, 3);

            // Assert
            Assert.Equal(facture.LignesFacture[0].Article, ligneFactureAttendu.Article);
            Assert.Equal(facture.LignesFacture[0].Quantite, ligneFactureAttendu.Quantite);
            Assert.Equal(facture.LignesFacture[0].TotalHorsTaxes, ligneFactureAttendu.TotalHorsTaxes);
            Assert.Equal(facture.LignesFacture[0].MontantTaxes, ligneFactureAttendu.MontantTaxes);
            Assert.Equal(facture.LignesFacture[0].TotalTaxesIncluses, ligneFactureAttendu.TotalTaxesIncluses);
        }


        // Chercher Ligne Facture
        [Fact]
        public void ChercherLigneFacture_Precondition_throwException()
        {
            // Arrange
            string identifiantNull = null;
            Facture.Facture facture = new Facture.Facture();

            // Act and assert
            Assert.Throws<ArgumentException>(() => { facture.chercherlignefacture(identifiantNull); });
        }

        [Fact]
        public void ChercherLigneFacture_ChercherUneLigneFactureExistante_LigneFactureNotNull()
        {
            // Arrange
            Article article = new Article("1", "pomme", 3m, 0.15m);
            Facture.Facture facture = new Facture.Facture();
            string identifiant = "1";

            facture.AjouterArticle(article, 2);

            // Act
            LigneFacture ligneFactureObtenue = facture.chercherlignefacture(identifiant);

            // Assert
            Assert.NotNull(ligneFactureObtenue);
        }

        [Fact]
        public void ChercherLigneFacture_ChercherUneLigneFactureNonExistante_LigneFactureNotNull()
        {
            // Arrange
            Article article = new Article("1", "pomme", 3m, 0.15m);
            Facture.Facture facture = new Facture.Facture();
            string identifiant = "2";

            facture.AjouterArticle(article, 2);

            // Act
            LigneFacture ligneFactureObtenue = facture.chercherlignefacture(identifiant);

            // Assert
            Assert.Null(ligneFactureObtenue);
        }

        // Ajouter Article
        [Fact]
        public void AjouterArticleLigneFacture_Precondition_ThrowException()
        {
            // Arrange
            int quantite = 0;

            Article article = new Article("1", "pomme", 2m, 0.15m);
            LigneFacture ligneFacture = new LigneFacture(article, 0);

            // Act and assert
            Assert.Throws<ArgumentException>(() => { ligneFacture.AjouterArticle(quantite); });
        }

        [Fact]
        public void AjouterArticleLigneFacture__ThrowException()
        {
            // Arrange
            int quantite = 0;

            Article article = new Article("1", "pomme", 2m, 0.15m);
            LigneFacture ligneFacture = new LigneFacture(article, 0);

            // Act and assert
            Assert.Throws<ArgumentException>(() => { ligneFacture.AjouterArticle(quantite); });
        }
    }
}
