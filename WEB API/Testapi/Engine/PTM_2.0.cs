using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testapi.Models;

namespace Testapi.Engine
{
    public class PTM_2
    {

        public static int AASize = 0;

        public static void setAASize(int size)
        {
            AASize = size;
        }

        public static char siteDetect = '\0';

        public static void setsiteDetect(char letter)
        {
            siteDetect = letter;
        }

        public static IEnumerable<int[]> Combinations(int m, int n)     // nCr = nCm
        {
            int[] result = new int[m];
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value < n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == m)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }

        // Function: returns the total number of sites found in the given protein sequence
        public static int getSiteNumber(string protein_sequence)
        {
            int arraySize = 0;
            int i = 0;
            for (i = 0; i < protein_sequence.Length; i++)
            {
                if (protein_sequence[i] == siteDetect)
                    arraySize++;
            }
            return arraySize;
        }

        // Normalization
        public static double normalize(double value, int select)
        {
            double normalized_score = 0;
            double min = 0;
            double max = 0;
            double norm_factor = 0;




            switch (select)
            {
                //Acetylation_A
                case 1:
                    min = 0;
                    max = 0.24 * 0.17 * 0.17 * 0.14 * 0.15 * 0.12;

                    norm_factor = Math.Log10(max);
                    if (value == 0)
                        normalized_score = 0;
                    else
                        normalized_score = norm_factor / Math.Log10(value);
                    break;
                // Acetylation_K
                case 2:
                    min = 0;
                    max = 0.11 * 0.12 * 0.11 * 0.09 * 0.11 * 0.11 * 0.09 * 0.14 * 0.11 * 0.14 * 0.12 * 0.11;

                    norm_factor = Math.Log10(max);
                    if (value == 0)
                        normalized_score = 0;
                    else
                        normalized_score = norm_factor / Math.Log10(value);
                    break;
                // Acetylation_M
                case 3:
                    min = 0;
                    max = 0.39 * 0.14 * 0.09 * 0.10 * 0.12 * 0.10;

                    norm_factor = Math.Log10(max);
                    if (value == 0)
                        normalized_score = 0;
                    else
                        normalized_score = norm_factor / Math.Log10(value);
                    break;
                // Acetylation_S
                case 4:
                    min = 0;
                    max = 0.14 * 0.13 * 0.15 * 0.17 * 0.10 * 0.13;

                    norm_factor = Math.Log10(max);
                    if (value == 0)
                        normalized_score = 0;
                    else
                        normalized_score = norm_factor / Math.Log10(value);
                    break;
                // Amidation_F
                case 5:
                    min = 0;
                    max = 0.11 * 0.16 * 0.19 * 0.32 * 0.29 * 0.72;

                    norm_factor = Math.Log10(max);
                    if (value == 0)
                        normalized_score = 0;
                    else
                        normalized_score = norm_factor / Math.Log10(value);
                    break;
                // Hydroxylation_P
                case 6:
                    min = 0;
                    max = 0.30 * 0.59 * 0.28 * 0.21 * 0.61 * 0.32 * 0.62 * 0.26 * 0.31 * 0.59 * 0.22 * 0.32;

                    norm_factor = Math.Log10(max);
                    if (value == 0)
                        normalized_score = 0;
                    else
                        normalized_score = norm_factor / Math.Log10(value);
                    break;
                // Methylation_K
                case 7:
                    min = 0;
                    max = 0.14 * 0.15 * 0.18 * 0.14 * 0.22 * 0.24 * 0.19 * 0.16 * 0.15 * 0.12 * 0.15 * 0.17;

                    norm_factor = Math.Log10(max);
                    if (value == 0)
                        normalized_score = 0;
                    else
                        normalized_score = norm_factor / Math.Log10(value);
                    break;
                // Methylation_R
                case 8:
                    min = 0;
                    max = 0.25 * 0.26 * 0.19 * 0.29 * 0.23 * 0.32 * 0.56 * 0.31 * 0.23 * 0.22 * 0.29 * 0.21;

                    norm_factor = Math.Log10(max);
                    if (value == 0)
                        normalized_score = 0;
                    else
                        normalized_score = norm_factor / Math.Log10(value);
                    break;
                // N_linked_glycosylation_N
                case 9:
                    min = 0;
                    max = 0.09 * 0.08 * 0.09 * 0.08 * 0.1 * 0.1 * 0.1 * 0.63 * 0.11 * 0.09 * 0.1 * 0.09;

                    norm_factor = Math.Log10(max);
                    if (value == 0)
                        normalized_score = 0;
                    else
                        normalized_score = norm_factor / Math.Log10(value);
                    break;
                // O_linked_glycosylation_T
                case 10:
                    min = 0;
                    max = 0.44 * 0.36 * 0.45 * 0.26 * 0.44 * 0.32 * 0.31 * 0.43 * 0.36 * 0.44 * 0.33 * 0.48;

                    norm_factor = Math.Log10(max);
                    if (value == 0)
                        normalized_score = 0;
                    else
                        normalized_score = norm_factor / Math.Log10(value);
                    break;
                // O_linked_glycosylation_S
                case 11:
                    min = 0;
                    max = 0.21 * 0.17 * 0.16 * 0.16 * 0.21 * 0.31 * 0.20 * 0.30 * 0.26 * 0.31 * 0.14 * 0.29;


                    norm_factor = Math.Log10(max);
                    if (value == 0)
                        normalized_score = 0;
                    else
                        normalized_score = norm_factor / Math.Log10(value);
                    break;
                // Phosphorylation_S
                case 12:
                    min = 0;
                    max = 0.12 * 0.12 * 0.14 * 0.15 * 0.16 * 0.12 * 0.27 * 0.15 * 0.14 * 0.14 * 0.12 * 0.12;

                    norm_factor = Math.Log10(max);
                    if (value == 0)
                        normalized_score = 0;
                    else
                        normalized_score = norm_factor / Math.Log10(value);
                    break;
                // Phosphorylation_T
                case 13:
                    min = 0;
                    max = 0.12 * 0.11 * 0.13 * 0.11 * 0.15 * 0.11 * 0.32 * 0.13 * 0.12 * 0.13 * 0.11 * 0.11;

                    norm_factor = Math.Log10(max);
                    if (value == 0)
                        normalized_score = 0;
                    else
                        normalized_score = norm_factor / Math.Log10(value);
                    break;
                // Phosphorylation_Y
                case 14:
                    min = 0;
                    max = 0.09 * 0.09 * 0.10 * 0.11 * 0.09 * 0.09 * 0.11 * 0.09 * 0.10 * 0.09 * 0.09 * 0.08;

                    norm_factor = Math.Log10(max);
                    if (value == 0)
                        normalized_score = 0;
                    else
                        normalized_score = norm_factor / Math.Log10(value);
                    break;
                // Ubiquitination
                /*case 15:
                    min = 0;
                    max = 0.09 * 0.09 * 0.10 * 0.11 * 0.09 * 0.09 * 0.11 * 0.09 * 0.10 * 0.09 * 0.09 * 0.08;
                    norm_factor = 1 - Math.Exp(max);
                    normalized_score = (1 - Math.Exp(value)) / norm_factor;
                    break;*/
                default:
                    break;
            }

            return normalized_score;
        }

        // Function (Acetylation_A): Returns an object array with all the required parameters stored
        public static List<Sites> Acetylation_A(string protein_sequence, double PTM_tolerance)
        {
            //Sequence of protein
            //protein_sequence = "MAPNASCLCVHVRSEEWDLMTFDANPYDSVKKIKEHVRSKTKVPVQDQVLLLGSKILKPRRSLSSYGIDKEKTIHLTLKVVKPSDEELPLFLVESGDEAKRHLLQVRRSSSVAQVKAMIETKTGIIPETQIVTCNGKRLEDGKMMADYGIRKGNLLFLACYCIGG";

            setAASize(7);

            double mod_weight = 42.0106;
            string mod_name = "Acetylation";
            char site = 'A';

            setsiteDetect(site);

            // variable score is initialized
            double score = 0;

            // Variable to store total number of Alanine
            int TotalAla = 0;

            // stores the amino acids found
            List<char> AA = new List<char>();

            // list "array" creation
            List<Sites> array = new List<Sites>();

            // a higher scope variable declared to show the TotalAla (if statement at the end)
            int index = 0;

            // an indexing variable to iterate the dynamic array "array"
            int objectArrayIndex = 0;

            // for loop run for as many times as there are characters in the protein sequence
            for (int i = 0; i < protein_sequence.Length; i++)
            {
                if ((protein_sequence[i] == 'A') && (i < protein_sequence.Length) && (i + 1 < protein_sequence.Length) && (i + 2 < protein_sequence.Length) && (i + 3 < protein_sequence.Length) && (i + 4 < protein_sequence.Length) && (i + 5 < protein_sequence.Length) && (i + 6 < protein_sequence.Length))
                {
                    TotalAla = TotalAla + 1;

                    //variables to store sub - sequence
                    char g, h, m, j, k, l;

                    //It saves the score for i + 1 position
                    if (protein_sequence.Length >= i + 1)
                    {
                        l = (protein_sequence[i + 1]);

                        switch (protein_sequence[i + 1])
                        {
                            case 'R':
                            case 'H':
                            case 'M':
                            case 'Y':
                                score = 0.01;
                                break;
                            case 'N':
                            case 'C':
                            case 'K':
                            case 'F':
                                score = 0.02;
                                break;
                            case 'L':
                            case 'V':
                                score = 0.03;
                                break;
                            case 'Q':
                                score = 0.04;
                                break;
                            case 'G':
                                score = 0.06;
                                break;
                            case 'T':
                                score = 0.09;
                                break;
                            case 'A':
                                score = 0.24;
                                break;
                            case 'D':
                                score = 0.11;
                                break;
                            case 'E':
                            case 'S':
                                score = 0.14;
                                break;
                            case 'W':
                            case 'I':
                            case 'P':
                                score = 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 2 position
                    if (protein_sequence.Length >= i + 2)
                    {
                        k = protein_sequence[i + 2];
                        switch (protein_sequence[i + 2])
                        {
                            case 'Y':
                            case 'M':
                            case 'H':
                            case 'C':
                                score = score * 0.01;
                                break;
                            case 'I':
                                score = score * 0.02;
                                break;
                            case 'R':
                            case 'K':
                                score = score * 0.03;
                                break;
                            case 'D':
                            case 'N':
                            case 'F':
                                score = score * 0.04;
                                break;
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'E':
                                score = score * 0.06;
                                break;
                            case 'G':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'Q':
                            case 'L':
                            case 'P':
                                score = score * 0.08;
                                break;
                            case 'S':
                                score = score * 0.09;
                                break;
                            case 'A':
                                score = score * 0.17;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 3 position
                    if (protein_sequence.Length >= i + 3)
                    {
                        j = protein_sequence[i + 3];
                        switch (protein_sequence[i + 3])
                        {
                            case 'C':
                            case 'W':
                            case 'M':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'R':
                            case 'F':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'N':
                            case 'Q':
                            case 'I':
                            case 'K':
                                score = score * 0.03;
                                break;
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'D':
                                score = score * 0.06;
                                break;
                            case 'E':
                            case 'V':
                            case 'L':
                                score = score * 0.09;
                                break;
                            case 'G':
                            case 'S':
                                score = score * 0.1;
                                break;
                            case 'A':
                                score = score * 0.17;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 4 position
                    if (protein_sequence.Length >= i + 4)
                    {
                        m = protein_sequence[i + 4];
                        switch (protein_sequence[i + 4])
                        {
                            case 'H':
                            case 'M':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'N':
                            case 'K':
                            case 'F':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'R':
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'D':
                            case 'L':
                                score = score * 0.07;
                                break;
                            case 'P':
                            case 'S':
                            case 'V':
                                score = score * 0.08;
                                break;
                            case 'G':
                            case 'T':
                                score = score * 0.09;
                                break;
                            case 'E':
                                score = score * 0.1;
                                break;
                            case 'A':
                                score = score * 0.14;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 5 position
                    if (protein_sequence.Length >= i + 5)
                    {
                        h = protein_sequence[i + 5];
                        switch (protein_sequence[i + 5])
                        {
                            case 'C':
                            case 'W':
                            case 'H':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'I':
                            case 'F':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'N':
                                score = score * 0.03;
                                break;
                            case 'R':
                            case 'T':
                                score = score * 0.04;
                                break;
                            case 'K':
                            case 'P':
                                score = score * 0.05;
                                break;
                            case 'D':
                            case 'Q':
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'G':
                                score = score * 0.08;
                                break;
                            case 'E':
                            case 'S':
                                score = score * 0.09;
                                break;
                            case 'A':
                                score = score * 0.15;
                                break;
                            case 'L':
                                score = score * 0.1;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 6 position
                    if (protein_sequence.Length >= i + 6)
                    {
                        g = protein_sequence[i + 6];
                        switch (protein_sequence[i + 6])
                        {
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'C':
                            case 'F':
                            case 'Y':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'R':
                            case 'N':
                            case 'Q':
                            case 'I':
                                score = score * 0.04;
                                break;
                            case 'T':
                            case 'K':
                                score = score * 0.05;
                                break;
                            case 'D':
                                score = score * 0.06;
                                break;
                            case 'G':
                                score = score * 0.07;
                                break;
                            case 'P':
                            case 'V':
                            case 'E':
                            case 'L':
                                score = score * 0.08;
                                break;
                            case 'S':
                                score = score * 0.1;
                                break;
                            case 'A':
                                score = score * 0.12;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    // score scaling according to higest score
                    score = normalize(score, 1);

                    if (score >= PTM_tolerance)
                    {
                        l = protein_sequence[i + 1];
                        k = protein_sequence[i + 2];
                        j = protein_sequence[i + 3];
                        m = protein_sequence[i + 4];
                        h = protein_sequence[i + 5];
                        g = protein_sequence[i + 6];

                        //% it stores the protein sub-sequence
                        AA.Add(protein_sequence[i]);
                        AA.Add(l);
                        AA.Add(k);
                        AA.Add(j);
                        AA.Add(m);
                        AA.Add(h);
                        AA.Add(g);

                        // Storing the data in the list "array"
                        array.Add(new Sites(i, score, mod_weight, mod_name, site, AA));

                        objectArrayIndex++;

                        // score of Alanine at that position
                    }
                }

                // for the TotalAla if condition coming up ahead
                index = i;
            }

            // it displays total number of Alanine found in sequence
            if (index == protein_sequence.Length)
            {
                Console.WriteLine("Total Alanine found: " + TotalAla);
            }
            //disp(['Total Alanine found: ', num2str(TotalAla)])

            // returning the object array
            return array;
        }

        // Function (Acetylation_K): Returns an object array with all the required parameters stored
        public static List<Sites> Acetylation_K(string protein_sequence, double PTM_tolerance)
        {
            //Sequence of protein
            //protein_sequence = "MAPNASCLCVHVRSEEWDLMTFDANPYDSVKKIKEHVRSKTKVPVQDQVLLLGSKILKPRRSLSSYGIDKEKTIHLTLKVVKPSDEELPLFLVESGDEAKRHLLQVRRSSSVAQVKAMIETKTGIIPETQIVTCNGKRLEDGKMMADYGIRKGNLLFLACYCIGG";

            setAASize(13);

            double mod_weight = 42.0106;
            string mod_name = "Acetylation";
            char site = 'K';

            setsiteDetect(site);

            // variable score is initialized
            double score = 0;

            // Variable to store total number of Lysine
            int TotalLys = 0;

            // stores the amino acids found
            List<char> AA = new List<char>();

            // list "array" creation
            List<Sites> array = new List<Sites>();

            // a higher scope variable declared to show the TotalLys (if statement at the end)
            int index = 0;

            // an indexing variable to iterate the dynamic array "array"
            int objectArrayIndex = 0;

            // for loop run for as many times as there are characters in the protein sequence
            for (int i = 0; i < protein_sequence.Length; i++)
            {
                if ((protein_sequence[i] == 'K') && (i < protein_sequence.Length) && (i + 1 < protein_sequence.Length) && (i + 2 < protein_sequence.Length) && (i + 3 < protein_sequence.Length) && (i + 4 < protein_sequence.Length) && (i + 5 < protein_sequence.Length) && (i + 6 < protein_sequence.Length))
                {
                    TotalLys = TotalLys + 1;

                    //variables to store sub - sequence
                    char a, b, c, d, e, f, g, h, m, j, k, l;

                    //It saves the score for i + 1 position
                    if (protein_sequence.Length >= i + 1)
                    {
                        l = (protein_sequence[i + 1]);

                        switch (protein_sequence[i + 1])
                        {
                            case 'W':
                                score = 0.01;
                                break;
                            case 'M':
                                score = 0.02;
                                break;
                            case 'Q':
                                score = 0.03;
                                break;
                            case 'N':
                            case 'H':
                            case 'I':
                            case 'T':
                                score = 0.04;
                                break;
                            case 'V':
                            case 'S':
                            case 'F':
                            case 'R':
                                score = 0.05;
                                break;
                            case 'G':
                            case 'D':
                            case 'P':
                                score = 0.06;
                                break;
                            case 'K':
                                score = 0.07;
                                break;
                            case 'A':
                            case 'E':
                            case 'Y':
                                score = 0.08;
                                break;
                            case 'L':
                                score = 0.09;
                                break;
                            case 'C':
                                score = 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 2 position
                    if (protein_sequence.Length >= i + 2)
                    {
                        k = protein_sequence[i + 2];
                        switch (protein_sequence[i + 2])
                        {
                            case 'W':
                            case 'C':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Q':
                            case 'N':
                                score = score * 0.03;
                                break;
                            case 'D':
                            case 'Y':
                            case 'T':
                                score = score * 0.04;
                                break;
                            case 'P':
                            case 'F':
                            case 'R':
                                score = score * 0.05;
                                break;
                            case 'G':
                            case 'S':
                                score = score * 0.06;
                                break;
                            case 'K':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'A':
                            case 'I':
                                score = score * 0.08;
                                break;
                            case 'E':
                                score = score * 0.09;
                                break;
                            case 'L':
                                score = score * 0.12;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 3 position
                    if (protein_sequence.Length >= i + 3)
                    {
                        j = protein_sequence[i + 3];
                        switch (protein_sequence[i + 3])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'N':
                            case 'Q':
                            case 'I':
                            case 'F':
                                score = score * 0.04;
                                break;
                            case 'V':
                            case 'P':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'D':
                            case 'S':
                                score = score * 0.06;
                                break;
                            case 'A':
                            case 'G':
                            case 'L':
                                score = score * 0.07;
                                break;
                            case 'R':
                            case 'E':
                                score = score * 0.08;
                                break;
                            case 'K':
                                score = score * 0.11;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 4 position
                    if (protein_sequence.Length >= i + 4)
                    {
                        m = protein_sequence[i + 4];
                        switch (protein_sequence[i + 4])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Y':
                            case 'N':
                                score = score * 0.03;
                                break;
                            case 'P':
                            case 'Q':
                            case 'F':
                                score = score * 0.04;
                                break;
                            case 'V':
                            case 'D':
                            case 'I':
                                score = score * 0.05;
                                break;
                            case 'T':
                            case 'S':
                                score = score * 0.06;
                                break;
                            case 'A':
                            case 'G':
                            case 'R':
                                score = score * 0.07;
                                break;
                            case 'L':
                            case 'E':
                                score = score * 0.08;
                                break;
                            case 'K':
                                score = score * 0.14;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 5 position
                    if (protein_sequence.Length >= i + 5)
                    {
                        h = protein_sequence[i + 5];
                        switch (protein_sequence[i + 5])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'P':
                            case 'Q':
                            case 'F':
                            case 'N':
                            case 'I':
                                score = score * 0.04;
                                break;
                            case 'D':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'R':
                            case 'S':
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'G':
                            case 'E':
                                score = score * 0.07;
                                break;
                            case 'A':
                                score = score * 0.08;
                                break;
                            case 'L':
                                score = score * 0.09;
                                break;
                            case 'K':
                                score = score * 0.14;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 6 position
                    if (protein_sequence.Length >= i + 6)
                    {
                        g = protein_sequence[i + 6];
                        switch (protein_sequence[i + 6])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Y':
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'P':
                            case 'Q':
                            case 'N':
                                score = score * 0.04;
                                break;
                            case 'D':
                            case 'T':
                            case 'I':
                                score = score * 0.05;
                                break;
                            case 'S':
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'G':
                            case 'E':
                            case 'R':
                                score = score * 0.07;
                                break;
                            case 'A':
                                score = score * 0.08;
                                break;
                            case 'L':
                                score = score * 0.09;
                                break;
                            case 'K':
                                score = score * 0.11;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 1
                    if (i - 1 > 0)
                    {
                        f = protein_sequence[i - 1];
                        switch (protein_sequence[i - 1])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Y':
                            case 'P':
                            case 'R':
                                score = score * 0.03;
                                break;
                            case 'F':
                            case 'N':
                                score = score * 0.04;
                                break;
                            case 'Q':
                            case 'D':
                            case 'T':
                            case 'K':
                            case 'I':
                                score = score * 0.05;
                                break;
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'S':
                                score = score * 0.07;
                                break;
                            case 'A':
                                score = score * 0.08;
                                break;
                            case 'L':
                                score = score * 0.09;
                                break;
                            case 'G':
                            case 'E':
                                score = score * 0.11;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 2
                    if (i - 2 > 0)
                    {
                        e = protein_sequence[i - 2];
                        switch (protein_sequence[i - 2])
                        {
                            case 'C':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                            case 'R':
                            case 'W':
                                score = score * 0.02;
                                break;
                            case 'Q':
                                score = score * 0.03;
                                break;
                            case 'P':
                            case 'T':
                            case 'N':
                                score = score * 0.04;
                                break;
                            case 'D':
                            case 'Y':
                                score = score * 0.05;
                                break;
                            case 'E':
                            case 'I':
                            case 'K':
                            case 'S':
                                score = score * 0.06;
                                break;
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'G':
                            case 'F':
                                score = score * 0.08;
                                break;
                            case 'A':
                                score = score * 0.09;
                                break;
                            case 'L':
                                score = score * 0.11;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 3
                    if (i - 3 > 0)
                    {
                        d = protein_sequence[i - 3];
                        switch (protein_sequence[i - 3])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'Y':
                            case 'H':
                                score = score * 0.03;
                                break;
                            case 'R':
                            case 'F':
                            case 'N':
                                score = score * 0.04;
                                break;
                            case 'D':
                            case 'Q':
                            case 'I':
                            case 'P':
                                score = score * 0.05;
                                break;
                            case 'T':
                            case 'S':
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'G':
                            case 'K':
                                score = score * 0.07;
                                break;
                            case 'A':
                            case 'E':
                            case 'L':
                                score = score * 0.09;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 4
                    if (i - 4 > 0)
                    {
                        c = protein_sequence[i - 4];
                        switch (protein_sequence[i - 4])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'Y':
                            case 'H':
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'N':
                            case 'I':
                                score = score * 0.04;
                                break;
                            case 'D':
                            case 'R':
                            case 'Q':
                                score = score * 0.05;
                                break;
                            case 'P':
                            case 'T':
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'G':
                            case 'A':
                            case 'L':
                                score = score * 0.07;
                                break;
                            case 'S':
                                score = score * 0.08;
                                break;
                            case 'E':
                                score = score * 0.09;
                                break;
                            case 'K':
                                score = score * 0.11;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 5
                    if (i - 5 > 0)
                    {
                        b = protein_sequence[i - 5];
                        switch (protein_sequence[i - 5])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Y':
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'N':
                            case 'D':
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'I':
                            case 'T':
                            case 'P':
                                score = score * 0.05;
                                break;
                            case 'G':
                            case 'E':
                                score = score * 0.06;
                                break;
                            case 'R':
                            case 'S':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'A':
                                score = score * 0.08;
                                break;
                            case 'L':
                                score = score * 0.09;
                                break;
                            case 'K':
                                score = score * 0.12;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 6
                    if (i - 6 > 0)
                    {
                        a = protein_sequence[i - 6];
                        switch (protein_sequence[i - 6])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'N':
                            case 'I':
                            case 'F':
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'D':
                            case 'T':
                            case 'P':
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'G':
                                score = score * 0.06;
                                break;
                            case 'R':
                            case 'S':
                            case 'E':
                                score = score * 0.07;
                                break;
                            case 'A':
                            case 'L':
                                score = score * 0.09;
                                break;
                            case 'K':
                                score = score * 0.11;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    // score scaling according to higest score
                    score = normalize(score, 2);

                    if ((score >= PTM_tolerance) && (i - 6 >= 0) && (i - 5 >= 0) && (i - 4 >= 0) && (i - 3 >= 0) && (i - 2 >= 0) && (i - 1 >= 0))
                    {
                        l = protein_sequence[i + 1];
                        k = protein_sequence[i + 2];
                        j = protein_sequence[i + 3];
                        m = protein_sequence[i + 4];
                        h = protein_sequence[i + 5];
                        g = protein_sequence[i + 6];
                        a = protein_sequence[i - 6];
                        b = protein_sequence[i - 5];
                        c = protein_sequence[i - 4];
                        d = protein_sequence[i - 3];
                        e = protein_sequence[i - 2];
                        f = protein_sequence[i - 1];

                        //% it stores the protein sub-sequence
                        AA.Add(a);
                        AA.Add(b);
                        AA.Add(c);
                        AA.Add(d);
                        AA.Add(e);
                        AA.Add(f);
                        AA.Add(protein_sequence[i]);
                        AA.Add(l);
                        AA.Add(k);
                        AA.Add(j);
                        AA.Add(m);
                        AA.Add(h);
                        AA.Add(g);

                        // Storing the data in the list "array"
                        array.Add(new Sites(i, score, mod_weight, mod_name, site, AA));

                        objectArrayIndex++;

                        // score of Lysine at that position
                    }
                }

                // for the TotalLys if condition coming up ahead
                index = i;
            }

            // it displays total number of Lysine found in sequence
            if (index == protein_sequence.Length)
            {
                Console.WriteLine("Total Lysine found: " + TotalLys);
            }
            //disp(['Total Lysine found: ', num2str(TotalLys)])

            // returning the object array
            return array;
        }

        // Function (Acetylation_M): Returns an object array with all the required parameters stored
        public static List<Sites> Acetylation_M(string protein_sequence, double PTM_tolerance)
        {
            //Sequence of protein
            //protein_sequence = "MAPNASCLCVHVRSEEWDLMTFDANPYDSVKKIKEHVRSKTKVPVQDQVLLLGSKILKPRRSLSSYGIDKEKTIHLTLKVVKPSDEELPLFLVESGDEAKRHLLQVRRSSSVAQVKAMIETKTGIIPETQIVTCNGKRLEDGKMMADYGIRKGNLLFLACYCIGG";

            setAASize(7);

            double mod_weight = 42.0106;
            string mod_name = "Acetylation";
            char site = 'M';

            setsiteDetect(site);

            // variable score is initialized
            double score = 0;

            // Variable to store total number of Methionine
            int TotalMet = 0;

            // stores the amino acids found
            List<char> AA = new List<char>();

            // list "array" creation
            List<Sites> array = new List<Sites>();

            // a higher scope variable declared to show the TotalMet (if statement at the end)
            int index = 0;

            // an indexing variable to iterate the dynamic array "array"
            int objectArrayIndex = 0;

            // for loop run for as many times as there are characters in the protein sequence
            for (int i = 0; i < protein_sequence.Length; i++)
            {
                if ((protein_sequence[i] == 'M') && (i < protein_sequence.Length) && (i + 1 < protein_sequence.Length) && (i + 2 < protein_sequence.Length) && (i + 3 < protein_sequence.Length) && (i + 4 < protein_sequence.Length) && (i + 5 < protein_sequence.Length) && (i + 6 < protein_sequence.Length))
                {
                    TotalMet = TotalMet + 1;

                    //variables to store sub - sequence
                    char g, h, m, j, k, l;

                    //It saves the score for i + 1 position
                    if (protein_sequence.Length >= i + 1)
                    {
                        l = protein_sequence[i + 1];
                        switch (protein_sequence[i + 1])
                        {
                            case 'A':
                            case 'I':
                            case 'K':
                            case 'S':
                            case 'T':
                                score = 0.01;
                                break;
                            case 'R':
                            case 'C':
                            case 'G':
                            case 'H':
                            case 'P':
                            case 'W':
                            case 'Y':
                                score = 0;
                                break;
                            case 'N':
                                score = 0.09;
                                break;
                            case 'D':
                                score = 0.28;
                                break;
                            case 'E':
                                score = 0.39;
                                break;
                            case 'Q':
                            case 'V':
                                score = 0.03;
                                break;
                            case 'M':
                            case 'F':
                                score = 0.04;
                                break;
                            case 'L':
                                score = 0.12;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 2 position
                    if (protein_sequence.Length >= i + 2)
                    {
                        k = protein_sequence[i + 2];
                        switch (protein_sequence[i + 2])
                        {
                            case 'A':
                                score = score * 0.1;
                                break;
                            case 'R':
                            case 'I':
                                score = score * 0.02;
                                break;
                            case 'N':
                                score = score * 0.04;
                                break;
                            case 'D':
                                score = score * 0.06;
                                break;
                            case 'C':
                            case 'H':
                            case 'M':
                            case 'F':
                            case 'W':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'G':
                                score = score * 0.09;
                                break;
                            case 'E':
                            case 'L':
                                score = score * 0.08;
                                break;
                            case 'Q':
                            case 'T':
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'K':
                                score = score * 0.03;
                                break;
                            case 'P':
                                score = score * 0.14;
                                break;
                            case 'S':
                                score = score * 0.11;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 3 position
                    if (protein_sequence.Length >= i + 3)
                    {
                        j = protein_sequence[i + 3];
                        switch (protein_sequence[i + 3])
                        {
                            case 'A':
                            case 'E':
                            case 'Q':
                                score = score * 0.09;
                                break;
                            case 'N':
                            case 'G':
                            case 'S':
                                score = score * 0.08;
                                break;
                            case 'R':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'D':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'H':
                                score = score * 0.01;
                                break;
                            case 'I':
                            case 'K':
                                score = score * 0.04;
                                break;
                            case 'L':
                            case 'T':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'M':
                            case 'W':
                                score = score * 0;
                                break;
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'P':
                                score = score * 0.06;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 4 position
                    if (protein_sequence.Length >= i + 4)
                    {
                        m = protein_sequence[i + 4];
                        switch (protein_sequence[i + 4])
                        {
                            case 'A':
                            case 'E':
                            case 'Q':
                                score = score * 0.1;
                                break;
                            case 'R':
                            case 'H':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'N':
                                score = score * 0.03;
                                break;
                            case 'D':
                            case 'K':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'I':
                                score = score * 0.06;
                                break;
                            case 'L':
                            case 'P':
                            case 'S':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'M':
                            case 'F':
                                score = score * 0.01;
                                break;
                            case 'T':
                                score = score * 0.04;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            case 'G':
                                score = score * 0.08;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 5 position
                    if (protein_sequence.Length >= i + 5)
                    {
                        h = protein_sequence[i + 5];
                        switch (protein_sequence[i + 5])
                        {
                            case 'A':
                            case 'Q':
                                score = score * 0.07;
                                break;
                            case 'R':
                            case 'C':
                            case 'M':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'N':
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'D':
                            case 'T':
                            case 'K':
                                score = score * 0.05;
                                break;
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'G':
                            case 'P':
                                score = score * 0.08;
                                break;
                            case 'E':
                            case 'S':
                                score = score * 0.11;
                                break;
                            case 'H':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'L':
                                score = score * 0.12;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 6 position
                    if (protein_sequence.Length >= i + 6)
                    {
                        g = protein_sequence[i + 6];
                        switch (protein_sequence[i + 6])
                        {
                            case 'A':
                                score = score * 0.09;
                                break;
                            case 'R':
                            case 'Q':
                            case 'T':
                                score = score * 0.04;
                                break;
                            case 'N':
                                score = score * 0.02;
                                break;
                            case 'D':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'K':
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'G':
                                score = score * 0.08;
                                break;
                            case 'I':
                            case 'H':
                            case 'F':
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'L':
                            case 'S':
                                score = score * 0.1;
                                break;
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'P':
                            case 'E':
                                score = score * 0.07;
                                break;
                            default: //W=0
                                score = 0;
                                break;
                        }
                    }

                    // score scaling according to higest score
                    score = normalize(score, 3);

                    if (score >= PTM_tolerance)
                    {
                        l = protein_sequence[i + 1];
                        k = protein_sequence[i + 2];
                        j = protein_sequence[i + 3];
                        m = protein_sequence[i + 4];
                        h = protein_sequence[i + 5];
                        g = protein_sequence[i + 6];

                        //% it stores the protein sub-sequence
                        AA.Add(protein_sequence[i]);
                        AA.Add(l);
                        AA.Add(k);
                        AA.Add(j);
                        AA.Add(m);
                        AA.Add(h);
                        AA.Add(g);

                        // Storing the data in the list "array"
                        array.Add(new Sites(i, score, mod_weight, mod_name, site, AA));

                        objectArrayIndex++;

                        // score of Methionine at that position
                    }
                }

                // for the TotalMet if condition coming up ahead
                index = i;
            }

            // it displays total number of Methionine found in sequence
            if (index == protein_sequence.Length)
            {
                Console.WriteLine("Total Methionine found: " + TotalMet);
            }
            //disp(['Total Methionine found: ', num2str(TotalMet)])

            // returning the object array
            return array;
        }

        // Function (Acetylation_S): Returns an object array with all the required parameters stored
        public static List<Sites> Acetylation_S(string protein_sequence, double PTM_tolerance)
        {
            //Sequence of protein
            //protein_sequence = "MAPNASCLCVHVRSEEWDLMTFDANPYDSVKKIKEHVRSKTKVPVQDQVLLLGSKILKPRRSLSSYGIDKEKTIHLTLKVVKPSDEELPLFLVESGDEAKRHLLQVRRSSSVAQVKAMIETKTGIIPETQIVTCNGKRLEDGKMMADYGIRKGNLLFLACYCIGG";

            setAASize(7);

            double mod_weight = 42.0106;
            string mod_name = "Acetylation";
            char site = 'S';

            setsiteDetect(site);

            // variable score is initialized
            double score = 0;

            // Variable to store total number of Serine
            int TotalSer = 0;

            // stores the amino acids found
            List<char> AA = new List<char>();

            // list "array" creation
            List<Sites> array = new List<Sites>();

            // a higher scope variable declared to show the TotalSer (if statement at the end)
            int index = 0;

            // an indexing variable to iterate the dynamic array "array"
            int objectArrayIndex = 0;

            // for loop run for as many times as there are characters in the protein sequence
            for (int i = 0; i < protein_sequence.Length; i++)
            {
                if ((protein_sequence[i] == 'S') && (i < protein_sequence.Length) && (i + 1 < protein_sequence.Length) && (i + 2 < protein_sequence.Length) && (i + 3 < protein_sequence.Length) && (i + 4 < protein_sequence.Length) && (i + 5 < protein_sequence.Length) && (i + 6 < protein_sequence.Length))
                {
                    TotalSer = TotalSer + 1;

                    //variables to store sub - sequence
                    char g, h, m, j, k, l;

                    //It saves the score for i + 1 position
                    if (protein_sequence.Length >= i + 1)
                    {
                        l = protein_sequence[i + 1];
                        switch (protein_sequence[i + 1])
                        {
                            case 'A':
                            case 'I':
                            case 'K':
                            case 'S':
                            case 'T':
                                score = 0.01;
                                break;
                            case 'R':
                            case 'C':
                            case 'G':
                            case 'H':
                            case 'P':
                            case 'W':
                            case 'Y':
                                score = 0;
                                break;
                            case 'N':
                                score = 0.09;
                                break;
                            case 'D':
                                score = 0.28;
                                break;
                            case 'E':
                                score = 0.39;
                                break;
                            case 'Q':
                            case 'V':
                                score = 0.03;
                                break;
                            case 'M':
                            case 'F':
                                score = 0.04;
                                break;
                            case 'L':
                                score = 0.12;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 2 position
                    if (protein_sequence.Length >= i + 2)
                    {
                        k = protein_sequence[i + 2];
                        switch (protein_sequence[i + 2])
                        {
                            case 'A':
                                score = score * 0.1;
                                break;
                            case 'R':
                            case 'I':
                                score = score * 0.02;
                                break;
                            case 'N':
                                score = score * 0.04;
                                break;
                            case 'D':
                                score = score * 0.06;
                                break;
                            case 'C':
                            case 'H':
                            case 'M':
                            case 'F':
                            case 'W':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'G':
                                score = score * 0.09;
                                break;
                            case 'E':
                            case 'L':
                                score = score * 0.08;
                                break;
                            case 'Q':
                            case 'T':
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'K':
                                score = score * 0.03;
                                break;
                            case 'P':
                                score = score * 0.14;
                                break;
                            case 'S':
                                score = score * 0.11;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 3 position
                    if (protein_sequence.Length >= i + 3)
                    {
                        j = protein_sequence[i + 3];
                        switch (protein_sequence[i + 3])
                        {
                            case 'A':
                            case 'E':
                            case 'Q':
                                score = score * 0.09;
                                break;
                            case 'N':
                            case 'G':
                            case 'S':
                                score = score * 0.08;
                                break;
                            case 'R':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'D':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'H':
                                score = score * 0.01;
                                break;
                            case 'I':
                            case 'K':
                                score = score * 0.04;
                                break;
                            case 'L':
                            case 'T':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'M':
                            case 'W':
                                score = score * 0;
                                break;
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'P':
                                score = score * 0.06;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 4 position
                    if (protein_sequence.Length >= i + 4)
                    {
                        m = protein_sequence[i + 4];
                        switch (protein_sequence[i + 4])
                        {
                            case 'A':
                            case 'E':
                            case 'Q':
                                score = score * 0.1;
                                break;
                            case 'R':
                            case 'H':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'N':
                                score = score * 0.03;
                                break;
                            case 'D':
                            case 'K':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'I':
                                score = score * 0.06;
                                break;
                            case 'L':
                            case 'P':
                            case 'S':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'M':
                            case 'F':
                                score = score * 0.01;
                                break;
                            case 'T':
                                score = score * 0.04;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            case 'G':
                                score = score * 0.8;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 5 position
                    if (protein_sequence.Length >= i + 5)
                    {
                        h = protein_sequence[i + 5];
                        switch (protein_sequence[i + 5])
                        {
                            case 'C':
                            case 'W':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'H':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'R':
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'N':
                            case 'I':
                            case 'K':
                            case 'P':
                                score = score * 0.04;
                                break;
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'S':
                                score = score * 0.06;
                                break;
                            case 'Q':
                                score = score * 0.07;
                                break;
                            case 'A':
                            case 'G':
                            case 'E':
                                score = score * 0.08;
                                break;
                            case 'D':
                            case 'L':
                            case 'V':
                                score = score * 0.1;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 6 position
                    if (protein_sequence.Length >= i + 6)
                    {
                        g = protein_sequence[i + 6];
                        switch (protein_sequence[i + 6])
                        {
                            case 'M':
                            case 'C':
                            case 'H':
                                score = score * 0.01;
                                break;
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'N':
                            case 'Q':
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'D':
                            case 'R':
                                score = score * 0.04;
                                break;
                            case 'I':
                            case 'L':
                            case 'T':
                            case 'P':
                                score = score * 0.05;
                                break;
                            case 'E':
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'S':
                                score = score * 0.09;
                                break;
                            case 'G':
                                score = score * 0.12;
                                break;
                            case 'A':
                            case 'K':
                                score = score * 0.13;
                                break;
                            default:     //% W = 0
                                score = 0;
                                break;
                        }
                    }

                    // score scaling according to higest score
                    score = normalize(score, 4);

                    if (score >= PTM_tolerance)
                    {
                        l = protein_sequence[i + 1];
                        k = protein_sequence[i + 2];
                        j = protein_sequence[i + 3];
                        m = protein_sequence[i + 4];
                        h = protein_sequence[i + 5];
                        g = protein_sequence[i + 6];

                        //% it stores the protein sub-sequence
                        AA.Add(protein_sequence[i]);
                        AA.Add(l);
                        AA.Add(k);
                        AA.Add(j);
                        AA.Add(m);
                        AA.Add(h);
                        AA.Add(g);

                        // Storing the data in the list "array"
                        array.Add(new Sites(i, score, mod_weight, mod_name, site, AA));

                        objectArrayIndex++;

                        // score of Serine at that position
                    }
                }

                // for the TotalSer if condition coming up ahead
                index = i;
            }

            // it displays total number of Serine found in sequence
            if (index == protein_sequence.Length)
            {
                Console.WriteLine("Total Serine found: " + TotalSer);
            }
            //disp(['Total Methionine found: ', num2str(TotalMet)])

            // returning the object array
            return array;
        }

        // Function (Amidation_F): Returns an object array with all the required parameters stored
        public static List<Sites> Amidation_F(string protein_sequence, double PTM_tolerance)
        {
            //Sequence of protein
            //protein_sequence = "MAPNASCLCVHVRSEEWDLMTFDANPYDSVKKIKEHVRSKTKVPVQDQVLLLGSKILKPRRSLSSYGIDKEKTIHLTLKVVKPSDEELPLFLVESGDEAKRHLLQVRRSSSVAQVKAMIETKTGIIPETQIVTCNGKRLEDGKMMADYGIRKGNLLFLACYCIGG";

            setAASize(7);

            double mod_weight = -0.984016;
            string mod_name = "Amidation";
            char site = 'F';

            setsiteDetect(site);

            // variable score is initialized
            double score = 0;

            // Variable to store total number of Phenylalanine
            int TotalPhe = 0;

            // stores the amino acids found
            List<char> AA = new List<char>();

            // list "array" creation
            List<Sites> array = new List<Sites>();

            // a higher scope variable declared to show the TotalSer (if statement at the end)
            int index = 0;

            // an indexing variable to iterate the dynamic array "array"
            int objectArrayIndex = 0;

            // for loop run for as many times as there are characters in the protein sequence
            for (int i = 0; i < protein_sequence.Length; i++)
            {
                if ((protein_sequence[i] == 'F') && (i < protein_sequence.Length) && (i + 1 < protein_sequence.Length) && (i + 2 < protein_sequence.Length) && (i + 3 < protein_sequence.Length) && (i + 4 < protein_sequence.Length) && (i + 5 < protein_sequence.Length) && (i + 6 < protein_sequence.Length))
                {
                    TotalPhe = TotalPhe + 1;

                    //variables to store sub - sequence
                    char a, b, c, d, e, f;

                    //% it will score amino acid at position i - 1
                    if (i - 1 > 0)
                    {
                        f = protein_sequence[i - 1];
                        switch (protein_sequence[i - 1])
                        {
                            case 'A':
                            case 'I':
                            case 'L':
                            case 'K':
                            case 'S':
                            case 'T':
                            case 'V':
                                score = 0.01;
                                break;
                            case 'G':
                                score = 0.02;
                                break;
                            case 'H':
                                score = 0.03;
                                break;
                            case 'D':
                                score = 0.15;
                                break;
                            case 'R':
                                score = 0.72;
                                break;
                            case 'N':
                            case 'C':
                            case 'E':
                            case 'Q':
                            case 'M':
                            case 'F':
                            case 'P':
                            case 'W':
                            case 'Y':
                                score = 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 2
                    if (i - 2 > 0)
                    {
                        e = protein_sequence[i - 2];
                        switch (protein_sequence[i - 2])
                        {
                            case 'A':
                            case 'R':
                            case 'C':
                            case 'T':
                            case 'Y':
                            case 'V':
                                score = score * 0.01;
                                break;
                            case 'D':
                            case 'Q':
                            case 'H':
                            case 'K':
                            case 'P':
                            case 'S':
                                score = score * 0.02;
                                break;
                            case 'E':
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'I':
                                score = score * 0.04;
                                break;
                            case 'G':
                                score = score * 0.21;
                                break;
                            case 'L':
                                score = score * 0.22;
                                break;
                            case 'M':
                                score = score * 0.29;
                                break;
                            case 'N':
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 3
                    if (i - 3 > 0)
                    {
                        d = protein_sequence[i - 3];
                        switch (protein_sequence[i - 3])
                        {
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'D':
                            case 'G':
                            case 'H':
                            case 'L':
                            case 'P':
                                score = score * 0.02;
                                break;
                            case 'A':
                                score = score * 0.03;
                                break;
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'R':
                            case 'K':
                            case 'S':
                            case 'Y':
                                score = score * 0.05;
                                break;
                            case 'Q':
                                score = score * 0.16;
                                break;
                            case 'F':
                                score = score * 0.32;
                                break;
                            case 'W':
                                score = score * 0.14;
                                break;
                            case 'N':
                            case 'C':
                            case 'E':
                            case 'T':
                            case 'I':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 4
                    if (i - 4 > 0)
                    {
                        c = protein_sequence[i - 4];
                        switch (protein_sequence[i - 4])
                        {
                            case 'Q':
                            case 'K':
                            case 'M':
                            case 'T':
                            case 'V':
                                score = score * 0.01;
                                break;
                            case 'I':
                            case 'S':
                            case 'W':
                                score = score * 0.02;
                                break;
                            case 'E':
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'A':
                                score = score * 0.05;
                                break;
                            case 'R':
                            case 'N':
                                score = score * 0.08;
                                break;
                            case 'P':
                            case 'L':
                                score = score * 0.11;
                                break;
                            case 'D':
                                score = score * 0.19;
                                break;
                            case 'G':
                                score = score * 0.2;
                                break;
                            case 'C':
                            case 'H':
                            case 'Y':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 5
                    if (i - 5 > 0)
                    {
                        b = protein_sequence[i - 5];
                        switch (protein_sequence[i - 5])
                        {
                            case 'I':
                                score = score * 0.01;
                                break;
                            case 'L':
                                score = score * 0.02;
                                break;
                            case 'N':
                            case 'H':
                            case 'F':
                            case 'W':
                            case 'V':
                                score = score * 0.03;
                                break;
                            case 'M':
                                score = score * 0.04;
                                break;
                            case 'A':
                            case 'G':
                            case 'Q':
                            case 'Y':
                                score = score * 0.05;
                                break;
                            case 'R':
                            case 'P':
                                score = score * 0.06;
                                break;
                            case 'T':
                            case 'S':
                                score = score * 0.07;
                                break;
                            case 'K':
                                score = score * 0.09;
                                break;
                            case 'D':
                                score = score * 0.1;
                                break;
                            case 'C':
                                score = score * 0;
                                break;
                            case 'E':
                                score = score * 0.16;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 6
                    if (i - 6 > 0)
                    {
                        a = protein_sequence[i - 6];
                        switch (protein_sequence[i - 6])
                        {
                            case 'C':
                            case 'L':
                            case 'T':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'I':
                            case 'M':
                            case 'V':
                                score = score * 0.02;
                                break;
                            case 'H':
                                score = score * 0.03;
                                break;
                            case 'A':
                            case 'N':
                            case 'E':
                            case 'P':
                                score = score * 0.06;
                                break;
                            case 'Q':
                            case 'S':
                                score = score * 0.07;
                                break;
                            case 'K':
                                score = score * 0.08;
                                break;
                            case 'G':
                                score = score * 0.09;
                                break;
                            case 'Y':
                                score = score * 0.1;
                                break;
                            case 'R':
                            case 'D':
                                score = score * 0.11;
                                break;
                            case 'F':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    // score scaling according to higest score
                    score = normalize(score, 5);

                    if ((score >= PTM_tolerance) && (i - 6 >= 0) && (i - 5 >= 0) && (i - 4 >= 0) && (i - 3 >= 0) && (i - 2 >= 0) && (i - 1 >= 0))
                    {
                        f = protein_sequence[i - 1];
                        e = protein_sequence[i - 2];
                        d = protein_sequence[i - 3];
                        c = protein_sequence[i - 4];
                        b = protein_sequence[i - 5];
                        a = protein_sequence[i - 6];

                        //% it stores the protein sub-sequence
                        AA.Add(a);
                        AA.Add(b);
                        AA.Add(c);
                        AA.Add(d);
                        AA.Add(e);
                        AA.Add(f);
                        AA.Add(protein_sequence[i]);

                        // Storing the data in the list "array"
                        array.Add(new Sites(i, score, mod_weight, mod_name, site, AA));

                        objectArrayIndex++;

                        // score of Phenylalanine at that position
                    }
                }

                // for the TotalPhe if condition coming up ahead
                index = i;
            }

            // it displays total number of Serine found in sequence
            if (index == protein_sequence.Length)
            {
                Console.WriteLine("Total Phenylalanine found: " + TotalPhe);
            }
            //disp(['Total Phenylalanine found: ', num2str(TotalPhe)])

            // returning the object array
            return array;
        }

        // Function (Hydroxylation_P): Returns an object array with all the required parameters stored
        public static List<Sites> Hydroxylation_P(string protein_sequence, double PTM_tolerance)
        {
            //Sequence of protein
            //protein_sequence = "MAPNASCLCVHVRSEEWDLMTFDANPYDSVKKIKEHVRSKTKVPVQDQVLLLGSKILKPRRSLSSYGIDKEKTIHLTLKVVKPSDEELPLFLVESGDEAKRHLLQVRRSSSVAQVKAMIETKTGIIPETQIVTCNGKRLEDGKMMADYGIRKGNLLFLACYCIGG";

            setAASize(13);

            double mod_weight = 15.9949;
            string mod_name = "Hydroxylation";
            char site = 'P';

            setsiteDetect(site);

            // variable score is initialized
            double score = 0;

            // Variable to store total number of Proline
            int TotalPro = 0;

            // stores the amino acids found
            List<char> AA = new List<char>();

            // list "array" creation
            List<Sites> array = new List<Sites>();

            // a higher scope variable declared to show the TotalPro (if statement at the end)
            int index = 0;

            // an indexing variable to iterate the dynamic array "array"
            int objectArrayIndex = 0;

            // for loop run for as many times as there are characters in the protein sequence
            for (int i = 0; i < protein_sequence.Length; i++)
            {
                if ((protein_sequence[i] == 'P') && (i < protein_sequence.Length) && (i + 1 < protein_sequence.Length) && (i + 2 < protein_sequence.Length) && (i + 3 < protein_sequence.Length) && (i + 4 < protein_sequence.Length) && (i + 5 < protein_sequence.Length) && (i + 6 < protein_sequence.Length))
                {
                    TotalPro = TotalPro + 1;

                    //variables to store sub - sequence
                    char a, b, c, d, e, f, g, h, m, j, k, l;

                    //It saves the score for i + 1 position
                    if (protein_sequence.Length >= i + 1)
                    {
                        l = protein_sequence[i + 1];
                        switch (protein_sequence[i + 1])
                        {
                            case 'R':
                            case 'C':
                            case 'K':
                            case 'Y':
                            case 'V':
                            case 'I':
                                score = 0.01;
                                break;
                            case 'A':
                                score = 0.03;
                                break;
                            case 'G':
                                score = 0.61;
                                break;
                            case 'P':
                                score = 0.13;
                                break;
                            case 'T':
                                score = 0.08;
                                break;
                            case 'S':
                                score = 0.1;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 2 position
                    if (protein_sequence.Length >= i + 2)
                    {
                        k = protein_sequence[i + 2];
                        switch (protein_sequence[i + 2])
                        {
                            case 'N':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'R':
                            case 'D':
                            case 'Q':
                            case 'H':
                            case 'I':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'L':
                            case 'K':
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'S':
                                score = score * 0.06;
                                break;
                            case 'G':
                            case 'E':
                                score = score * 0.07;
                                break;
                            case 'T':
                                score = score * 0.08;
                                break;
                            case 'A':
                                score = score * 0.09;
                                break;
                            case 'Y':
                                score = score * 0.12;
                                break;
                            case 'P':
                                score = score * 0.25;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 3 position
                    if (protein_sequence.Length >= i + 3)
                    {
                        j = protein_sequence[i + 3];
                        switch (protein_sequence[i + 3])
                        {
                            case 'E':
                            case 'I':
                            case 'L':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'N':
                                score = score * 0.02;
                                break;
                            case 'G':
                            case 'V':
                                score = score * 0.03;
                                break;
                            case 'T':
                                score = score * 0.04;
                                break;
                            case 'Q':
                                score = score * 0.05;
                                break;
                            case 'R':
                            case 'D':
                            case 'S':
                                score = score * 0.06;
                                break;
                            case 'Y':
                                score = score * 0.07;
                                break;
                            case 'K':
                                score = score * 0.13;
                                break;
                            case 'A':
                                score = score * 0.11;
                                break;
                            case 'P':
                                score = score * 0.29;
                                break;
                            case 'H':
                            case 'C':
                            case 'F':
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 4 position
                    if (protein_sequence.Length >= i + 4)
                    {
                        m = protein_sequence[i + 4];
                        switch (protein_sequence[i + 4])
                        {
                            case 'R':
                            case 'D':
                            case 'C':
                            case 'I':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'V':
                                score = score * 0.02;
                                break;
                            case 'T':
                                score = score * 0.03;
                                break;
                            case 'S':
                                score = score * 0.04;
                                break;
                            case 'A':
                                score = score * 0.06;
                                break;
                            case 'K':
                                score = score * 0.07;
                                break;
                            case 'P':
                                score = score * 0.13;
                                break;
                            case 'G':
                                score = score * 0.58;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 5 position
                    if (protein_sequence.Length >= i + 5)
                    {
                        h = protein_sequence[i + 5];
                        switch (protein_sequence[i + 5])
                        {
                            case 'H':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'N':
                            case 'Q':
                            case 'I':
                            case 'F':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'D':
                            case 'V':
                                score = score * 0.03;
                                break;
                            case 'R':
                                score = score * 0.04;
                                break;
                            case 'L':
                            case 'S':
                                score = score * 0.06;
                                break;
                            case 'G':
                            case 'E':
                            case 'K':
                                score = score * 0.07;
                                break;
                            case 'T':
                                score = score * 0.08;
                                break;
                            case 'A':
                                score = score * 0.15;
                                break;
                            case 'P':
                                score = score * 0.21;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 6 position
                    if (protein_sequence.Length >= i + 6)
                    {
                        g = protein_sequence[i + 6];
                        switch (protein_sequence[i + 6])
                        {
                            case 'H':
                            case 'L':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'N':
                            case 'E':
                            case 'I':
                                score = score * 0.02;
                                break;
                            case 'G':
                            case 'V':
                                score = score * 0.03;
                                break;
                            case 'D':
                                score = score * 0.04;
                                break;
                            case 'T':
                            case 'Q':
                                score = score * 0.05;
                                break;
                            case 'S':
                            case 'Y':
                                score = score * 0.07;
                                break;
                            case 'A':
                            case 'R':
                                score = score * 0.08;
                                break;
                            case 'K':
                                score = score * 0.12;
                                break;
                            case 'P':
                                score = score * 0.29;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 1
                    if (i - 1 > 0)
                    {
                        f = protein_sequence[i - 1];
                        switch (protein_sequence[i - 1])
                        {
                            case 'N':
                            case 'D':
                            case 'H':
                                score = score * 0.01;
                                break;
                            case 'Q':
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'R':
                            case 'I':
                            case 'T':
                            case 'V':
                                score = score * 0.03;
                                break;
                            case 'F':
                                score = score * 0.04;
                                break;
                            case 'G':
                            case 'E':
                                score = score * 0.05;
                                break;
                            case 'L':
                                score = score * 0.06;
                                break;
                            case 'Y':
                            case 'S':
                            case 'K':
                                score = score * 0.07;
                                break;
                            case 'A':
                                score = score * 0.11;
                                break;
                            case 'P':
                                score = score * 0.28;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 2
                    if (i - 2 > 0)
                    {
                        e = protein_sequence[i - 2];
                        switch (protein_sequence[i - 2])
                        {
                            case 'R':
                            case 'E':
                            case 'Q':
                            case 'I':
                            case 'K':
                                score = score * 0.01;
                                break;
                            case 'L':
                            case 'V':
                                score = score * 0.02;
                                break;
                            case 'T':
                                score = score * 0.03;
                                break;
                            case 'Y':
                                score = score * 0.06;
                                break;
                            case 'A':
                                score = score * 0.07;
                                break;
                            case 'P':
                            case 'S':
                                score = score * 0.08;
                                break;
                            case 'G':
                                score = score * 0.6;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 3
                    if (i - 3 > 0)
                    {
                        d = protein_sequence[i - 3];
                        switch (protein_sequence[i - 3])
                        {
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'N':
                            case 'E':
                            case 'I':
                            case 'L':
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'D':
                            case 'G':
                            case 'V':
                                score = score * 0.03;
                                break;
                            case 'T':
                                score = score * 0.04;
                                break;
                            case 'Q':
                                score = score * 0.05;
                                break;
                            case 'K':
                                score = score * 0.09;
                                break;
                            case 'R':
                            case 'S':
                                score = score * 0.1;
                                break;
                            case 'A':
                                score = score * 0.13;
                                break;
                            case 'P':
                                score = score * 0.28;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 4
                    if (i - 4 > 0)
                    {
                        c = protein_sequence[i - 4];
                        switch (protein_sequence[i - 4])
                        {
                            case 'C':
                            case 'H':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'N':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'R':
                            case 'D':
                            case 'Q':
                            case 'I':
                            case 'T':
                                score = score * 0.03;
                                break;
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'L':
                            case 'S':
                                score = score * 0.05;
                                break;
                            case 'Y':
                            case 'G':
                                score = score * 0.07;
                                break;
                            case 'A':
                                score = score * 0.08;
                                break;
                            case 'K':
                            case 'E':
                                score = score * 0.09;
                                break;
                            case 'P':
                                score = score * 0.25;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 5
                    if (i - 5 > 0)
                    {
                        b = protein_sequence[i - 5];
                        switch (protein_sequence[i - 5])
                        {
                            case 'R':
                            case 'N':
                            case 'D':
                            case 'Q':
                            case 'Y':
                            case 'V':
                                score = score * 0.01;
                                break;
                            case 'L':
                                score = score * 0.02;
                                break;
                            case 'S':
                                score = score * 0.03;
                                break;
                            case 'K':
                            case 'P':
                                score = score * 0.06;
                                break;
                            case 'T':
                                score = score * 0.08;
                                break;
                            case 'A':
                                score = score * 0.09;
                                break;
                            case 'G':
                                score = score * 0.58;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 6
                    if (i - 6 > 0)
                    {
                        a = protein_sequence[i - 6];
                        switch (protein_sequence[i - 6])
                        {
                            case 'N':
                            case 'E':
                            case 'I':
                            case 'M':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'D':
                            case 'G':
                            case 'L':
                            case 'V':
                                score = score * 0.03;
                                break;
                            case 'T':
                                score = score * 0.04;
                                break;
                            case 'S':
                                score = score * 0.05;
                                break;
                            case 'Q':
                                score = score * 0.06;
                                break;
                            case 'R':
                                score = score * 0.08;
                                break;
                            case 'K':
                                score = score * 0.12;
                                break;
                            case 'A':
                                score = score * 0.13;
                                break;
                            case 'P':
                                score = score * 0.3;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    // score scaling according to higest score
                    score = normalize(score, 6);

                    if ((score >= PTM_tolerance) && (i - 6 >= 0) && (i - 5 >= 0) && (i - 4 >= 0) && (i - 3 >= 0) && (i - 2 >= 0) && (i - 1 >= 0))
                    {
                        l = protein_sequence[i + 1];
                        k = protein_sequence[i + 2];
                        j = protein_sequence[i + 3];
                        m = protein_sequence[i + 4];
                        h = protein_sequence[i + 5];
                        g = protein_sequence[i + 6];
                        f = protein_sequence[i - 1];
                        e = protein_sequence[i - 2];
                        d = protein_sequence[i - 3];
                        c = protein_sequence[i - 4];
                        b = protein_sequence[i - 5];
                        a = protein_sequence[i - 6];

                        //% it stores the protein sub-sequence
                        AA.Add(a);
                        AA.Add(b);
                        AA.Add(c);
                        AA.Add(d);
                        AA.Add(e);
                        AA.Add(f);
                        AA.Add(protein_sequence[i]);
                        AA.Add(l);
                        AA.Add(k);
                        AA.Add(j);
                        AA.Add(m);
                        AA.Add(h);
                        AA.Add(g);

                        // Storing the data in the list "array"
                        array.Add(new Sites(i, score, mod_weight, mod_name, site, AA));

                        objectArrayIndex++;

                        // score of Proline at that position
                    }
                }

                // for the TotalPro if condition coming up ahead
                index = i;
            }

            // it displays total number of Proline found in sequence
            if (index == protein_sequence.Length)
            {
                Console.WriteLine("Total Proline found: " + TotalPro);
            }
            //disp(['Total Proline found: ', num2str(TotalPro)])

            // returning the object array
            return array;
        }

        // Function (Methylation_K): Returns an object array with all the required parameters stored
        public static List<Sites> Methylation_K(string protein_sequence, double PTM_tolerance)
        {
            //Sequence of protein
            //protein_sequence = "MAPNASCLCVHVRSEEWDLMTFDANPYDSVKKIKEHVRSKTKVPVQDQVLLLGSKILKPRRSLSSYGIDKEKTIHLTLKVVKPSDEELPLFLVESGDEAKRHLLQVRRSSSVAQVKAMIETKTGIIPETQIVTCNGKRLEDGKMMADYGIRKGNLLFLACYCIGG";

            setAASize(13);

            double mod_weight = 14.0156;
            string mod_name = "Methylation";
            char site = 'K';

            setsiteDetect(site);

            // variable score is initialized
            double score = 0;

            // Variable to store total number of Lysine
            int TotalLys = 0;

            // stores the amino acids found
            List<char> AA = new List<char>();

            // list "array" creation
            List<Sites> array = new List<Sites>();

            // a higher scope variable declared to show the TotalLys (if statement at the end)
            int index = 0;

            // an indexing variable to iterate the dynamic array "array"
            int objectArrayIndex = 0;

            // for loop run for as many times as there are characters in the protein sequence
            for (int i = 0; i < protein_sequence.Length; i++)
            {
                if ((protein_sequence[i] == 'K') && (i < protein_sequence.Length) && (i + 1 < protein_sequence.Length) && (i + 2 < protein_sequence.Length) && (i + 3 < protein_sequence.Length) && (i + 4 < protein_sequence.Length) && (i + 5 < protein_sequence.Length) && (i + 6 < protein_sequence.Length))
                {
                    TotalLys = TotalLys + 1;

                    //variables to store sub - sequence
                    char b, c, d, e, f, g, h, j, k, l, m, n;

                    //% it will score amino acid at position i - 6
                    if (i - 6 > 0)
                    {
                        b = protein_sequence[i - 6];
                        switch (protein_sequence[i - 6])
                        {
                            case 'A':
                                score = 0.23;
                                break;
                            case 'D':
                            case 'C':
                            case 'Q':
                            case 'F':
                                score = 0;
                                break;
                            case 'G':
                            case 'P':
                                score = 0.11;
                                break;
                            case 'E':
                            case 'K':
                            case 'S':
                                score = 0.05;
                                break;
                            case 'L':
                            case 'M':
                            case 'Y':
                                score = 0.04;
                                break;
                            case 'T':
                                score = 0.14;
                                break;
                            case 'V':
                                score = 0.07;
                                break;
                            case 'R':
                            case 'N':
                            case 'H':
                            case 'I':
                            case 'W':
                                score = 0.02;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 5
                    if (i - 5 > 0)
                    {
                        c = protein_sequence[i - 5];
                        switch (protein_sequence[i - 5])
                        {
                            case 'A':
                            case 'G':
                            case 'S':
                            case 'T':
                                score = score * 0.12;
                                break;
                            case 'R':
                            case 'N':
                                score = score * 0.05;
                                break;
                            case 'D':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'C':
                            case 'Q':
                            case 'I':
                            case 'L':
                            case 'M':
                            case 'F':
                            case 'W':
                            case 'Y':
                            case 'V':
                                score = score * 0;
                                break;
                            case 'E':
                                score = score * 0.11;
                                break;
                            case 'K':
                                score = score * 0.19;
                                break;
                            case 'P':
                                score = score * 0.07;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 4
                    if (i - 4 > 0)
                    {
                        d = protein_sequence[i - 4];
                        switch (protein_sequence[i - 4])
                        {
                            case 'A':
                                score = score * 0.09;
                                break;
                            case 'R':
                                score = score * 0.07;
                                break;
                            case 'N':
                            case 'V':
                                score = score * 0.02;
                                break;
                            case 'D':
                            case 'G':
                            case 'L':
                            case 'F':
                            case 'S':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'E':
                            case 'H':
                            case 'P':
                            case 'T':
                            case 'Y':
                                score = score * 0.04;
                                break;
                            case 'Q':
                                score = score * 0.14;
                                break;
                            case 'K':
                                score = score * 0.19;
                                break;
                            case 'I':
                            case 'M':
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 3
                    if (i - 3 > 0)
                    {
                        e = protein_sequence[i - 3];
                        switch (protein_sequence[i - 3])
                        {
                            case 'A':
                                score = score * 0.21;
                                break;
                            case 'R':
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'N':
                            case 'C':
                            case 'E':
                            case 'Q':
                            case 'H':
                            case 'M':
                            case 'F':
                            case 'W':
                            case 'Y':
                                score = score * 0;
                                break;
                            case 'D':
                            case 'K':
                                score = score * 0.05;
                                break;
                            case 'G':
                                score = score * 0.11;
                                break;
                            case 'I':
                                score = score * 0.02;
                                break;
                            case 'L':
                                score = score * 0.16;
                                break;
                            case 'P':
                            case 'S':
                                score = score * 0.07;
                                break;
                            case 'T':
                                score = score * 0.19;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 2
                    if (i - 2 > 0)
                    {
                        f = protein_sequence[i - 2];
                        switch (protein_sequence[i - 2])
                        {
                            case 'A':
                                score = score * 0.33;
                                break;
                            case 'R':
                            case 'H':
                            case 'P':
                            case 'S':
                                score = score * 0.04;
                                break;
                            case 'N':
                            case 'K':
                                score = score * 0.09;
                                break;
                            case 'D':
                            case 'E':
                            case 'I':
                                score = score * 0.02;
                                break;
                            case 'C':
                            case 'Q':
                            case 'L':
                            case 'M':
                            case 'F':
                            case 'W':
                            case 'Y':
                                score = score * 0;
                                break;
                            case 'G':
                                score = score * 0.19;
                                break;
                            case 'T':
                            case 'V':
                                score = score * 0.05;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 1
                    if (i - 1 > 0)
                    {
                        g = protein_sequence[i - 1];
                        switch (protein_sequence[i - 1])
                        {
                            case 'A':
                            case 'C':
                            case 'S':
                                score = score * 0.04;
                                break;
                            case 'R':
                                score = score * 0.4;
                                break;
                            case 'N':
                            case 'Q':
                            case 'I':
                            case 'M':
                            case 'F':
                            case 'P':
                            case 'W':
                            case 'Y':
                                score = score * 0;
                                break;
                            case 'D':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'G':
                            case 'E':
                                score = score * 0.07;
                                break;
                            case 'L':
                                score = score * 0.09;
                                break;
                            case 'K':
                                score = score * 0.12;
                                break;
                            case 'T':
                            case 'V':
                                score = score * 0.05;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 1
                    if (protein_sequence.Length >= i + 1)
                    {
                        h = protein_sequence[i + 1];
                        switch (protein_sequence[i + 1])
                        {
                            case 'A':
                                score = score * 0.14;
                                break;
                            case 'R':
                            case 'D':
                            case 'I':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'N':
                            case 'G':
                            case 'E':
                            case 'L':
                            case 'M':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'H':
                            case 'P':
                            case 'W':
                            case 'Y':
                                score = score * 0;
                                break;
                            case 'Q':
                            case 'T':
                                score = score * 0.04;
                                break;
                            case 'K':
                                score = score * 0.14;
                                break;
                            case 'S':
                                score = score * 0.21;
                                break;
                            case 'V':
                                score = score * 0.11;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 2
                    if (protein_sequence.Length >= i + 2)
                    {
                        j = protein_sequence[i + 2];
                        switch (protein_sequence[i + 2])
                        {
                            case 'A':
                                score = score * 0.21;
                                break;
                            case 'R':
                            case 'N':
                            case 'D':
                            case 'Q':
                            case 'L':
                            case 'F':
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'C':
                            case 'H':
                            case 'I':
                            case 'M':
                            case 'Y':
                                score = score * 0;
                                break;
                            case 'G':
                            case 'P':
                                score = score * 0.07;
                                break;
                            case 'E':
                                score = score * 0.11;
                                break;
                            case 'K':
                            case 'S':
                                score = score * 0.05;
                                break;
                            case 'T':
                                score = score * 0.18;
                                break;
                            case 'W':
                                score = score * 0.02;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 3
                    if (protein_sequence.Length >= i + 3)
                    {
                        k = protein_sequence[i + 3];
                        switch (protein_sequence[i + 3])
                        {
                            case 'A':
                            case 'S':
                                score = score * 0.09;
                                break;
                            case 'R':
                            case 'D':
                            case 'Q':
                            case 'L':
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'N':
                            case 'C':
                            case 'E':
                            case 'M':
                            case 'W':
                            case 'Y':
                                score = score * 0;
                                break;
                            case 'G':
                                score = score * 0.19;
                                break;
                            case 'H':
                                score = score * 0.04;
                                break;
                            case 'I':
                                score = score * 0.07;
                                break;
                            case 'P':
                                score = score * 0.11;
                                break;
                            case 'K':
                                score = score * 0.12;
                                break;
                            case 'F':
                            case 'T':
                                score = score * 0.02;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 4
                    if (protein_sequence.Length >= i + 4)
                    {
                        l = protein_sequence[i + 4];
                        switch (protein_sequence[i + 4])
                        {
                            case 'A':
                                score = score * 0.18;
                                break;
                            case 'R':
                            case 'D':
                            case 'E':
                            case 'K':
                            case 'S':
                            case 'Y':
                                score = score * 0.05;
                                break;
                            case 'N':
                            case 'H':
                            case 'L':
                            case 'M':
                            case 'T':
                                score = score * 0.02;
                                break;
                            case 'C':
                            case 'Q':
                            case 'W':
                                score = score * 0;
                                break;
                            case 'G':
                                score = score * 0.16;
                                break;
                            case 'I':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'P':
                                score = score * 0.09;
                                break;
                            case 'F':
                                score = score * 0.04;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 5
                    if (protein_sequence.Length >= i + 5)
                    {
                        m = protein_sequence[i + 5];
                        switch (protein_sequence[i + 5])
                        {
                            case 'A':
                                score = score * 0.11;
                                break;
                            case 'R':
                            case 'Q':
                            case 'S':
                            case 'Y':
                                score = score * 0.04;
                                break;
                            case 'N':
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'D':
                            case 'I':
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'G':
                            case 'H':
                            case 'L':
                            case 'W':
                                score = score * 0;
                                break;
                            case 'E':
                            case 'F':
                                score = score * 0.09;
                                break;
                            case 'K':
                                score = score * 0.18;
                                break;
                            case 'T':
                                score = score * 0.14;
                                break;
                            case 'P':
                                score = score * 0.07;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 6
                    if (protein_sequence.Length >= i + 6)
                    {
                        n = protein_sequence[i + 6];
                        switch (protein_sequence[i + 6])
                        {
                            case 'A':
                            case 'K':
                                score = score * 0.19;
                                break;
                            case 'R':
                            case 'L':
                            case 'F':
                            case 'P':
                            case 'S':
                            case 'T':
                                score = score * 0.04;
                                break;
                            case 'N':
                            case 'C':
                            case 'I':
                                score = score * 0.02;
                                break;
                            case 'D':
                                score = score * 0.11;
                                break;
                            case 'G':
                            case 'V':
                                score = score * 0.12;
                                break;
                            case 'Q':
                            case 'E':
                            case 'H':
                            case 'M':
                            case 'W':
                            case 'Y':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    // score scaling according to higest score
                    score = normalize(score, 7);

                    if ((score >= PTM_tolerance) && (i - 6 >= 0) && (i - 5 >= 0) && (i - 4 >= 0) && (i - 3 >= 0) && (i - 2 >= 0) && (i - 1 >= 0))
                    {
                        b = protein_sequence[i - 6];
                        c = protein_sequence[i - 5];
                        d = protein_sequence[i - 4];
                        e = protein_sequence[i - 3];
                        f = protein_sequence[i - 2];
                        g = protein_sequence[i - 1];
                        h = protein_sequence[i + 1];
                        j = protein_sequence[i + 2];
                        k = protein_sequence[i + 3];
                        l = protein_sequence[i + 4];
                        m = protein_sequence[i + 5];
                        n = protein_sequence[i + 6];

                        //% it stores the protein sub-sequence
                        AA.Add(b);
                        AA.Add(c);
                        AA.Add(d);
                        AA.Add(e);
                        AA.Add(f);
                        AA.Add(g);
                        AA.Add(protein_sequence[i]);
                        AA.Add(h);
                        AA.Add(j);
                        AA.Add(k);
                        AA.Add(l);
                        AA.Add(m);
                        AA.Add(n);

                        // Storing the data in the list "array"
                        array.Add(new Sites(i, score, mod_weight, mod_name, site, AA));

                        objectArrayIndex++;

                        // score of Lysine at that position
                    }
                }

                // for the TotalLys if condition coming up ahead
                index = i;
            }

            // it displays total number of Lysine found in sequence
            if (index == protein_sequence.Length)
            {
                Console.WriteLine("Total Lysine found: " + TotalLys);
            }
            //disp(['Total Lysine found: ', num2str(TotalLys)])

            // returning the object array
            return array;
        }

        // Function (Methylation_R): Returns an object array with all the required parameters stored
        public static List<Sites> Methylation_R(string protein_sequence, double PTM_tolerance)
        {
            //Sequence of protein
            //protein_sequence = "MAPNASCLCVHVRSEEWDLMTFDANPYDSVKKIKEHVRSKTKVPVQDQVLLLGSKILKPRRSLSSYGIDKEKTIHLTLKVVKPSDEELPLFLVESGDEAKRHLLQVRRSSSVAQVKAMIETKTGIIPETQIVTCNGKRLEDGKMMADYGIRKGNLLFLACYCIGG";

            setAASize(14);

            double mod_weight = 14.0156;
            string mod_name = "Methylation";
            char site = 'R';

            setsiteDetect(site);

            // variable score is initialized
            double score = 0;

            // Variable to store total number of argenine
            int TotalArg = 0;

            // stores the amino acids found
            List<char> AA = new List<char>();

            // list "array" creation
            List<Sites> array = new List<Sites>();

            // a higher scope variable declared to show the TotalArg (if statement at the end)
            int index = 0;

            // an indexing variable to iterate the dynamic array "array"
            int objectArrayIndex = 0;

            // for loop run for as many times as there are characters in the protein sequence
            for (int i = 0; i < protein_sequence.Length; i++)
            {
                if ((protein_sequence[i] == 'R') && (i < protein_sequence.Length) && (i + 1 < protein_sequence.Length) && (i + 2 < protein_sequence.Length) && (i + 3 < protein_sequence.Length) && (i + 4 < protein_sequence.Length) && (i + 5 < protein_sequence.Length) && (i + 6 < protein_sequence.Length))
                {
                    TotalArg = TotalArg + 1;

                    //variables to store sub - sequence
                    char b, c, d, e, f, g, h, j, k, l, m, n;

                    //% it will score amino acid at position i - 6
                    if (i - 6 > 0)
                    {
                        b = protein_sequence[i - 6];
                        switch (protein_sequence[i - 6])
                        {
                            case 'A':
                            case 'I':
                            case 'M':
                            case 'Y':
                            case 'V':
                                score = 0.03;
                                break;
                            case 'R':
                                score = 0.15;
                                break;
                            case 'N':
                            case 'F':
                                score = 0.02;
                                break;
                            case 'D':
                            case 'Q':
                            case 'L':
                                score = 0.05;
                                break;
                            case 'G':
                                score = 0.25;
                                break;
                            case 'E':
                            case 'K':
                            case 'T':
                                score = 0.04;
                                break;
                            case 'H':
                                score = 0.01;
                                break;
                            case 'P':
                                score = 0.08;
                                break;
                            case 'S':
                                score = 0.06;
                                break;
                            case 'C':
                            case 'W':
                                score = 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 5
                    if (i - 5 > 0)
                    {
                        c = protein_sequence[i - 5];
                        switch (protein_sequence[i - 5])
                        {

                            case 'A':
                                score = score * 0.09;
                                break;
                            case 'S':
                            case 'R':
                                score = score * 0.1;
                                break;
                            case 'D':
                            case 'N':
                            case 'L':
                            case 'M':
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'G':
                                score = score * 0.26;
                                break;
                            case 'E':
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'H':
                                score = score * 0.01;
                                break;
                            case 'I':
                            case 'K':
                            case 'T':
                                score = score * 0.02;
                                break;
                            case 'Q':
                            case 'F':
                            case 'P':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 4
                    if (i - 4 > 0)
                    {
                        d = protein_sequence[i - 4];
                        switch (protein_sequence[i - 4])
                        {
                            case 'A':
                            case 'L':
                                score = score * 0.05;
                                break;
                            case 'R':
                                score = score * 0.19;
                                break;
                            case 'N':
                            case 'D':
                            case 'Q':
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'G':
                                score = score * 0.18;
                                break;
                            case 'E':
                            case 'K':
                            case 'T':
                                score = score * 0.04;
                                break;
                            case 'H':
                                score = score * 0.01;
                                break;
                            case 'I':
                            case 'M':
                            case 'V':
                                score = score * 0.02;
                                break;
                            case 'P':
                                score = score * 0.1;
                                break;
                            case 'S':
                                score = score * 0.08;
                                break;
                            case 'Y':
                                score = score * 0.06;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 3
                    if (i - 3 > 0)
                    {
                        e = protein_sequence[i - 3];
                        switch (protein_sequence[i - 3])
                        {
                            case 'A':
                                score = score * 0.06;
                                break;
                            case 'R':
                            case 'S':
                                score = score * 0.09;
                                break;
                            case 'N':
                            case 'L':
                            case 'M':
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'D':
                            case 'E':
                            case 'T':
                                score = score * 0.02;
                                break;
                            case 'C':
                            case 'I':
                                score = score * 0.01;
                                break;
                            case 'G':
                                score = score * 0.29;
                                break;
                            case 'Q':
                            case 'K':
                            case 'F':
                                score = score * 0.05;
                                break;
                            case 'P':
                                score = score * 0.08;
                                break;
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'H':
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 2
                    if (i - 2 > 0)
                    {
                        f = protein_sequence[i - 2];
                        switch (protein_sequence[i - 2])
                        {
                            case 'A':
                                score = score * 0.1;
                                break;
                            case 'R':
                                score = score * 0.18;
                                break;
                            case 'N':
                            case 'C':
                            case 'H':
                            case 'F':
                            case 'T':
                                score = score * 0.01;
                                break;
                            case 'D':
                            case 'L':
                            case 'K':
                            case 'M':
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'G':
                                score = score * 0.23;
                                break;
                            case 'E':
                                score = score * 0.05;
                                break;
                            case 'Q':
                            case 'I':
                                score = score * 0.02;
                                break;
                            case 'P':
                            case 'S':
                                score = score * 0.08;
                                break;
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 1
                    if (i - 1 > 0)
                    {
                        g = protein_sequence[i - 1];
                        switch (protein_sequence[i - 1])
                        {
                            case 'A':
                            case 'L':
                                score = score * 0.05;
                                break;
                            case 'R':
                                score = score * 0.06;
                                break;
                            case 'N':
                            case 'I':
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'D':
                                score = score * 0.07;
                                break;
                            case 'G':
                                score = score * 0.32;
                                break;
                            case 'E':
                            case 'K':
                            case 'T':
                            case 'V':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'H':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'P':
                            case 'S':
                                score = score * 0.1;
                                break;
                            case 'W':
                            case 'C':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 1
                    if (protein_sequence.Length >= i + 1)
                    {
                        h = protein_sequence[i + 1];
                        switch (protein_sequence[i + 1])
                        {
                            case 'A':
                                score = score * 0.07;
                                break;
                            case 'R':
                                score = score * 0.04;
                                break;
                            case 'N':
                            case 'H':
                            case 'I':
                            case 'T':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'D':
                            case 'E':
                            case 'Q':
                            case 'M':
                            case 'F':
                            case 'S':
                            case 'V':
                                score = score * 0.02;
                                break;
                            case 'G':
                                score = score * 0.56;
                                break;
                            case 'L':
                                score = score * 0.05;
                                break;
                            case 'K':
                                score = score * 0.03;
                                break;
                            case 'P':
                                score = score * 0.06;
                                break;
                            case 'W':
                            case 'C':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 2
                    if (protein_sequence.Length >= i + 2)
                    {
                        j = protein_sequence[i + 2];
                        switch (protein_sequence[i + 2])
                        {
                            case 'A':
                                score = score * 0.07;
                                break;
                            case 'R':
                                score = score * 0.22;
                                break;
                            case 'N':
                            case 'C':
                            case 'M':
                            case 'W':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'D':
                            case 'E':
                            case 'H':
                            case 'I':
                                score = score * 0.02;
                                break;
                            case 'G':
                                score = score * 0.31;
                                break;
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'L':
                                score = score * 0.06;
                                break;
                            case 'K':
                            case 'F':
                            case 'S':
                            case 'T':
                            case 'V':
                                score = score * 0.03;
                                break;
                            case 'P':
                                score = score * 0.05;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 3
                    if (protein_sequence.Length >= i + 3)
                    {
                        k = protein_sequence[i + 3];
                        switch (protein_sequence[i + 3])
                        {
                            case 'A':
                            case 'P':
                            case 'S':
                                score = score * 0.08;
                                break;
                            case 'R':
                            case 'L':
                                score = score * 0.07;
                                break;
                            case 'N':
                            case 'D':
                            case 'V':
                                score = score * 0.03;
                                break;
                            case 'G':
                                score = score * 0.23;
                                break;
                            case 'E':
                            case 'M':
                                score = score * 0.04;
                                break;
                            case 'Q':
                            case 'H':
                            case 'K':
                            case 'T':
                                score = score * 0.02;
                                break;
                            case 'I':
                                score = score * 0.01;
                                break;
                            case 'F':
                                score = score * 0.09;
                                break;
                            case 'Y':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 4
                    if (protein_sequence.Length >= i + 4)
                    {
                        l = protein_sequence[i + 4];
                        switch (protein_sequence[i + 4])
                        {
                            case 'A':
                            case 'S':
                                score = score * 0.06;
                                break;
                            case 'R':
                                score = score * 0.18;
                                break;
                            case 'N':
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'D':
                            case 'E':
                            case 'Q':
                            case 'L':
                            case 'K':
                                score = score * 0.04;
                                break;
                            case 'G':
                                score = score * 0.22;
                                break;
                            case 'H':
                            case 'I':
                                score = score * 0.05;
                                break;
                            case 'F':
                            case 'T':
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'P':
                                score = score * 0.08;
                                break;
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 5
                    if (protein_sequence.Length >= i + 5)
                    {
                        m = protein_sequence[i + 5];
                        switch (protein_sequence[i + 5])
                        {
                            case 'A':
                                score = score * 0.06;
                                break;
                            case 'R':
                                score = score * 0.09;
                                break;
                            case 'N':
                            case 'E':
                            case 'H':
                            case 'V':
                                score = score * 0.03;
                                break;
                            case 'D':
                            case 'L':
                            case 'K':
                            case 'F':
                                score = score * 0.04;
                                break;
                            case 'G':
                                score = score * 0.29;
                                break;
                            case 'Q':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'I':
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'P':
                            case 'S':
                                score = score * 0.07;
                                break;
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 6
                    if (protein_sequence.Length >= i + 6)
                    {
                        n = protein_sequence[i + 6];
                        switch (protein_sequence[i + 6])
                        {
                            case 'A':
                            case 'D':
                            case 'Q':
                            case 'L':
                                score = score * 0.05;
                                break;
                            case 'R':
                                score = score * 0.14;
                                break;
                            case 'N':
                            case 'E':
                                score = score * 0.04;
                                break;
                            case 'G':
                                score = score * 0.21;
                                break;
                            case 'H':
                            case 'I':
                                score = score * 0.01;
                                break;
                            case 'K':
                            case 'F':
                            case 'P':
                                score = score * 0.06;
                                break;
                            case 'M':
                                score = score * 0.03;
                                break;
                            case 'S':
                                score = score * 0.07;
                                break;
                            case 'T':
                            case 'W':
                            case 'Y':
                            case 'V':
                                score = score * 0.02;
                                break;
                            case 'C':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    // score scaling according to higest score
                    score = normalize(score, 8);

                    if ((score >= PTM_tolerance) && (i - 6 >= 0) && (i - 5 >= 0) && (i - 4 >= 0) && (i - 3 >= 0) && (i - 2 >= 0) && (i - 1 >= 0))
                    {
                        b = protein_sequence[i - 6];
                        c = protein_sequence[i - 5];
                        d = protein_sequence[i - 4];
                        e = protein_sequence[i - 3];
                        f = protein_sequence[i - 2];
                        g = protein_sequence[i - 1];
                        h = protein_sequence[i + 1];
                        j = protein_sequence[i + 2];
                        k = protein_sequence[i + 3];
                        l = protein_sequence[i + 4];
                        m = protein_sequence[i + 5];
                        n = protein_sequence[i + 6];

                        //% it stores the protein sub-sequence
                        AA.Add(b);
                        AA.Add(c);
                        AA.Add(d);
                        AA.Add(e);
                        AA.Add(f);
                        AA.Add(g);
                        AA.Add(protein_sequence[i]);
                        AA.Add(protein_sequence[i + 1]);
                        AA.Add(h);
                        AA.Add(j);
                        AA.Add(k);
                        AA.Add(l);
                        AA.Add(m);
                        AA.Add(n);

                        // Storing the data in the list "array"
                        array.Add(new Sites(i, score, mod_weight, mod_name, site, AA));

                        objectArrayIndex++;

                        // score of Argenine at that position
                    }
                }

                // for the TotalArg if condition coming up ahead
                index = i;
            }

            // it displays total number of Argenine found in sequence
            if (index == protein_sequence.Length)
            {
                Console.WriteLine("Total Argenine found: " + TotalArg);
            }
            //disp(['Total Argenine found: ', num2str(TotalArg)])

            // returning the object array
            return array;
        }

        // Function (N_linked_glycosylation_N): Returns an object array with all the required parameters stored
        public static List<Sites> N_linked_glycosylation_N(string protein_sequence, double PTM_tolerance)
        {
            //Sequence of protein
            //protein_sequence = "MAPNASCLCVHVRSEEWDLMTFDANPYDSVKKIKEHVRSKTKVPVQDQVLLLGSKILKPRRSLSSYGIDKEKTIHLTLKVVKPSDEELPLFLVESGDEAKRHLLQVRRSSSVAQVKAMIETKTGIIPETQIVTCNGKRLEDGKMMADYGIRKGNLLFLACYCIGG";

            setAASize(14);

            double mod_weight = 317.122;
            string mod_name = "N-linked Glycosylation";
            char site = 'N';

            setsiteDetect(site);

            // variable score is initialized
            double score = 0;

            // Variable to store total number of Asparagine
            int TotalAsn = 0;

            // stores the amino acids found
            List<char> AA = new List<char>();

            // list "array" creation
            List<Sites> array = new List<Sites>();

            // a higher scope variable declared to show the TotalAsn (if statement at the end)
            int index = 0;

            // an indexing variable to iterate the dynamic array "array"
            int objectArrayIndex = 0;

            // for loop run for as many times as there are characters in the protein sequence
            for (int i = 0; i < protein_sequence.Length; i++)
            {
                if ((protein_sequence[i] == 'N') && (i < protein_sequence.Length) && (i + 1 < protein_sequence.Length) && (i + 2 < protein_sequence.Length) && (i + 3 < protein_sequence.Length) && (i + 4 < protein_sequence.Length) && (i + 5 < protein_sequence.Length) && (i + 6 < protein_sequence.Length))
                {
                    TotalAsn = TotalAsn + 1;

                    //variables to store sub - sequence
                    char b, c, d, e, f, g, h, j, k, l, m, n;

                    //% it will score amino acid at position i - 6
                    if (i - 6 > 0)
                    {
                        b = protein_sequence[i - 6];
                        switch (protein_sequence[i - 6])
                        {
                            case 'A':
                            case 'D':
                            case 'E':
                            case 'F':
                                score = 0.05;
                                break;
                            case 'R':
                            case 'Q':
                            case 'K':
                            case 'Y':
                                score = 0.04;
                                break;
                            case 'N':
                            case 'T':
                            case 'V':
                                score = 0.07;
                                break;
                            case 'C':
                            case 'W':
                            case 'H':
                            case 'M':
                                score = 0.02;
                                break;
                            case 'G':
                            case 'I':
                            case 'P':
                            case 'S':
                                score = 0.06;
                                break;
                            case 'L':
                                score = 0.09;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 5
                    if (i - 5 > 0)
                    {
                        c = protein_sequence[i - 5];
                        switch (protein_sequence[i - 5])
                        {
                            case 'A':
                            case 'I':
                                score = score * 0.07;
                                break;
                            case 'Q':
                            case 'R':
                            case 'F':
                            case 'Y':
                                score = score * 0.04;
                                break;
                            case 'N':
                            case 'G':
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'D':
                            case 'E':
                            case 'K':
                            case 'P':
                                score = score * 0.05;
                                break;
                            case 'C':
                                score = score * 0.03;
                                break;
                            case 'H':
                            case 'M':
                            case 'W':
                                score = score * 0.02;
                                break;
                            case 'L':
                            case 'S':
                            case 'T':
                                score = score * 0.08;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 4
                    if (i - 4 > 0)
                    {
                        d = protein_sequence[i - 4];
                        switch (protein_sequence[i - 4])
                        {
                            case 'A':
                            case 'E':
                            case 'K':
                            case 'F':
                            case 'P':
                            case 'Y':
                                score = score * 0.05;
                                break;
                            case 'R':
                            case 'D':
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'C':
                            case 'H':
                                score = score * 0.03;
                                break;
                            case 'G':
                            case 'S':
                            case 'T':
                                score = score * 0.07;
                                break;
                            case 'I':
                            case 'N':
                                score = score * 0.06;
                                break;
                            case 'L':
                                score = score * 0.09;
                                break;
                            case 'M':
                            case 'W':
                                score = score * 0.02;
                                break;
                            case 'V':
                                score = score * 0.08;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 3
                    if (i - 3 > 0)
                    {
                        e = protein_sequence[i - 3];
                        switch (protein_sequence[i - 3])
                        {
                            case 'A':
                            case 'T':
                                score = score * 0.06;
                                break;
                            case 'R':
                            case 'N':
                            case 'E':
                            case 'I':
                            case 'P':
                            case 'Y':
                                score = score * 0.05;
                                break;
                            case 'D':
                            case 'Q':
                            case 'F':
                                score = score * 0.04;
                                break;
                            case 'C':
                                score = score * 0.03;
                                break;
                            case 'G':
                            case 'K':
                            case 'S':
                                score = score * 0.07;
                                break;
                            case 'H':
                            case 'M':
                            case 'W':
                                score = score * 0.02;
                                break;
                            case 'L':
                            case 'V':
                                score = score * 0.08;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 2
                    if (i - 2 > 0)
                    {
                        f = protein_sequence[i - 2];
                        switch (protein_sequence[i - 2])
                        {
                            case 'A':
                            case 'G':
                            case 'I':
                            case 'F':
                                score = score * 0.06;
                                break;
                            case 'R':
                            case 'D':
                            case 'Q':
                            case 'K':
                                score = score * 0.04;
                                break;
                            case 'N':
                            case 'E':
                            case 'P':
                            case 'Y':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'H':
                                score = score * 0.03;
                                break;
                            case 'L':
                                score = score * 0.1;
                                break;
                            case 'M':
                            case 'W':
                                score = score * 0.02;
                                break;
                            case 'S':
                            case 'T':
                            case 'V':
                                score = score * 0.07;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 1
                    if (i - 1 > 0)
                    {
                        g = protein_sequence[i - 1];
                        switch (protein_sequence[i - 1])
                        {
                            case 'A':
                            case 'G':
                            case 'T':
                                score = score * 0.07;
                                break;
                            case 'R':
                            case 'N':
                            case 'I':
                            case 'F':
                            case 'Y':
                                score = score * 0.05;
                                break;
                            case 'D':
                            case 'E':
                            case 'K':
                            case 'P':
                                score = score * 0.04;
                                break;
                            case 'C':
                            case 'Q':
                                score = score * 0.03;
                                break;
                            case 'H':
                            case 'W':
                                score = score * 0.02;
                                break;
                            case 'L':
                                score = score * 0.1;
                                break;
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'S':
                                score = score * 0.09;
                                break;
                            case 'V':
                                score = score * 0.08;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 1
                    if (protein_sequence.Length >= i + 1)
                    {
                        h = protein_sequence[i + 1];
                        switch (protein_sequence[i + 1])
                        {
                            case 'A':
                            case 'T':
                                score = score * 0.06;
                                break;
                            case 'R':
                                score = score * 0.03;
                                break;
                            case 'N':
                            case 'D':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'E':
                            case 'Q':
                            case 'K':
                            case 'F':
                            case 'Y':
                                score = score * 0.04;
                                break;
                            case 'G':
                            case 'S':
                                score = score * 0.9;
                                break;
                            case 'H':
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'I':
                            case 'L':
                                score = score * 0.08;
                                break;
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'P':
                                score = score * 0;
                                break;
                            case 'V':
                                score = score * 0.1;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 2
                    if (protein_sequence.Length >= i + 2)
                    {
                        j = protein_sequence[i + 2];
                        switch (protein_sequence[i + 2])
                        {
                            case 'S':
                                score = score * 0.36;
                                break;
                            case 'T':
                                score = score * 0.63;
                                break;
                            default:
                                score = score * 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 3
                    if (protein_sequence.Length >= i + 3)
                    {
                        k = protein_sequence[i + 3];
                        switch (protein_sequence[i + 3])
                        {
                            case 'A':
                            case 'G':
                            case 'E':
                            case 'I':
                                score = score * 0.06;
                                break;
                            case 'R':
                            case 'Q':
                            case 'Y':
                                score = score * 0.04;
                                break;
                            case 'N':
                            case 'D':
                            case 'K':
                            case 'F':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0.03;
                                break;
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'L':
                                score = score * 0.11;
                                break;
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'T':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'S':
                                score = score * 0.09;
                                break;
                            case 'P':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 4
                    if (protein_sequence.Length >= i + 4)
                    {
                        l = protein_sequence[i + 4];
                        switch (protein_sequence[i + 4])
                        {
                            case 'A':
                            case 'N':
                            case 'E':
                            case 'P':
                                score = score * 0.06;
                                break;
                            case 'R':
                            case 'Q':
                            case 'K':
                            case 'Y':
                                score = score * 0.04;
                                break;
                            case 'D':
                            case 'G':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'H':
                            case 'M':
                            case 'W':
                                score = score * 0.02;
                                break;
                            case 'I':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'L':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'S':
                                score = score * 0.08;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 5
                    if (protein_sequence.Length >= i + 5)
                    {
                        m = protein_sequence[i + 5];
                        switch (protein_sequence[i + 5])
                        {
                            case 'A':
                            case 'N':
                            case 'D':
                            case 'G':
                            case 'E':
                                score = score * 0.06;
                                break;
                            case 'R':
                            case 'Q':
                            case 'K':
                            case 'F':
                            case 'Y':
                                score = score * 0.04;
                                break;
                            case 'C':
                                score = score * 0.03;
                                break;
                            case 'H':
                            case 'M':
                            case 'W':
                                score = score * 0.02;
                                break;
                            case 'I':
                            case 'S':
                                score = score * 0.07;
                                break;
                            case 'L':
                                score = score * 0.1;
                                break;
                            case 'P':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'V':
                                score = score * 0.08;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 6
                    if (protein_sequence.Length >= i + 6)
                    {
                        n = protein_sequence[i + 6];
                        switch (protein_sequence[i + 6])
                        {
                            case 'A':
                            case 'R':
                            case 'D':
                                score = score * 0.05;
                                break;
                            case 'N':
                            case 'E':
                            case 'I':
                            case 'P':
                                score = score * 0.06;
                                break;
                            case 'C':
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'G':
                            case 'T':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'Q':
                            case 'K':
                            case 'Y':
                                score = score * 0.04;
                                break;
                            case 'H':
                            case 'W':
                                score = score * 0.02;
                                break;
                            case 'L':
                            case 'S':
                                score = score * 0.09;
                                break;
                            case 'M':
                                score = score * 0.01;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    // score scaling according to higest score
                    score = normalize(score, 9);

                    if ((score >= PTM_tolerance) && (i - 6 >= 0) && (i - 5 >= 0) && (i - 4 >= 0) && (i - 3 >= 0) && (i - 2 >= 0) && (i - 1 >= 0))
                    {
                        b = protein_sequence[i - 6];
                        c = protein_sequence[i - 5];
                        d = protein_sequence[i - 4];
                        e = protein_sequence[i - 3];
                        f = protein_sequence[i - 2];
                        g = protein_sequence[i - 1];
                        h = protein_sequence[i + 1];
                        j = protein_sequence[i + 2];
                        k = protein_sequence[i + 3];
                        l = protein_sequence[i + 4];
                        m = protein_sequence[i + 5];
                        n = protein_sequence[i + 6];

                        //% it stores the protein sub-sequence
                        AA.Add(b);
                        AA.Add(c);
                        AA.Add(d);
                        AA.Add(e);
                        AA.Add(f);
                        AA.Add(g);
                        AA.Add(protein_sequence[i]);
                        AA.Add(protein_sequence[i + 1]);
                        AA.Add(h);
                        AA.Add(j);
                        AA.Add(k);
                        AA.Add(l);
                        AA.Add(m);
                        AA.Add(n);

                        // Storing the data in the list "array"
                        array.Add(new Sites(i, score, mod_weight, mod_name, site, AA));

                        objectArrayIndex++;

                        // score of Asparagine at that position
                    }
                }

                // for the TotalAsn if condition coming up ahead
                index = i;
            }

            // it displays total number of Asparagine found in sequence
            if (index == protein_sequence.Length)
            {
                Console.WriteLine("Total Asparagine found: " + TotalAsn);
            }
            //disp(['Total Asparagine found: ', num2str(TotalAsn)])

            // returning the object array
            return array;
        }

        // Function (O_linked_glycosylation_T): Returns an object array with all the required parameters stored
        public static List<Sites> O_linked_glycosylation_T(string protein_sequence, double PTM_tolerance)
        {
            //Sequence of protein
            //protein_sequence = "MAPNASCLCVHVRSEEWDLMTFDANPYDSVKKIKEHVRSKTKVPVQDQVLLLGSKILKPRRSLSSYGIDKEKTIHLTLKVVKPSDEELPLFLVESGDEAKRHLLQVRRSSSVAQVKAMIETKTGIIPETQIVTCNGKRLEDGKMMADYGIRKGNLLFLACYCIGG";

            setAASize(13);

            double mod_weight = 203.079;
            string mod_name = "O-Linked Glycosylation";
            char site = 'T';

            setsiteDetect(site);

            // variable score is initialized
            double score = 0;

            // Variable to store total number of Threonine
            int TotalThr = 0;

            // stores the amino acids found
            List<char> AA = new List<char>();

            // list "array" creation
            List<Sites> array = new List<Sites>();

            // a higher scope variable declared to show the TotalThr (if statement at the end)
            int index = 0;

            // an indexing variable to iterate the dynamic array "array"
            int objectArrayIndex = 0;

            // for loop run for as many times as there are characters in the protein sequence
            for (int i = 0; i < protein_sequence.Length; i++)
            {
                if ((protein_sequence[i] == 'T') && (i < protein_sequence.Length) && (i + 1 < protein_sequence.Length) && (i + 2 < protein_sequence.Length) && (i + 3 < protein_sequence.Length) && (i + 4 < protein_sequence.Length) && (i + 5 < protein_sequence.Length) && (i + 6 < protein_sequence.Length))
                {
                    TotalThr = TotalThr + 1;

                    //variables to store sub - sequence
                    char a, b, c, d, e, f, g, h, m, j, k, l;

                    //It saves the score for i + 1 position
                    if (protein_sequence.Length >= i + 1)
                    {
                        l = protein_sequence[i + 1];
                        switch (protein_sequence[i + 1])
                        {
                            case 'Y':
                                score = 0.01;
                                break;
                            case 'N':
                            case 'I':
                            case 'M':
                            case 'F':
                                score = 0.02;
                                break;
                            case 'D':
                                score = 0.03;
                                break;
                            case 'R':
                            case 'G':
                            case 'E':
                            case 'L':
                                score = 0.04;
                                break;
                            case 'K':
                                score = 0.06;
                                break;
                            case 'P':
                                score = 0.07;
                                break;
                            case 'Q':
                            case 'V':
                                score = 0.08;
                                break;
                            case 'A':
                                score = 0.1;
                                break;
                            case 'T':
                                score = 0.14;
                                break;
                            case 'S':
                                score = 0.17;
                                break;
                            case 'C':
                            case 'H':
                            case 'W':
                                score = 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 2 position
                    if (protein_sequence.Length >= i + 2)
                    {
                        k = protein_sequence[i + 2];
                        switch (protein_sequence[i + 2])
                        {
                            case 'N':
                                score = score * 0.01;
                                break;
                            case 'D':
                            case 'E':
                            case 'Q':
                            case 'I':
                            case 'K':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'L':
                                score = score * 0.03;
                                break;
                            case 'R':
                            case 'H':
                                score = score * 0.04;
                                break;
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'G':
                                score = score * 0.08;
                                break;
                            case 'P':
                                score = score * 0.13;
                                break;
                            case 'S':
                            case 'T':
                                score = score * 0.15;
                                break;
                            case 'A':
                                score = score * 0.17;
                                break;
                            case 'C':
                            case 'M':
                            case 'W':
                            case 'Y':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 3 position
                    if (protein_sequence.Length >= i + 3)
                    {
                        j = protein_sequence[i + 3];
                        switch (protein_sequence[i + 3])
                        {
                            case 'C':
                                score = score * 0.01;
                                break;
                            case 'D':
                            case 'I':
                            case 'K':
                            case 'M':
                            case 'F':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'R':
                            case 'N':
                                score = score * 0.03;
                                break;
                            case 'E':
                                score = score * 0.04;
                                break;
                            case 'G':
                                score = score * 0.05;
                                break;
                            case 'Q':
                                score = score * 0.06;
                                break;
                            case 'L':
                                score = score * 0.07;
                                break;
                            case 'T':
                                score = score * 0.09;
                                break;
                            case 'V':
                            case 'P':
                                score = score * 0.11;
                                break;
                            case 'S':
                                score = score * 0.14;
                                break;
                            case 'H':
                            case 'W':
                                score = score * 0;
                                break;
                            case 'A':
                                score = score * 0.13;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 4 position
                    if (protein_sequence.Length >= i + 4)
                    {
                        m = protein_sequence[i + 4];
                        switch (protein_sequence[i + 4])
                        {
                            case 'Q':
                                score = score * 0.01;
                                break;
                            case 'N':
                            case 'H':
                            case 'M':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'D':
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'R':
                            case 'E':
                            case 'P':
                            case 'Y':
                                score = score * 0.04;
                                break;
                            case 'L':
                            case 'K':
                                score = score * 0.05;
                                break;
                            case 'G':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'A':
                                score = score * 0.11;
                                break;
                            case 'S':
                                score = score * 0.14;
                                break;
                            case 'T':
                                score = score * 0.18;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 5 position
                    if (protein_sequence.Length >= i + 5)
                    {
                        h = protein_sequence[i + 5];
                        switch (protein_sequence[i + 5])
                        {
                            case 'C':
                            case 'H':
                            case 'F':
                                score = score * 0.01;
                                break;
                            case 'N':
                            case 'D':
                            case 'E':
                            case 'Q':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'G':
                                score = score * 0.03;
                                break;
                            case 'R':
                            case 'L':
                            case 'K':
                                score = score * 0.08;
                                break;
                            case 'I':
                            case 'V':
                                score = score * 0.09;
                                break;
                            case 'A':
                            case 'P':
                                score = score * 0.11;
                                break;
                            case 'S':
                            case 'T':
                                score = score * 0.1;
                                break;
                            case 'W':
                            case 'M':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 6 position
                    if (protein_sequence.Length >= i + 6)
                    {
                        g = protein_sequence[i + 6];
                        switch (protein_sequence[i + 6])
                        {
                            case 'N':
                            case 'D':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'C':
                            case 'F':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'L':
                                score = score * 0.03;
                                break;
                            case 'E':
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'R':
                            case 'I':
                                score = score * 0.05;
                                break;
                            case 'Q':
                            case 'H':
                                score = score * 0.06;
                                break;
                            case 'G':
                            case 'K':
                                score = score * 0.07;
                                break;
                            case 'A':
                                score = score * 0.08;
                                break;
                            case 'P':
                                score = score * 0.09;
                                break;
                            case 'T':
                                score = score * 0.13;
                                break;
                            case 'S':
                                score = score * 0.14;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 1
                    if (i - 1 > 0)
                    {
                        f = protein_sequence[i - 1];
                        switch (protein_sequence[i - 1])
                        {
                            case 'D':
                            case 'H':
                            case 'F':
                                score = score * 0.01;
                                break;
                            case 'C':
                            case 'E':
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'R':
                                score = score * 0.03;
                                break;
                            case 'I':
                            case 'L':
                            case 'K':
                                score = score * 0.04;
                                break;
                            case 'Q':
                                score = score * 0.05;
                                break;
                            case 'G':
                                score = score * 0.06;
                                break;
                            case 'A':
                                score = score * 0.1;
                                break;
                            case 'P':
                            case 'S':
                                score = score * 0.12;
                                break;
                            case 'T':
                                score = score * 0.15;
                                break;
                            case 'V':
                                score = score * 0.16;
                                break;
                            case 'W':
                            case 'Y':
                            case 'N':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 2
                    if (i - 2 > 0)
                    {
                        e = protein_sequence[i - 2];
                        switch (protein_sequence[i - 2])
                        {
                            case 'D':
                            case 'C':
                            case 'Y':
                            case 'E':
                                score = score * 0.01;
                                break;
                            case 'N':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'R':
                            case 'I':
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'G':
                            case 'L':
                                score = score * 0.07;
                                break;
                            case 'T':
                                score = score * 0.08;
                                break;
                            case 'K':
                            case 'V':
                                score = score * 0.09;
                                break;
                            case 'S':
                                score = score * 0.11;
                                break;
                            case 'A':
                                score = score * 0.12;
                                break;
                            case 'P':
                                score = score * 0.16;
                                break;
                            case 'W':
                            case 'M':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 3
                    if (i - 3 > 0)
                    {
                        d = protein_sequence[i - 3];
                        switch (protein_sequence[i - 3])
                        {
                            case 'E':
                            case 'H':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'N':
                            case 'D':
                                score = score * 0.02;
                                break;
                            case 'G':
                                score = score * 0.03;
                                break;
                            case 'Q':
                            case 'I':
                                score = score * 0.04;
                                break;
                            case 'R':
                            case 'A':
                            case 'K':
                                score = score * 0.05;
                                break;
                            case 'Y':
                                score = score * 0.06;
                                break;
                            case 'L':
                                score = score * 0.07;
                                break;
                            case 'T':
                                score = score * 0.09;
                                break;
                            case 'S':
                                score = score * 0.11;
                                break;
                            case 'V':
                                score = score * 0.15;
                                break;
                            case 'P':
                                score = score * 0.17;
                                break;
                            case 'C':
                            case 'M':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 4
                    if (i - 4 > 0)
                    {
                        c = protein_sequence[i - 4];
                        switch (protein_sequence[i - 4])
                        {
                            case 'H':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'N':
                            case 'I':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'D':
                            case 'G':
                            case 'L':
                            case 'V':
                            case 'R':
                                score = score * 0.05;
                                break;
                            case 'E':
                            case 'Q':
                            case 'K':
                                score = score * 0.06;
                                break;
                            case 'P':
                                score = score * 0.07;
                                break;
                            case 'A':
                                score = score * 0.1;
                                break;
                            case 'T':
                                score = score * 0.13;
                                break;
                            case 'S':
                                score = score * 0.15;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 5
                    if (i - 5 > 0)
                    {
                        b = protein_sequence[i - 5];
                        switch (protein_sequence[i - 5])
                        {
                            case 'M':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'N':
                            case 'C':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'H':
                                score = score * 0.03;
                                break;
                            case 'I':
                            case 'G':
                            case 'E':
                                score = score * 0.04;
                                break;
                            case 'A':
                            case 'D':
                            case 'Q':
                                score = score * 0.05;
                                break;
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'L':
                            case 'K':
                                score = score * 0.07;
                                break;
                            case 'S':
                            case 'R':
                                score = score * 0.08;
                                break;
                            case 'P':
                                score = score * 0.11;
                                break;
                            case 'T':
                                score = score * 0.13;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 6
                    if (i - 6 > 0)
                    {
                        a = protein_sequence[i - 6];
                        switch (protein_sequence[i - 6])
                        {
                            case 'N':
                                score = score * 0.01;
                                break;
                            case 'D':
                            case 'Q':
                            case 'H':
                            case 'M':
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'R':
                            case 'I':
                            case 'L':
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'E':
                                score = score * 0.05;
                                break;
                            case 'G':
                                score = score * 0.07;
                                break;
                            case 'K':
                                score = score * 0.08;
                                break;
                            case 'A':
                                score = score * 0.09;
                                break;
                            case 'P':
                                score = score * 0.11;
                                break;
                            case 'S':
                                score = score * 0.16;
                                break;
                            case 'T':
                                score = score * 0.1;
                                break;
                            case 'W':
                            case 'Y':
                            case 'C':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    // score scaling according to higest score
                    score = normalize(score, 10);

                    if ((score >= PTM_tolerance) && (i - 6 >= 0) && (i - 5 >= 0) && (i - 4 >= 0) && (i - 3 >= 0) && (i - 2 >= 0) && (i - 1 >= 0))
                    {
                        l = protein_sequence[i + 1];
                        k = protein_sequence[i + 2];
                        j = protein_sequence[i + 3];
                        m = protein_sequence[i + 4];
                        h = protein_sequence[i + 5];
                        g = protein_sequence[i + 6];
                        f = protein_sequence[i - 1];
                        e = protein_sequence[i - 2];
                        d = protein_sequence[i - 3];
                        c = protein_sequence[i - 4];
                        b = protein_sequence[i - 5];
                        a = protein_sequence[i - 6];

                        //% it stores the protein sub-sequence
                        AA.Add(a);
                        AA.Add(b);
                        AA.Add(c);
                        AA.Add(d);
                        AA.Add(e);
                        AA.Add(f);
                        AA.Add(protein_sequence[i]);
                        AA.Add(l);
                        AA.Add(k);
                        AA.Add(j);
                        AA.Add(m);
                        AA.Add(h);
                        AA.Add(g);

                        // Storing the data in the list "array"
                        array.Add(new Sites(i, score, mod_weight, mod_name, site, AA));

                        objectArrayIndex++;

                        // score of Threonine at that position
                    }
                }

                // for the TotalThr if condition coming up ahead
                index = i;
            }

            // it displays total number of Threonine found in sequence
            if (index == protein_sequence.Length)
            {
                Console.WriteLine("Total Threonine found: " + TotalThr);
            }
            //disp(['Total Threonine found: ', num2str(TotalThr)])

            // returning the object array
            return array;
        }

        // Function (O_linked_glycosylation_S): Returns an object array with all the required parameters stored
        public static List<Sites> O_linked_glycosylation_S(string protein_sequence, double PTM_tolerance)
        {
            //Sequence of protein
            //protein_sequence = "MAPNASCLCVHVRSEEWDLMTFDANPYDSVKKIKEHVRSKTKVPVQDQVLLLGSKILKPRRSLSSYGIDKEKTIHLTLKVVKPSDEELPLFLVESGDEAKRHLLQVRRSSSVAQVKAMIETKTGIIPETQIVTCNGKRLEDGKMMADYGIRKGNLLFLACYCIGG";

            setAASize(13);

            double mod_weight = 203.079;
            string mod_name = "O-Linked Glycosylation";
            char site = 'S';

            setsiteDetect(site);

            // variable score is initialized
            double score = 0;

            // Variable to store total number of Serine
            int TotalSer = 0;

            // stores the amino acids found
            List<char> AA = new List<char>();

            // list "array" creation
            List<Sites> array = new List<Sites>();

            // a higher scope variable declared to show the TotalSer (if statement at the end)
            int index = 0;

            // an indexing variable to iterate the dynamic array "array"
            int objectArrayIndex = 0;

            // for loop run for as many times as there are characters in the protein sequence
            for (int i = 0; i < protein_sequence.Length; i++)
            {
                if ((protein_sequence[i] == 'S') && (i < protein_sequence.Length) && (i + 1 < protein_sequence.Length) && (i + 2 < protein_sequence.Length) && (i + 3 < protein_sequence.Length) && (i + 4 < protein_sequence.Length) && (i + 5 < protein_sequence.Length) && (i + 6 < protein_sequence.Length))
                {
                    TotalSer = TotalSer + 1;

                    //variables to store sub - sequence
                    char a, b, c, d, e, f, g, h, m, j, k, l;

                    //It saves the score for i + 1 position
                    if (protein_sequence.Length >= i + 1)
                    {
                        l = protein_sequence[i + 1];
                        switch (protein_sequence[i + 1])
                        {
                            case 'C':
                            case 'H':
                            case 'Y':
                                score = 0.01;
                                break;
                            case 'D':
                            case 'I':
                            case 'K':
                                score = 0.02;
                                break;
                            case 'Q':
                            case 'V':
                                score = 0.03;
                                break;
                            case 'R':
                                score = 0.04;
                                break;
                            case 'G':
                                score = 0.06;
                                break;
                            case 'L':
                                score = 0.07;
                                break;
                            case 'S':
                                score = 0.09;
                                break;
                            case 'P':
                                score = 0.1;
                                break;
                            case 'E':
                                score = 0.16;
                                break;
                            case 'A':
                                score = 0.14;
                                break;
                            case 'T':
                                score = 0.2;
                                break;
                            case 'N':
                            case 'M':
                            case 'F':
                            case 'W':
                                score = 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 2 position
                    if (protein_sequence.Length >= i + 2)
                    {
                        k = protein_sequence[i + 2];
                        switch (protein_sequence[i + 2])
                        {
                            case 'D':
                            case 'K':
                            case 'M':
                            case 'F':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'Q':
                            case 'I':
                            case 'L':
                                score = score * 0.02;
                                break;
                            case 'R':
                            case 'E':
                                score = score * 0.03;
                                break;
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'T':
                                score = score * 0.07;
                                break;
                            case 'G':
                                score = score * 0.11;
                                break;
                            case 'S':
                                score = score * 0.12;
                                break;
                            case 'P':
                                score = score * 0.17;
                                break;
                            case 'A':
                                score = score * 0.3;
                                break;
                            case 'N':
                            case 'C':
                            case 'H':
                            case 'Y':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 3 position
                    if (protein_sequence.Length >= i + 3)
                    {
                        j = protein_sequence[i + 3];
                        switch (protein_sequence[i + 3])
                        {
                            case 'R':
                            case 'N':
                            case 'C':
                            case 'M':
                            case 'F':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'E':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Q':
                            case 'L':
                                score = score * 0.03;
                                break;
                            case 'I':
                                score = score * 0.04;
                                break;
                            case 'G':
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'S':
                                score = score * 0.08;
                                break;
                            case 'D':
                                score = score * 0.09;
                                break;
                            case 'T':
                                score = score * 0.1;
                                break;
                            case 'A':
                                score = score * 0.17;
                                break;
                            case 'W':
                            case 'K':
                                score = score * 0;
                                break;
                            case 'P':
                                score = score * 0.26;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 4 position
                    if (protein_sequence.Length >= i + 4)
                    {
                        m = protein_sequence[i + 4];
                        switch (protein_sequence[i + 4])
                        {
                            case 'R':
                            case 'E':
                            case 'M':
                            case 'W':
                            case 'Y':
                            case 'H':
                                score = score * 0.01;
                                break;
                            case 'N':
                            case 'D':
                            case 'Q':
                            case 'K':
                                score = score * 0.02;
                                break;
                            case 'I':
                            case 'L':
                                score = score * 0.04;
                                break;
                            case 'G':
                                score = score * 0.05;
                                break;
                            case 'A':
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'S':
                                score = score * 0.11;
                                break;
                            case 'T':
                                score = score * 0.31;
                                break;
                            case 'P':
                                score = score * 0.2;
                                break;
                            case 'C':
                            case 'F':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 5 position
                    if (protein_sequence.Length >= i + 5)
                    {
                        h = protein_sequence[i + 5];
                        switch (protein_sequence[i + 5])
                        {
                            case 'C':
                            case 'M':
                            case 'F':
                                score = score * 0.01;
                                break;
                            case 'N':
                            case 'D':
                            case 'E':
                            case 'I':
                            case 'K':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'Q':
                            case 'H':
                                score = score * 0.03;
                                break;
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'L':
                                score = score * 0.07;
                                break;
                            case 'S':
                            case 'T':
                                score = score * 0.08;
                                break;
                            case 'R':
                                score = score * 0.1;
                                break;
                            case 'G':
                                score = score * 0.16;
                                break;
                            case 'P':
                                score = score * 0.11;
                                break;
                            case 'A':
                                score = score * 0.14;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 6 position
                    if (protein_sequence.Length >= i + 6)
                    {
                        g = protein_sequence[i + 6];
                        switch (protein_sequence[i + 6])
                        {
                            case 'D':
                            case 'C':
                            case 'M':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'E':
                            case 'I':
                            case 'K':
                                score = score * 0.02;
                                break;
                            case 'Q':
                                score = score * 0.03;
                                break;
                            case 'R':
                                score = score * 0.04;
                                break;
                            case 'A':
                            case 'G':
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'L':
                                score = score * 0.07;
                                break;
                            case 'T':
                                score = score * 0.09;
                                break;
                            case 'H':
                                score = score * 0.1;
                                break;
                            case 'S':
                                score = score * 0.12;
                                break;
                            case 'P':
                                score = score * 0.29;
                                break;
                            case 'W':
                            case 'F':
                            case 'N':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 1
                    if (i - 1 > 0)
                    {
                        f = protein_sequence[i - 1];
                        switch (protein_sequence[i - 1])
                        {
                            case 'R':
                            case 'N':
                            case 'E':
                            case 'H':
                            case 'K':
                            case 'M':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'Q':
                                score = score * 0.02;
                                break;
                            case 'L':
                                score = score * 0.03;
                                break;
                            case 'I':
                            case 'F':
                                score = score * 0.04;
                                break;
                            case 'A':
                                score = score * 0.06;
                                break;
                            case 'V':
                                score = score * 0.08;
                                break;
                            case 'S':
                                score = score * 0.09;
                                break;
                            case 'G':
                                score = score * 0.13;
                                break;
                            case 'P':
                                score = score * 0.14;
                                break;
                            case 'T':
                                score = score * 0.31;
                                break;
                            case 'W':
                            case 'C':
                            case 'D':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 2
                    if (i - 2 > 0)
                    {
                        e = protein_sequence[i - 2];
                        switch (protein_sequence[i - 2])
                        {
                            case 'C':
                            case 'D':
                            case 'H':
                            case 'I':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'R':
                            case 'Q':
                            case 'L':
                            case 'K':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'E':
                                score = score * 0.04;
                                break;
                            case 'N':
                            case 'G':
                            case 'T':
                                score = score * 0.06;
                                break;
                            case 'S':
                                score = score * 0.11;
                                break;
                            case 'V':
                                score = score * 0.13;
                                break;
                            case 'P':
                                score = score * 0.21;
                                break;
                            case 'A':
                                score = score * 0.18;
                                break;
                            case 'W':
                            case 'F':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 3
                    if (i - 3 > 0)
                    {
                        d = protein_sequence[i - 3];
                        switch (protein_sequence[i - 3])
                        {
                            case 'N':
                            case 'C':
                            case 'H':
                            case 'K':
                            case 'M':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'R':
                            case 'Q':
                            case 'I':
                            case 'L':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'W':
                                score = score * 0.03;
                                break;
                            case 'E':
                                score = score * 0.04;
                                break;
                            case 'S':
                            case 'T':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'G':
                                score = score * 0.12;
                                break;
                            case 'A':
                                score = score * 0.14;
                                break;
                            case 'D':
                                score = score * 0.15;
                                break;
                            case 'P':
                                score = score * 0.16;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 4
                    if (i - 4 > 0)
                    {
                        c = protein_sequence[i - 4];
                        switch (protein_sequence[i - 4])
                        {
                            case 'C':
                            case 'W':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'R':
                            case 'Q':
                            case 'I':
                            case 'M':
                            case 'F':
                            case 'V':
                            case 'N':
                                score = score * 0.02;
                                break;
                            case 'G':
                            case 'K':
                                score = score * 0.04;
                                break;
                            case 'L':
                            case 'E':
                                score = score * 0.05;
                                break;
                            case 'T':
                                score = score * 0.07;
                                break;
                            case 'A':
                                score = score * 0.08;
                                break;
                            case 'H':
                                score = score * 0.09;
                                break;
                            case 'S':
                                score = score * 0.11;
                                break;
                            case 'P':
                                score = score * 0.16;
                                break;
                            case 'D':
                                score = score * 0.14;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 5
                    if (i - 5 > 0)
                    {
                        b = protein_sequence[i - 5];
                        switch (protein_sequence[i - 5])
                        {
                            case 'N':
                            case 'H':
                            case 'F':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'I':
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'D':
                            case 'Q':
                                score = score * 0.03;
                                break;
                            case 'V':
                            case 'L':
                                score = score * 0.04;
                                break;
                            case 'E':
                                score = score * 0.05;
                                break;
                            case 'K':
                            case 'S':
                                score = score * 0.07;
                                break;
                            case 'P':
                                score = score * 0.08;
                                break;
                            case 'T':
                                score = score * 0.09;
                                break;
                            case 'R':
                                score = score * 0.1;
                                break;
                            case 'A':
                                score = score * 0.14;
                                break;
                            case 'G':
                                score = score * 0.17;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 6
                    if (i - 6 > 0)
                    {
                        a = protein_sequence[i - 6];
                        switch (protein_sequence[i - 6])
                        {
                            case 'M':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'D':
                            case 'C':
                            case 'Q':
                            case 'H':
                            case 'K':
                            case 'F':
                            case 'W':
                                score = score * 0.02;
                                break;
                            case 'R':
                            case 'N':
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'E':
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'G':
                            case 'L':
                                score = score * 0.05;
                                break;
                            case 'A':
                                score = score * 0.07;
                                break;
                            case 'P':
                                score = score * 0.18;
                                break;
                            case 'S':
                                score = score * 0.21;
                                break;
                            case 'T':
                                score = score * 0.14;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    // score scaling according to higest score
                    score = normalize(score, 11);

                    if ((score >= PTM_tolerance) && (i - 6 >= 0) && (i - 5 >= 0) && (i - 4 >= 0) && (i - 3 >= 0) && (i - 2 >= 0) && (i - 1 >= 0))
                    {
                        l = protein_sequence[i + 1];
                        k = protein_sequence[i + 2];
                        j = protein_sequence[i + 3];
                        m = protein_sequence[i + 4];
                        h = protein_sequence[i + 5];
                        g = protein_sequence[i + 6];
                        f = protein_sequence[i - 1];
                        e = protein_sequence[i - 2];
                        d = protein_sequence[i - 3];
                        c = protein_sequence[i - 4];
                        b = protein_sequence[i - 5];
                        a = protein_sequence[i - 6];

                        //% it stores the protein sub-sequence
                        AA.Add(a);
                        AA.Add(b);
                        AA.Add(c);
                        AA.Add(d);
                        AA.Add(e);
                        AA.Add(f);
                        AA.Add(protein_sequence[i]);
                        AA.Add(l);
                        AA.Add(k);
                        AA.Add(j);
                        AA.Add(m);
                        AA.Add(h);
                        AA.Add(g);

                        // Storing the data in the list "array"
                        array.Add(new Sites(i, score, mod_weight, mod_name, site, AA));

                        objectArrayIndex++;

                        // score of Serine at that position
                    }
                }

                // for the TotalSer if condition coming up ahead
                index = i;
            }

            // it displays total number of Serine found in sequence
            if (index == protein_sequence.Length)
            {
                Console.WriteLine("Total Serine found: " + TotalSer);
            }
            //disp(['Total Serine found: ', num2str(TotalSer)])

            // returning the object array
            return array;
        }

        // Function (Phosphorylation_S): Returns an object array with all the required parameters stored
        public static List<Sites> Phosphorylation_S(string protein_sequence, double PTM_tolerance)
        {
            //Sequence of protein
            //protein_sequence = "MAPNASCLCVHVRSEEWDLMTFDANPYDSVKKIKEHVRSKTKVPVQDQVLLLGSKILKPRRSLSSYGIDKEKTIHLTLKVVKPSDEELPLFLVESGDEAKRHLLQVRRSSSVAQVKAMIETKTGIIPETQIVTCNGKRLEDGKMMADYGIRKGNLLFLACYCIGG";

            setAASize(13);

            double mod_weight = 79.9663;
            string mod_name = "Phosphorylation";
            char site = 'S';

            setsiteDetect(site);

            // variable score is initialized
            double score = 0;

            // Variable to store total number of Serine
            int TotalSer = 0;

            // stores the amino acids found
            List<char> AA = new List<char>();

            // list "array" creation
            List<Sites> array = new List<Sites>();

            // a higher scope variable declared to show the TotalSer (if statement at the end)
            int index = 0;

            // an indexing variable to iterate the dynamic array "array"
            int objectArrayIndex = 0;

            // for loop run for as many times as there are characters in the protein sequence
            for (int i = 0; i < protein_sequence.Length; i++)
            {
                if ((protein_sequence[i] == 'S') && (i < protein_sequence.Length) && (i + 1 < protein_sequence.Length) && (i + 2 < protein_sequence.Length) && (i + 3 < protein_sequence.Length) && (i + 4 < protein_sequence.Length) && (i + 5 < protein_sequence.Length) && (i + 6 < protein_sequence.Length))
                {
                    TotalSer = TotalSer + 1;

                    //variables to store sub - sequence
                    char b, c, d, e, f, g, h, j, k, l, m, n;

                    //% it will score amino acid at position i - 6
                    if (i - 6 > 0)
                    {
                        b = protein_sequence[i - 6];
                        switch (protein_sequence[i - 6])
                        {
                            case 'A':
                            case 'G':
                            case 'L':
                            case 'K':
                                score = 0.07;
                                break;
                            case 'R':
                            case 'E':
                            case 'P':
                                score = 0.08;
                                break;
                            case 'N':
                            case 'I':
                                score = 0.03;
                                break;
                            case 'D':
                            case 'V':
                                score = 0.05;
                                break;
                            case 'C':
                                score = 0.01;
                                break;
                            case 'Q':
                                score = 0.04;
                                break;
                            case 'H':
                            case 'M':
                            case 'F':
                            case 'Y':
                                score = 0.02;
                                break;
                            case 'S':
                                score = 0.12;
                                break;
                            case 'T':
                                score = 0.06;
                                break;
                            case 'W':
                                score = 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 5
                    if (i - 5 > 0)
                    {
                        c = protein_sequence[i - 5];
                        switch (protein_sequence[i - 5])
                        {
                            case 'A':
                            case 'G':
                            case 'K':
                                score = score * 0.07;
                                break;
                            case 'R':
                            case 'L':
                                score = score * 0.09;
                                break;
                            case 'N':
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'D':
                                score = score * 0.06;
                                break;
                            case 'C':
                                score = score * 0.01;
                                break;
                            case 'E':
                            case 'P':
                                score = score * 0.08;
                                break;
                            case 'H':
                            case 'M':
                            case 'F':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            case 'T':
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'S':
                                score = score * 0.12;
                                break;
                            case 'Q':
                                score = score * 0.04;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 4
                    if (i - 4 > 0)
                    {
                        d = protein_sequence[i - 4];
                        switch (protein_sequence[i - 4])
                        {
                            case 'A':
                            case 'G':
                            case 'L':
                            case 'K':
                                score = score * 0.07;
                                break;
                            case 'R':
                            case 'E':
                            case 'P':
                                score = score * 0.08;
                                break;
                            case 'N':
                                score = score * 0.04;
                                break;
                            case 'D':
                            case 'Q':
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'H':
                            case 'F':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            case 'T':
                                score = score * 0.06;
                                break;
                            case 'S':
                                score = score * 0.14;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 3
                    if (i - 3 > 0)
                    {
                        e = protein_sequence[i - 3];
                        switch (protein_sequence[i - 3])
                        {
                            case 'A':
                            case 'D':
                                score = score * 0.06;
                                break;
                            case 'R':
                                score = score * 0.15;
                                break;
                            case 'N':
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'C':
                            case 'M':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'G':
                            case 'E':
                            case 'L':
                            case 'K':
                            case 'P':
                                score = score * 0.07;
                                break;
                            case 'Q':
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'H':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'S':
                                score = score * 0.13;
                                break;
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 2
                    if (i - 2 > 0)
                    {
                        f = protein_sequence[i - 2];
                        switch (protein_sequence[i - 2])
                        {
                            case 'A':
                            case 'E':
                            case 'L':
                                score = score * 0.07;
                                break;
                            case 'N':
                            case 'Q':
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'R':
                            case 'P':
                                score = score * 0.09;
                                break;
                            case 'C':
                            case 'M':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'G':
                            case 'D':
                            case 'T':
                                score = score * 0.06;
                                break;
                            case 'H':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'K':
                                score = score * 0.05;
                                break;
                            case 'S':
                                score = score * 0.16;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            case 'I':
                                score = score * 0.03;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 1
                    if (i - 1 > 0)
                    {
                        g = protein_sequence[i - 1];
                        switch (protein_sequence[i - 1])
                        {
                            case 'A':
                            case 'R':
                                score = score * 0.07;
                                break;
                            case 'N':
                            case 'Q':
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'D':
                            case 'P':
                                score = score * 0.08;
                                break;
                            case 'C':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'G':
                            case 'L':
                                score = score * 0.09;
                                break;
                            case 'E':
                                score = score * 0.06;
                                break;
                            case 'H':
                            case 'F':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'K':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'S':
                                score = score * 0.12;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 1
                    if (protein_sequence.Length >= i + 1)
                    {
                        h = protein_sequence[i + 1];
                        switch (protein_sequence[i + 1])
                        {
                            case 'A':
                            case 'R':
                            case 'T':
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'N':
                                score = score * 0.02;
                                break;
                            case 'D':
                            case 'L':
                                score = score * 0.08;
                                break;
                            case 'C':
                            case 'H':
                            case 'M':
                            case 'W':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'G':
                            case 'Q':
                                score = score * 0.05;
                                break;
                            case 'E':
                                score = score * 0.07;
                                break;
                            case 'I':
                            case 'F':
                            case 'K':
                                score = score * 0.03;
                                break;
                            case 'P':
                                score = score * 0.27;
                                break;
                            case 'S':
                                score = score * 0.1;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 2
                    if (protein_sequence.Length >= i + 2)
                    {
                        j = protein_sequence[i + 2];
                        switch (protein_sequence[i + 2])
                        {
                            case 'A':
                            case 'L':
                            case 'T':
                                score = score * 0.06;
                                break;
                            case 'R':
                            case 'K':
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'N':
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'D':
                            case 'G':
                                score = score * 0.08;
                                break;
                            case 'C':
                            case 'M':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'E':
                                score = score * 0.11;
                                break;
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'H':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'S':
                                score = score * 0.15;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            case 'P':
                                score = score * 0.09;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 3
                    if (protein_sequence.Length >= i + 3)
                    {
                        k = protein_sequence[i + 3];
                        switch (protein_sequence[i + 3])
                        {
                            case 'A':
                            case 'R':
                            case 'L':
                            case 'K':
                                score = score * 0.06;
                                break;
                            case 'N':
                                score = score * 0.03;
                                break;
                            case 'D':
                            case 'P':
                                score = score * 0.08;
                                break;
                            case 'C':
                            case 'M':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'G':
                                score = score * 0.07;
                                break;
                            case 'E':
                                score = score * 0.13;
                                break;
                            case 'Q':
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'H':
                            case 'I':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            case 'S':
                                score = score * 0.14;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 4
                    if (protein_sequence.Length >= i + 4)
                    {
                        l = protein_sequence[i + 4];
                        switch (protein_sequence[i + 4])
                        {
                            case 'A':
                            case 'R':
                            case 'T':
                                score = score * 0.06;
                                break;
                            case 'N':
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'D':
                            case 'G':
                                score = score * 0.07;
                                break;
                            case 'C':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'E':
                                score = score * 0.1;
                                break;
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'H':
                            case 'M':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'L':
                            case 'P':
                                score = score * 0.08;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            case 'V':
                            case 'K':
                                score = score * 0.05;
                                break;
                            case 'S':
                                score = score * 0.14;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 5
                    if (protein_sequence.Length >= i + 5)
                    {
                        m = protein_sequence[i + 5];
                        switch (protein_sequence[i + 5])
                        {
                            case 'A':
                            case 'R':
                            case 'D':
                            case 'L':
                                score = score * 0.07;
                                break;
                            case 'N':
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'C':
                            case 'M':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'G':
                            case 'K':
                                score = score * 0.06;
                                break;
                            case 'T':
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'E':
                            case 'P':
                                score = score * 0.09;
                                break;
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'H':
                            case 'Y':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'S':
                                score = score * 0.12;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 6
                    if (protein_sequence.Length >= i + 6)
                    {
                        n = protein_sequence[i + 6];
                        switch (protein_sequence[i + 6])
                        {
                            case 'A':
                            case 'R':
                            case 'G':
                            case 'L':
                            case 'K':
                                score = score * 0.07;
                                break;
                            case 'N':
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'D':
                            case 'T':
                                score = score * 0.06;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'E':
                                score = score * 0.09;
                                break;
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'H':
                            case 'M':
                            case 'F':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'S':
                                score = score * 0.12;
                                break;
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'P':
                                score = score * 0.08;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    // score scaling according to higest score
                    score = normalize(score, 12);

                    if ((score >= PTM_tolerance) && (i - 6 >= 0) && (i - 5 >= 0) && (i - 4 >= 0) && (i - 3 >= 0) && (i - 2 >= 0) && (i - 1 >= 0))
                    {
                        b = protein_sequence[i - 6];
                        c = protein_sequence[i - 5];
                        d = protein_sequence[i - 4];
                        e = protein_sequence[i - 3];
                        f = protein_sequence[i - 2];
                        g = protein_sequence[i - 1];
                        h = protein_sequence[i + 1];
                        j = protein_sequence[i + 2];
                        k = protein_sequence[i + 3];
                        l = protein_sequence[i + 4];
                        m = protein_sequence[i + 5];
                        n = protein_sequence[i + 6];

                        //% it stores the protein sub-sequence
                        AA.Add(b);
                        AA.Add(c);
                        AA.Add(d);
                        AA.Add(e);
                        AA.Add(f);
                        AA.Add(g);
                        AA.Add(protein_sequence[i]);
                        AA.Add(h);
                        AA.Add(j);
                        AA.Add(k);
                        AA.Add(l);
                        AA.Add(m);
                        AA.Add(n);

                        // Storing the data in the list "array"
                        array.Add(new Sites(i, score, mod_weight, mod_name, site, AA));

                        objectArrayIndex++;

                        // score of Serine at that position
                    }
                }

                // for the TotalSer if condition coming up ahead
                index = i;
            }

            // it displays total number of Serine found in sequence
            if (index == protein_sequence.Length)
            {
                Console.WriteLine("Total Serine found: " + TotalSer);
            }
            //disp(['Total Serine found: ', num2str(TotalSer)])

            // returning the object array
            return array;
        }

        // Function (Phosphorylation_T): Returns an object array with all the required parameters stored
        public static List<Sites> Phosphorylation_T(string protein_sequence, double PTM_tolerance)
        {
            //Sequence of protein
            //protein_sequence = "MAPNASCLCVHVRSEEWDLMTFDANPYDSVKKIKEHVRSKTKVPVQDQVLLLGSKILKPRRSLSSYGIDKEKTIHLTLKVVKPSDEELPLFLVESGDEAKRHLLQVRRSSSVAQVKAMIETKTGIIPETQIVTCNGKRLEDGKMMADYGIRKGNLLFLACYCIGG";

            setAASize(13);

            double mod_weight = 79.9663;
            string mod_name = "Phosphorylation";
            char site = 'T';

            setsiteDetect(site);

            // variable score is initialized
            double score = 0;

            // Variable to store total number of Thrmine
            int TotalThr = 0;

            // stores the amino acids found
            List<char> AA = new List<char>();

            // list "array" creation
            List<Sites> array = new List<Sites>();

            // a higher scope variable declared to show the TotalThr (if statement at the end)
            int index = 0;

            // an indexing variable to iterate the dynamic array "array"
            int objectArrayIndex = 0;

            // for loop run for as many times as there are characters in the protein sequence
            for (int i = 0; i < protein_sequence.Length; i++)
            {
                if ((protein_sequence[i] == 'T') && (i < protein_sequence.Length) && (i + 1 < protein_sequence.Length) && (i + 2 < protein_sequence.Length) && (i + 3 < protein_sequence.Length) && (i + 4 < protein_sequence.Length) && (i + 5 < protein_sequence.Length) && (i + 6 < protein_sequence.Length))
                {
                    TotalThr = TotalThr + 1;

                    //variables to store sub - sequence
                    char b, c, d, e, f, g, h, j, k, l, m, n;

                    //% it will score amino acid at position i - 6
                    if (i - 6 > 0)
                    {
                        b = protein_sequence[i - 6];
                        switch (protein_sequence[i - 6])
                        {
                            case 'A':
                            case 'R':
                            case 'E':
                            case 'L':
                            case 'K':
                                score = 0.07;
                                break;
                            case 'D':
                            case 'V':
                                score = 0.05;
                                break;
                            case 'N':
                            case 'Q':
                            case 'I':
                                score = 0.04;
                                break;
                            case 'C':
                            case 'W':
                                score = 0.01;
                                break;
                            case 'G':
                            case 'T':
                                score = 0.06;
                                break;
                            case 'S':
                                score = 0.12;
                                break;
                            case 'H':
                            case 'M':
                            case 'F':
                            case 'Y':
                                score = 0.02;
                                break;
                            case 'P':
                                score = 0.09;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 5
                    if (i - 5 > 0)
                    {
                        c = protein_sequence[i - 5];
                        switch (protein_sequence[i - 5])
                        {
                            case 'A':
                            case 'R':
                            case 'E':
                            case 'K':
                                score = score * 0.07;
                                break;
                            case 'N':
                            case 'Q':
                            case 'I':
                                score = score * 0.04;
                                break;
                            case 'D':
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'C':
                                score = score * 0.01;
                                break;
                            case 'G':
                            case 'T':
                                score = score * 0.06;
                                break;
                            case 'L':
                                score = score * 0.08;
                                break;
                            case 'H':
                            case 'M':
                            case 'F':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            case 'P':
                                score = score * 0.09;
                                break;
                            case 'S':
                                score = score * 0.11;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 4
                    if (i - 4 > 0)
                    {
                        d = protein_sequence[i - 4];
                        switch (protein_sequence[i - 4])
                        {
                            case 'A':
                            case 'R':
                            case 'G':
                            case 'E':
                            case 'L':
                            case 'K':
                            case 'T':
                                score = score * 0.07;
                                break;
                            case 'D':
                                score = score * 0.06;
                                break;
                            case 'N':
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'H':
                            case 'F':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            case 'P':
                                score = score * 0.08;
                                break;
                            case 'S':
                                score = score * 0.13;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 3
                    if (i - 3 > 0)
                    {
                        e = protein_sequence[i - 3];
                        switch (protein_sequence[i - 3])
                        {
                            case 'A':
                            case 'G':
                            case 'K':
                                score = score * 0.07;
                                break;
                            case 'R':
                                score = score * 0.1;
                                break;
                            case 'N':
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'C':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'E':
                            case 'T':
                                score = score * 0.06;
                                break;
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'H':
                            case 'M':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'L':
                                score = score * 0.08;
                                break;
                            case 'P':
                                score = score * 0.09;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            case 'S':
                                score = score * 0.11;
                                break;
                            case 'D':
                            case 'V':
                                score = score * 0.05;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 2
                    if (i - 2 > 0)
                    {
                        f = protein_sequence[i - 2];
                        switch (protein_sequence[i - 2])
                        {
                            case 'A':
                            case 'E':
                            case 'L':
                            case 'T':
                                score = score * 0.07;
                                break;
                            case 'R':
                            case 'G':
                                score = score * 0.06;
                                break;
                            case 'D':
                            case 'K':
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'C':
                                score = score * 0.01;
                                break;
                            case 'Q':
                            case 'N':
                                score = score * 0.03;
                                break;
                            case 'H':
                            case 'F':
                            case 'M':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'I':
                                score = score * 0.04;
                                break;
                            case 'S':
                                score = score * 0.15;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            case 'P':
                                score = score * 0.11;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 1
                    if (i - 1 > 0)
                    {
                        g = protein_sequence[i - 1];
                        switch (protein_sequence[i - 1])
                        {
                            case 'A':
                            case 'R':
                            case 'E':
                                score = score * 0.07;
                                break;
                            case 'N':
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'D':
                            case 'K':
                                score = score * 0.06;
                                break;
                            case 'C':
                                score = score * 0.01;
                                break;
                            case 'G':
                            case 'L':
                                score = score * 0.08;
                                break;
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'H':
                            case 'M':
                            case 'F':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'P':
                                score = score * 0.1;
                                break;
                            case 'V':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'S':
                                score = score * 0.11;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 1
                    if (protein_sequence.Length >= i + 1)
                    {
                        h = protein_sequence[i + 1];
                        switch (protein_sequence[i + 1])
                        {
                            case 'A':
                            case 'D':
                            case 'G':
                                score = score * 0.05;
                                break;
                            case 'N':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'E':
                            case 'L':
                                score = score * 0.06;
                                break;
                            case 'C':
                            case 'H':
                            case 'M':
                            case 'Y':
                                score = score * 0.01;
                                break;
                            case 'V':
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'I':
                            case 'K':
                            case 'R':
                            case 'T':
                                score = score * 0.03;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            case 'P':
                                score = score * 0.32;
                                break;
                            case 'S':
                                score = score * 0.1;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 2
                    if (protein_sequence.Length >= i + 2)
                    {
                        j = protein_sequence[i + 2];
                        switch (protein_sequence[i + 2])
                        {
                            case 'A':
                            case 'D':
                            case 'G':
                            case 'L':
                            case 'K':
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'R':
                                score = score * 0.05;
                                break;
                            case 'N':
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'E':
                                score = score * 0.09;
                                break;
                            case 'C':
                            case 'M':
                            case 'Y':
                            case 'H':
                                score = score * 0.01;
                                break;
                            case 'T':
                                score = score * 0.07;
                                break;
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            case 'P':
                            case 'S':
                                score = score * 0.13;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 3
                    if (protein_sequence.Length >= i + 3)
                    {
                        k = protein_sequence[i + 3];
                        switch (protein_sequence[i + 3])
                        {
                            case 'A':
                            case 'G':
                            case 'L':
                                score = score * 0.07;
                                break;
                            case 'N':
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'D':
                            case 'R':
                            case 'T':
                                score = score * 0.06;
                                break;
                            case 'C':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'E':
                                score = score * 0.09;
                                break;
                            case 'K':
                                score = score * 0.08;
                                break;
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'H':
                            case 'Y':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'P':
                                score = score * 0.09;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            case 'S':
                                score = score * 0.12;
                                break;
                            case 'V':
                                score = score * 0.05;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 4
                    if (protein_sequence.Length >= i + 4)
                    {
                        l = protein_sequence[i + 4];
                        switch (protein_sequence[i + 4])
                        {
                            case 'A':
                            case 'R':
                            case 'D':
                            case 'G':
                                score = score * 0.06;
                                break;
                            case 'N':
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'E':
                            case 'T':
                                score = score * 0.08;
                                break;
                            case 'C':
                                score = score * 0.01;
                                break;
                            case 'L':
                            case 'K':
                                score = score * 0.07;
                                break;
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'H':
                            case 'M':
                            case 'F':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'P':
                                score = score * 0.09;
                                break;
                            case 'S':
                                score = score * 0.13;
                                break;
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 5
                    if (protein_sequence.Length >= i + 5)
                    {
                        m = protein_sequence[i + 5];
                        switch (protein_sequence[i + 5])
                        {
                            case 'A':
                            case 'R':
                            case 'K':
                            case 'L':
                            case 'T':
                                score = score * 0.07;
                                break;
                            case 'N':
                            case 'I':
                                score = score * 0.03;
                                break;
                            case 'C':
                            case 'H':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'G':
                            case 'D':
                                score = score * 0.06;
                                break;
                            case 'E':
                                score = score * 0.08;
                                break;
                            case 'P':
                                score = score * 0.1;
                                break;
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'Y':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'S':
                                score = score * 0.11;
                                break;
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 6
                    if (protein_sequence.Length >= i + 6)
                    {
                        n = protein_sequence[i + 6];
                        switch (protein_sequence[i + 6])
                        {
                            case 'A':
                            case 'R':
                            case 'L':
                            case 'K':
                                score = score * 0.07;
                                break;
                            case 'N':
                                score = score * 0.03;
                                break;
                            case 'D':
                            case 'G':
                            case 'T':
                                score = score * 0.06;
                                break;
                            case 'C':
                                score = score * 0.01;
                                break;
                            case 'E':
                                score = score * 0.08;
                                break;
                            case 'Q':
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'H':
                            case 'M':
                            case 'F':
                            case 'Y':
                                score = score * 0.02;
                                break;
                            case 'S':
                                score = score * 0.11;
                                break;
                            case 'I':
                                score = score * 0.04;
                                break;
                            case 'P':
                                score = score * 0.09;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    // score scaling according to higest score
                    score = normalize(score, 13);

                    if ((score >= PTM_tolerance) && (i - 6 >= 0) && (i - 5 >= 0) && (i - 4 >= 0) && (i - 3 >= 0) && (i - 2 >= 0) && (i - 1 >= 0))
                    {
                        b = protein_sequence[i - 6];
                        c = protein_sequence[i - 5];
                        d = protein_sequence[i - 4];
                        e = protein_sequence[i - 3];
                        f = protein_sequence[i - 2];
                        g = protein_sequence[i - 1];
                        h = protein_sequence[i + 1];
                        j = protein_sequence[i + 2];
                        k = protein_sequence[i + 3];
                        l = protein_sequence[i + 4];
                        m = protein_sequence[i + 5];
                        n = protein_sequence[i + 6];

                        //% it stores the protein sub-sequence
                        AA.Add(b);
                        AA.Add(c);
                        AA.Add(d);
                        AA.Add(e);
                        AA.Add(f);
                        AA.Add(g);
                        AA.Add(protein_sequence[i]);
                        AA.Add(h);
                        AA.Add(j);
                        AA.Add(k);
                        AA.Add(l);
                        AA.Add(m);
                        AA.Add(n);

                        // Storing the data in the list "array"
                        array.Add(new Sites(i, score, mod_weight, mod_name, site, AA));

                        objectArrayIndex++;

                        // score of Thrmine at that position
                    }
                }

                // for the TotalThr if condition coming up ahead
                index = i;
            }

            // it displays total number of Thrmine found in sequence
            if (index == protein_sequence.Length)
            {
                Console.WriteLine("Total Thrmine found: " + TotalThr);
            }
            //disp(['Total Thrmine found: ', num2str(TotalThr)])

            // returning the object array
            return array;
        }

        // Function (Phosphorylation_Y): Returns an object array with all the required parameters stored
        public static List<Sites> Phosphorylation_Y(string protein_sequence, double PTM_tolerance)
        {
            //Sequence of protein
            //protein_sequence = "MAPNASCLCVHVRSEEWDLMTFDANPYDSVKKIKEHVRSKTKVPVQDQVLLLGSKILKPRRSLSSYGIDKEKTIHLTLKVVKPSDEELPLFLVESGDEAKRHLLQVRRSSSVAQVKAMIETKTGIIPETQIVTCNGKRLEDGKMMADYGIRKGNLLFLACYCIGG";

            setAASize(13);

            double mod_weight = 79.9663;
            string mod_name = "Phosphorylation";
            char site = 'Y';

            setsiteDetect(site);

            // variable score is initialized
            double score = 0;

            // Variable to store total number of Tyrosine
            int TotalTyr = 0;

            // stores the amino acids found
            List<char> AA = new List<char>();

            // list "array" creation
            List<Sites> array = new List<Sites>();

            // a higher scope variable declared to show the TotalTyr (if statement at the end)
            int index = 0;

            // an indexing variable to iterate the dynamic array "array"
            int objectArrayIndex = 0;

            // for loop run for as many times as there are characters in the protein sequence
            for (int i = 0; i < protein_sequence.Length; i++)
            {
                if ((protein_sequence[i] == 'Y') && (i < protein_sequence.Length) && (i + 1 < protein_sequence.Length) && (i + 2 < protein_sequence.Length) && (i + 3 < protein_sequence.Length) && (i + 4 < protein_sequence.Length) && (i + 5 < protein_sequence.Length) && (i + 6 < protein_sequence.Length))
                {
                    TotalTyr = TotalTyr + 1;

                    //variables to store sub - sequence
                    char b, c, d, e, f, g, h, j, k, l, m, n;

                    //% it will score amino acid at position i - 6
                    if (i - 6 > 0)
                    {
                        b = protein_sequence[i - 6];
                        switch (protein_sequence[i - 6])
                        {
                            case 'A':
                            case 'P':
                                score = 0.06;
                                break;
                            case 'R':
                            case 'D':
                            case 'G':
                            case 'K':
                                score = 0.07;
                                break;
                            case 'N':
                            case 'Q':
                            case 'I':
                                score = 0.04;
                                break;
                            case 'C':
                            case 'W':
                                score = 0.01;
                                break;
                            case 'E':
                            case 'L':
                                score = 0.08;
                                break;
                            case 'S':
                                score = 0.09;
                                break;
                            case 'H':
                            case 'M':
                                score = 0.02;
                                break;
                            case 'V':
                            case 'T':
                                score = 0.05;
                                break;
                            case 'F':
                            case 'Y':
                                score = 0.03;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 5
                    if (i - 5 > 0)
                    {
                        c = protein_sequence[i - 5];
                        switch (protein_sequence[i - 5])
                        {
                            case 'A':
                            case 'D':
                            case 'G':
                            case 'L':
                            case 'K':
                            case 'P':
                                score = score * 0.07;
                                break;
                            case 'N':
                            case 'I':
                                score = score * 0.04;
                                break;
                            case 'V':
                            case 'T':
                            case 'Q':
                                score = score * 0.05;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'E':
                                score = score * 0.08;
                                break;
                            case 'S':
                                score = score * 0.09;
                                break;
                            case 'H':
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'F':
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'R':
                                score = score * 0.06;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 4
                    if (i - 4 > 0)
                    {
                        d = protein_sequence[i - 4];
                        switch (protein_sequence[i - 4])
                        {
                            case 'A':
                            case 'R':
                            case 'K':
                                score = score * 0.06;
                                break;
                            case 'N':
                            case 'Q':
                            case 'T':
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'D':
                            case 'G':
                                score = score * 0.08;
                                break;
                            case 'E':
                                score = score * 0.09;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'H':
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'I':
                            case 'F':
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'L':
                            case 'P':
                                score = score * 0.07;
                                break;
                            case 'S':
                                score = score * 0.1;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 3
                    if (i - 3 > 0)
                    {
                        e = protein_sequence[i - 3];
                        switch (protein_sequence[i - 3])
                        {
                            case 'A':
                            case 'R':
                            case 'L':
                            case 'K':
                            case 'P':
                                score = score * 0.06;
                                break;
                            case 'N':
                            case 'Q':
                            case 'V':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'D':
                            case 'S':
                                score = score * 0.09;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'G':
                                score = score * 0.08;
                                break;
                            case 'E':
                                score = score * 0.11;
                                break;
                            case 'H':
                            case 'M':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'I':
                            case 'Y':
                                score = score * 0.03;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 2
                    if (i - 2 > 0)
                    {
                        f = protein_sequence[i - 2];
                        switch (protein_sequence[i - 2])
                        {
                            case 'A':
                                score = score * 0.07;
                                break;
                            case 'R':
                            case 'N':
                            case 'T':
                            case 'V':
                                score = score * 0.05;
                                break;
                            case 'D':
                            case 'G':
                            case 'S':
                                score = score * 0.09;
                                break;
                            case 'C':
                                score = score * 0.01;
                                break;
                            case 'E':
                            case 'P':
                                score = score * 0.08;
                                break;
                            case 'H':
                            case 'F':
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'K':
                            case 'L':
                                score = score * 0.06;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            case 'Y':
                            case 'I':
                                score = score * 0.03;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 1
                    if (i - 1 > 0)
                    {
                        g = protein_sequence[i - 1];
                        switch (protein_sequence[i - 1])
                        {
                            case 'A':
                            case 'P':
                            case 'T':
                                score = score * 0.06;
                                break;
                            case 'N':
                            case 'R':
                            case 'Q':
                                score = score * 0.04;
                                break;
                            case 'D':
                            case 'L':
                                score = score * 0.09;
                                break;
                            case 'C':
                            case 'M':
                                score = score * 0.01;
                                break;
                            case 'G':
                            case 'I':
                            case 'S':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'E':
                                score = score * 0.08;
                                break;
                            case 'H':
                            case 'F':
                                score = score * 0.02;
                                break;
                            case 'K':
                                score = score * 0.05;
                                break;
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'W':
                                score = score * 0;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 1
                    if (protein_sequence.Length >= i + 1)
                    {
                        h = protein_sequence[i + 1];
                        switch (protein_sequence[i + 1])
                        {
                            case 'A':
                            case 'L':
                            case 'G':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'R':
                            case 'Q':
                                score = score * 0.05;
                                break;
                            case 'N':
                            case 'F':
                            case 'P':
                                score = score * 0.03;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'E':
                                score = score * 0.1;
                                break;
                            case 'H':
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'D':
                                score = score * 0.08;
                                break;
                            case 'I':
                            case 'K':
                            case 'Y':
                                score = score * 0.04;
                                break;
                            case 'S':
                                score = score * 0.11;
                                break;
                            case 'T':
                                score = score * 0.06;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 2
                    if (protein_sequence.Length >= i + 2)
                    {
                        j = protein_sequence[i + 2];
                        switch (protein_sequence[i + 2])
                        {
                            case 'A':
                            case 'D':
                            case 'G':
                            case 'L':
                                score = score * 0.07;
                                break;
                            case 'R':
                            case 'N':
                                score = score * 0.05;
                                break;
                            case 'V':
                            case 'T':
                            case 'P':
                            case 'K':
                                score = score * 0.06;
                                break;
                            case 'E':
                                score = score * 0.08;
                                break;
                            case 'C':
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'S':
                                score = score * 0.09;
                                break;
                            case 'Q':
                            case 'I':
                                score = score * 0.04;
                                break;
                            case 'F':
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'W':
                                score = score * 0.01;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 3
                    if (protein_sequence.Length >= i + 3)
                    {
                        k = protein_sequence[i + 3];
                        switch (protein_sequence[i + 3])
                        {
                            case 'A':
                            case 'I':
                            case 'T':
                                score = score * 0.06;
                                break;
                            case 'R':
                            case 'D':
                            case 'G':
                            case 'E':
                            case 'K':
                                score = score * 0.05;
                                break;
                            case 'N':
                            case 'Q':
                            case 'M':
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'L':
                            case 'P':
                                score = score * 0.1;
                                break;
                            case 'F':
                                score = score * 0.04;
                                break;
                            case 'S':
                                score = score * 0.09;
                                break;
                            case 'V':
                                score = score * 0.08;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 4
                    if (protein_sequence.Length >= i + 4)
                    {
                        l = protein_sequence[i + 4];
                        switch (protein_sequence[i + 4])
                        {
                            case 'A':
                            case 'K':
                            case 'D':
                            case 'T':
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'R':
                            case 'G':
                            case 'L':
                            case 'P':
                                score = score * 0.07;
                                break;
                            case 'N':
                            case 'Y':
                                score = score * 0.04;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'E':
                                score = score * 0.08;
                                break;
                            case 'Q':
                                score = score * 0.05;
                                break;
                            case 'H':
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'I':
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'S':
                                score = score * 0.09;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 5
                    if (protein_sequence.Length >= i + 5)
                    {
                        m = protein_sequence[i + 5];
                        switch (protein_sequence[i + 5])
                        {
                            case 'A':
                            case 'R':
                            case 'D':
                                score = score * 0.06;
                                break;
                            case 'N':
                            case 'I':
                            case 'Y':
                            case 'V':
                                score = score * 0.04;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'G':
                            case 'E':
                                score = score * 0.08;
                                break;
                            case 'Q':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'H':
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'L':
                            case 'K':
                            case 'P':
                                score = score * 0.07;
                                break;
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'S':
                                score = score * 0.09;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i + 6
                    if (protein_sequence.Length >= i + 6)
                    {
                        n = protein_sequence[i + 6];
                        switch (protein_sequence[i + 6])
                        {
                            case 'A':
                            case 'R':
                            case 'G':
                            case 'E':
                            case 'K':
                            case 'P':
                                score = score * 0.07;
                                break;
                            case 'N':
                            case 'Q':
                            case 'I':
                            case 'Y':
                                score = score * 0.04;
                                break;
                            case 'D':
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'H':
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'L':
                            case 'S':
                                score = score * 0.08;
                                break;
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'T':
                                score = score * 0.05;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    // score scaling according to higest score
                    score = normalize(score, 14);

                    if ((score >= PTM_tolerance) && (i - 6 >= 0) && (i - 5 >= 0) && (i - 4 >= 0) && (i - 3 >= 0) && (i - 2 >= 0) && (i - 1 >= 0))
                    {
                        b = protein_sequence[i - 6];
                        c = protein_sequence[i - 5];
                        d = protein_sequence[i - 4];
                        e = protein_sequence[i - 3];
                        f = protein_sequence[i - 2];
                        g = protein_sequence[i - 1];
                        h = protein_sequence[i + 1];
                        j = protein_sequence[i + 2];
                        k = protein_sequence[i + 3];
                        l = protein_sequence[i + 4];
                        m = protein_sequence[i + 5];
                        n = protein_sequence[i + 6];

                        //% it stores the protein sub-sequence
                        AA.Add(b);
                        AA.Add(c);
                        AA.Add(d);
                        AA.Add(e);
                        AA.Add(f);
                        AA.Add(g);
                        AA.Add(protein_sequence[i]);
                        AA.Add(h);
                        AA.Add(j);
                        AA.Add(k);
                        AA.Add(l);
                        AA.Add(m);
                        AA.Add(n);

                        // Storing the data in the list "array"
                        array.Add(new Sites(i, score, mod_weight, mod_name, site, AA));

                        objectArrayIndex++;

                        // score of Tyrosine at that position
                    }
                }

                // for the TotalTyr if condition coming up ahead
                index = i;
            }

            // it displays total number of Tyrosine found in sequence
            if (index == protein_sequence.Length)
            {
                Console.WriteLine("Total Tyrosine found: " + TotalTyr);
            }
            //disp(['Total Tyrosine found: ', num2str(TotalTyr)])

            // returning the object array
            return array;
        }

        // Function (Ubiquitination_K): Returns an object array with all the required parameters stored
        public static List<Sites> Ubiquitination_K(string protein_sequence, double PTM_tolerance)
        {
            //Sequence of protein
            //protein_sequence = "MAPNASCLCVHVRSEEWDLMTFDANPYDSVKKIKEHVRSKTKVPVQDQVLLLGSKILKPRRSLSSYGIDKEKTIHLTLKVVKPSDEELPLFLVESGDEAKRHLLQVRRSSSVAQVKAMIETKTGIIPETQIVTCNGKRLEDGKMMADYGIRKGNLLFLACYCIGG";

            setAASize(13);

            double mod_weight = 8561;
            string mod_name = "protein_sequenceation";
            char site = 'K';

            setsiteDetect(site);

            // variable score is initialized
            double score = 0;

            // Variable to store total number of Lysine
            int TotalLys = 0;

            // stores the amino acids found
            List<char> AA = new List<char>();

            // list "array" creation
            List<Sites> array = new List<Sites>();

            // a higher scope variable declared to show the TotalLys (if statement at the end)
            int index = 0;

            // an indexing variable to iterate the dynamic array "array"
            int objectArrayIndex = 0;

            // for loop run for as many times as there are characters in the protein sequence
            for (int i = 0; i < protein_sequence.Length; i++)
            {
                if ((protein_sequence[i] == 'K') && (i < protein_sequence.Length) && (i + 1 < protein_sequence.Length) && (i + 2 < protein_sequence.Length) && (i + 3 < protein_sequence.Length) && (i + 4 < protein_sequence.Length) && (i + 5 < protein_sequence.Length) && (i + 6 < protein_sequence.Length))
                {
                    TotalLys = TotalLys + 1;

                    //variables to store sub - sequence
                    char a, b, c, d, e, f, g, h, m, j, k, l;

                    //It saves the score for i + 1 position
                    if (protein_sequence.Length >= i + 1)
                    {
                        l = (protein_sequence[i + 1]);

                        switch (protein_sequence[i + 1])
                        {
                            case 'C':
                            case 'W':
                                score = 0.01;
                                break;
                            case 'H':
                            case 'M':
                                score = 0.02;
                                break;
                            case 'K':
                            case 'F':
                            case 'Y':
                                score = 0.04;
                                break;
                            case 'R':
                            case 'N':
                            case 'I':
                            case 'P':
                                score = 0.05;
                                break;
                            case 'D':
                            case 'G':
                            case 'Q':
                            case 'S':
                            case 'T':
                            case 'V':
                                score = 0.06;
                                break;
                            case 'A':
                                score = 0.08;
                                break;
                            case 'E':
                            case 'L':
                                score = 0.1;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 2 position
                    if (protein_sequence.Length >= i + 2)
                    {
                        k = protein_sequence[i + 2];
                        switch (protein_sequence[i + 2])
                        {
                            case 'W':
                            case 'C':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'N':
                                score = score * 0.04;
                                break;
                            case 'R':
                            case 'D':
                            case 'Q':
                            case 'K':
                            case 'P':
                            case 'F':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'I':
                            case 'S':
                                score = score * 0.06;
                                break;
                            case 'A':
                            case 'G':
                            case 'E':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'L':
                                score = score * 0.14;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 3 position
                    if (protein_sequence.Length >= i + 3)
                    {
                        j = protein_sequence[i + 3];
                        switch (protein_sequence[i + 3])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'N':
                            case 'F':
                                score = score * 0.04;
                                break;
                            case 'R':
                            case 'I':
                            case 'K':
                            case 'P':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'D':
                            case 'G':
                            case 'Q':
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'A':
                            case 'S':
                                score = score * 0.07;
                                break;
                            case 'E':
                                score = score * 0.09;
                                break;
                            case 'L':
                                score = score * 0.1;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 4 position
                    if (protein_sequence.Length >= i + 4)
                    {
                        m = protein_sequence[i + 4];
                        switch (protein_sequence[i + 4])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'N':
                            case 'F':
                                score = score * 0.04;
                                break;
                            case 'R':
                            case 'Q':
                            case 'I':
                            case 'P':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'D':
                            case 'G':
                            case 'K':
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'A':
                            case 'S':
                                score = score * 0.07;
                                break;
                            case 'E':
                                score = score * 0.09;
                                break;
                            case 'L':
                                score = score * 0.1;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 5 position
                    if (protein_sequence.Length >= i + 5)
                    {
                        h = protein_sequence[i + 5];
                        switch (protein_sequence[i + 5])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'F':
                            case 'N':
                                score = score * 0.04;
                                break;
                            case 'Q':
                            case 'I':
                            case 'P':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'R':
                            case 'D':
                            case 'G':
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'A':
                            case 'K':
                            case 'S':
                                score = score * 0.07;
                                break;
                            case 'E':
                            case 'L':
                                score = score * 0.09;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% It saves the score for i + 6 position
                    if (protein_sequence.Length >= i + 6)
                    {
                        g = protein_sequence[i + 6];
                        switch (protein_sequence[i + 6])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'F':
                            case 'N':
                                score = score * 0.04;
                                break;
                            case 'P':
                            case 'T':
                            case 'Q':
                            case 'I':
                                score = score * 0.05;
                                break;
                            case 'R':
                            case 'D':
                                score = score * 0.06;
                                break;
                            case 'G':
                            case 'K':
                            case 'S':
                            case 'V':
                            case 'A':
                                score = score * 0.07;
                                break;
                            case 'E':
                                score = score * 0.08;
                                break;
                            case 'L':
                                score = score * 0.09;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 1
                    if (i - 1 > 0)
                    {
                        f = protein_sequence[i - 1];
                        switch (protein_sequence[i - 1])
                        {
                            case 'C':
                            case 'H':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                                score = score * 0.02;
                                break;
                            case 'Y':
                            case 'P':
                                score = score * 0.03;
                                break;
                            case 'R':
                            case 'N':
                            case 'K':
                            case 'F':
                                score = score * 0.04;
                                break;
                            case 'D':
                                score = score * 0.05;
                                break;
                            case 'Q':
                            case 'I':
                            case 'T':
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'G':
                                score = score * 0.07;
                                break;
                            case 'A':
                            case 'S':
                                score = score * 0.08;
                                break;
                            case 'E':
                                score = score * 0.09;
                                break;
                            case 'L':
                                score = score * 0.12;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 2
                    if (i - 2 > 0)
                    {
                        e = protein_sequence[i - 2];
                        switch (protein_sequence[i - 2])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'R':
                                score = score * 0.04;
                                break;
                            case 'N':
                            case 'Q':
                            case 'K':
                            case 'F':
                            case 'P':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'D':
                            case 'G':
                            case 'I':
                                score = score * 0.06;
                                break;
                            case 'S':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'A':
                            case 'E':
                                score = score * 0.08;
                                break;
                            case 'L':
                                score = score * 0.11;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 3
                    if (i - 3 > 0)
                    {
                        d = protein_sequence[i - 3];
                        switch (protein_sequence[i - 3])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'F':
                            case 'N':
                                score = score * 0.04;
                                break;
                            case 'R':
                            case 'K':
                            case 'Q':
                            case 'I':
                            case 'P':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'D':
                            case 'G':
                            case 'V':
                                score = score * 0.06;
                                break;
                            case 'S':
                            case 'A':
                                score = score * 0.07;
                                break;
                            case 'L':
                                score = score * 0.11;
                                break;
                            case 'E':
                                score = score * 0.1;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 4
                    if (i - 4 > 0)
                    {
                        c = protein_sequence[i - 4];
                        switch (protein_sequence[i - 4])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'N':
                            case 'F':
                                score = score * 0.04;
                                break;
                            case 'R':
                            case 'Q':
                            case 'I':
                            case 'P':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'G':
                            case 'K':
                                score = score * 0.06;
                                break;
                            case 'V':
                            case 'A':
                            case 'D':
                            case 'S':
                                score = score * 0.07;
                                break;
                            case 'E':
                                score = score * 0.09;
                                break;
                            case 'L':
                                score = score * 0.1;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 5
                    if (i - 5 > 0)
                    {
                        b = protein_sequence[i - 5];
                        switch (protein_sequence[i - 5])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Y':
                                score = score * 0.03;
                                break;
                            case 'F':
                            case 'N':
                                score = score * 0.04;
                                break;
                            case 'Q':
                            case 'I':
                            case 'P':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'D':
                            case 'R':
                            case 'G':
                                score = score * 0.06;
                                break;
                            case 'A':
                            case 'K':
                            case 'S':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'E':
                                score = score * 0.08;
                                break;
                            case 'L':
                                score = score * 0.1;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    //% it will score amino acid at position i - 6
                    if (i - 6 > 0)
                    {
                        a = protein_sequence[i - 6];
                        switch (protein_sequence[i - 6])
                        {
                            case 'C':
                            case 'W':
                                score = score * 0.01;
                                break;
                            case 'M':
                            case 'H':
                                score = score * 0.02;
                                break;
                            case 'Y':
                            case 'F':
                                score = score * 0.03;
                                break;
                            case 'N':
                            case 'P':
                                score = score * 0.04;
                                break;
                            case 'Q':
                            case 'I':
                            case 'T':
                                score = score * 0.05;
                                break;
                            case 'R':
                            case 'D':
                            case 'G':
                                score = score * 0.06;
                                break;
                            case 'K':
                            case 'S':
                            case 'V':
                                score = score * 0.07;
                                break;
                            case 'A':
                            case 'E':
                                score = score * 0.08;
                                break;
                            case 'L':
                                score = score * 0.1;
                                break;
                            default:
                                score = 0;
                                break;
                        }
                    }

                    // score scaling according to higest score
                    score = normalize(score, 15);

                    if ((score >= PTM_tolerance) && (i - 6 >= 0) && (i - 5 >= 0) && (i - 4 >= 0) && (i - 3 >= 0) && (i - 2 >= 0) && (i - 1 >= 0))
                    {
                        l = protein_sequence[i + 1];
                        k = protein_sequence[i + 2];
                        j = protein_sequence[i + 3];
                        m = protein_sequence[i + 4];
                        h = protein_sequence[i + 5];
                        g = protein_sequence[i + 6];
                        a = protein_sequence[i - 6];
                        b = protein_sequence[i - 5];
                        c = protein_sequence[i - 4];
                        d = protein_sequence[i - 3];
                        e = protein_sequence[i - 2];
                        f = protein_sequence[i - 1];

                        //% it stores the protein sub-sequence
                        AA.Add(a);
                        AA.Add(b);
                        AA.Add(c);
                        AA.Add(d);
                        AA.Add(e);
                        AA.Add(f);
                        AA.Add(protein_sequence[i]);
                        AA.Add(l);
                        AA.Add(k);
                        AA.Add(j);
                        AA.Add(m);
                        AA.Add(h);
                        AA.Add(g);

                        // Storing the data in the list "array"
                        array.Add(new Sites(i, score, mod_weight, mod_name, site, AA));

                        objectArrayIndex++;

                        // score of Lysine at that position
                    }
                }

                // for the TotalLys if condition coming up ahead
                index = i;
            }

            // it displays total number of Lysine found in sequence
            if (index == protein_sequence.Length)
            {
                Console.WriteLine("Total Lysine found: " + TotalLys);
            }
            //disp(['Total Lysine found: ', num2str(TotalLys)])

            // returning the object array
            return array;
        }

        //*******************************


        // calls functions of PTMs and calculates scores
        public static void runAlgosv(string prot_sequence, double tol, List<Sites> filtered, List<int> PTM_Code)
        {
            // Runs only the PTMS that the user selected

            //List<Sites> filtered_sites = new List<Sites>();
            List<Sites> dummy = new List<Sites>();

            foreach (int a in PTM_Code)
            {
                switch (a)
                {
                    case 1:
                        dummy = Acetylation_A(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 2:
                        dummy = Acetylation_K(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 3:
                        dummy = Acetylation_M(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 4:
                        dummy = Acetylation_S(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 5:
                        dummy = Amidation_F(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 6:
                        dummy = Hydroxylation_P(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 7:
                        dummy = Methylation_K(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 8:
                        dummy = Methylation_R(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 9:
                        dummy = N_linked_glycosylation_N(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 10:
                        dummy = O_linked_glycosylation_T(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 11:
                        dummy = O_linked_glycosylation_S(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 12:
                        dummy = Phosphorylation_S(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 13:
                        dummy = Phosphorylation_T(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 14:
                        dummy = Phosphorylation_Y(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 15:
                        dummy = Ubiquitination_K(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    default:
                        // idle
                        break;
                }
            }
        }

        public static void runAlgosf(string prot_sequence, double tol, List<Sites> filtered, List<int> PTM_Code)
        {
            //List<Sites> filtered_sites = new List<Sites>();
            List<Sites> dummy = new List<Sites>();

            foreach (int a in PTM_Code)
            {
                switch (a)
                {
                    case 1:
                        dummy = Acetylation_A(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 2:
                        dummy = Acetylation_K(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 3:
                        dummy = Acetylation_M(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 4:
                        dummy = Acetylation_S(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 5:
                        dummy = Amidation_F(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 6:
                        dummy = Hydroxylation_P(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 7:
                        dummy = Methylation_K(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 8:
                        dummy = Methylation_R(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 9:
                        dummy = N_linked_glycosylation_N(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 10:
                        dummy = O_linked_glycosylation_T(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 11:
                        dummy = O_linked_glycosylation_S(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 12:
                        dummy = Phosphorylation_S(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 13:
                        dummy = Phosphorylation_T(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 14:
                        dummy = Phosphorylation_Y(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    case 15:
                        dummy = Ubiquitination_K(prot_sequence, tol);
                        //filter(dummy, filtered, tol);
                        foreach (Sites b in dummy)
                            filtered.Add(b);
                        break;
                    default:
                        // idle
                        break;
                }
            }
        }

        // FUNCTION FOR MAKING MODIFIED PROTEINS
        public static void make_mod_proteins_2(List<Sites> filtered_sites, List<proteins> mod_proteins, List<int> combos, proteins parent, List<proteins> short_prot, string clevageType, string ions, List<double> peakList, double tol, double mw_weight, double pst_weight, double insilico_weight)
        {
            double dummyMW = parent.MW;        // MW of the original sequence
            double dummy_ptm_score = 0;     // ptm score of the unmodified sequence
            //var aStringBuilder = new StringBuilder(sequence);

            /*foreach(int a in combos)
            {
                Console.WriteLine(a);
            }*/

            List<Sites> sites_info = new List<Sites>();

            foreach (int i in combos)
            {
                if (i != 777)
                {
                    dummyMW += filtered_sites.ElementAt(i).mod_weight;      // accumulates the mod weight of all the sites in the current combination
                    dummy_ptm_score += filtered_sites.ElementAt(i).score;       //accumlates the ptm score
                    sites_info.Add(filtered_sites.ElementAt(i));

                    //aStringBuilder.Remove(filtered_sites.ElementAt(i).i, 1);
                    //aStringBuilder.Insert(filtered_sites.ElementAt(i).i, (filtered_sites.ElementAt(i).site + "mod"));
                    //obj.sequence = aStringBuilder.ToString();
                }
                else if (i == 777)
                {
                    proteins temp = new proteins();

                    //mod_proteins.Add(temp);     // adding the protein

                    int min = 0;
                    double val = 0; ;

                    if(short_prot.Count == 10000)
                    {
                        min = 0;
                        val = short_prot.ElementAt(0).score;
                        for(int kkk = 1; kkk < short_prot.Count; kkk++)
                        {
                            if(val > short_prot.ElementAt(kkk).score)
                            {
                                min = kkk;
                                val = short_prot.ElementAt(kkk).score;
                            }
                        }

                        short_prot.RemoveAt(min);
                    }

                    


                    short_prot.Add(temp);

                    // using count - 1 because the list counts a single object as 1 and not as zeroth element
                    // in case of fixed modifications, the first element is 777. so the unmodified protein is added with the default weight and score
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).MW = dummyMW;
                    short_prot.ElementAt(short_prot.Count - 1).MW = dummyMW;
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).ptm_score = dummy_ptm_score;
                    short_prot.ElementAt(short_prot.Count - 1).ptm_score = dummy_ptm_score;
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).sequence = parent.sequence;
                    short_prot.ElementAt(short_prot.Count - 1).sequence = parent.sequence;
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).header = parent.header;
                    short_prot.ElementAt(short_prot.Count - 1).header = parent.header;
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).est_score = parent.est_score;
                    short_prot.ElementAt(short_prot.Count - 1).est_score = parent.est_score;
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).insilico_score = parent.insilico_score;
                    short_prot.ElementAt(short_prot.Count - 1).insilico_score = parent.insilico_score;
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).MW_score = parent.MW_score;
                    short_prot.ElementAt(short_prot.Count - 1).MW_score = parent.MW_score;
                    ////mod_proteins.ElementAt(mod_proteins.Count - 1).ptm_particulars = parent.ptm_particulars;
                    ////mod_proteins.ElementAt(mod_proteins.Count - 1).ptm_particulars.Add(filtered_sites.ElementAt(i));
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).score = parent.score;
                    short_prot.ElementAt(short_prot.Count - 1).score = parent.score;
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).insilico_details = parent.insilico_details;
                    short_prot.ElementAt(short_prot.Count - 1).insilico_details = parent.insilico_details;

                    foreach (Sites a in sites_info)
                    {
                        //mod_proteins.ElementAt(mod_proteins.Count - 1).ptm_particulars.Add(a);
                        short_prot.ElementAt(short_prot.Count - 1).ptm_particulars.Add(a);
                    }

                    Insilico_Module.insilico_fragmentation_2(short_prot.ElementAt(short_prot.Count - 1), clevageType, ions);
                    Insilico_Module.Insilico_filter_U2(short_prot.ElementAt(short_prot.Count - 1), peakList, tol);
                    short_prot.ElementAt(short_prot.Count - 1).set_score(mw_weight, pst_weight, insilico_weight);

                    dummyMW = parent.MW;
                    dummy_ptm_score = 0;
                    sites_info = new List<Sites>();
                    //aStringBuilder = new StringBuilder(sequence);
                }
            }

        }
        public static double variable_mods_2(List<double> curve, string protein_sequence, List<Sites> filtered_sitesA, double tol, List<int> indices, List<proteins> mod_prot, List<int> PTM_CodeV, proteins parentPro, List<proteins> shortlisted, string clevageType, string ions, List<double> peakList, double insilico_tol, double mw_weight, double pst_weight, double insilico_weight)
        {
            //Console.WriteLine("working");
            runAlgosv(protein_sequence, tol, filtered_sitesA, PTM_CodeV);       // filtered sites is currently empty

            List<Sites> SortedList = filtered_sitesA.OrderBy(o => o.score).ToList();    //sorting in ascending order of scores of sites

            int j;
            List<string> combos = new List<string>();
            //List<int> indices = new List<int>();

            int limitCombs = 0;

            //for (j = 1; j <= SortedList.Count; j++)
            for (j = 1; j <= 5; j++)
            {
                foreach (int[] c in Combinations(j, SortedList.Count))
                {
                    string dummy = "";
                    //Console.WriteLine(int.MaxValue);
                    int i;
                    for (i = 0; i < c.Length; i++)
                    {
                        dummy += c[i].ToString();
                        indices.Add(c[i]);          // separates indices
                    }
                    combos.Add(dummy);
                    indices.Add(777);
                    //Console.WriteLine();
                }
                //Console.WriteLine("CHECK");
            }
            //Console.WriteLine("CHECK");

            shortlisted.Add(parentPro);

            Insilico_Module.insilico_fragmentation_2(shortlisted.ElementAt(shortlisted.Count - 1), clevageType, ions);
            Insilico_Module.Insilico_filter_U2(shortlisted.ElementAt(shortlisted.Count - 1), peakList, insilico_tol);
            shortlisted.ElementAt(shortlisted.Count - 1).set_score(mw_weight, pst_weight, insilico_weight);

            if (SortedList.Count > 0)
                make_mod_proteins_2(filtered_sitesA, mod_prot, indices, parentPro, shortlisted, clevageType, ions, peakList, insilico_tol, mw_weight, pst_weight, insilico_weight);

            //mod_prot.ElementAt(0).ptm_particulars = new List<Sites>();
            int counter = 1;
            bool con = false;
            List<Sites> dummyList = new List<Sites>();

            ////////////////////////////////////////////////////////////////////////////////////////////

            //for (int x = 0; x < indices.Count; x++)
            //{
            //    if (indices.ElementAt(x) != 777)
            //    {
            //        con = false;
            //        dummyList.Add(filtered_sitesA.ElementAt(indices.ElementAt(x)));
            //    }
            //    else if (indices.ElementAt(x) == 777)
            //    {
            //        if (con == false)
            //        {
            //            mod_prot.ElementAt(counter).ptm_particulars = new List<Sites>();
            //            con = true;
            //        }
            //        mod_prot.ElementAt(counter).ptm_particulars.AddRange(dummyList);
            //        counter++;
            //        dummyList.Clear();
            //    }
            //    //mod_prot.ElementAt(x+1).ptm_particulars
            //}

            ////////////////////////////////////////////////////////////////////////////////////////////

            double totalScore = 0;

            int cou = 0;
            double finalScore = 0;

            foreach (proteins a in mod_prot)
            {
                if (a.ptm_score != 0)
                {
                    a.ptm_score = 1 - Math.Exp(-a.ptm_score);
                }
            }

            return finalScore;
        }

        public static double fixed_mods_2(List<double> curve, string protein_sequence, List<Sites> filtered_sitesB, double tol, List<int> indices, List<proteins> mod_prot, List<int> PTM_CodeF, proteins parentPro, List<proteins> short_prot, string clevageType, string ions, List<double> peakList, double insilico_tol, double mw_weight, double pst_weight, double insilico_weight)
        {
            //Console.WriteLine("working");
            //int j;

            runAlgosf(protein_sequence, 0, filtered_sitesB, PTM_CodeF);       // runs the modifications selected by the user and stores the sites in filtered sites

            List<Sites> SortedList = filtered_sitesB.OrderBy(o => o.score).ToList();        // sorts the filtered sites in ascending order of their ptm scores

            //indices.Add(777);
            for (int i = 0; i < SortedList.Count; i++)
            {
                indices.Add(i);
            }
            indices.Add(777);

            if (SortedList.Count > 0)
                make_mod_proteins_2(filtered_sitesB, mod_prot, indices, parentPro, short_prot, clevageType, ions, peakList, insilico_tol, mw_weight, pst_weight, insilico_weight);

            //short_prot.ElementAt(short_prot.Count - 1).ptm_particulars = new List<Sites>();
            //foreach (Sites a in filtered_sitesB)
            //{
            //    mod_prot.ElementAt(mod_prot.Count - 1).ptm_particulars.Add(a);
            //}

            


            double totalScore = 0;

            int cou = 1;
            foreach (proteins a in mod_prot)
            {
                if ((a.ptm_score != 0) && (cou == mod_prot.Count))
                {
                    a.ptm_score = 1 - Math.Exp(-a.ptm_score);
                }
                cou++;
            }

            return totalScore;
        }


        public static void finalFilter(List<proteins> filterProts)
        {
            //filterProts.Sort((x, y) => y.score.CompareTo(x.score));
            filterProts.AsParallel().OrderBy(x => x.score);
            filterProts.RemoveRange(10000, filterProts.Count - 10000);
        }

        public static void PTM_Control_2(List<proteins> input, double tolerance, List<proteins> modified_proteins, List<int> ptm_code_var, List<int> ptm_code_fix, List<proteins> shortlisted_prot, string clevageType, string ions, List<double> peakList, double insilico_tol, double mw_weight, double pst_weight, double insilico_weight)
        {

            /*foreach (proteins a in input)
            {
                modified_proteins.Add(a);
                a.ptm_particulars = new List<Sites>();
                //counter++;
            }*/

            List<Sites> filtered_sitesA = new List<Sites>();        // for the variable modifications
            List<Sites> filtered_sitesB = new List<Sites>();        // for the fixed modifications
            List<Sites> filtered_sitesC = new List<Sites>();        // for both kind of modifications
            List<double> curveV = new List<double>();               // for the variable modifications
            List<double> curveF = new List<double>();               // for the fixed modifications
            List<double> curveVarFix = new List<double>();          // for both kind of modifications
            List<int> indicesV = new List<int>();                   // and so on
            List<int> indicesF = new List<int>();
            List<int> indicesVarFix = new List<int>();
            double totalScoreVar = 0;
            double totalScoreFix = 0;
            double totalScoreVarFix = 0;

            //string typeCode = "";

            if (ptm_code_var.Count != 0)
            {
                foreach (proteins p in input)
                {
                    filtered_sitesA.Clear();        // resetting all variables before calling another protein
                    filtered_sitesB.Clear();
                    filtered_sitesC.Clear();
                    curveV.Clear();
                    curveF.Clear();
                    curveVarFix.Clear();
                    indicesV.Clear();
                    indicesF.Clear();
                    indicesVarFix.Clear();
                    totalScoreVar = 0;
                    totalScoreFix = 0;
                    totalScoreVarFix = 0;
                    totalScoreVar = variable_mods_2(curveV, p.sequence, filtered_sitesA, tolerance, indicesV, modified_proteins, ptm_code_var, p, shortlisted_prot, clevageType, ions, peakList, insilico_tol, mw_weight, pst_weight, insilico_weight);
                    p.ptm_score = totalScoreVar;

                    if(shortlisted_prot.Count >= 50000)
                    {
                        finalFilter(shortlisted_prot);
                    }
                }
            }

            if (ptm_code_fix.Count != 0)
            {
                foreach (proteins p in input)
                {
                    //filtered_sitesA.Clear();        // resetting all variables before calling another protein
                    filtered_sitesB.Clear();
                    filtered_sitesC.Clear();
                    curveV.Clear();
                    curveF.Clear();

                    //indicesV.Clear();
                    indicesF.Clear();

                    totalScoreVar = 0;
                    totalScoreFix = 0;

                    totalScoreFix = fixed_mods_2(curveF, p.sequence, filtered_sitesB, tolerance, indicesF, modified_proteins, ptm_code_fix, p, shortlisted_prot,  clevageType,  ions,  peakList,  insilico_tol,  mw_weight,  pst_weight,  insilico_weight);
                    p.ptm_score = totalScoreFix;

                    int counter = shortlisted_prot.Count;
                    int fix_prot_index = shortlisted_prot.Count - 1;
                    make_mod_proteins_2(filtered_sitesA, modified_proteins, indicesV, shortlisted_prot.ElementAt(shortlisted_prot.Count - 1), shortlisted_prot, clevageType, ions, peakList, insilico_tol, mw_weight, pst_weight, insilico_weight);

                    //modified_proteins.ElementAt(0).ptm_particulars = new List<Sites>();
                    //int counter = modified_proteins.Count - 1;
                    /*bool con = false;
                    List<Sites> dummyList = new List<Sites>();
                    foreach (Sites abc in modified_proteins.ElementAt(fix_prot_index).ptm_particulars)
                        dummyList.Add(abc);
                    for (int x = 0; x < indicesV.Count; x++)
                    {
                        if (indicesV.ElementAt(x) != 777)
                        {
                            con = false;

                            dummyList.Add(filtered_sitesA.ElementAt(indicesV.ElementAt(x)));
                        }
                        else if (indicesV.ElementAt(x) == 777)
                        {
                            if (con == false)
                            {
                                modified_proteins.ElementAt(counter).ptm_particulars = new List<Sites>();
                                con = true;
                            }

                            foreach (Sites site in dummyList)
                            {
                                modified_proteins.ElementAt(counter).ptm_particulars.Add(site);
                            }

                            //modified_proteins.ElementAt(counter).ptm_particulars.AddRange(dummyList);
                            counter++;
                            dummyList.Clear();
                            foreach (Sites abc in modified_proteins.ElementAt(fix_prot_index).ptm_particulars)
                                dummyList.Add(abc);
                        }
                    }*/
                }
            }
        }
    }
}