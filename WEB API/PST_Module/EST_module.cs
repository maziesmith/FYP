using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AminoAcidData;
using DTO;

namespace PST_Module
{

    
    public class EstModule
    {
        
     

        public static List<double> GPU_Filter(char[] matchedResult, List<Tags> estTags, List<int> proInd,
            List<proteins> prot)
        {
            List<double> scores = new List<double>();
            int temp = 0;
            int counter = 0;
            for (int i = 0; i < proInd.Count; i++)
            {
                double score = 0;
                temp += proInd[i];
                while (counter < temp)
                {
                    if (Convert.ToInt16(matchedResult[counter]) > 0)
                    {
                        score += (estTags[matchedResult[counter] - 1].score_e +
                                  estTags[matchedResult[counter] - 1].score_i +
                                  estTags[matchedResult[counter] - 1].score_l);
                    }
                    counter++;
                }
                score = score/Convert.ToDouble(prot[i].sequence.Length);
                prot[i].est_score = score;

                scores.Add(score);
            }

            return scores;
        }
    }
}