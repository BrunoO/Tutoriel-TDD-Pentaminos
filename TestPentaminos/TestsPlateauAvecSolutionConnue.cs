using System.Collections.Generic;
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

  

        #region Additional test attributes
      
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
