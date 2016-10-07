using System.Collections.Generic;

namespace DTO
{
    public class QuerryParameters
    {
        public string Queryid;
        public string UserId;
        public string Title;
        public string ProtDb;
        public int OutputFormat;
        public string InsilicoFragType;
        public int FilterDb;

        public int MinimumEstLength;
        public int MaximumEstLength;
        // public double pst_tolerance;
        public double PtmTolerance;
        public double MwTolerance;
        public string MwTolUnit;
        // public double peptideTol;
        public double HopThreshhold;
        //added
        public string HopTolUnit;

        public double GuiMass;
        public List<int> PtmCodeVar;
        public List<int> PtmCodeFix;
        // public double tag_error_tol;
        //  public string peakListFolder;
        public string FileType;
        public string [] PeakListFile;
        public int Autotune;
        //public string current;
        public string HandleIons;

        //add
        public double MwSweight;
        public double PstSweight;
        public double InsilicoSweight;
        public int NumberOfOutputs;
        /////
        public int DenovoAllow;
        public int PtmAllow;

    }

}