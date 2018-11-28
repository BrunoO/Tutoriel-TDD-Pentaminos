using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pentaminos;

namespace TestsUnitairesPentaminos
{
 
    [TestClass]
    public class TestsPlateauConversion
    {

        [TestMethod]
        public void LePremierCadran_DuPlateauStandard_NeContientPasLaPosition27()//TestPosition27DansPremierQuadrant()
        {
            Assert.IsFalse( (new Plateau()).EstDansPremierQuadrant(27));
        }

        [TestMethod]
        public void LePremierCadran_DuPlateauStandard_ContientLaPosition17() //TestPosition17DansPremierQuadrant()
        {
            Assert.IsTrue( (new Plateau()).EstDansPremierQuadrant(17));
        }
    }
}
