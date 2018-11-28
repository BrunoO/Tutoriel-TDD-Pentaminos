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
        private Plateau plateauConnu;

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
         public void RemplissagePlateauAvecSolutionConnue()
        {
            plateauConnu = new Plateau();
            foreach (int i in SolutionIndexes)
            {
                ResultatsMethodeAjoute += plateauConnu.Ajoute(liste[i], plateauConnu.ProchainePositionLibre()).ToString() + " ";
                ResultatsAttendus += true.ToString() + " ";
            }
        }

        #endregion
       
        [TestMethod]
        public void TousLesPentaminos_DansLePlateauConnu_SontAjoutesCorrectement() //ConstructionSolutionComplete()
        {
            Assert.AreEqual( ResultatsAttendus, ResultatsMethodeAjoute);
        }

        [TestMethod]
        public void SolutionTrouvee_PourLePlateauConnu_RetourneVrai()
        {
            Assert.IsTrue( plateauConnu.SolutionTrouvee);
        }


        [TestMethod]
        public void LaLigne_1_EstCorrecte() //DescriptionLigne1()
        {
            Assert.AreEqual("VVVTTTWWFF", plateauConnu.Lignes()[0] );
        }

        [TestMethod]
        public void LaLigne_2_EstCorrecte() //DescriptionLigne2()
        {
            Assert.AreEqual("VUUUTWWFFL", plateauConnu.Lignes()[1]);
        }

        [TestMethod]
        public void LaLigne_3_EstCorrecte() //DescriptionLigne3()
        {
            Assert.AreEqual("VUZUTWPPFL", plateauConnu.Lignes()[2]);
        }
        
        [TestMethod]
        public void LaLigne_4_EstCorrecte() //DescriptionLigne4()
        {
            Assert.AreEqual("ZZZNNXPPPL", plateauConnu.Lignes()[3]);
        }
        [TestMethod]
        public void LaLigne_5_EstCorrecte() //DescriptionLigne5()
        {
            Assert.AreEqual("ZNNNXXXYLL", plateauConnu.Lignes()[4]);
        }
        [TestMethod]
        public void LaLigne_6_EstCorrecte() //DescriptionLigne6()
        {
            Assert.AreEqual("IIIIIXYYYY", plateauConnu.Lignes()[5]);
        }
    }

    
}
