using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testapi.Models
{
    public class Sites
    {
        // Declaring Variables
        public int i;	// amino acid index
        public double score;	// protein score
        public double mod_weight;
        public string mod_name;
        public char site;
        public List<char> AA = new List<char>();		// amino acid sequence

        // Constructor
        public Sites()
        {
            // Initializing Variales
            i = 0;
            score = 0;
            mod_weight = 0;
            mod_name = null;
            site = '\0';
        }

        //Another Constructor
        public Sites(int i, double score, double mod_weight, string mod_name, char site, List<char> AA)
        {
            // TODO: Complete member initialization
            this.i = i;
            this.score = score;
            this.mod_weight = mod_weight;
            this.mod_name = mod_name;
            this.site = site;
            this.AA = AA;
        }

        // Set functions
        public void setIndex(int index)
        {
            i = index;
        }
        public void setScore(double sc)
        {
            score = sc;
        }
        public void setModWeight(double weight)
        {
            mod_weight = weight;
        }
        public void setModName(string name)
        {
            mod_name = name;
        }
        public void setSite(char syte)
        {
            site = syte;
        }
        public void setAmino(char[] amino)
        {
            foreach (char c in amino)
            {
                AA.Add(c);
            }
        }

        // Get functions
        public int getIndex()
        {
            return i;
        }
        public double getScore()
        {
            return score;
        }
        public double getModWeight()
        {
            return mod_weight;
        }
        public string getModName()
        {
            return mod_name;
        }
        public char getSite()
        {
            return site;
        }
        public List<char> getAmino()
        {
            return AA;
        }
    }



}