using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Testapi.Models;
using System.IO;

namespace Testapi.Engine
{
    public class EST_module
    {

        // It returns tags and their scores 
        public static List<tags> findEST(List<double> peakList, List<double> intensity, double hop_tol, int mintagLength, int maxtagLength)
        {


            char AA;
            List<tags> Singletag_list = new List<tags>();

            //Sorting peaklist in ascending order
            peakList.Sort();


            //for each element of peaklist

            for (int i = 0; i < peakList.Count; i++)
            {

                // for each element of peaklist after ith element
                for (int j = i + 1; j < peakList.Count; j++)
                {
                    //Returns amino acid that is within hop tolerance
                    //Returns * if none found
                    double w = peakList[j] - peakList[i] ;
                    AA = AminoAcids.getAA(w,hop_tol);
                    if (w > 465)
                        break;
                     if (AA != '*')
                    {
                        //Calculating error square
                        List<double> error_square = new List<double>();
                        error_square.Add(Math.Pow((AminoAcids.getMW(AA) - (peakList[j] - peakList[i])), 2));

                        //Calculating Error intensity
                        List<double> avg_Intensity = new List<double>();
                        avg_Intensity.Add((intensity[i] + intensity[j]) / 2);


                        // Adding A tag to AA_list
                        tags temp = new tags(AA.ToString(), i, j, error_square, avg_Intensity, 1);
                        //i=start j=end length=1

                        //NEWCODE

                        temp.locations.Add(i);
                        temp.locations.Add(j);

                        /////////////////////////////////////////////////////////////////////////////////////////////

                        Singletag_list.Add(temp);


                    }



                }//inner loop terminated



            }//outer loop terminated


            //for (int i = 0; i < AA_list.Count; i++)
            //{
            //Console.WriteLine(AA_list[i].AA);
            //}


            /*string path = @"C:\Users\Urwa\Desktop\pst\single.txt";
            if (File.Exists(path))
                File.Delete(path);

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("AA\tstart\tend\tscore_e");
                    sw.WriteLine();

                    for (int x = 0; x < Singletag_list.Count; x++)
                    {
                        sw.WriteLine(Singletag_list.ElementAt(x).AA + "\t" + Singletag_list.ElementAt(x).start + "\t" + Singletag_list.ElementAt(x).end + "\t" + Singletag_list.ElementAt(x).score_e);
                        
                    }
                    //sw.WriteLine(mz.ElementAt(i) + "\t" + intensity.ElementAt(i));
                }
            }*/


            List<tags> Doubletag_list = new List<tags>();

            //for each 1 length tag AA_List
            for (int i = 0; i < Singletag_list.Count; i++)
            {
                //for each 1 length tag AA_List after ith
                for (int j = i + 1; j < Singletag_list.Count; j++)
                {

                    //If they are consecutive
                    if (Singletag_list[i].end == Singletag_list[j].start)
                    {
                        //temporary list holds errors of both participating tags
                        List<double> temp_error = new List<double>();
                       
                        temp_error.Add(Singletag_list[i].errors[0]);
                        temp_error.Add(Singletag_list[j].errors[0]);

                        //temporary list holds intensities of both
                        List<double> temp_intensity = new List<double>();
                        temp_intensity.Add(Singletag_list[i].intensity[0]);
                        temp_intensity.Add(Singletag_list[j].intensity[0]);


                        tags temp = new tags(Singletag_list[i].AA + Singletag_list[j].AA, Singletag_list[i].start, Singletag_list[j].end, temp_error, temp_intensity, 2);
                        // both tags are joined into one tag and added to double_list


                        //NEWCODE

                        temp.locations.Add(Singletag_list[i].start);
                        temp.locations.Add(Singletag_list[i].end);
                        temp.locations.Add(Singletag_list[j].end);
                        //////////////////////////////////


                        Doubletag_list.Add(temp);
                    }


                    // avoids iteration through unnecessary tags
                    else if (Singletag_list[i].end < Singletag_list[j].start)
                    {
                        break;
                    }

                }

            }
            ///////////






            // Generates the tags of length bigger than two using doublelength tags
            List<tags> Multipletag_list = joinTags(Doubletag_list);



            // Tag_Ladder stores tags of all lengths
            List<tags> Tag_Ladder = new List<tags>();
            Tag_Ladder = Singletag_list;


            for (int i = 0; i < Multipletag_list.Count; i++)
            {


                Tag_Ladder.Add(Multipletag_list[i]);


            }


            //Filters for tags with desired length
            for (int i = 0; i < Tag_Ladder.Count; i++)
            {
                if ((mintagLength != -1) && (maxtagLength != -1))

                if (Tag_Ladder[i].len < mintagLength || Tag_Ladder[i].len > maxtagLength)
                {
                    Tag_Ladder.RemoveAt(i);
                }
            }

            for (int i = Tag_Ladder.Count - 1; i >= 0; i--)
            {

                for (int j = i - 1; j >= 0; j--)
                {
                    if (Tag_Ladder[i].AA == Tag_Ladder[j].AA)
                    {

                        if (Tag_Ladder[i].score_e < Tag_Ladder[j].score_e)
                        {
                            Tag_Ladder.RemoveAt(j);
                        }
                        else
                        {
                            Tag_Ladder.RemoveAt(i);
                        }
                        break;
                    }


                }

            }
            //string path = @"C:\Users\Urwa\Desktop\pst\single.txt";
            //if (File.Exists(path))
            //    File.Delete(path);

            //if (!File.Exists(path))
            //{
            //    using (StreamWriter sw = File.CreateText(path))
            //    {
            //        sw.WriteLine("AA\tstart\tend\tscore_e");
            //        sw.WriteLine();

            //        for (int x = 0; x < Tag_Ladder.Count; x++)
            //        {
            //            sw.WriteLine(Tag_Ladder.ElementAt(x).AA + "\t" + Tag_Ladder.ElementAt(x).start + "\t" + Tag_Ladder.ElementAt(x).end + "\t" + Tag_Ladder.ElementAt(x).score_e);

            //        }
            //        //sw.WriteLine(mz.ElementAt(i) + "\t" + intensity.ElementAt(i));
            //    }
            //}

            return Tag_Ladder;

        }




        //Recursive function that retrieves multiple length tags from double length tags

        static List<tags> joinTags(List<tags> pst, int n = 1, int ss = 0)
        {

            int c = pst.Count;
            int k;
            k = 0;

            //Console.WriteLine(pst.Count);
            //Console.WriteLine(n);
            //Console.WriteLine(ss);


            //Console.ReadKey();
            for (int i = ss; i < c; i++)
            {

                for (int j = i + 1; j < c; j++)
                {

                    if ((pst[i].AA.Substring(pst[i].AA.Length - n, n) == pst[j].AA.Substring(0, n)) && (pst[i].end > pst[j].start))
                    {

                        bool y = true;
                        int start1=pst[i].AA.Length - n-1;
                        int start2=0;
                        for(start2=0;start2<n+1;start2++,start1++)
                        {
                            if (pst[i].locations[start1] == pst[j].locations[start2])
                            {
                                y = false;
                                break;
                            }
                        }
                        if (y)
                        {

                            List<double> temp_1 = new List<double>();

                            for (int itemp = 0; itemp < pst[i].errors.Count;itemp++ )
                            {
                                temp_1.Add(pst[i].errors[itemp]);
                            }

                            temp_1.Add(pst[j].errors[pst[j].errors.Count - 1]);

                            List<double> temp_2 = new List<double>();
                            for (int itemp = 0; itemp < pst[i].intensity.Count; itemp++)
                            {
                                temp_2.Add(pst[i].intensity[itemp]);
                            }
                            

                            temp_2.Add(pst[j].intensity[pst[j].intensity.Count - 1]);





                            tags temp = new tags(pst[i].AA.Substring(0, pst[i].AA.Length - n) + pst[j].AA, pst[i].start, pst[j].end, temp_1, temp_2, 2 + n);
                           

                            for(int tt=0; tt<pst[i].locations.Count;tt++ )
                            {
                                temp.locations.Add(pst[i].locations[tt]);
                            }
                            temp.locations.Add(pst[j].locations[pst[j].locations.Count - 1]);

                            pst.Add(temp);
                            //pst[i].len = -1;
                            //pst[j].len = -1;
                        }
                    }//end if

                }


            }//outer loop

            if (pst.Count == c) { return pst; }

            /*	for (int i=c-1; i>=ss; i--) {

                    if (pst[i].len == -1)
                    {
                        pst.RemoveAt(i);
                        k++;
                    }
                }*/




            //Console.WriteLine(k);
            c = c - k;



            //	for (int i = 0; i < pst.Count; i++)
            //	{
            //	Console.WriteLine(pst[i].AA);
            //	}



            return (joinTags(pst, n + 1, c));




        }




        public static List<proteins> EST_filter(List<tags> est_tags, List<proteins> MW_prot)
        {


            int counter = 0;


            //List<proteins> EST_prot = new List<proteins>();


            int occurences;



            //while ((line = file.ReadLine()) != null)
            for (int j = 0; j < MW_prot.Count; j++)
            {






                double score = 0;

                for (int i = 0; i < est_tags.Count; i++)
                {

                    occurences = Regex.Matches(MW_prot[j].sequence, est_tags[i].AA).Count;

                    score += (est_tags[i].score_e + est_tags[i].score_i + est_tags[i].score_l) * occurences;

                }



                score = score / MW_prot[j].sequence.Length;

                MW_prot[j].est_score = score;

                //  proteins temp_p = new proteins(MW_prot[j].header, MW_prot[j].sequence);
                //  temp_p.est_score = score;
                //  EST_prot.Add(temp_p);





                //System.Console.WriteLine(line);


                counter++;
            }



            for (int i = 0; i < MW_prot.Count; i++)
            {
                if (MW_prot[i].est_score <= 0)
                {
                    MW_prot.RemoveAt(i);
                }


            }


            return MW_prot;




        }




        public static List<double> GPU_Filter(char[] matched_result, List<tags> est_tags, List<int> pro_ind, List<proteins> PROT)
        {
            List<double> scores = new List<double>();
            int temp = 0;
            int counter = 0;
            double score;
            for (int i = 0; i < pro_ind.Count; i++)
            {
                score = 0;
                temp += pro_ind[i];
                while (counter < temp)
                {
                    if (Convert.ToInt16(matched_result[counter]) > 0)
                    {
                        score += (est_tags[matched_result[counter] - 1].score_e + est_tags[matched_result[counter] - 1].score_i + est_tags[matched_result[counter] - 1].score_l);

                    }
                    counter++;
                }
                score = score / Convert.ToDouble(PROT[i].sequence.Length);
                PROT[i].est_score = score;

                scores.Add(score);
            }

            return scores;
        }







    }


















}