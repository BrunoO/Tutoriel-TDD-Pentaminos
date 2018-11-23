using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pentaminos;

namespace TestsUnitairesPentaminos
{
    /// <summary>
    /// Summary description for TestPlateauAvecSolutionConnue
    /// </summary>
    [TestClass]
    public class TestsPlateauAvecSolutionConnue
    {
        private Plateau plateau;

        private List<Pentamino> liste = FabriqueDePentaminos.ListeDePentaminos(10);

        private int[] SolutionIndexes = { 
                                        08,
                                        11,
                                        18,
                                        48,
                                        19,
                                        24,
                                        06,
                                        59,
                                        31,
                                        02,
                                        45,
                                        00 
        };

        private string ResultatsMethodeAjoute = "";
        private string ResultatsAttendus = "";

        public TestsPlateauAvecSolutionConnue()
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
            foreach (int i in SolutionIndexes)
            {
                ResultatsMethodeAjoute += plateau.Ajoute(liste[i], plateau.ProchainePositionLibre()).ToString() + " ";
                ResultatsAttendus += true.ToString() + " ";
            }
        }
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
       
        [TestMethod]
        public void ConstructionSolutionComplete()
        {
            Assert.AreEqual( ResultatsAttendus, ResultatsMethodeAjoute);
        }

        [TestMethod]
        public void SolutionTrouvee()
        {
            Assert.IsTrue( plateau.SolutionTrouvee);
        }


        [TestMethod]
        public void DescriptionLigne1()
        {
            Assert.AreEqual("VVVTTTWWFF", plateau.Lignes()[0] );
        }

        [TestMethod]
        public void DescriptionLigne2()
        {
            Assert.AreEqual("VUUUTWWFFL", plateau.Lignes()[1]);
        }

        [TestMethod]
        public void DescriptionLigne3()
        {
            Assert.AreEqual("VUZUTWPPFL", plateau.Lignes()[2]);
        }
        
        [TestMethod]
        public void DescriptionLigne4()
        {
            Assert.AreEqual("ZZZNNXPPPL", plateau.Lignes()[3]);
        }
        [TestMethod]
        public void DescriptionLigne5()
        {
            Assert.AreEqual("ZNNNXXXYLL", plateau.Lignes()[4]);
        }
        [TestMethod]
        public void DescriptionLigne6()
        {
            Assert.AreEqual("IIIIIXYYYY", plateau.Lignes()[5]);
        }
    }

    
}
