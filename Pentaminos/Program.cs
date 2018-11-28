using System;



namespace Pentaminos
{

    public class Program
    {        
     
        
        static void Main(string[] args)
        {
            Algorithme algorithme = new AlgorithmeSansSymetries(new Plateau(10,6), FabriqueDePentaminos.ListeDePentaminos(6));
            int total_solutions = algorithme.ChercheSolutions();
            Console.WriteLine("Nombre total de solutions : {0} ", total_solutions); 
        }
    }


}
