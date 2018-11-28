using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pentaminos;

namespace TestsUnitairesPentaminos
{
    /// <summary>
    /// Summary description for TestsProgram
    /// </summary>
    [TestClass]
    public class TestsProgram
    {

        [TestMethod]
        public void TestDescription()
        {
            Assert.IsTrue(Program.Description.Length > 0);
        }
    }
}
