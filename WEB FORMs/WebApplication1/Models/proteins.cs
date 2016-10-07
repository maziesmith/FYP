using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{

    public class proteins
    {
        public string header;
        public string sequence;
        public double est_score;
        public double insilico_score;
        public double ptm_score;
        public double score;
        public double MW_score;
        public double MW;
        public List<Sites> ptm_particulars;
        public insilico_obj insilico_details;


        public proteins()
        {
            header = "";
            sequence = "";
            est_score = 0;
            insilico_score = 0;
            ptm_score = 0;
            score = 0;
            MW_score = 0;
            ptm_particulars = new List<Sites>();
            insilico_details = new insilico_obj();
        }

        public proteins(string h, string s, double mw, double mw_score)
        {
            header = h;
            sequence = s;
            est_score = 0;
            MW_score = mw_score;
            insilico_score = 0;
            ptm_score = 0;
            score = 0;
            MW = mw;
            //ptm_particulars = new List<Sites>();
        }

        public string getSequence()
        {
            return sequence;
        }


        public void set_score(double MW_sweight, double PST_sweight, double Insilico_sweight)
        {
            score = PST_sweight * est_score + Insilico_sweight * insilico_score + MW_sweight * MW_score;
        }
    }




}