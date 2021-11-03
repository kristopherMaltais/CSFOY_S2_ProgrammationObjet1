using System;
using Xunit;
using voiture;

namespace voitureUnitTests
{
    public class UnitTest1
    {
        // Demarrer
        [Fact]
        public void Demarrer_VoitureDejaDemarree_AssertTrue()
        {
            // Arrange
            Voiture voiture = new Voiture();
            voiture.EstDemaree = true;

            // Act
            voiture.Demarrer();

            // Assert
            Assert.True(voiture.EstDemaree);
        }

        [Fact]
        public void Demarrer_VoitureArretee_AssertTrue()
        {
            // Arrange
            Voiture voiture = new Voiture();
            voiture.EstDemaree = false;

            // Act
            voiture.Demarrer();

            // Assert
            Assert.True(voiture.EstDemaree);
        }

        // Arreter
        [Fact]
        public void Arreter_VoitureDejaArretee_Assertfalse()
        {
            // Arrange
            Voiture voiture = new Voiture();
            voiture.EstDemaree = false;

            // Act
            voiture.Arreter();

            // Assert
            Assert.False(voiture.EstDemaree);
        }

        [Fact]
        public void Arreter_VoitureDemarrerPlus5km_Asserttrue()
        {
            // Arrange
            Voiture voiture = new Voiture();
            voiture.Vitesse = 6;
            voiture.EstDemaree = true;

            // Act
            voiture.Arreter();

            // Assert
            Assert.True(voiture.EstDemaree);
        }

        [Fact]
        public void Arreter_VoitureDemarrerMoins5km_AssertFalse()
        {
            // Arrange
            Voiture voiture = new Voiture();
            voiture.Vitesse = 4;
            voiture.EstDemaree = true;

            // Act
            voiture.Arreter();

            // Assert
            Assert.False(voiture.EstDemaree);
        }

        // Accélérer
        [Fact]
        public void Accelerer_VoitureAccelere_AssertEqual()
        {
            // Arrange
            int acceleration = 20;
            int vitesseAttendu = 20;

            Voiture voiture = new Voiture();
            voiture.EstDemaree = true;

            // Act
            voiture.Accelerer(acceleration);

            // Assert
            Assert.Equal(vitesseAttendu, voiture.Vitesse);

        }

        [Fact]
        public void Accelerer_VoitureArreteeAcceleration_AssertEqual()
        {
            // Arrange
            int acceleration = 20;
            int vitesseAttendu = 0;

            Voiture voiture = new Voiture();
            voiture.EstDemaree = false;

            // Act
            voiture.Accelerer(acceleration);

            // Assert
            Assert.Equal(vitesseAttendu, voiture.Vitesse);

        }

        [Fact]
        public void Accelerer_VoitureVitesseLimite_AssertEqual()
        {
            // Arrange
            int acceleration = 20;
            int vitesseAttendu = 220;

            Voiture voiture = new Voiture();
            voiture.EstDemaree = true;
            voiture.Vitesse = 220;

            // Act
            voiture.Accelerer(acceleration);

            // Assert
            Assert.Equal(vitesseAttendu, voiture.Vitesse);

        }

        // Freiner
        [Fact]
        public void Freiner_VoitureFreine_AssertEqual()
        {
            // Arrange
            int freinage = 20;
            int vitesseAttendu = 80;

            Voiture voiture = new Voiture();
            voiture.EstDemaree = true;
            voiture.Vitesse = 100;

            // Act
            voiture.Freiner(freinage);

            // Assert
            Assert.Equal(vitesseAttendu, voiture.Vitesse);

        }

        [Fact]
        public void Freiner_VoitureFreineArreter_AssertEqual()
        {
            // Arrange
            int freinage = 20;
            int vitesseAttendu = 0;

            Voiture voiture = new Voiture();
            voiture.EstDemaree = false;

            // Act
            voiture.Freiner(freinage);

            // Assert
            Assert.Equal(vitesseAttendu, voiture.Vitesse);

        }

        [Fact]
        public void Freiner_VoitureFreinevitesseLimite_AssertEqual()
        {
            // Arrange
            int freinage = 40;
            int vitesseAttendu = 30;

            Voiture voiture = new Voiture();
            voiture.EstDemaree = true;
            voiture.Vitesse = 30;

            // Act
            voiture.Freiner(freinage);

            // Assert
            Assert.Equal(vitesseAttendu, voiture.Vitesse);

        }
    }
}
