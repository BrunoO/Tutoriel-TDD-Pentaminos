using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pentaminos;

namespace TestsFonctionnelsPentaminos
{
    /// <summary>
    /// Summary description for TestsAlgorithme
    /// </summary>
    [TestClass]
    public class TestsAlgorithme
    {
        private const int NombreSolutionsUniques = 2339;

 

        #region Additional test attributes
         #endregion

        [TestMethod]
        public void NombreDeSolutions()
        {
            Algorithme algorithme = new Algorithme(new Plateau(), FabriqueDePentaminos.ListeDePentaminos(10));
            Assert.AreEqual(4 * NombreSolutionsUniques, algorithme.ChercheSolutions());
        }
        [TestMethod]
        public void EchangeDeDimensions()
        {
            Algorithme algorithme = new Algorithme(new Plateau(10, 6), FabriqueDePentaminos.ListeDePentaminos(6));
            Assert.AreEqual(4 * NombreSolutionsUniques, algorithme.ChercheSolutions());
        }

    }
}
