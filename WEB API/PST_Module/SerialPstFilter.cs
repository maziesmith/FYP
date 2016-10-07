using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DTO;

namespace PST_Module
{
    class SerialPstFilter : IPstFilter
    {
        private readonly List<Tags> _pstTags;
        private readonly List<Proteins> _proteins;

        public SerialPstFilter( List<Proteins> proteins)
        { 
            this._proteins = proteins;
        }

        public void FilterProteinsByPstScore(List<Tags> pstTags)
        {
            AssignPstScore(_pstTags, _proteins);

            FilterByScore(_proteins);
        }

        public List<Proteins> GetFilteredProteins()
        {
            return _proteins;
        }

        private static void AssignPstScore(List<Tags> pstTags, List<Proteins> proteins)
        {
            foreach (Proteins protein in proteins)
            {
                double score = 0;

                foreach (Tags tag in pstTags)
                {
                    var occurences = Regex.Matches(protein.Sequence, tag.Aa).Count;

                    score += (tag.ScoreE + tag.ScoreI + tag.ScoreL)*occurences;
                }


                score = score/protein.Sequence.Length;

                protein.EstScore = score;
            }
        }

        private static void FilterByScore(List<Proteins> proteins)
        {
            for (int i = proteins.Count - 1; i >= 0; i--)
            {
                if (proteins[i].EstScore <= 0)
                {
                    proteins.RemoveAt(i);
                }
            }
        }
    }
}
