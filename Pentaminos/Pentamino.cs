using System;
using System.Collections.Generic;
using System.Text;

namespace Pentaminos
{
    public class Pentamino
    {
        public int[] Decalages = new int[5];
        public int Variante;
        public char Representation;

        private int Correction(int decalage6x10, int nombreColonnes)
        {
            int correction = nombreColonnes - 10 + 2;

            int supplement = 0;
            if (decalage6x10 >= 7)
            {
                supplement += correction;
            }
            if (decalage6x10 >= 18)
            {
                supplement += correction;
            }
            if (decalage6x10 >= 28)
            {
                supplement += correction;
            }
            if (decalage6x10 >= 38)
            {
                supplement += correction;
            }
            return decalage6x10 + supplement;
        }


        public Pentamino(char representation, int variante, int decalage1, int decalage2, int decalage3, int decalage4, int nombreColonnes)
        {
            Variante = variante-1;
            Decalages[0] = Correction(decalage1, nombreColonnes) ;
            Decalages[1] = Correction(decalage2, nombreColonnes);
            Decalages[2] = Correction(decalage3, nombreColonnes);
            Decalages[3] = Correction(decalage4, nombreColonnes);
            Decalages[4] = 0;
            Representation = representation;
        }
    }

    public class FabriqueDePentaminos
    {
        private static int[,] DescriptionsInternes = {
           { 1, 1,2,3,4 },   //00  // This array represents everything the program
	   { 1, 10,20,30,40 },   //01  // knows about the individual pentominos.  Each
	   { 2, 9,10,11,20 },    //02  // row in the array represents a particular
	   { 3, 1,10,19,20 },    //03  // pentomino in a particular orientation.  Different
	   { 3, 10,11,12,22 },   //04  // orientations are obtained by rotating or flipping
	   { 3, 1,11,21,22 },    //05  // the pentomino over.  Note that the program must
	   { 3, 8,9,10,18 },     //06  // try each pentomino in each possible orientation,
	   { 4, 10,20,21,22 },   //07  // but must be careful not to reuse a piece if
	   { 4, 1,2,10,20 },     //08  // it has already been used on the board in a
	   { 4, 10,18,19,20 },   //09  // different orientation.
	   { 4, 1,2,12,22 },     //10  //     The pentominoes are numbered from 1 to 12.
	   { 5, 1,2,11,21 },     //11   // The first number on each row here tells which pentomino
	   { 5, 8,9,10,20 },     //12  // that line represents.  Note that there can be
	   { 5, 10,19,20,21 },   //13  // up to 8 different rows for each pentomino.
	   { 5, 10,11,12,20 },   //14  // some pentominos have fewer rows because they are
	   { 6, 10,11,21,22 },   //15  // symmetric.  For example, the pentomino that looks
	   { 6, 9,10,18,19 },    //16  // like:
	   { 6, 1,11,12,22 },    //17  //           GGG
	   { 6, 1,9,10,19 },     //18  //           G G
	   { 7, 1,2,10,12 },     //19  //
	   { 7, 1,11,20,21 },    //20  // can be rotated into three additional positions,
	   { 7, 2,10,11,12 },    //21  // but flipping it over will give nothing new.
	   { 7, 1,10,20,21 },    //22  // So, it has only 4 rows in the array.
	   { 8, 10,11,12,13 },   //23  //     The four remaining entries in the array
	   { 8, 10,20,29,30 },   //24  // describe the given piece in the given orientation,
	   { 8, 1,2,3,13 },      //25  // in a way convenient for placing the piece into
	   { 8, 1,10,20,30 },    //26  // the one-dimensional array that represents the
	   { 8, 1,11,21,31 },    //27  // board.  As an example, consider the row
	   { 8, 1,2,3,10 },      //28  //
	   { 8, 10,20,30,31 },   //29  //           { 7, 1,2,10,19 }
	   { 8, 7,8,9,10 },      //30  //
	   { 9, 1,8,9,10 },      //31  // If this piece is placed on the board so that
	   { 9, 10,11,21,31 },   //32  // its topmost/leftmost square fills position
	   { 9, 1,2,9,10 },      //33  // p in the array, then the other four squares
	   { 9, 10,20,21,31 },   //34  // will be at positions  p+1, p+2, p+10, and p+19.
	   { 9, 1,11,12,13 },    //35  // To see whether the piece can be played at that
	   { 9, 10,19,20,29 },   //36  // position, it suffices to check whether any of
	   { 9, 1,2,12,13 },     //37  // these five squares are filled. 
	   { 9, 9,10,19,29 },    //38  //     On the board, each piece will be shown
	   { 10, 8,9,10,11 },    //39  // in its own color.
	   { 10, 9,10,20,30 },   //40 
	   { 10, 1,2,3,11 },     //41
	   { 10, 10,20,21,30 },  //42
	   { 10, 1,2,3,12 },     //43
	   { 10, 10,11,20,30 },  //44
	   { 10, 9,10,11,12 },   //45 //45
	   { 10, 10,19,20,30 },  //46
	   { 11, 9,10,11,21 },   //47
	   { 11, 1,9,10,20 },    //48 //48
	   { 11, 10,11,12,21 },  //49
	   { 11, 10,11,19,20 },  //50 //
	   { 11, 8,9,10,19},     //51
	   { 11, 1,11,12,21 },   //52
	   { 11, 9,10,11,19 },   //53
	   { 11, 9,10,20,21 },   //54
	   { 12, 1,10,11,21 },   //55
	   { 12, 1,2,10,11 },    //56
	   { 12, 10,11,20,21 },  //57
	   { 12, 1,9,10,11 },    //58 //58
	   { 12, 1,10,11,12 },   //59 //59
	   { 12, 9,10,19,20 },   //60
	   { 12, 1,2,11,12 },    //61
	   { 12, 1,10,11,20 }    //62
        };

        private static char[] Representations = { 'I', 'X', 'Z', 'V', 'T', 'W', 'U', 'L', 'N', 'Y', 'F', 'P' };

        static public int NombreDeVariantes
        {
            get { return DescriptionsInternes.GetUpperBound(0) + 1; }
        }

        public const int NombreDePentaminos = 12 ;

        static public List<Pentamino> ListeDePentaminos(int nombreColonnes)
        {
            List<Pentamino> liste = new List<Pentamino>();
            for (int i = 0; i < NombreDeVariantes; i++)
            {
                liste.Add(new Pentamino(Representations[DescriptionsInternes[i, 0] - 1], DescriptionsInternes[i, 0], DescriptionsInternes[i, 1], DescriptionsInternes[i, 2], DescriptionsInternes[i, 3], DescriptionsInternes[i, 4], nombreColonnes));
            }
            return liste;
        }

    }


}
