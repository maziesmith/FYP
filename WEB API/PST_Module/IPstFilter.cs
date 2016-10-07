using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace PST_Module
{
    interface IPstFilter
    {
        void FilterProteinsByPstScore(List<Tags> pstTags);
    
        List<Proteins> GetFilteredProteins();
    }
}
