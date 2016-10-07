using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testapi.Models;
using System.IO;

namespace Testapi.Engine
{
    public class Insilico_Module
    {
        public static void insilico_fragmentation(List<proteins> prot, string clevageType, string ions)
        {
           // List<Fragment> result = new List<Fragment>();
            for (int i = 0; i < prot.Count; i++)
            {
                frag1(prot[i], clevageType, ions, i);
            }

            //return result;
        }

        public static void frag1(proteins prot, string clevageType, string HandleIon, int index)
        {
            string strprotein = prot.sequence;
            int prtlength = strprotein.Length; //Gives length of Protein
            strprotein = strprotein.ToUpper(); //Convert all amino aFragment letters into uppercase letters
           
            if (prot.ptm_particulars != null)
            {
                if (prot.ptm_particulars.Count != 0)
                {
                    for (int j = 0; j < prot.ptm_particulars.Count; j++)
                    {
                        prot.insilico_details.insilico_mass_right[0] += prot.ptm_particulars[j].mod_weight;
                        if (prot.ptm_particulars[j].i == 0)
                        {
                            prot.insilico_details.insilico_mass_left[0] += prot.ptm_particulars[j].mod_weight;
                        }
                    }
                }
            }

            for (int ifragmentationposition = 1; ifragmentationposition < prtlength; ifragmentationposition++)
            {
                if (prot.ptm_particulars != null)
                {
                    if (prot.ptm_particulars.Count != 0)
                    {
                        for (int j = 0; j < prot.ptm_particulars.Count; j++)
                        {
                            if (prot.ptm_particulars[j].i == ifragmentationposition)
                            {
                                for (int k = ifragmentationposition; k < prtlength;k++ )
                                    prot.insilico_details.insilico_mass_left[ifragmentationposition] += prot.ptm_particulars[j].mod_weight;
                                for (int k = ifragmentationposition; k > 0; k--)
                                    prot.insilico_details.insilico_mass_right[ifragmentationposition] -= prot.ptm_particulars[j].mod_weight;
                            }
                        }
                    }
                    else break;
                }
                else break;
            }
      
            if (clevageType == "CID" || clevageType == "cid" || clevageType == "bird" || clevageType == "BIRD" || clevageType == "imd" || clevageType == "IMD" || clevageType == "HCD" || clevageType == "hcd" || clevageType == "SID" || clevageType == "sid")
            {
                for (int i = 0; i < prtlength; i++)//for Fragment
                {
                    if (HandleIon == "bo")
                        prot.insilico_details.insilico_mass_left.Add(prot.insilico_details.insilico_mass_left[i] - 18 - 1.00794);
                    else if (HandleIon == "bstar")
                        prot.insilico_details.insilico_mass_left.Add(prot.insilico_details.insilico_mass_left[i] - 17.026549 - 1.00794);
                    else if (HandleIon == "ystar")
                        prot.insilico_details.insilico_mass_right.Add(prot.insilico_details.insilico_mass_right[i] - 17.026549 + 1.00794);
                    else if (HandleIon == "yo")
                        prot.insilico_details.insilico_mass_right.Add(prot.insilico_details.insilico_mass_right[i] - 18 + 1.00794);

                    prot.insilico_details.insilico_mass_left[i] -= 1.00794;
                    prot.insilico_details.insilico_mass_right[i] += 1.00794;
                }
            }

            else if (clevageType == "ECD" || clevageType == "ecd" || clevageType == "ETD" || clevageType == "etd")
            {
                for (int i = 0; i < prtlength; i++)//for Fragment
                {
                    if (HandleIon == "zd")
                        prot.insilico_details.insilico_mass_right.Add(prot.insilico_details.insilico_mass_right[i] + 1 - 16.02258);
                    else if (HandleIon == "zdd")
                        prot.insilico_details.insilico_mass_right.Add(prot.insilico_details.insilico_mass_right[i] + 2 - 16.02258);

                    prot.insilico_details.insilico_mass_left[i] += 16.02258;
                    prot.insilico_details.insilico_mass_right[i] -= 16.02258;
                }
            }

            else if (clevageType == "EDD" || clevageType == "edd" || clevageType == "NETD" || clevageType == "netd")
            {
                for (int i = 0; i < prtlength; i++)//for Fragment
                {
                    if (HandleIon == "ao")
                        prot.insilico_details.insilico_mass_left.Add(prot.insilico_details.insilico_mass_left[i] - 18 - 29.01804);
                    else if (HandleIon == "astar")
                        prot.insilico_details.insilico_mass_left.Add(prot.insilico_details.insilico_mass_left[i] - 17.026549 - 29.01804);

                    prot.insilico_details.insilico_mass_left[i] -= 29.01804;
                    prot.insilico_details.insilico_mass_right[i] += 27.02534;
                }
            }

           //return output;
        }

        public static void Insilico_filter( List<proteins> prot, List<double> peakList, double tol)
        {
            double l_score;
            double r_score;
            double score;
            bool left;
            bool right;
            insilico_obj comp;
            for (int j = 0; j < prot.Count; j++)
            {
                comp = new insilico_obj();
                r_score = 0;
                l_score = 0;

                comp = prot.ElementAt(j).insilico_details;
                //comp.insilico_mass_right = frags.ElementAt(j).mw_right_ion;

                for (int k = 0; k < prot.ElementAt(j).insilico_details.insilico_mass_left.Count; k++)
                {
                    left = false;
                    for (int i = 0; i < peakList.Count; i++)
                    {
                        if (Math.Abs(prot.ElementAt(j).insilico_details.insilico_mass_left[k] - peakList[i]) < tol)
                        {
                            l_score++;
                            comp.peaklist_mass_left.Add(peakList[i]);
                            left = true;
                        }
                    }
                    if (left == false)
                    {
                        comp.peaklist_mass_left.Add(0);
                    }
                }

                for (int k = 0; k < prot.ElementAt(j).insilico_details.insilico_mass_right.Count; k++)
                {
                    right = false;

                    for (int i = 0; i < peakList.Count; i++)
                    {
                        if (Math.Abs(prot.ElementAt(j).insilico_details.insilico_mass_right[k] - peakList[i]) < tol)
                        {
                            comp.peaklist_mass_right.Add(peakList[i]);
                            r_score++;
                            right = true;
                        }
                    }
                    if (right == false)
                    {
                        comp.peaklist_mass_right.Add(0);
                    }
                }

                score = (l_score + r_score) / (peakList.Count);
                Console.WriteLine("Insilico score:");
                Console.WriteLine(score);

                prot[j].insilico_score = score;
                prot[j].insilico_details = comp;
            }
        }


        public static void Insilico_filter_U( List<proteins> prot, List<double> peakList, double tol)
        {


            List<double> xyz = new List<double>();

            double l_score;
            double r_score;
            double score;

           // bool right;
            insilico_obj comp;
            for (int j = 0; j < prot.Count; j++)
            {
                comp = new insilico_obj();
                r_score = 0;
                l_score = 0;

                comp.insilico_mass_left = prot[j].insilico_details.insilico_mass_left; //frags.ElementAt(j).mw_left_ion;
                comp.insilico_mass_right = prot[j].insilico_details.insilico_mass_right;//frags.ElementAt(j).mw_right_ion;


                double[] m_arrayy = new double[comp.insilico_mass_right.Count];


                for (int mass_i = 0, peak_i = 0; mass_i < comp.insilico_mass_left.Count && peak_i < peakList.Count; )
                {


                    if ((comp.insilico_mass_left[mass_i] - peakList[peak_i]) <= (-1 * tol))
                    {
                        mass_i++;


                    }
                    else if ((comp.insilico_mass_left[mass_i] - peakList[peak_i]) >= (tol))
                    {
                        peak_i++;
                    }
                    else
                    {
                        l_score++;
                       // comp.peaklist_mass_left.Add(peakList[peak_i]);
                        m_arrayy[mass_i] = peakList[peak_i];
                        peak_i++;
                    }



                }
                comp.peaklist_mass_left = m_arrayy.ToList();

                 m_arrayy = new double[comp.insilico_mass_right.Count];



                for (int mass_i = 0, peak_i = 0; mass_i < comp.insilico_mass_right.Count && peak_i < peakList.Count; )
                {


                    if ((comp.insilico_mass_right[mass_i] - peakList[peak_i]) <= (-1 * tol))
                    {
                        mass_i++;


                    }
                    else if ((comp.insilico_mass_right[mass_i] - peakList[peak_i]) >= (tol))
                    {
                        peak_i++;
                    }
                    else
                    {
                        r_score++;
                        //comp.peaklist_mass_right.Add(peakList[peak_i]);

                        m_arrayy[mass_i] = peakList[peak_i];


                        peak_i++;
                    }

                    if (mass_i == 24 || peak_i == 150)
                    {

                    }


                }


                comp.peaklist_mass_right = m_arrayy.ToList();


                ///////////////////////////////////////////////////
                // Changed Code


                //for (int k = 0; k < frags[j].mw_left_ion.Count; k++)
                //{



                //    for (int i = 0; i < peakList.Count; i++)
                //    {



                //        if (Math.Abs(frags[j].mw_left_ion[k] - peakList[i]) < tol)
                //        {
                //            l_score++;
                //            comp.peaklist_mass_left.Add(peakList[i]);
                //            left = true;
                //        }

                //    }



                //}


                //for (int k = 0; k < frags[j].mw_right_ion.Count; k++)
                //{


                //    for (int i = 0; i < peakList.Count; i++)
                //    {

                //        if (Math.Abs(frags[j].mw_right_ion[k] - peakList[i]) < tol)
                //        {
                //            comp.peaklist_mass_right.Add(peakList[i]);
                //            r_score++;

                //        }


                //    }



                //}


                score = (l_score + r_score) / (peakList.Count);
                //Console.WriteLine("Insilico score:");
                //Console.WriteLine(score);

                prot[j].insilico_score = score;
                prot[j].insilico_details = comp;
            }



        }

        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void insilico_fragmentation_2(proteins prot, string clevageType, string ions)
        {
            frag1_2(prot, clevageType, ions, 0);

            //return result;
        }

        public static void frag1_2(proteins prot, string clevageType, string HandleIon, int index)
        {
            string strprotein = prot.sequence;
            int prtlength = strprotein.Length; //Gives length of Protein
            strprotein = strprotein.ToUpper(); //Convert all amino aFragment letters into uppercase letters

            if (prot.ptm_particulars != null)
            {
                if (prot.ptm_particulars.Count != 0)
                {
                    for (int j = 0; j < prot.ptm_particulars.Count; j++)
                    {
                        prot.insilico_details.insilico_mass_right[0] += prot.ptm_particulars[j].mod_weight;
                        if (prot.ptm_particulars[j].i == 0)
                        {
                            prot.insilico_details.insilico_mass_left[0] += prot.ptm_particulars[j].mod_weight;
                        }
                    }
                }
            }

            for (int ifragmentationposition = 1; ifragmentationposition < prtlength; ifragmentationposition++)
            {
                if (prot.ptm_particulars != null)
                {
                    if (prot.ptm_particulars.Count != 0)
                    {
                        for (int j = 0; j < prot.ptm_particulars.Count; j++)
                        {
                            if (prot.ptm_particulars[j].i == ifragmentationposition)
                            {
                                for (int k = ifragmentationposition; k < prtlength; k++)
                                    prot.insilico_details.insilico_mass_left[ifragmentationposition] += prot.ptm_particulars[j].mod_weight;
                                for (int k = ifragmentationposition; k > 0; k--)
                                    prot.insilico_details.insilico_mass_right[ifragmentationposition] -= prot.ptm_particulars[j].mod_weight;
                            }
                        }
                    }
                    else break;
                }
                else break;
            }

            if (clevageType == "CID" || clevageType == "cid" || clevageType == "bird" || clevageType == "BIRD" || clevageType == "imd" || clevageType == "IMD" || clevageType == "HCD" || clevageType == "hcd" || clevageType == "SID" || clevageType == "sid")
            {
                for (int i = 0; i < prtlength; i++)//for Fragment
                {
                    if (HandleIon == "bo")
                        prot.insilico_details.insilico_mass_left.Add(prot.insilico_details.insilico_mass_left[i] - 18 - 1.00794);
                    else if (HandleIon == "bstar")
                        prot.insilico_details.insilico_mass_left.Add(prot.insilico_details.insilico_mass_left[i] - 17.026549 - 1.00794);
                    else if (HandleIon == "ystar")
                        prot.insilico_details.insilico_mass_right.Add(prot.insilico_details.insilico_mass_right[i] - 17.026549 + 1.00794);
                    else if (HandleIon == "yo")
                        prot.insilico_details.insilico_mass_right.Add(prot.insilico_details.insilico_mass_right[i] - 18 + 1.00794);

                    prot.insilico_details.insilico_mass_left[i] -= 1.00794;
                    prot.insilico_details.insilico_mass_right[i] += 1.00794;
                }
            }

            else if (clevageType == "ECD" || clevageType == "ecd" || clevageType == "ETD" || clevageType == "etd")
            {
                for (int i = 0; i < prtlength; i++)//for Fragment
                {
                    if (HandleIon == "zd")
                        prot.insilico_details.insilico_mass_right.Add(prot.insilico_details.insilico_mass_right[i] + 1 - 16.02258);
                    else if (HandleIon == "zdd")
                        prot.insilico_details.insilico_mass_right.Add(prot.insilico_details.insilico_mass_right[i] + 2 - 16.02258);

                    prot.insilico_details.insilico_mass_left[i] += 16.02258;
                    prot.insilico_details.insilico_mass_right[i] -= 16.02258;
                }
            }

            else if (clevageType == "EDD" || clevageType == "edd" || clevageType == "NETD" || clevageType == "netd")
            {
                for (int i = 0; i < prtlength; i++)//for Fragment
                {
                    if (HandleIon == "ao")
                        prot.insilico_details.insilico_mass_left.Add(prot.insilico_details.insilico_mass_left[i] - 18 - 29.01804);
                    else if (HandleIon == "astar")
                        prot.insilico_details.insilico_mass_left.Add(prot.insilico_details.insilico_mass_left[i] - 17.026549 - 29.01804);

                    prot.insilico_details.insilico_mass_left[i] -= 29.01804;
                    prot.insilico_details.insilico_mass_right[i] += 27.02534;
                }
            }

            //return output;
        }
        public static void Insilico_filter_U2(proteins prot, List<double> peakList, double tol)
        {


            double l_score;
            double r_score;
            double score;
            bool left;
            bool right;
            insilico_obj comp;
            
                comp = new insilico_obj();
                r_score = 0;
                l_score = 0;

                comp = prot.insilico_details;
                //comp.insilico_mass_right = frags.ElementAt(j).mw_right_ion;

                for (int k = 0; k < prot.insilico_details.insilico_mass_left.Count; k++)
                {
                    left = false;
                    for (int i = 0; i < peakList.Count; i++)
                    {
                        if (Math.Abs(prot.insilico_details.insilico_mass_left[k] - peakList[i]) < tol)
                        {
                            l_score++;
                            comp.peaklist_mass_left.Add(peakList[i]);
                            left = true;
                        }
                    }
                    if (left == false)
                    {
                        comp.peaklist_mass_left.Add(0);
                    }
                }

                for (int k = 0; k < prot.insilico_details.insilico_mass_right.Count; k++)
                {
                    right = false;

                    for (int i = 0; i < peakList.Count; i++)
                    {
                        if (Math.Abs(prot.insilico_details.insilico_mass_right[k] - peakList[i]) < tol)
                        {
                            comp.peaklist_mass_right.Add(peakList[i]);
                            r_score++;
                            right = true;
                        }
                    }
                    if (right == false)
                    {
                        comp.peaklist_mass_right.Add(0);
                    }
                }

                score = (l_score + r_score) / (peakList.Count);
                Console.WriteLine("Insilico score:");
                Console.WriteLine(score);

                prot.insilico_score = score;
                prot.insilico_details = comp;
            

        }

    }
}