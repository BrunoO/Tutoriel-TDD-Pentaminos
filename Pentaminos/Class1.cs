using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.SyntaxHelpers;


namespace Pentaminos
{
    class Pentamino
    {
    }

    class FabriqueDePentaminos
    {
        static public List<Pentamino> ListeDePentaminos()
        {
            return new List<Pentamino>();
        }

    }

    [TestFixture]
    public class TestListePentaminos
    {
        [Test]
        public void TestTotalPentaminos()
        {
            Assert.That(FabriqueDePentaminos.ListeDePentaminos().Count, Is.EqualTo(63));
        }
    }
}
