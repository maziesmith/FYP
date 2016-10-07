using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace PST_Module
{
    class SerialPstComputation : IPstComputation
    {

        private readonly IPstGenerator _pstGenerator;
        private readonly IPstFilter _pstFilter;
        private List<Tags> _pstTags;
        private List<Proteins> _proteins;

        public SerialPstComputation(int mintagLength, int maxtagLength, double hopTol, List<double> intensity,
            List<double> peakList, List<Proteins> proteinList)
        {
            _pstFilter = new SerialPstFilter(proteinList);
            _pstGenerator = new SerialPstGenerator(mintagLength,maxtagLength,hopTol,intensity,peakList );
            _proteins = proteinList;
        }

        public void FilterProteinsByDenovoSequencing()
        {
            _pstTags = _pstGenerator.GeneratePstTagsFromPeaklistData();
            _pstFilter.FilterProteinsByPstScore(_pstTags);
            _proteins = _pstFilter.GetFilteredProteins();
        }

        public List<Proteins> GetFilteredProteins()
        {
            return _proteins;
        }


       
    }
}
