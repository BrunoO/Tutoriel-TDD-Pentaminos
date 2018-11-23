using System;
using System.Collections.Generic;

using System.Diagnostics;


namespace Pentaminos
{
    public class Plateau
    {
        private Boolean[] VariantesDejaAjoutees = new Boolean[FabriqueDePentaminos.NombreDePentaminos];

        private int TotalVariantesDejaAjoutees = 0;

        private char[] Cases ; 

        private int PositionLibreActuelle = 1;

        private const char POSITIONINTERDITE = '.';
        private const char POSITIONLIBRE = ' ';

        private int NOMBRE_DE_COLONNES ;
        private int NOMBRE_DE_LIGNES ;

        public Boolean EstDansPremierQuadrant(int position)
        {
            int x, y;
            CoordonnesXY(position, out x, out y);
            return (x < (NOMBRE_DE_LIGNES / 2)-1) && (y <= NOMBRE_DE_COLONNES / 2);
        }

        private void CoordonnesXY(int position, out int x, out int y)
        {
            x = position / (NOMBRE_DE_COLONNES + 2);
            y = position % (NOMBRE_DE_COLONNES + 2);
        }

        public List<string> Lignes()
        {
            List<string> liste = new List<string>();
            string ligne_en_cours = "";
            
            foreach (char c in Cases)
            {
                if (c != POSITIONINTERDITE)
                {
                    ligne_en_cours += c;
                }
                if (ligne_en_cours.Length == NOMBRE_DE_COLONNES)
                {
                    liste.Add(ligne_en_cours);
                    ligne_en_cours = "";
                }
            }
           return liste;
        }

        public void Affiche()
        {
            foreach (string s in Lignes())
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }

        public Plateau(int nombreLignes, int nombreColonnes)
        {
            int position = 0;
            NOMBRE_DE_LIGNES = nombreLignes;
            NOMBRE_DE_COLONNES = nombreColonnes;
            Cases = new Char[(NOMBRE_DE_COLONNES + 2) * (NOMBRE_DE_LIGNES + 1)];

            for (int index_ligne = 1; index_ligne <= NOMBRE_DE_LIGNES; index_ligne++)
            {
                Cases[position++] = POSITIONINTERDITE;
                for (int index_colonne = 1; index_colonne <= NOMBRE_DE_COLONNES; index_colonne++)
                {
                    Cases[position++] = POSITIONLIBRE;
                }
                Cases[position++] = POSITIONINTERDITE;
            }
            for (int index_colonne = 0; index_colonne <= NOMBRE_DE_COLONNES + 1; index_colonne++)
            {
                Cases[position++] = POSITIONINTERDITE;
            }
        }

        public Plateau() : this(6,10)
        {
        }


        public Boolean SolutionTrouvee
        {
            get { return (TotalVariantesDejaAjoutees == FabriqueDePentaminos.NombreDePentaminos) ; }
        }

        private void Pose(Pentamino pentamino, int position, Boolean ajout)
        {
            VariantesDejaAjoutees[pentamino.Variante] = ajout;
            TotalVariantesDejaAjoutees = TotalVariantesDejaAjoutees + (ajout ? 1 : -1);

            foreach (int decalage in pentamino.Decalages)
            {
                Debug.Assert( (Cases[position + decalage] == POSITIONLIBRE) == ajout);
                Cases[position + decalage] = ajout ? pentamino.Representation : POSITIONLIBRE;
            }
        }

        public void Enleve(Pentamino pentamino, int position)
        {
            Pose(pentamino,position,false);
            PositionLibreActuelle = position;
        }

        public Boolean Ajoute(Pentamino pentamino, int position)
        {
            if (VariantesDejaAjoutees[pentamino.Variante] || !VerifierPlaceLibre(pentamino, position))
            {
                return false;
            }
            else
            {
                Pose(pentamino, position, true);
                return true;
            }
        }
            

        public Boolean VerifierPlaceLibre(Pentamino pentamino, int position)
        {
            foreach (int decalage in pentamino.Decalages)
            {
                if (Cases[position + decalage] != POSITIONLIBRE)
                {
                    return false;
                }
            }
            return true;
        }

        public int ProchainePositionLibre()
        {
            while (Cases[PositionLibreActuelle] != POSITIONLIBRE)
            {
                PositionLibreActuelle++;
            }
            return PositionLibreActuelle;
        }
            
    }
}
