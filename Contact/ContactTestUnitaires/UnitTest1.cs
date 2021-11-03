using System;
using Xunit;
using ContactProgramme;

namespace ContactTestUnitaires
{
    public class UnitTest1
    {
        // Propriété Nom
        [Fact]
        public void Nom_préconditionNomNull_ExceptionLevee()
        {
            // Arrange
            string nomNull = null;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Contact nouveauContact = new Contact(nomNull); });
        }

        [Fact]
        public void Nom_préconditionNomVide_ExceptionLevee()
        {
            // Arrange
            string nomVide = "";

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Contact nouveauContact = new Contact(nomVide); });
        }


        // Constructeur Contact
        //[Fact]
        //public void Contact_IncrementationIdContact_AssertEqual()
        //{
        //    // Arrange
        //    int IdAttendu = 4;
        //    Contact contact1 = new Contact("Kristopher");

        //    // Act
        //    Contact contact2 = new Contact("Rachel");

        //    // Assert
        //    Assert.Equal(IdAttendu, contact2.Id);
        //}

        [Fact]
        public void Contact_NomAjouteCorrectement_AssertEqual()
        {
            // Arrange
            string nomAttendu = "Rachel";

            // Act
            Contact nouveauContact = new Contact("Rachel");

            // Assert
            Assert.Equal(nomAttendu, nouveauContact.Nom);
        }

        //[Fact]
        //public void Contact_IdContactCorrect_AssertEqual()
        //{
        //    // Arrange
        //    int IdAttendu = 1;

        //    // Act
        //    Contact nouveauContact = new Contact("Rachel");

        //    // Assert
        //    Assert.Equal(IdAttendu, nouveauContact.Id);
        //}

        [Fact]
        public void Contact_InitialisationDesListes_AssertEqual()
        {
            // Arrange
            Contact Contact5 = new Contact("Rachel");
            int countAttenduSiNonNull = 0;

            //Act and Assert
            Assert.Equal(Contact5.NbTelephones, countAttenduSiNonNull);
            Assert.Equal(Contact5.NbCourriels, countAttenduSiNonNull);
        }

        // * MÉTHODES ** //

        // AjouterTelephone
        [Fact]
        public void AjouterTelephone_PreconditionTelephoneNull_ThrowException()
        {
            // Arrange
            string numeroTelephone = null;
            Contact nouveauContact = new Contact("Rachel");

            // Act and assert
            Assert.Throws<ArgumentException>(() => { nouveauContact.AjouterTelephone(numeroTelephone); });

        }

        [Fact]
        public void AjouterTelephone_PreconditionTelephoneInferieur10_ThrowException()
        {
            // Arrange
            string numeroTelephone = "418668448";
            Contact nouveauContact = new Contact("Rachel");

            // Act and assert
            Assert.Throws<ArgumentException>(() => { nouveauContact.AjouterTelephone(numeroTelephone); });

        }

        [Fact]
        public void ajouterTelephone_AjouterTelephoneCorrectement_AssertEqual()
        {
            // Arrange
            Contact nouveauContact = new Contact("Rachel");
            string numeroTelephone = "4186684483";

            // Act
            nouveauContact.AjouterTelephone(numeroTelephone);
            string telephoneObtenu = nouveauContact.ObtenirTelephone(0);

            // Assert
            Assert.Equal(numeroTelephone, telephoneObtenu);
        }

    }
}
