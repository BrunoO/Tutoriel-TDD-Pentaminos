using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pentaminos;

namespace TestsUnitairesPentaminos
{
    /// <summary>
    /// Summary description for TestsPlateauConversion
    /// </summary>
    [TestClass]
    public class TestsPlateauConversion
    {

        [TestMethod]
        public void TestPosition27DansPremierQuadrant()
        {
            Assert.IsFalse( (new Plateau()).EstDansPremierQuadrant(27));
        }

        [TestMethod]
        public void TestPosition17DansPremierQuadrant()
        {
            Assert.IsTrue( (new Plateau()).EstDansPremierQuadrant(17));
        }
    }
}
