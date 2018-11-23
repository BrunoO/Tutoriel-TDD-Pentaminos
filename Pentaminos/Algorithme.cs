using System;
using System.Collections.Generic;
using System.Text;




namespace Pentaminos
{
    public class Algorithme
    {
        protected Plateau Plateau;
        private List<Pentamino> Liste;

        public Algorithme(Plateau plateau, List<Pentamino> liste)
        {
            Plateau = plateau;
            Liste = liste;
        }

        virtual protected Boolean Accepte(Pentamino pentamino, int position)
        {
            return true;
        }

        public int ChercheSolutions()
        {
            if (Plateau.SolutionTrouvee)
            {
                Plateau.Affiche();
                return 1;
            }
            else
            {
                int total_solutions = 0;
                int position_libre = Plateau.ProchainePositionLibre();

                foreach (Pentamino pentamino in Liste)
                {
                    if (Accepte(pentamino,position_libre) && (Plateau.Ajoute(pentamino, position_libre)))
                    {
                        total_solutions += ChercheSolutions();
                        Plateau.Enleve(pentamino, position_libre);
                    }
                }
                return total_solutions;
            }
        }
    }

    class AlgorithmeSansSymetries : Algorithme
    {
        public AlgorithmeSansSymetries(Plateau plateau, List<Pentamino> liste)
            : base(plateau, liste)
        {
        }
        
        static private Boolean EstDansIntervalle(int x, int a, int b)
        {
            return (x >= a) && ( x<= b) ;
        }

        protected override bool Accepte(Pentamino pentamino, int position)
        {
            if (pentamino.Variante == 1)
            {
                return Plateau.EstDansPremierQuadrant(position);
            }
            else
            {
                return true;
            }
        }
    }

  
}
