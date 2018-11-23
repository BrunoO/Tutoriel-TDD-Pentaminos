using System;



namespace Pentaminos
{

    public class Program
    {        
        static public string Description
        {
            get { return "Calcul des solutions du problème des Pentaminos"; }
        }
        
        static void Main(string[] args)
        {
            Algorithme algorithme = new Algorithme(new Plateau(10,6), FabriqueDePentaminos.ListeDePentaminos(6));
            int total_solutions = algorithme.ChercheSolutions();
            Console.WriteLine("Nombre total de solutions : {0} ", total_solutions); 
        }
    }


}
