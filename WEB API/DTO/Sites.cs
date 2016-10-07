using System.Collections.Generic;

namespace DTO
{
    public class Sites
    {
        // Declaring Variables
        public int I;	// amino acid index
        public double Score;	// protein score
        public double ModWeight;
        public string ModName;
        public char Site;
        public List<char> Aa = new List<char>();		// amino acid sequence

        // Constructor
        public Sites()
        {
            // Initializing Variales
            I = 0;
            Score = 0;
            ModWeight = 0;
            ModName = null;
            Site = '\0';
        }

        //Another Constructor
        public Sites(int i, double score, double modWeight, string modName, char site, List<char> aa)
        {
            // TODO: Complete member initialization
            this.I = i;
            this.Score = score;
            this.ModWeight = modWeight;
            this.ModName = modName;
            this.Site = site;
            this.Aa = aa;
        }

        // Set functions
        public void SetIndex(int index)
        {
            I = index;
        }
        public void SetScore(double sc)
        {
            Score = sc;
        }
        public void SetModWeight(double weight)
        {
            ModWeight = weight;
        }
        public void SetModName(string name)
        {
            ModName = name;
        }
        public void SetSite(char syte)
        {
            Site = syte;
        }
        public void SetAmino(char[] amino)
        {
            foreach (char c in amino)
            {
                Aa.Add(c);
            }
        }

        // Get functions
        public int GetIndex()
        {
            return I;
        }
        public double GetScore()
        {
            return Score;
        }
        public double GetModWeight()
        {
            return ModWeight;
        }
        public string GetModName()
        {
            return ModName;
        }
        public char GetSite()
        {
            return Site;
        }
        public List<char> GetAmino()
        {
            return Aa;
        }
    }



}