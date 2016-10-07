using System;

namespace AminoAcidData
{
    public class AminoAcids
    {
        //! AminoAcids class
        /*!
         * This class gives us the MW for amino acids and amino acids given weights
         * 
         */
        public static double GetMolecularWeight(char aminoAcid)
        {
            /*< function reading the letter code of a specific amino acid and returing back its MW*/
            double mw = -1;	/*< initialize MW variable. */

            if (aminoAcid == 'M') /*< If AA is Methionine return its MW. */
                mw = 131.040485;
            else if (aminoAcid == 'Q')	/*< If AA is Glutamine return its MW. */
                mw = 128.058578;
            else if (aminoAcid == 'A')	/*< If AA is Alanine return its MW. */
                mw = 71.037114;
            else if (aminoAcid == 'R')	/*< If AA is Arginine return its MW. */
                mw = 156.101111;
            else if (aminoAcid == 'N')	/*< If AA is Asparagine return its MW. */
                mw = 114.042927;
            else if (aminoAcid == 'D')	/*< If AA is Aspartic Acid return its MW. */
                mw = 115.026943;
            else if (aminoAcid == 'C')	/*< If AA is Cysteine return its MW. */
                mw = 103.009185;
            else if (aminoAcid == 'E')	/*< If AA is Glutamic acid return its MW. */
                mw = 129.042593;
            else if (aminoAcid == 'G')	/*< If AA is Glycine its MW. */
                mw = 57.021464;
            else if (aminoAcid == 'H')	/*< If AA is Histidine return its MW. */
                mw = 137.058912;
            else if (aminoAcid == 'I')	/*< If AA is Isoleucine return its MW. */
                mw = 113.084064;
            else if (aminoAcid == 'L')	/*< If AA is Leucine return its MW. */
                mw = 113.084064;
            else if (aminoAcid == 'K')	/*< If AA is Lysine its MW. */
                mw = 128.094963;
            else if (aminoAcid == 'F')	/*< If AA is Phenylalanine its MW. */
                mw = 147.068414;
            else if (aminoAcid == 'P')	/*< If AA is Proline return its MW. */
                mw = 97.052764;
            else if (aminoAcid == 'S')	/*< If AA is Serine return its MW. */
                mw = 87.032028;
            else if (aminoAcid == 'T')	/*< If AA is Threonine return its MW. */
                mw = 101.047679;
            else if (aminoAcid == 'W')	/*< If AA is Tryptophan return its MW. */
                mw = 186.079313;
            else if (aminoAcid == 'Y')	/*< If AA is Tyrosine return its MW. */
                mw = 163.06332;
            else if (aminoAcid == 'V')	/*< If AA is Valine return its MW. */
                mw = 99.068414;

            return mw;
        }

        public static char GetAminoAcid(double molecularWeight, double tolerance)
        {
            char AA = '*';	/*< initialize MW variable. */
            if (Math.Abs(molecularWeight - 131.040485) < tolerance) /*< If MW is Methionine return its MW. */
                AA = 'M';
            else if (Math.Abs(molecularWeight - 128.058578) < tolerance)	/*< If MW is Glutamine return its MW. */
                AA = 'Q';
            else if (Math.Abs(molecularWeight - 71.037114) < tolerance)	/*< If MW is Alanine return its MW. */
                AA = 'A';
            else if (Math.Abs(molecularWeight - 156.101111) < tolerance)	/*< If MW is Arginine return its MW. */
                AA = 'R';
            else if (Math.Abs(molecularWeight - 114.042927) < tolerance)	/*< If MW is Asparagine return its MW. */
                AA = 'N';
            else if (Math.Abs(molecularWeight - 115.026943) < tolerance)	/*< If MW is Aspartic Acid return its MW. */
                AA = 'D';
            else if (Math.Abs(molecularWeight - 103.009185) < tolerance)	/*< If MW is Cysteine return its MW. */
                AA = 'C';
            else if (Math.Abs(molecularWeight - 129.042593) < tolerance)	/*< If MW is Glutamic acid return its MW. */
                AA = 'E';
            else if (Math.Abs(molecularWeight - 57.021464) < tolerance)	/*< If MW is Glycine its MW. */
                AA = 'G';
            else if (Math.Abs(molecularWeight - 137.058912) < tolerance)	/*< If MW is Histidine return its MW. */
                AA = 'H';
            else if (Math.Abs(molecularWeight - 113.084064) < tolerance)	/*< If MW is Isoleucine return its MW. */
                AA = 'I';
            else if (Math.Abs(molecularWeight - 113.084064) < tolerance)	/*< If MW is Leucine return its MW. */
                AA = 'L';
            else if (Math.Abs(molecularWeight - 128.094963) < tolerance)	/*< If MW is Lysine its MW. */
                AA = 'K';
            else if (Math.Abs(molecularWeight - 147.068414) < tolerance)	/*< If MW is Phenylalanine its MW. */
                AA = 'F';
            else if (Math.Abs(molecularWeight - 97.052764) < tolerance)	/*< If MW is Proline return its MW. */
                AA = 'P';
            else if (Math.Abs(molecularWeight - 87.032028) < tolerance)	/*< If MW is Serine return its MW. */
                AA = 'S';
            else if (Math.Abs(molecularWeight - 101.047679) < tolerance)	/*< If MW is Threonine return its MW. */
                AA = 'T';
            else if (Math.Abs(molecularWeight - 186.079313) < tolerance)	/*< If MW is Tryptophan return its MW. */
                AA = 'W';
            else if (Math.Abs(molecularWeight - 163.06332) < tolerance)	/*< If MW is Tyrosine return its MW. */
                AA = 'Y';
            else if (Math.Abs(molecularWeight - 99.068414) < tolerance)	/*< If MW is Valine return its MW. */
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