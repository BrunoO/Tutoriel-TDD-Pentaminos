using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pentaminos;

namespace TestsUnitairesPentaminos
{
    /// <summary>
    /// Summary description for TestsPentamino
    /// </summary>
    [TestClass]
    public class TestsPentamino
    {
        public TestsPentamino()
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
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestTotalPentaminos()
        {
            Assert.AreEqual(FabriqueDePentaminos.ListeDePentaminos(10).Count, FabriqueDePentaminos.NombreDeVariantes);
        }

        [TestMethod]
        public void TestPositionDuPentominoX()
        {
            Pentamino x = FabriqueDePentaminos.ListeDePentaminos(10)[2];

            Assert.AreEqual(11, x.Decalages[0], "le premier décalage de X est incorrect");
            Assert.AreEqual(12, x.Decalages[1], "le deuxième décalage de X est incorrect");
            Assert.AreEqual(13, x.Decalages[2], "le troisième décalage de X est incorrect");
            Assert.AreEqual(24, x.Decalages[3], "le quatrième décalage de X est incorrect");
            Assert.AreEqual(1, x.Variante, "la variante de X est incorrecte");
            Assert.AreEqual('X', x.Representation, "X n'est pas représenté par la bonne lettre");
        }
    }
}
