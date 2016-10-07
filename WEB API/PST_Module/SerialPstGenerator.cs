using System;
using System.Collections.Generic;
using System.Linq;
using AminoAcidData;
using DTO;

namespace PST_Module
{
    internal class SerialPstGenerator : IPstGenerator
    {
        private readonly List<double> _peakList;
        private readonly List<double> _intensity;
        private readonly double _hopTol;
        private readonly int _mintagLength;
        private readonly int _maxtagLength;

        private const char AminoAcidDoesNotExist = '*';
        private const int MaximumAminoAcidMolecularWeight = 465;
        private const int NotSelected = -1;

        public SerialPstGenerator(int mintagLength, int maxtagLength, double hopTol, List<double> intensity,
            List<double> peakList)
        {
            _mintagLength = mintagLength;
            _maxtagLength = maxtagLength;
            _hopTol = hopTol;
            _intensity = intensity;
            _peakList = peakList;
        }

       

        public List<Tags> GeneratePstTagsFromPeaklistData()
        {
            //Sorting peaklist in ascending order
            _peakList.Sort();

            var singleTagList = ExtractSingleTags();


            var doubletagList = PairUpAdjacentTags(singleTagList);


            // Generates the tags of length bigger than two using doublelength tags
            var multipletagList = GenerateLargerTagsRecursively(doubletagList);


            // Tag_Ladder stores tags of all lengths
            var tagLadder = MergeTags(singleTagList, multipletagList);
            ;


            //Filters for tags with desired length
            if ((_mintagLength != NotSelected) && (_maxtagLength != NotSelected))
                FilterTagsByLength(tagLadder);


            RemoveDuplicateTags(tagLadder);


            return tagLadder;
        }

        private static void RemoveDuplicateTags(List<Tags> tagLadder)
        {
            for (var i = tagLadder.Count - 1; i >= 0; i--)
                for (var j = i - 1; j >= 0; j--)
                    if (tagLadder[i].Aa == tagLadder[j].Aa)
                    {
                        if (tagLadder[i].ScoreE < tagLadder[j].ScoreE)
                            tagLadder.RemoveAt(j);
                        else
                            tagLadder.RemoveAt(i);
                        break;
                    }
        }

        private void FilterTagsByLength(List<Tags> tagLadder)
        {
            for (var i = tagLadder.Count - 1; i >= 0; i--)


                if ((tagLadder[i].Len < _mintagLength) || (tagLadder[i].Len > _maxtagLength))
                    tagLadder.RemoveAt(i);
        }

        private static List<Tags> MergeTags(List<Tags> first, List<Tags> second)
        {
            first.AddRange(second);
            return first;
        }

        private List<Tags> PairUpAdjacentTags(List<Tags> singleTagList)
        {
            var doubleTagList = new List<Tags>();

            for (var i = 0; i < singleTagList.Count; i++)
                for (var j = i + 1; j < singleTagList.Count; j++)
                    if (singleTagList[i].End == singleTagList[j].Start)
                    {
                        //temporary list holds errors of both participating tags
                        var tempError = new List<double>
                        {
                            singleTagList[i].Errors[0],
                            singleTagList[j].Errors[0]
                        };


                        //temporary list holds intensities of both
                        var tempIntensity = new List<double>
                        {
                            singleTagList[i].Intensity[0],
                            singleTagList[j].Intensity[0]
                        };


                        var temp = new Tags(singleTagList[i].Aa + singleTagList[j].Aa, singleTagList[i].Start,
                            singleTagList[j].End, tempError, tempIntensity, 2);
                        // both tags are joined into one tag and added to double_list


                        //NEWCODE

                        temp.Locations.Add(singleTagList[i].Start);
                        temp.Locations.Add(singleTagList[i].Start);
                        temp.Locations.Add(singleTagList[j].Start);
                        //////////////////////////////////


                        doubleTagList.Add(temp);
                    }


                    // avoids iteration through unnecessary tags
                    else if (singleTagList[i].End < singleTagList[j].Start)
                    {
                        break;
                    }
            return doubleTagList;
        }

        private List<Tags> ExtractSingleTags()
        {
            var singletagList = new List<Tags>();
            for (var i = 0; i < _peakList.Count; i++)
                for (var j = i + 1; j < _peakList.Count; j++)
                {
                    var innerPeak = _peakList[i];
                    var outerPeak = _peakList[j];

                    var differenceOfPeaks = _peakList[j] - _peakList[i];
                    var tempAminoAcid = AminoAcids.GetAminoAcid(differenceOfPeaks, _hopTol);
                    if (differenceOfPeaks > MaximumAminoAcidMolecularWeight)
                        break;
                    if (tempAminoAcid != AminoAcidDoesNotExist)
                    {
                        //Calculating error square
                        var errorSquare = new List<double>
                        {
                            Math.Pow(AminoAcids.GetMolecularWeight(tempAminoAcid) - (outerPeak - innerPeak), 2)
                        };


                        var avgIntensity = new List<double> {GetAverage(_intensity[i], _intensity[j])};


                        var temp = new Tags(tempAminoAcid.ToString(), i, j, errorSquare, avgIntensity);


                        temp.Locations.Add(i);
                        temp.Locations.Add(j);

                        /////////////////////////////////////////////////////////////////////////////////////////////

                        singletagList.Add(temp);
                    }
                } //inner loop terminated
            return singletagList;
        }

        private double GetAverage(double one, double two)
        {
            return (one + two)/2;
        }

        private List<Tags> GenerateLargerTagsRecursively(List<Tags> pst, int n = 1, int numberOfPstInLastRun = 0)
        {
            var numberOfPst = pst.Count;

            for (var i = numberOfPstInLastRun; i < numberOfPst; i++)
                for (var j = i + 1; j < numberOfPst; j++)
                    if ((pst[i].Aa.Substring(pst[i].Aa.Length - n, n) == pst[j].Aa.Substring(0, n)) &&
                        (pst[i].End > pst[j].Start))
                    {
                        var overlapFound = true;
                        var start1 = pst[i].Aa.Length - n - 1;

                        for (var start2 = 0; start2 < n + 1; start2++, start1++)
                            if (pst[i].Locations[start1] == pst[j].Locations[start2])
                            {
                                overlapFound = false;
                                break;
                            }
                        if (overlapFound)
                        {
                            var temp1 = pst[i].Errors.ToList();

                            temp1.Add(pst[j].Errors[pst[j].Errors.Count - 1]);

                            var temp2 = pst[i].Intensity.ToList();

                            temp2.Add(pst[j].Intensity[pst[j].Intensity.Count - 1]);


                            var temp = new Tags(pst[i].Aa.Substring(0, pst[i].Aa.Length - n) + pst[j].Aa, pst[i].Start,
                                pst[j].End, temp1, temp2, 2 + n);


                            for (var iterator = 0; iterator < pst[i].Locations.Count; iterator++)
                                temp.Locations.Add(pst[i].Locations[iterator]);

                            temp.Locations.Add(pst[j].Locations[pst[j].Locations.Count - 1]);

                            pst.Add(temp);
                        }
                    } //end if

            var newNumberOfPst = pst.Count;
            if (newNumberOfPst == numberOfPst)
                return pst;


            return GenerateLargerTagsRecursively(pst, n + 1, numberOfPst);
        }
    }
}

