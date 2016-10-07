using System.Collections.Generic;
using DTO;

namespace PST_Module
{
    public interface IPstComputation
    {
        void FilterProteinsByDenovoSequencing();

        List<Proteins> GetFilteredProteins();

    }
}