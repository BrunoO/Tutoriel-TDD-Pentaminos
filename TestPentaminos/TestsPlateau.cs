using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pentaminos;


namespace TestsUnitairesPentaminos
{

    [TestClass]
    public class TestsPlateau
    {
        private Plateau plateau;
        private Pentamino I, X;

     

        #region Additional test attributes

         [TestInitialize()]
         public void MyTestInitialize()
         {
             plateau = new Plateau();
             I = FabriqueDePentaminos.ListeDePentaminos(10)[0];
             X = FabriqueDePentaminos.ListeDePentaminos(10)[2];
         }
        
        #endregion


        [TestMethod]
        public void AjouterI_SurPlateauVideEnPosition1_EstPossible() //TestAjoutPentamino()
        {
            Assert.IsTrue(plateau.Ajoute(I, 1));
        }

        [TestMethod]
        public void AjouterI_SurPlateauContenantDejaIenPosition1_EstInterdit() //TestAjoutPentaminoSansRepetition()
        {
            //Et ajouter I à une autre position ? surement possible, pas responsabilité de Ajoute
            plateau.Ajoute(I, 1);
            Assert.IsFalse(plateau.Ajoute(I, 1));
        }

        [TestMethod]
        public void SolutionTrouvee_PourPlateauVide_RetourneFaux()//TestSolutionTrouveePlateauVide()
        {
            Assert.IsFalse(plateau.SolutionTrouvee);
        }

        [TestMethod]
        public void VerifierPlaceLibre_PourPlateauVide_RetourneVrai()//PlaceLibreSurPlateauVide()
        {
            Assert.IsTrue(plateau.VerifierPlaceLibre(I, 1));
        }

        [TestMethod]
        public void VerifierPlaceLibre_ApresAjoutSurPlace_RetourneFaux() //PlaceNonLibreXapresI()
        {
            plateau.Ajoute(I, 1);
            Assert.IsFalse( plateau.VerifierPlaceLibre(X, 1));
        }

        [TestMethod]
        public void VerifierPlaceLibre_EnFinDeLigne_RetourneFaux() //PlaceNonLibreEnFinDeLigne()
        {
            Assert.IsFalse( plateau.VerifierPlaceLibre(I, 9));
        }

        [TestMethod]
        public void VerifierPlaceLibrePourX_HorsPlateauEnPosition65_RetourneFaux() //PlaceNonLibrePourXen65()
        {
            Assert.IsFalse( plateau.VerifierPlaceLibre(X, 65));
        }

        [TestMethod]
        public void VerifierPlaceLibrePourX_HorsPlateauEnPosition37_RetourneFaux() //PlaceNonLibrePourXen37()
        {
            Assert.IsFalse( plateau.VerifierPlaceLibre(X, 37));
        }

        [TestMethod]
        public void VerifierPlaceLibrePourX_DansPlateauEnPosition45_RetourneVrai() //PlaceLibrePourXen45()
        {
            Assert.IsTrue( plateau.VerifierPlaceLibre(X, 45));
        }

        [TestMethod]
        public void ProchainePositionLibre_PourPlateauVide_Retourne1() //ProchainePositionPlateauVide()
        {
            Assert.AreEqual( 1, plateau.ProchainePositionLibre());
        }

        [TestMethod]
        public void ProchainePositionLibre_PourPlateauContenantI_Retourne6() //ProchainePositionPlateauApresI()
        {
            plateau.Ajoute(I, 1);
            Assert.AreEqual( 6, plateau.ProchainePositionLibre());
        }

        [TestMethod]
        public void AjouterP_SurPlateauVide_RetourneVrai() //DepassementLimites() - ????
        {
            Assert.IsTrue(plateau.Ajoute(FabriqueDePentaminos.ListeDePentaminos(10)[62], 27));
        }

        [TestMethod]
        public void VerifierPlaceLibre_ApresAjoutduI_EstCorrectePourPlusieursPositions() //PlacementVenPosition1()
        {
            plateau.Ajoute(FabriqueDePentaminos.ListeDePentaminos(10)[08], 1);

            Assert.IsFalse( plateau.VerifierPlaceLibre(I, 2));
            Assert.IsFalse(plateau.VerifierPlaceLibre(I, 3));
            Assert.IsTrue(plateau.VerifierPlaceLibre(I, 4));
            Assert.IsFalse(plateau.VerifierPlaceLibre(I, 13));
            Assert.IsFalse(plateau.VerifierPlaceLibre(I, 25));
        }

        [TestMethod]
        public void LesLignesDuPlateau_ApresAjoutDuVenPosition1_SontCorrectes() //PlacementVenPosition1viaLignes()
        {
            plateau.Ajoute(FabriqueDePentaminos.ListeDePentaminos(10)[08], 1);

            Assert.AreEqual("VVV       ", plateau.Lignes()[0]);
            Assert.AreEqual("V         ", plateau.Lignes()[1]);
            Assert.AreEqual("V         ", plateau.Lignes()[2]);
        }

        [TestMethod]
        public void LesLignesDuPlateau_ApresAjoutDuLenPosition5_SontCorrectes() //PlacementLenPosition5viaLignes()
        {
            plateau.Ajoute(FabriqueDePentaminos.ListeDePentaminos(10)[30], 5);
            Assert.AreEqual("    L     ", plateau.Lignes()[0]);
            Assert.AreEqual(" LLLL     ", plateau.Lignes()[1]);
        }

        [TestMethod]
        public void AjouterI_ApresAjouterPuisEnlever_EstPossible() //AjouterPuisEnleverI()
        {
            plateau.Ajoute(I, 1);
            plateau.Enleve(I, 1);
            Assert.IsTrue(plateau.Ajoute(I, 1));
        }

        [TestMethod]
        public void ProchainePositionLibre_ApresAjouterPuisEnlever_EstToujoursIdentique()
        {
            plateau.Ajoute(I, 1);
            int position_libre = plateau.ProchainePositionLibre();

            plateau.Enleve(I, 1);
            Assert.AreEqual(1, plateau.ProchainePositionLibre());
        }

    }
}
