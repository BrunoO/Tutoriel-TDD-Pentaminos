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

        [TestMethod]
        public void ChercheSolutions_SurPlateauStandard_TrouveTotalAttendu() //NombreDeSolutions()
        {
            Algorithme algorithme = new Algorithme(new Plateau(), FabriqueDePentaminos.ListeDePentaminos(10));
            Assert.AreEqual(4 * NombreSolutionsUniques, algorithme.ChercheSolutions());
        }
        [TestMethod]
        public void ChercheSolutions_SurPlateauInverse_TrouveTotalAttendu() //EchangeDeDimensions()
        {
            Algorithme algorithme = new Algorithme(new Plateau(10, 6), FabriqueDePentaminos.ListeDePentaminos(6));
            Assert.AreEqual(4 * NombreSolutionsUniques, algorithme.ChercheSolutions());
        }

    }
}
