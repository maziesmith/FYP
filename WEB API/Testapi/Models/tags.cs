using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testapi.Models
{
    public class tags
    {
        public string AA;
        public int start;
        public int end;
        public int len;

        //length Score
        public double score_l;

        //Squared errors
        public List<double> errors;

        //Error Score
        public double score_e;
        public List<double> intensity;
        //Intensity score
        public double score_i;

        public List<int> locations;

        public tags(string a, int s, int e, List<double> tag_errors, List<double> tag_intensities, int l = 1)
        {
            AA = a;
            start = s;
            end = e;
            len = l;
            //scoring length
            score_l = Math.Pow(AA.Length, 2);

            //error scoring
            errors = new List<double>();
            errors = tag_errors;

            score_e = 0;
            for (int i = 0; i < errors.Count; i++)
            {
                score_e += errors[i];
            }

            //RMSE
            score_e = (Math.Sqrt(score_e)) / errors.Count;

            // Saturating the curve
            score_e = Math.Exp(-20 * score_e);


            //intensity score
            intensity = new List<double>();
            intensity = tag_intensities;

            score_i = 0;
            for (int i = 0; i < intensity.Count; i++)
            {
                score_i += intensity[i];
            }
            score_i = (score_i / intensity.Count) * score_l;

            locations = new List<int>();

        }
    }






}