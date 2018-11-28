using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pentaminos;

namespace TestsUnitairesPentaminos
{

    [TestClass]
    public class TestsPentamino
    {
 
        [TestMethod]
        public void FabriqueDePentaminos_PourPlateauStandard_DoitFabriquerToutesLesVariantes() //TestTotalPentaminos()
        {
            Assert.AreEqual(FabriqueDePentaminos.ListeDePentaminos(10).Count, FabriqueDePentaminos.NombreDeVariantes);
        }

        [TestMethod]
        public void FabriqueDePentaminos_PourPlateauStandard_DoitBienPositionnerLeX()// TestPositionDuPentominoX()
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
