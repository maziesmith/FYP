using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testapi.Engine
{
    public class AminoAcids
    {
        //! AminoAcids class
        /*!
         * This class gives us the MW for amino acids and amino acids given weights
         * 
         */
        public static double getMW(char AA)
        {
            /*< function reading the letter code of a specific amino acid and returing back its MW*/
            double MW = -1;	/*< initialize MW variable. */

            if (AA == 'M') /*< If AA is Methionine return its MW. */
                MW = 131.040485;
            else if (AA == 'Q')	/*< If AA is Glutamine return its MW. */
                MW = 128.058578;
            else if (AA == 'A')	/*< If AA is Alanine return its MW. */
                MW = 71.037114;
            else if (AA == 'R')	/*< If AA is Arginine return its MW. */
                MW = 156.101111;
            else if (AA == 'N')	/*< If AA is Asparagine return its MW. */
                MW = 114.042927;
            else if (AA == 'D')	/*< If AA is Aspartic Acid return its MW. */
                MW = 115.026943;
            else if (AA == 'C')	/*< If AA is Cysteine return its MW. */
                MW = 103.009185;
            else if (AA == 'E')	/*< If AA is Glutamic acid return its MW. */
                MW = 129.042593;
            else if (AA == 'G')	/*< If AA is Glycine its MW. */
                MW = 57.021464;
            else if (AA == 'H')	/*< If AA is Histidine return its MW. */
                MW = 137.058912;
            else if (AA == 'I')	/*< If AA is Isoleucine return its MW. */
                MW = 113.084064;
            else if (AA == 'L')	/*< If AA is Leucine return its MW. */
                MW = 113.084064;
            else if (AA == 'K')	/*< If AA is Lysine its MW. */
                MW = 128.094963;
            else if (AA == 'F')	/*< If AA is Phenylalanine its MW. */
                MW = 147.068414;
            else if (AA == 'P')	/*< If AA is Proline return its MW. */
                MW = 97.052764;
            else if (AA == 'S')	/*< If AA is Serine return its MW. */
                MW = 87.032028;
            else if (AA == 'T')	/*< If AA is Threonine return its MW. */
                MW = 101.047679;
            else if (AA == 'W')	/*< If AA is Tryptophan return its MW. */
                MW = 186.079313;
            else if (AA == 'Y')	/*< If AA is Tyrosine return its MW. */
                MW = 163.06332;
            else if (AA == 'V')	/*< If AA is Valine return its MW. */
                MW = 99.068414;

            return MW;
        }

        public static char getAA(double MW, double tol)
        {
            char AA = '*';	/*< initialize MW variable. */
            if (Math.Abs(MW - 131.040485) < tol) /*< If MW is Methionine return its MW. */
                AA = 'M';
            else if (Math.Abs(MW - 128.058578) < tol)	/*< If MW is Glutamine return its MW. */
                AA = 'Q';
            else if (Math.Abs(MW - 71.037114) < tol)	/*< If MW is Alanine return its MW. */
                AA = 'A';
            else if (Math.Abs(MW - 156.101111) < tol)	/*< If MW is Arginine return its MW. */
                AA = 'R';
            else if (Math.Abs(MW - 114.042927) < tol)	/*< If MW is Asparagine return its MW. */
                AA = 'N';
            else if (Math.Abs(MW - 115.026943) < tol)	/*< If MW is Aspartic Acid return its MW. */
                AA = 'D';
            else if (Math.Abs(MW - 103.009185) < tol)	/*< If MW is Cysteine return its MW. */
                AA = 'C';
            else if (Math.Abs(MW - 129.042593) < tol)	/*< If MW is Glutamic acid return its MW. */
                AA = 'E';
            else if (Math.Abs(MW - 57.021464) < tol)	/*< If MW is Glycine its MW. */
                AA = 'G';
            else if (Math.Abs(MW - 137.058912) < tol)	/*< If MW is Histidine return its MW. */
                AA = 'H';
            else if (Math.Abs(MW - 113.084064) < tol)	/*< If MW is Isoleucine return its MW. */
                AA = 'I';
            else if (Math.Abs(MW - 113.084064) < tol)	/*< If MW is Leucine return its MW. */
                AA = 'L';
            else if (Math.Abs(MW - 128.094963) < tol)	/*< If MW is Lysine its MW. */
                AA = 'K';
            else if (Math.Abs(MW - 147.068414) < tol)	/*< If MW is Phenylalanine its MW. */
                AA = 'F';
            else if (Math.Abs(MW - 97.052764) < tol)	/*< If MW is Proline return its MW. */
                AA = 'P';
            else if (Math.Abs(MW - 87.032028) < tol)	/*< If MW is Serine return its MW. */
                AA = 'S';
            else if (Math.Abs(MW - 101.047679) < tol)	/*< If MW is Threonine return its MW. */
                AA = 'T';
            else if (Math.Abs(MW - 186.079313) < tol)	/*< If MW is Tryptophan return its MW. */
                AA = 'W';
            else if (Math.Abs(MW - 163.06332) < tol)	/*< If MW is Tyrosine return its MW. */
                AA = 'Y';
            else if (Math.Abs(MW - 99.068414) < tol)	/*< If MW is Valine return its MW. */
                AA = 'V';

            //////////////////////////////////////////////////////////////////////////////////////////////



            //else if (Math.Abs(MW - (79.9663 + 163.0633)) < tol)	/*< If MW is Valine return its MW. */
            //    AA = 'Y';
            //else if (Math.Abs(MW - (79.9663 + 101.04768)) < tol)	/*< If MW is Valine return its MW. */
            //    AA = 'T';
            //else if (Math.Abs(MW - (79.9663 + 87.03203)) < tol)	/*< If MW is Valine return its MW. */
            //    AA = 'S';
            //else if (Math.Abs(MW - (14.0157 + 128.09496)) < tol)	/*< If MW is Valine return its MW. */
            //    AA = 'K';
            //else if (Math.Abs(MW - (14.0157 + 156.10111)) < tol)	/*< If MW is Valine return its MW. */
            //    AA = 'R';
            //else if (Math.Abs(MW - (42.0106 + 131.040485)) < tol)	/*< If MW is Valine return its MW. */
            //    AA = 'M';
            //else if (Math.Abs(MW - (42.0106 + 87.03203)) < tol)	/*< If MW is Valine return its MW. */
            //    AA = 'S';
            //else if (Math.Abs(MW - (42.0106 + 128.09496)) < tol)	/*< If MW is Valine return its MW. */
            //    AA = 'K';
            //else if (Math.Abs(MW - (42.0106 + 71.03711)) < tol)	/*< If MW is Valine return its MW. */
            //   AA = 'a';
            //else if (Math.Abs(MW - (-0.9840 + 147.608414)) < tol)	/*< If MW is Valine return its MW. */
            //    AA = 'F';
            //else if (Math.Abs(MW - (15.9949 + 97.05276)) < tol)	/*< If MW is Valine return its MW. */
            //    AA = 'P';
            //else if (Math.Abs(MW - (203.0794 + 101.04768)) < tol)	/*< If MW is Valine return its MW. */
            //    AA = 'T';
            //else if (Math.Abs(MW - (203.0794 + 87.03203)) < tol)	/*< If MW is Valine return its MW. */
            //    AA = 'S';
            //else if (Math.Abs(MW - (317.122 + 114.04293)) < tol)	/*< If MW is Valine return its MW. */
            //   AA = 'N';

            return AA;
        }
    }
}