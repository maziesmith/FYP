using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class QuerryParameters
    {
        public string queryid;
        public string userID;
        public string title;
        public string protDB;
        public int outputFormat;
        public string insilico_frag_type;
        public int filterDB;

        public int minimum_est_length;
        public int maximum_est_length;
        // public double pst_tolerance;
        public double ptm_tolerance;
        public double MW_tolerance;
        public string MWTolUnit;
        // public double peptideTol;
        public double hopThreshhold;
        //added
        public string hopTolUnit;

        public double GUI_mass;
        public List<int> ptm_code_var;
        public List<int> ptm_code_fix;
        // public double tag_error_tol;
        //  public string peakListFolder;
        public string fileType;
        public string [] peakListFile;
        public int autotune;
        //public string current;
       // public double tunetol;
        //add
       // public string tunetolUnit;

        public string HandleIons;

        //add
        public double MW_sweight;
        public double PST_sweight;
        public double Insilico_sweight;
        public int NumberOfOutputs;
        /////
        public int denovo_allow;
        public int ptm_allow;

    }

}