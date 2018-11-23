using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pentaminos;


namespace TestsUnitairesPentaminos
{
    /// <summary>
    /// Summary description for TestsPlateau
    /// </summary>
    [TestClass]
    public class TestsPlateau
    {
        private Plateau plateau;
        private Pentamino I, X;

        public TestsPlateau()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
         [TestInitialize()]
         public void MyTestInitialize()
         {
             plateau = new Plateau();
             I = FabriqueDePentaminos.ListeDePentaminos(10)[0];
             X = FabriqueDePentaminos.ListeDePentaminos(10)[2];
         }
        
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        [TestMethod]
        public void TestAjoutPentamino()
        {
            Assert.IsTrue(plateau.Ajoute(I, 1));
        }

        [TestMethod]
        public void TestAjoutPentaminoSansRepetition()
        {
            plateau.Ajoute(I, 1);
            Assert.IsFalse(plateau.Ajoute(I, 1));
        }

        [TestMethod]
        public void TestSolutionTrouveePlateauVide()
        {
            Assert.IsFalse(plateau.SolutionTrouvee);
        }

        [TestMethod]
        public void PlaceLibreSurPlateauVide()
        {
            Assert.IsTrue(plateau.VerifierPlaceLibre(I, 1));
        }

        [TestMethod]
        public void PlaceNonLibreXapresI()
        {
            plateau.Ajoute(I, 1);
            Assert.IsFalse( plateau.VerifierPlaceLibre(X, 1));
        }

        [TestMethod]
        public void PlaceNonLibreEnFinDeLigne()
        {
            Assert.IsFalse( plateau.VerifierPlaceLibre(I, 9));
        }

        [TestMethod]
        public void PlaceNonLibrePourXen65()
        {
            Assert.IsFalse( plateau.VerifierPlaceLibre(X, 65));
        }

        [TestMethod]
        public void PlaceNonLibrePourXen37()
        {
            Assert.IsFalse( plateau.VerifierPlaceLibre(X, 37));
        }

        [TestMethod]
        public void PlaceLibrePourXen45()
        {
            Assert.IsTrue( plateau.VerifierPlaceLibre(X, 45));
        }

        [TestMethod]
        public void ProchainePositionPlateauVide()
        {
            Assert.AreEqual( 1, plateau.ProchainePositionLibre());
        }

        [TestMethod]
        public void ProchainePositionPlateauApresI()
        {
            plateau.Ajoute(I, 1);
            Assert.AreEqual( 6, plateau.ProchainePositionLibre());
        }

        [TestMethod]
        public void DepassementLimites()
        {
            Assert.IsTrue(plateau.Ajoute(FabriqueDePentaminos.ListeDePentaminos(10)[62], 27));
        }

        [TestMethod]
        public void PlacementVenPosition1()
        {
            plateau.Ajoute(FabriqueDePentaminos.ListeDePentaminos(10)[08], 1);

            Assert.IsFalse( plateau.VerifierPlaceLibre(I, 2));
            Assert.IsFalse(plateau.VerifierPlaceLibre(I, 3));
            Assert.IsTrue(plateau.VerifierPlaceLibre(I, 4));
            Assert.IsFalse(plateau.VerifierPlaceLibre(I, 13));
            Assert.IsFalse(plateau.VerifierPlaceLibre(I, 25));
        }

        [TestMethod]
        public void PlacementVenPosition1viaLignes()
        {
            plateau.Ajoute(FabriqueDePentaminos.ListeDePentaminos(10)[08], 1);

            Assert.AreEqual("VVV       ", plateau.Lignes()[0]);
            Assert.AreEqual("V         ", plateau.Lignes()[1]);
            Assert.AreEqual("V         ", plateau.Lignes()[2]);
        }

        [TestMethod]
        public void PlacementLenPosition5viaLignes()
        {
            plateau.Ajoute(FabriqueDePentaminos.ListeDePentaminos(10)[30], 5);
            Assert.AreEqual("    L     ", plateau.Lignes()[0]);
            Assert.AreEqual(" LLLL     ", plateau.Lignes()[1]);
        }

        [TestMethod]
        public void AjouterPuisEnleverI()
        {
            plateau.Ajoute(I, 1);
            plateau.Enleve(I, 1);
            Assert.IsTrue(plateau.Ajoute(I, 1));
        }

        [TestMethod]
        public void PositionLibreApresAjouterPuisEnleverI()
        {
            plateau.Ajoute(I, 1);
            int position_libre = plateau.ProchainePositionLibre();

            plateau.Enleve(I, 1);
            Assert.AreEqual(1, plateau.ProchainePositionLibre());
        }

    }
}
