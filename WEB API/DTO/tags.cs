using System;
using System.Collections.Generic;

namespace DTO
{
    public class Tags
    {
        public string Aa;
        public int Start;
        public int End;
        public int Len;

        //length Score
        public double ScoreL;

        //Squared errors
        public List<double> Errors;

        //Error Score
        public double ScoreE;
        public List<double> Intensity;
        //Intensity score
        public double ScoreI;

        public List<int> Locations;

        public Tags(string a, int s, int e, List<double> tagErrors, List<double> tagIntensities, int l = 1)
        {
            Aa = a;
            Start = s;
            End = e;
            Len = l;
            //scoring length
            ScoreL = Math.Pow(Aa.Length, 2);

            //error scoring
            Errors = new List<double>();
            Errors = tagErrors;

            ScoreE = 0;
            for (var i = 0; i < Errors.Count; i++)
                ScoreE += Errors[i];

            //RMSE
            ScoreE = Math.Sqrt(ScoreE)/Errors.Count;

            // Saturating the curve
            ScoreE = Math.Exp(-20*ScoreE);


            //intensity score
            Intensity = new List<double>();
            Intensity = tagIntensities;

            ScoreI = 0;
            for (int i = 0; i < Intensity.Count; i++)
            {
                ScoreI += Intensity[i];
                ;
            }
            ScoreI = ScoreI/Intensity.Count*ScoreL;

            Locations = new List<int>();
        }
    }
}