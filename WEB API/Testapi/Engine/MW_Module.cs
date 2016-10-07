using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testapi.Models;
using System.IO;


namespace Testapi.Engine
{
    //! MW_Module class
    /*!
     * This class is used to load the user selected database into memory along with their insilico fragments and the MW. It also computes the MW_score 
     * 
     * This class loads the databases into a persistent dictionary on first run which means its keys will be in the memory while the
     * data will reside on the disk. It further computes the MW and the insilico fragments and store them along with protein information extracted from the 
     * Uniprot.
     */
    public class MW_Module
    {
        public static CPersistentDictionary Uniprot = new CPersistentDictionary(@"C:\inetpub\wwwroot\DIC\DIC\Uniprot.txt");              /*!< Uniprot.txt stores the Uniprot i.e. all annotated proteins along with their fragments and MW. */
        public static CPersistentDictionary Ubiquitin = new CPersistentDictionary(@"C:\inetpub\wwwroot\DIC\DIC\Ubiquitin.txt");          /*!< Ubiquitin.txt stores the test ubiquitin database. It contains 8 proteins. */
        public static CPersistentDictionary Archaea = new CPersistentDictionary(@"C:\inetpub\wwwroot\DIC\DIC\Archea.txt");               /*!< Archea.txt stores all the Archea annotated proteins. */
        public static CPersistentDictionary Bacteria = new CPersistentDictionary(@"C:\inetpub\wwwroot\DIC\DIC\Bacteria.txt");            /*!< Bacteria.txt stores all the Bacteria annotated proteins. */
        public static CPersistentDictionary Cellular = new CPersistentDictionary(@"C:\inetpub\wwwroot\DIC\DIC\Cellular.txt");            /*!< Cellular.txt stores all the Cellular annotated proteins. */
        public static CPersistentDictionary Eukaryota = new CPersistentDictionary(@"C:\inetpub\wwwroot\DIC\DIC\Eukaryota.txt");          /*!< Eukaryota.txt stores all the Eukaryota annotated proteins. */
        public static CPersistentDictionary Fungi = new CPersistentDictionary(@"C:\inetpub\wwwroot\DIC\DIC\Fungi.txt");                  /*!< Fungi.txt stores all the Fungi annotated proteins. */
        public static CPersistentDictionary Human = new CPersistentDictionary(@"C:\inetpub\wwwroot\DIC\DIC\Human.txt");                  /*!< Human.txt stores all the Human annotated proteins. */
        public static CPersistentDictionary Vertebrates = new CPersistentDictionary(@"C:\inetpub\wwwroot\DIC\DIC\Vertebrates.txt");      /*!< Vertebrates.txt stores all the Vertebrates annotated proteins. */
        public static CPersistentDictionary Mammals = new CPersistentDictionary(@"C:\inetpub\wwwroot\DIC\DIC\Mammals.txt");              /*!< Mammals.txt stores all the Mammals annotated proteins. */
        public static CPersistentDictionary Rodents = new CPersistentDictionary(@"C:\inetpub\wwwroot\DIC\DIC\Rodents.txt");              /*!< Rodents.txt stores all the Rodents annotated proteins. */
        public static CPersistentDictionary Viridiplantae = new CPersistentDictionary(@"C:\inetpub\wwwroot\DIC\DIC\Virdiplantae.txt");   /*!< Virdiplantae.txt stores all the Virdiplantae annotated proteins. */
        public static CPersistentDictionary Viruses = new CPersistentDictionary(@"C:\inetpub\wwwroot\DIC\DIC\Viruses.txt");              /*!< Viruses.txt stores all the Viruses annotated proteins. */

        public static int cond_var = -1;     /*!< Condition Variable */

        public static List<int> Uniprot_list = new List<int>();         /*!< Uniprot_list contains the integer masses of all protein in Uniprot. */
        public static List<int> Ubiquitin_list = new List<int>();       /*!< Ubiquitin_list contains the integer masses of all protein in Ubiquitin.  */
        public static List<int> Archaea_list = new List<int>();         /*!< Archaea_list contains the integer masses of all protein in Archea. */
        public static List<int> Bacteria_list = new List<int>();        /*!< Bacteria_list contains the integer masses of all protein in Bacteria */
        public static List<int> Cellular_list = new List<int>();        /*!< Cellular_list contains the integer masses of all protein in Cellular taxonomy. */
        public static List<int> Eukaryota_list = new List<int>();       /*!< Eukaryota_list contains the integer masses of all protein in Eukoryotes. */
        public static List<int> Fungi_list = new List<int>();           /*!< Fungi_list contains the integer masses of all protein in Fungi. */
        public static List<int> Human_list = new List<int>();           /*!< Human_list contains the integer masses of all protein in Human. */
        public static List<int> Vertebrates_list = new List<int>();     /*!< Vertebrates_list contains the integer masses of all protein in vertebrates.  */
        public static List<int> Mammals_list = new List<int>();         /*!< Mammals_list contains the integer masses of all protein in Mammals. */
        public static List<int> Rodents_list = new List<int>();         /*!< Rodents_list contains the integer masses of all protein in rodents. */
        public static List<int> Viridiplantae_list = new List<int>();   /*!< Viridiplantae_list contains the integer masses of all protein in Virdiplantae. */
        public static List<int> Viruses_list = new List<int>();         /*!< Viruses_list contains the integer masses of all protein in Viruses. */

        //! SQLITED-SQLITED12 are static member function with no arguments and void return type
        /*!
         *These functions Load the Databse into the dic along with the computation of the MW and the Insilico fragments
         */
        public static void SQLITED()
        {
            data data1 = new data();                /*!<  */
            int counter = 0; int counter1 = 0;      /*!<  */
            List<data> tempD = new List<data>();    /*!<  */
            string line;                /*!<  */
            string temp_header = "";    /*!<  */
            string temp_sequence = "";  /*!<  */
            string path = @"C:\inetpub\wwwroot\Databases\uniprot_sprot.fasta";   /*!<  */
            StreamReader file = new StreamReader(path);     /*!<  */

            while ((line = file.ReadLine()) != null)        /*!<  */
            {
                if (line.Contains('>') && counter > 0)      /*!<  */
                {

                    double temp_MW = AminoAcids.getMW(temp_sequence[0]);


                    for (int i = 0; i < temp_sequence.Length; i++)
                    {
                        temp_MW = temp_MW + AminoAcids.getMW(temp_sequence[i]);
                    }

                    string k = temp_header.Substring(4, 6);
                    data1 = new data(k, temp_sequence, temp_MW, "", "");
                    tempD.Add(data1);

                    temp_header = "";
                    temp_sequence = "";


                }

                if (line.Contains(" "))
                {
                    temp_header = temp_header + line;
                }
                else
                    temp_sequence = temp_sequence + line;

                counter++;
            }
            tempD = tempD.OrderBy(n => n.MW).ToList();
            List<double> left = new List<double>();
            List<double> right = new List<double>();
            string Insilico_Left;
            string Insilico_Right;


            while (tempD.Count > 0)
            {
                counter1++;
                Insilico_Left = "";
                Insilico_Right = "";
                left = new List<double>();
                right = new List<double>();

                var duplicateKeys = tempD.GroupBy(x => x.MW).Where(group => group.Count() > 1).Select(group => group.Key);
                string strprotein = tempD[0].Seq;
                int prtlength = strprotein.Length;

                left.Add(AminoAcids.getMW(strprotein[0]));
                right.Add(tempD[0].MW);

                for (int ifragmentationposition = 1; ifragmentationposition < prtlength; ifragmentationposition++)
                {
                    left.Add(left[ifragmentationposition - 1] + AminoAcids.getMW(strprotein[ifragmentationposition]));
                    right.Add(right[ifragmentationposition - 1] - AminoAcids.getMW(strprotein[ifragmentationposition]));
                }

                Insilico_Left= String.Join(",", left.Select(x => x.ToString()).ToArray());
                Insilico_Right = String.Join(",", right.Select(x => x.ToString()).ToArray());
                ///////////////////////

                string res = "";
                res = tempD[0].ID + "&" + tempD[0].MW.ToString() + "&" + tempD[0].Seq + "&" + Insilico_Left+ "&" + Insilico_Right + "\n";
                string index = Convert.ToInt32(tempD[0].MW).ToString();
                string temp_str = "";
                temp_str = Uniprot[index].ToString();
                if (temp_str == "")
                {
                    Uniprot_list.Add(Convert.ToInt32(index));
                    Uniprot.Add(index, "-" + res);
                }
                else
                {
                    res = res.Substring(0, res.Length - 2) + "|" + temp_str.ToString() + "\n";
                    Uniprot.Add(index, res);
                }
                tempD.RemoveAt(0);

            }
            file.Close();
            cond_var = 1;
        }
        public static void SQLITED1()
        {
            data data1 = new data();
            int counter = 0; int counter1 = 0;
            List<data> tempD = new List<data>();
            string line;
            string temp_h = "";
            string temp_s = "";
            string path = @"C:\inetpub\wwwroot\Databases\ubiquitin_db.fasta";
            StreamReader file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains('>') && counter > 0)
                {

                    double temp_MW = AminoAcids.getMW(temp_s[0]);


                    for (int i = 0; i < temp_s.Length; i++)
                    {
                        temp_MW = temp_MW + AminoAcids.getMW(temp_s[i]);
                    }



                    string k;
                    if (temp_h.Contains('|'))
                    {
                        k = temp_h.Substring(4, 6);
                    }
                    else
                    {
                        k = temp_h.Substring(1);
                    }

                    //                    string k = temp_h.Substring(4, 6);

                    data1 = new data(k, temp_s, temp_MW, "", "");
                    tempD.Add(data1);

                    temp_h = "";
                    temp_s = "";


                }

                if (line.Contains(" "))
                {
                    temp_h = temp_h + line;
                }
                else
                    temp_s = temp_s + line;

                counter++;
            }
            tempD = tempD.OrderBy(n => n.MW).ToList();
            List<double> left = new List<double>();
            List<double> right = new List<double>();
            string Ins;
            string InsR;


            while (tempD.Count > 0)
            {
                counter1++;
                Ins = "";
                InsR = "";
                left = new List<double>();
                right = new List<double>();

                var duplicateKeys = tempD.GroupBy(x => x.MW).Where(group => group.Count() > 1).Select(group => group.Key);
                string strprotein = tempD[0].Seq;
                int prtlength = strprotein.Length;

                left.Add(AminoAcids.getMW(strprotein[0]));
                right.Add(tempD[0].MW);

                for (int ifragmentationposition = 1; ifragmentationposition < prtlength; ifragmentationposition++)
                {
                    left.Add(left[ifragmentationposition - 1] + AminoAcids.getMW(strprotein[ifragmentationposition]));
                    right.Add(right[ifragmentationposition - 1] - AminoAcids.getMW(strprotein[ifragmentationposition]));
                }

                Ins = String.Join(",", left.Select(x => x.ToString()).ToArray());
                InsR = String.Join(",", right.Select(x => x.ToString()).ToArray());

                string res = "";
                res = tempD[0].ID + "&" + tempD[0].MW.ToString() + "&" + tempD[0].Seq + "&" + Ins + "&" + InsR;
                string index = Convert.ToInt32(tempD[0].MW).ToString();
                string xyx = "";
                xyx = Ubiquitin[index].ToString();
                if (xyx == "")
                {
                    Ubiquitin_list.Add(Convert.ToInt32(index));
                    Ubiquitin.Add(index, "-" + res);
                }
                else
                {

                    res = res.Substring(0, res.Length - 2) + "|" + xyx.ToString();
                    Ubiquitin.Add(index, res);
                }
                tempD.RemoveAt(0);

            }
            file.Close();
            cond_var = 1;
        }
        public static void SQLITED2()
        {
            data data1 = new data();
            int counter = 0; int counter1 = 0;
            List<data> tempD = new List<data>();
            string line;
            string temp_h = "";
            string temp_s = "";
            string path = @"C:\inetpub\wwwroot\Databases\uniprot_sprot_archaea.fasta";
            StreamReader file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains('>') && counter > 0)
                {

                    double temp_MW = AminoAcids.getMW(temp_s[0]);


                    for (int i = 0; i < temp_s.Length; i++)
                    {
                        temp_MW = temp_MW + AminoAcids.getMW(temp_s[i]);
                    }

                    string k = temp_h.Substring(4, 6);
                    data1 = new data(k, temp_s, temp_MW, "", "");
                    tempD.Add(data1);

                    temp_h = "";
                    temp_s = "";


                }

                if (line.Contains(" "))
                {
                    temp_h = temp_h + line;
                }
                else
                    temp_s = temp_s + line;

                counter++;
            }
            tempD = tempD.OrderBy(n => n.MW).ToList();
            List<double> left = new List<double>();
            List<double> right = new List<double>();
            string Ins;
            string InsR;


            while (tempD.Count > 0)
            {
                counter1++;
                Ins = "";
                InsR = "";
                left = new List<double>();
                right = new List<double>();

                var duplicateKeys = tempD.GroupBy(x => x.MW).Where(group => group.Count() > 1).Select(group => group.Key);
                string strprotein = tempD[0].Seq;
                int prtlength = strprotein.Length;

                left.Add(AminoAcids.getMW(strprotein[0]));
                right.Add(tempD[0].MW);

                for (int ifragmentationposition = 1; ifragmentationposition < prtlength; ifragmentationposition++)
                {
                    left.Add(left[ifragmentationposition - 1] + AminoAcids.getMW(strprotein[ifragmentationposition]));
                    right.Add(right[ifragmentationposition - 1] - AminoAcids.getMW(strprotein[ifragmentationposition]));
                }

                Ins = String.Join(",", left.Select(x => x.ToString()).ToArray());
                InsR = String.Join(",", right.Select(x => x.ToString()).ToArray());

                string res = "";
                res = tempD[0].ID + "&" + tempD[0].MW.ToString() + "&" + tempD[0].Seq + "&" + Ins + "&" + InsR + "\n";
                string index = Convert.ToInt32(tempD[0].MW).ToString();
                string xyx = "";
                xyx = Archaea[index].ToString();
                if (xyx == "")
                {
                    Archaea_list.Add(Convert.ToInt32(index));
                    Archaea.Add(index, res);
                }
                else
                {
                    res = res.Substring(0, res.Length - 2) + "|" + xyx.ToString() + "\n";
                    Archaea.Add(index, res);
                }
                tempD.RemoveAt(0);

            }
            file.Close();
            cond_var = 1;
        }
        public static void SQLITED3()
        {
            data data1 = new data();
            int counter = 0; int counter1 = 0;
            List<data> tempD = new List<data>();
            string line;
            string temp_h = "";
            string temp_s = "";
            string path = @"C:\inetpub\wwwroot\Databases\uniprot_sprot_bacteria.fasta";
            StreamReader file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains('>') && counter > 0)
                {

                    double temp_MW = AminoAcids.getMW(temp_s[0]);


                    for (int i = 0; i < temp_s.Length; i++)
                    {
                        temp_MW = temp_MW + AminoAcids.getMW(temp_s[i]);
                    }

                    string k = temp_h.Substring(4, 6);
                    data1 = new data(k, temp_s, temp_MW, "", "");
                    tempD.Add(data1);

                    temp_h = "";
                    temp_s = "";


                }

                if (line.Contains(" "))
                {
                    temp_h = temp_h + line;
                }
                else
                    temp_s = temp_s + line;

                counter++;
            }
            tempD = tempD.OrderBy(n => n.MW).ToList();
            List<double> left = new List<double>();
            List<double> right = new List<double>();
            string Ins;
            string InsR;


            while (tempD.Count > 0)
            {
                counter1++;
                Ins = "";
                InsR = "";
                left = new List<double>();
                right = new List<double>();

                var duplicateKeys = tempD.GroupBy(x => x.MW).Where(group => group.Count() > 1).Select(group => group.Key);
                string strprotein = tempD[0].Seq;
                int prtlength = strprotein.Length;

                left.Add(AminoAcids.getMW(strprotein[0]));
                right.Add(tempD[0].MW);

                for (int ifragmentationposition = 1; ifragmentationposition < prtlength; ifragmentationposition++)
                {
                    left.Add(left[ifragmentationposition - 1] + AminoAcids.getMW(strprotein[ifragmentationposition]));
                    right.Add(right[ifragmentationposition - 1] - AminoAcids.getMW(strprotein[ifragmentationposition]));
                }

                Ins = String.Join(",", left.Select(x => x.ToString()).ToArray());
                InsR = String.Join(",", right.Select(x => x.ToString()).ToArray());

                string res = "";
                res = tempD[0].ID + "&" + tempD[0].MW.ToString() + "&" + tempD[0].Seq + "&" + Ins + "&" + InsR + "\n";
                string index = Convert.ToInt32(tempD[0].MW).ToString();
                string xyx = "";
                xyx = Bacteria[index].ToString();
                if (xyx == "")
                {
                    Bacteria_list.Add(Convert.ToInt32(index));
                    Bacteria.Add(index, res);
                }
                else
                {
                    res = res.Substring(0, res.Length - 2) + "|" + xyx.ToString() + "\n";
                    Bacteria.Add(index, res);
                }
                tempD.RemoveAt(0);

            }
            file.Close();
            cond_var = 1;
        }
        public static void SQLITED4()
        {
            data data1 = new data();
            int counter = 0; int counter1 = 0;
            List<data> tempD = new List<data>();
            string line;
            string temp_h = "";
            string temp_s = "";
            string path = @"C:\inetpub\wwwroot\Databases\uniprot_sprot_Cellular.fasta";
            StreamReader file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains('>') && counter > 0)
                {

                    double temp_MW = AminoAcids.getMW(temp_s[0]);


                    for (int i = 0; i < temp_s.Length; i++)
                    {
                        temp_MW = temp_MW + AminoAcids.getMW(temp_s[i]);
                    }

                    string k = temp_h.Substring(4, 6);
                    data1 = new data(k, temp_s, temp_MW, "", "");
                    tempD.Add(data1);

                    temp_h = "";
                    temp_s = "";


                }

                if (line.Contains(" "))
                {
                    temp_h = temp_h + line;
                }
                else
                    temp_s = temp_s + line;

                counter++;
            }
            tempD = tempD.OrderBy(n => n.MW).ToList();
            List<double> left = new List<double>();
            List<double> right = new List<double>();
            string Ins;
            string InsR;


            while (tempD.Count > 0)
            {
                counter1++;
                Ins = "";
                InsR = "";
                left = new List<double>();
                right = new List<double>();

                var duplicateKeys = tempD.GroupBy(x => x.MW).Where(group => group.Count() > 1).Select(group => group.Key);
                string strprotein = tempD[0].Seq;
                int prtlength = strprotein.Length;

                left.Add(AminoAcids.getMW(strprotein[0]));
                right.Add(tempD[0].MW);

                for (int ifragmentationposition = 1; ifragmentationposition < prtlength; ifragmentationposition++)
                {
                    left.Add(left[ifragmentationposition - 1] + AminoAcids.getMW(strprotein[ifragmentationposition]));
                    right.Add(right[ifragmentationposition - 1] - AminoAcids.getMW(strprotein[ifragmentationposition]));
                }

                Ins = String.Join(",", left.Select(x => x.ToString()).ToArray());
                InsR = String.Join(",", right.Select(x => x.ToString()).ToArray());

                string res = "";
                res = tempD[0].ID + "&" + tempD[0].MW.ToString() + "&" + tempD[0].Seq + "&" + Ins + "&" + InsR + "\n";
                string index = Convert.ToInt32(tempD[0].MW).ToString();
                string xyx = "";
                xyx = Cellular[index].ToString();
                if (xyx == "")
                {
                    Cellular_list.Add(Convert.ToInt32(index));
                    Cellular.Add(index, res);
                }
                else
                {
                    res = res.Substring(0, res.Length - 2) + "|" + xyx.ToString() + "\n";
                    Cellular.Add(index, res);
                }
                tempD.RemoveAt(0);

            }
            file.Close();
            cond_var = 1;
        }
        public static void SQLITED5()
        {
            data data1 = new data();
            int counter = 0; int counter1 = 0;
            List<data> tempD = new List<data>();
            string line;
            string temp_h = "";
            string temp_s = "";
            string path = @"C:\inetpub\wwwroot\Databases\uniprot_sprot_Eukaryota.fasta";
            StreamReader file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains('>') && counter > 0)
                {

                    double temp_MW = AminoAcids.getMW(temp_s[0]);


                    for (int i = 0; i < temp_s.Length; i++)
                    {
                        temp_MW = temp_MW + AminoAcids.getMW(temp_s[i]);
                    }

                    string k = temp_h.Substring(4, 6);
                    data1 = new data(k, temp_s, temp_MW, "", "");
                    tempD.Add(data1);

                    temp_h = "";
                    temp_s = "";


                }

                if (line.Contains(" "))
                {
                    temp_h = temp_h + line;
                }
                else
                    temp_s = temp_s + line;

                counter++;
            }
            tempD = tempD.OrderBy(n => n.MW).ToList();
            List<double> left = new List<double>();
            List<double> right = new List<double>();
            string Ins;
            string InsR;


            while (tempD.Count > 0)
            {
                counter1++;
                Ins = "";
                InsR = "";
                left = new List<double>();
                right = new List<double>();

                var duplicateKeys = tempD.GroupBy(x => x.MW).Where(group => group.Count() > 1).Select(group => group.Key);
                string strprotein = tempD[0].Seq;
                int prtlength = strprotein.Length;

                left.Add(AminoAcids.getMW(strprotein[0]));
                right.Add(tempD[0].MW);

                for (int ifragmentationposition = 1; ifragmentationposition < prtlength; ifragmentationposition++)
                {
                    left.Add(left[ifragmentationposition - 1] + AminoAcids.getMW(strprotein[ifragmentationposition]));
                    right.Add(right[ifragmentationposition - 1] - AminoAcids.getMW(strprotein[ifragmentationposition]));
                }

                Ins = String.Join(",", left.Select(x => x.ToString()).ToArray());
                InsR = String.Join(",", right.Select(x => x.ToString()).ToArray());

                string res = "";
                res = tempD[0].ID + "&" + tempD[0].MW.ToString() + "&" + tempD[0].Seq + "&" + Ins + "&" + InsR + "\n";
                string index = Convert.ToInt32(tempD[0].MW).ToString();
                string xyx = "";
                xyx = Eukaryota[index].ToString();
                if (xyx == "")
                {
                    Eukaryota_list.Add(Convert.ToInt32(index));
                    Eukaryota.Add(index, res);
                }
                else
                {
                    res = res.Substring(0, res.Length - 2) + "|" + xyx.ToString() + "\n";
                    Eukaryota.Add(index, res);
                }
                tempD.RemoveAt(0);

            }
            file.Close();
            cond_var = 1;
        }
        public static void SQLITED6()
        {
            data data1 = new data();
            int counter = 0; int counter1 = 0;
            List<data> tempD = new List<data>();
            string line;
            string temp_h = "";
            string temp_s = "";
            string path = @"C:\inetpub\wwwroot\Databases\uniprot_sprot_Fungi.fasta";
            StreamReader file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains('>') && counter > 0)
                {

                    double temp_MW = AminoAcids.getMW(temp_s[0]);


                    for (int i = 0; i < temp_s.Length; i++)
                    {
                        temp_MW = temp_MW + AminoAcids.getMW(temp_s[i]);
                    }

                    string k = temp_h.Substring(4, 6);
                    data1 = new data(k, temp_s, temp_MW, "", "");
                    tempD.Add(data1);

                    temp_h = "";
                    temp_s = "";


                }

                if (line.Contains(" "))
                {
                    temp_h = temp_h + line;
                }
                else
                    temp_s = temp_s + line;

                counter++;
            }
            tempD = tempD.OrderBy(n => n.MW).ToList();
            List<double> left = new List<double>();
            List<double> right = new List<double>();
            string Ins;
            string InsR;


            while (tempD.Count > 0)
            {
                counter1++;
                Ins = "";
                InsR = "";
                left = new List<double>();
                right = new List<double>();

                var duplicateKeys = tempD.GroupBy(x => x.MW).Where(group => group.Count() > 1).Select(group => group.Key);
                string strprotein = tempD[0].Seq;
                int prtlength = strprotein.Length;

                left.Add(AminoAcids.getMW(strprotein[0]));
                right.Add(tempD[0].MW);

                for (int ifragmentationposition = 1; ifragmentationposition < prtlength; ifragmentationposition++)
                {
                    left.Add(left[ifragmentationposition - 1] + AminoAcids.getMW(strprotein[ifragmentationposition]));
                    right.Add(right[ifragmentationposition - 1] - AminoAcids.getMW(strprotein[ifragmentationposition]));
                }

                Ins = String.Join(",", left.Select(x => x.ToString()).ToArray());
                InsR = String.Join(",", right.Select(x => x.ToString()).ToArray());

                string res = "";
                res = tempD[0].ID + "&" + tempD[0].MW.ToString() + "&" + tempD[0].Seq + "&" + Ins + "&" + InsR + "\n";
                string index = Convert.ToInt32(tempD[0].MW).ToString();
                string xyx = "";
                xyx = Fungi[index].ToString();
                if (xyx == "")
                {
                    Fungi_list.Add(Convert.ToInt32(index));
                    Fungi.Add(index, res);
                }
                else
                {
                    res = res.Substring(0, res.Length - 2) + "|" + xyx.ToString() + "\n";
                    Fungi.Add(index, res);
                }
                tempD.RemoveAt(0);

            }
            file.Close();
            cond_var = 1;
        }
        public static void SQLITED7()
        {
            data data1 = new data();
            int counter = 0; int counter1 = 0;
            List<data> tempD = new List<data>();
            string line;
            string temp_h = "";
            string temp_s = "";
            string path = @"C:\inetpub\wwwroot\Databases\uniprot_sprot_Human.fasta";
            StreamReader file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains('>') && counter > 0)
                {

                    double temp_MW = AminoAcids.getMW(temp_s[0]);


                    for (int i = 0; i < temp_s.Length; i++)
                    {
                        temp_MW = temp_MW + AminoAcids.getMW(temp_s[i]);
                    }

                    string k = temp_h.Substring(4, 6);
                    data1 = new data(k, temp_s, temp_MW, "", "");
                    tempD.Add(data1);

                    temp_h = "";
                    temp_s = "";


                }

                if (line.Contains(" "))
                {
                    temp_h = temp_h + line;
                }
                else
                    temp_s = temp_s + line;

                counter++;
            }
            tempD = tempD.OrderBy(n => n.MW).ToList();
            List<double> left = new List<double>();
            List<double> right = new List<double>();
            string Ins;
            string InsR;


            while (tempD.Count > 0)
            {
                counter1++;
                Ins = "";
                InsR = "";
                left = new List<double>();
                right = new List<double>();

                var duplicateKeys = tempD.GroupBy(x => x.MW).Where(group => group.Count() > 1).Select(group => group.Key);
                string strprotein = tempD[0].Seq;
                int prtlength = strprotein.Length;

                left.Add(AminoAcids.getMW(strprotein[0]));
                right.Add(tempD[0].MW);

                for (int ifragmentationposition = 1; ifragmentationposition < prtlength; ifragmentationposition++)
                {
                    left.Add(left[ifragmentationposition - 1] + AminoAcids.getMW(strprotein[ifragmentationposition]));
                    right.Add(right[ifragmentationposition - 1] - AminoAcids.getMW(strprotein[ifragmentationposition]));
                }

                Ins = String.Join(",", left.Select(x => x.ToString()).ToArray());
                InsR = String.Join(",", right.Select(x => x.ToString()).ToArray());

                string res = "";
                res = tempD[0].ID + "&" + tempD[0].MW.ToString() + "&" + tempD[0].Seq + "&" + Ins + "&" + InsR;
                string index = Convert.ToInt32(tempD[0].MW).ToString();
                string xyx = "";
                xyx = Human[index].ToString();
                if (xyx == "")
                {
                    Human_list.Add(Convert.ToInt32(index));
                    Human.Add(index, "-" + res);
                }
                else
                {
                    res = res.Substring(0, res.Length - 2) + "|" + xyx.ToString();
                    Human.Add(index, res);
                }
                tempD.RemoveAt(0);

            }
            file.Close();
            cond_var = 1;
        }
        public static void SQLITED8()
        {
            data data1 = new data();
            int counter = 0; int counter1 = 0;
            List<data> tempD = new List<data>();
            string line;
            string temp_h = "";
            string temp_s = "";
            string path = @"C:\inetpub\wwwroot\Databases\uniprot_sprot_Vertebrates.fasta";
            StreamReader file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains('>') && counter > 0)
                {

                    double temp_MW = AminoAcids.getMW(temp_s[0]);


                    for (int i = 0; i < temp_s.Length; i++)
                    {
                        temp_MW = temp_MW + AminoAcids.getMW(temp_s[i]);
                    }

                    string k = temp_h.Substring(4, 6);
                    data1 = new data(k, temp_s, temp_MW, "", "");
                    tempD.Add(data1);

                    temp_h = "";
                    temp_s = "";


                }

                if (line.Contains(" "))
                {
                    temp_h = temp_h + line;
                }
                else
                    temp_s = temp_s + line;

                counter++;
            }
            tempD = tempD.OrderBy(n => n.MW).ToList();
            List<double> left = new List<double>();
            List<double> right = new List<double>();
            string Ins;
            string InsR;


            while (tempD.Count > 0)
            {
                counter1++;
                Ins = "";
                InsR = "";
                left = new List<double>();
                right = new List<double>();

                var duplicateKeys = tempD.GroupBy(x => x.MW).Where(group => group.Count() > 1).Select(group => group.Key);
                string strprotein = tempD[0].Seq;
                int prtlength = strprotein.Length;

                left.Add(AminoAcids.getMW(strprotein[0]));
                right.Add(tempD[0].MW);

                for (int ifragmentationposition = 1; ifragmentationposition < prtlength; ifragmentationposition++)
                {
                    left.Add(left[ifragmentationposition - 1] + AminoAcids.getMW(strprotein[ifragmentationposition]));
                    right.Add(right[ifragmentationposition - 1] - AminoAcids.getMW(strprotein[ifragmentationposition]));
                }

                Ins = String.Join(",", left.Select(x => x.ToString()).ToArray());
                InsR = String.Join(",", right.Select(x => x.ToString()).ToArray());

                string res = "";
                res = tempD[0].ID + "&" + tempD[0].MW.ToString() + "&" + tempD[0].Seq + "&" + Ins + "&" + InsR + "\n";
                string index = Convert.ToInt32(tempD[0].MW).ToString();
                string xyx = "";
                xyx = Vertebrates[index].ToString();
                if (xyx == "")
                {
                    Vertebrates_list.Add(Convert.ToInt32(index));
                    Vertebrates.Add(index, res);
                }
                else
                {
                    res = res.Substring(0, res.Length - 2) + "|" + xyx.ToString() + "\n";
                    Vertebrates.Add(index, res);
                }
                tempD.RemoveAt(0);

            }
            file.Close();
            cond_var = 1;
        }
        public static void SQLITED9()
        {
            data data1 = new data();
            int counter = 0; int counter1 = 0;
            List<data> tempD = new List<data>();
            string line;
            string temp_h = "";
            string temp_s = "";
            string path = @"C:\inetpub\wwwroot\Databases\uniprot_sprot_Mammals.fasta";
            StreamReader file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains('>') && counter > 0)
                {

                    double temp_MW = AminoAcids.getMW(temp_s[0]);


                    for (int i = 0; i < temp_s.Length; i++)
                    {
                        temp_MW = temp_MW + AminoAcids.getMW(temp_s[i]);
                    }

                    string k = temp_h.Substring(4, 6);
                    data1 = new data(k, temp_s, temp_MW, "", "");
                    tempD.Add(data1);

                    temp_h = "";
                    temp_s = "";


                }

                if (line.Contains(" "))
                {
                    temp_h = temp_h + line;
                }
                else
                    temp_s = temp_s + line;

                counter++;
            }
            tempD = tempD.OrderBy(n => n.MW).ToList();
            List<double> left = new List<double>();
            List<double> right = new List<double>();
            string Ins;
            string InsR;


            while (tempD.Count > 0)
            {
                counter1++;
                Ins = "";
                InsR = "";
                left = new List<double>();
                right = new List<double>();

                var duplicateKeys = tempD.GroupBy(x => x.MW).Where(group => group.Count() > 1).Select(group => group.Key);
                string strprotein = tempD[0].Seq;
                int prtlength = strprotein.Length;

                left.Add(AminoAcids.getMW(strprotein[0]));
                right.Add(tempD[0].MW);

                for (int ifragmentationposition = 1; ifragmentationposition < prtlength; ifragmentationposition++)
                {
                    left.Add(left[ifragmentationposition - 1] + AminoAcids.getMW(strprotein[ifragmentationposition]));
                    right.Add(right[ifragmentationposition - 1] - AminoAcids.getMW(strprotein[ifragmentationposition]));
                }

                Ins = String.Join(",", left.Select(x => x.ToString()).ToArray());
                InsR = String.Join(",", right.Select(x => x.ToString()).ToArray());

                string res = "";
                res = tempD[0].ID + "&" + tempD[0].MW.ToString() + "&" + tempD[0].Seq + "&" + Ins + "&" + InsR + "\n";
                string index = Convert.ToInt32(tempD[0].MW).ToString();
                string xyx = "";
                xyx = Mammals[index].ToString();
                if (xyx == "")
                {
                    Mammals_list.Add(Convert.ToInt32(index));
                    Mammals.Add(index, res);
                }
                else
                {
                    res = res.Substring(0, res.Length - 2) + "|" + xyx.ToString() + "\n";
                    Mammals.Add(index, res);
                }
                tempD.RemoveAt(0);

            }
            file.Close();
            cond_var = 1;
        }
        public static void SQLITED10()
        {
            data data1 = new data();
            int counter = 0; int counter1 = 0;
            List<data> tempD = new List<data>();
            string line;
            string temp_h = "";
            string temp_s = "";
            string path = @"C:\inetpub\wwwroot\Databases\uniprot_sprot_Rodents.fasta";
            StreamReader file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains('>') && counter > 0)
                {

                    double temp_MW = AminoAcids.getMW(temp_s[0]);


                    for (int i = 0; i < temp_s.Length; i++)
                    {
                        temp_MW = temp_MW + AminoAcids.getMW(temp_s[i]);
                    }

                    string k = temp_h.Substring(4, 6);
                    data1 = new data(k, temp_s, temp_MW, "", "");
                    tempD.Add(data1);

                    temp_h = "";
                    temp_s = "";


                }

                if (line.Contains(" "))
                {
                    temp_h = temp_h + line;
                }
                else
                    temp_s = temp_s + line;

                counter++;
            }
            tempD = tempD.OrderBy(n => n.MW).ToList();
            List<double> left = new List<double>();
            List<double> right = new List<double>();
            string Ins;
            string InsR;


            while (tempD.Count > 0)
            {
                counter1++;
                Ins = "";
                InsR = "";
                left = new List<double>();
                right = new List<double>();

                var duplicateKeys = tempD.GroupBy(x => x.MW).Where(group => group.Count() > 1).Select(group => group.Key);
                string strprotein = tempD[0].Seq;
                int prtlength = strprotein.Length;

                left.Add(AminoAcids.getMW(strprotein[0]));
                right.Add(tempD[0].MW);

                for (int ifragmentationposition = 1; ifragmentationposition < prtlength; ifragmentationposition++)
                {
                    left.Add(left[ifragmentationposition - 1] + AminoAcids.getMW(strprotein[ifragmentationposition]));
                    right.Add(right[ifragmentationposition - 1] - AminoAcids.getMW(strprotein[ifragmentationposition]));
                }

                Ins = String.Join(",", left.Select(x => x.ToString()).ToArray());
                InsR = String.Join(",", right.Select(x => x.ToString()).ToArray());

                string res = "";
                res = tempD[0].ID + "&" + tempD[0].MW.ToString() + "&" + tempD[0].Seq + "&" + Ins + "&" + InsR + "\n";
                string index = Convert.ToInt32(tempD[0].MW).ToString();
                string xyx = "";
                xyx = Rodents[index].ToString();
                if (xyx == "")
                {
                    Rodents_list.Add(Convert.ToInt32(index));
                    Rodents.Add(index, res);
                }
                else
                {
                    res = res.Substring(0, res.Length - 2) + "|" + xyx.ToString() + "\n";
                    Rodents.Add(index, res);
                }
                tempD.RemoveAt(0);

            }
            file.Close();
            cond_var = 1;
        }
        public static void SQLITED11()
        {
            data data1 = new data();
            int counter = 0; int counter1 = 0;
            List<data> tempD = new List<data>();
            string line;
            string temp_h = "";
            string temp_s = "";
            string path = @"C:\inetpub\wwwroot\Databases\uniprot_sprot_Viridiplantae.fasta";
            StreamReader file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains('>') && counter > 0)
                {

                    double temp_MW = AminoAcids.getMW(temp_s[0]);


                    for (int i = 0; i < temp_s.Length; i++)
                    {
                        temp_MW = temp_MW + AminoAcids.getMW(temp_s[i]);
                    }

                    string k = temp_h.Substring(4, 6);
                    data1 = new data(k, temp_s, temp_MW, "", "");
                    tempD.Add(data1);

                    temp_h = "";
                    temp_s = "";


                }

                if (line.Contains(" "))
                {
                    temp_h = temp_h + line;
                }
                else
                    temp_s = temp_s + line;

                counter++;
            }
            tempD = tempD.OrderBy(n => n.MW).ToList();
            List<double> left = new List<double>();
            List<double> right = new List<double>();
            string Ins;
            string InsR;


            while (tempD.Count > 0)
            {
                counter1++;
                Ins = "";
                InsR = "";
                left = new List<double>();
                right = new List<double>();

                var duplicateKeys = tempD.GroupBy(x => x.MW).Where(group => group.Count() > 1).Select(group => group.Key);
                string strprotein = tempD[0].Seq;
                int prtlength = strprotein.Length;

                left.Add(AminoAcids.getMW(strprotein[0]));
                right.Add(tempD[0].MW);

                for (int ifragmentationposition = 1; ifragmentationposition < prtlength; ifragmentationposition++)
                {
                    left.Add(left[ifragmentationposition - 1] + AminoAcids.getMW(strprotein[ifragmentationposition]));
                    right.Add(right[ifragmentationposition - 1] - AminoAcids.getMW(strprotein[ifragmentationposition]));
                }

                Ins = String.Join(",", left.Select(x => x.ToString()).ToArray());
                InsR = String.Join(",", right.Select(x => x.ToString()).ToArray());

                string res = "";
                res = tempD[0].ID + "&" + tempD[0].MW.ToString() + "&" + tempD[0].Seq + "&" + Ins + "&" + InsR + "\n";
                string index = Convert.ToInt32(tempD[0].MW).ToString();
                string xyx = "";
                xyx = Viridiplantae[index].ToString();
                if (xyx == "")
                {
                    Viridiplantae_list.Add(Convert.ToInt32(index));
                    Viridiplantae.Add(index, res);
                }
                else
                {
                    res = res.Substring(0, res.Length - 2) + "|" + xyx.ToString() + "\n";
                    Viridiplantae.Add(index, res);
                }
                tempD.RemoveAt(0);

            }
            file.Close();
            cond_var = 1;
        }
        public static void SQLITED12()
        {
            data data1 = new data();
            int counter = 0; int counter1 = 0;
            List<data> tempD = new List<data>();
            string line;
            string temp_h = "";
            string temp_s = "";
            string path = @"C:\inetpub\wwwroot\Databases\uniprot_sprot_Viruses.fasta";
            StreamReader file = new StreamReader(path);

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains('>') && counter > 0)
                {

                    double temp_MW = AminoAcids.getMW(temp_s[0]);


                    for (int i = 0; i < temp_s.Length; i++)
                    {
                        temp_MW = temp_MW + AminoAcids.getMW(temp_s[i]);
                    }

                    string k = temp_h.Substring(4, 6);
                    data1 = new data(k, temp_s, temp_MW, "", "");
                    tempD.Add(data1);

                    temp_h = "";
                    temp_s = "";


                }

                if (line.Contains(" "))
                {
                    temp_h = temp_h + line;
                }
                else
                    temp_s = temp_s + line;

                counter++;
            }
            tempD = tempD.OrderBy(n => n.MW).ToList();
            List<double> left = new List<double>();
            List<double> right = new List<double>();
            string Ins;
            string InsR;


            while (tempD.Count > 0)
            {
                counter1++;
                Ins = "";
                InsR = "";
                left = new List<double>();
                right = new List<double>();

                var duplicateKeys = tempD.GroupBy(x => x.MW).Where(group => group.Count() > 1).Select(group => group.Key);
                string strprotein = tempD[0].Seq;
                int prtlength = strprotein.Length;

                left.Add(AminoAcids.getMW(strprotein[0]));
                right.Add(tempD[0].MW);

                for (int ifragmentationposition = 1; ifragmentationposition < prtlength; ifragmentationposition++)
                {
                    left.Add(left[ifragmentationposition - 1] + AminoAcids.getMW(strprotein[ifragmentationposition]));
                    right.Add(right[ifragmentationposition - 1] - AminoAcids.getMW(strprotein[ifragmentationposition]));
                }

                Ins = String.Join(",", left.Select(x => x.ToString()).ToArray());
                InsR = String.Join(",", right.Select(x => x.ToString()).ToArray());

                string res = "";
                res = tempD[0].ID + "&" + tempD[0].MW.ToString() + "&" + tempD[0].Seq + "&" + Ins + "&" + InsR + "\n";
                string index = Convert.ToInt32(tempD[0].MW).ToString();
                string xyx = "";
                xyx = Viruses[index].ToString();
                if (xyx == "")
                {
                    Viruses_list.Add(Convert.ToInt32(index));
                    Viruses.Add(index, res);
                }
                else
                {
                    res = res.Substring(0, res.Length - 2) + "|" + xyx.ToString() + "\n";
                    Viruses.Add(index, res);
                }
                tempD.RemoveAt(0);

            }
            file.Close();
            cond_var = 1;
        }

        //! Fasta_Reader is static member function taking 4 arguments and returning a List of proteins
        /*!
         * \param MW a double argument which contains protein MW
         * \param tol a double argument which conatins MW tol
         * \param database a string argument which contains Protein databse name
         * \param filterDB an integer variable which tells us about user decision regarding filteration of DB on protein MW
         * \return the List of shortlisted proteins
         */
        public static List<proteins> Fasta_Reader(double MW, double tol, string database, int filterDB)
        {
            CPersistentDictionary temp_dic = Uniprot;      /*!< Temporary dictionary: It loads the user seleted database in it. */
            List<int> temp_list = new List<int>();         /*!< Temporary list: It loads the user selected database's protein falling within user defined mass window. */

            if (filterDB == 0)      /*!< It checks user has asked us to filter the databse using MW window */
                tol = 1000;         /*!< If user hasn't asked to filter the database on MW then we will filter the database on a bigger window of 1 KDa. */

            if (cond_var != 1)      /*!< Check the conditional variable to see if the program is running for first time. if condition true load the databases into dic. */
            {
                //SQLITED();       /*!< Load the DIC. */
                //SQLITED1();      /*!< Load the DIC. */
                //SQLITED2();      /*!< Load the DIC. */
                //SQLITED3();      /*!< Load the DIC. */
                //SQLITED4();      /*!< Load the DIC. */
                //SQLITED5();      /*!< Load the DIC. */
                //SQLITED6();      /*!< Load the DIC. */
                SQLITED7();        /*!< Load the DIC. */
                //SQLITED8();      /*!< Load the DIC. */
                //SQLITED9();      /*!< Load the DIC. */
                //SQLITED10();     /*!< Load the DIC. */
                //SQLITED11();     /*!< Load the DIC. */
                //SQLITED12();     /*!< Load the DIC. */
            }

            /*!<  */

            switch (database)   /*!< Check the datbase and jump to the selected case. */
            {
                case "Uniprot":      /*!< if Uniprot */
                    temp_list = Uniprot_list.FindAll(item => item > Convert.ToInt32(MW - tol) & item < Convert.ToInt32(MW + 50));         /*!< Load into temp list. */
                    break;
                case "Ubiquitin":   /*!< if Ubiquitin */
                    temp_list = Ubiquitin_list.FindAll(item => item > Convert.ToInt32(MW - tol) & item < Convert.ToInt32(MW + 50));       /*!< Load into temp list. */
                    temp_dic = Ubiquitin;   /*!< Shallow copy of dictionary. */
                    break;
                case "Archaea": /*!< if Archea */
                    temp_list = Archaea_list.FindAll(item => item > Convert.ToInt32(MW - tol) & item < Convert.ToInt32(MW + 50));         /*!< Load into temp list. */
                    temp_dic = Archaea;     /*!< Shallow copy of dictionary. */
                    break;
                case "Bacteria":    /*!< if Bacteria */
                    temp_list = Bacteria_list.FindAll(item => item > Convert.ToInt32(MW - tol) & item < Convert.ToInt32(MW + 50));        /*!< Load into temp list. */
                    temp_dic = Bacteria;    /*!< Shallow copy of dictionary. */
                    break;
                case "Cellular":    /*!< If cellular organism */
                    temp_list = Cellular_list.FindAll(item => item > Convert.ToInt32(MW - tol) & item < Convert.ToInt32(MW + 50));       /*!< Load into temp list. */
                    temp_dic = Cellular;    /*!< Shallow copy of dictionary. */
                    break;
                case "Eukaryota":   /*!< if Eukaryotes */
                    temp_list = Eukaryota_list.FindAll(item => item > Convert.ToInt32(MW - tol) & item < Convert.ToInt32(MW + 50));      /*!< Load into temp list. */
                    temp_dic = Eukaryota;   /*!< Shallow copy of dictionary. */
                    break;
                case "Fungi":       /*!< If fungi */
                    temp_list = Fungi_list.FindAll(item => item > Convert.ToInt32(MW - tol) & item < Convert.ToInt32(MW + 50));          /*!< Load into temp list. */
                    temp_dic = Fungi;       /*!< Shallow copy of dictionary. */
                    break;
                case "Human":       /*!< if Hunman */
                    temp_list = Human_list.FindAll(item => item > Convert.ToInt32(MW - tol) & item < Convert.ToInt32(MW + 50));          /*!< Load into temp list. */
                    temp_dic = Human;       /*!< Shallow copy of dictionary. */
                    break;
                case "Vertebrates": /*!< if Vertebrates */
                    temp_list = Vertebrates_list.FindAll(item => item > Convert.ToInt32(MW - tol) & item < Convert.ToInt32(MW + 50));   /*!< Load into temp list. */
                    temp_dic = Vertebrates; /*!< Shallow copy of dictionary. */
                    break;
                case "Mammals":     /*!< if Mammals */
                    temp_list = Mammals_list.FindAll(item => item > Convert.ToInt32(MW - tol) & item < Convert.ToInt32(MW + 50));       /*!< Load into temp list. */
                    temp_dic = Mammals;     /*!< Shallow copy of dictionary. */
                    break;
                case "Rodents":     /*!< if Rodents */
                    temp_list = Rodents_list.FindAll(item => item > Convert.ToInt32(MW - tol) & item < Convert.ToInt32(MW + 50));       /*!< Load into temp list. */
                    temp_dic = Rodents;     /*!< Shallow copy of dictionary. */
                    break;
                case "Viridiplantae":/*!< If Virdiplantae */
                    temp_list = Viridiplantae_list.FindAll(item => item > Convert.ToInt32(MW - tol) & item < Convert.ToInt32(MW + 50)); /*!< Load into temp list. */
                    temp_dic = Viridiplantae;/*!< Shallow copy of dictionary. */
                    break;
                case "Viruses":     /*!< If Viruses */
                    temp_list = Viruses_list.FindAll(item => item > Convert.ToInt32(MW - tol) & item < Convert.ToInt32(MW + 50));       /*!< Load into temp list. */
                    temp_dic = Viruses;     /*!< Shallow copy of dictionary. */
                    break;
            }

            int first;       /*!< First index of token  */
            int last;        /*!< Last index of taken that separates proteins of same MW from the other adjacent Proteins */

            /*!
             * A single Protein eg. prot1 string is like this : Header&MW&Seq&C-term(comma-separated)&N-term(comma-separated)
             * Proteins at a single index eg p1 are like this: prot1|prot2|prot3
             * Whole protein string: p1-p2-p3
             */

            List<proteins> protein_list = new List<proteins>();      /*!< Initialize Protein list */
            double error_score;                                      /*!< Initiliaze MW Error Score */

            for (int i = 0; i < temp_list.Count; i++)                /*!< Run the following code for the no of elements in temporary list. */
            {
                string protein_string = temp_dic[temp_list[i].ToString()].ToString();   /*!< Get protein string for each element of the list */

                if (protein_string != "")       /*!< if Protein string is not empty execute following code */
                {
                    string protein_data;      /*!< Initilaize Protein data: It will contain the information of a single protein. */
                    string[] words = protein_string.Split('|');         /*!< Split protein string to get the array of proteins at a single index key in dic.  */

                    for (int j = 0; j < words.Length; j++)   /*!< Run for the numbers of proteins */
                    {
                        first = words[j].IndexOf("-");       /*!< get first index of character - */
                        last = words[j].LastIndexOf("-");    /*!< get last index of character - */

                        if (last > -1)           /*!< If character - exists in the protein string of a single protein */
                        {
                            if (first != last)   /*!< if first and last indices of - are not at the same index. */
                            {
                                protein_data = words[j].Substring(first, last - 1);   /*!< Get protein data by omiting the - sign at start and end */
                            }
                            else                 /*!< otherwise */
                            {
                                if (last == 0)   /*!< if - sign is at the start */
                                    protein_data = words[j].Substring(1);             /*!< Get protein data by omiting the - sign at the start */
                                else            /*!< otherwise */
                                    protein_data = words[j].Substring(0, last - 1);   /*!< Get protein data by omiting the - sign at the end */
                            }
                        }
                        else   /*!< otherwise */
                        {
                            if (words[j].IndexOf("-") > -1)
                                protein_data = words[j].Substring(first);

                            else
                                protein_data = words[j];
                        }

                        string[] dataPs = protein_data.Split('&');            /*!< split protein data to get the protein parameters. */

                        if (dataPs.Length == 5)      /*!< Check if a Protein string contains 5 parameters */
                        {
                            double MWw = Convert.ToDouble(dataPs[1]);    /*!< Experimental protein */
                            error_score = MW_filter(MW, tol, MWw, true);     /*!< Call MW_filter for MW error score */
                            proteins temp_p = new proteins(dataPs[0], dataPs[2], MWw, error_score);  /*!< Initialize Protein Object */
                            temp_p.insilico_details = new insilico_obj();                            /*!< Initialize an Insilico object in protein object for storing insilico details */
                            temp_p.insilico_details.insilico_mass_left = dataPs[3].Split(',').Select(t => double.Parse(t)).ToList<double>();     /*!< Parse the C-term ions and store them in protein object. */
                            temp_p.insilico_details.insilico_mass_right = dataPs[4].Split(',').Select(t => double.Parse(t)).ToList<double>();    /*!< Parse the N-term ions and store them in protein object. */
                            protein_list.Add(temp_p);    /*!< Add the protein into candidate protein List. */
                        }
                    }
                }
            }

            return protein_list;                /*!< Return the list of candidate proteins. */
        }

        //! MW_filter is static member function taking 4 arguments and returning a List of proteins
        /*!
         * \param MW a double argument which contains protein MW
         * \param tol a double argument which conatins MW tol
         * \param MW_experimental a double argument which contains Protein's MS1 given by user
         * \param fasta a bool variable which tells us whether function is being called first time or by PTM module
         * \return the List of shortlisted proteins
         */
        public static double MW_filter(double MW, double tol, double MW_experimental, bool fasta)
        {
            double error = Math.Abs(MW_experimental - MW);      /*!< error calculates the difference b/w theoretical and experimental MW. */
            double error_score = 0;                             /*!< defination of error_score which will be used to store the score of MW module */

            error_score = 1 / (Math.Pow(2, error));             /*!< calculation of error_score */

            if (fasta == true)                                  /*!< check condition of fasta variable */
            {
                return error_score;                             /*!< If MW_filter was called for first time return error score */
            }
            else                                                /*!< else case */
            {
                if (error < tol)                                /*!< if error is within user defined tolerance */
                    return error_score;                         /*!< return error score */
                else
                    return -7;                                  /*!< otherwise return -7 to indicate error */
            }
        }

    }
}