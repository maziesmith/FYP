using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Testapi.Engine
{
    public class PeakReader
    {

        public static void mzXMLReader(List<string> raw, ref string address_mzXML)
        {
            string line;

            // Read the file and display it line by line.
            //System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Urwa\Desktop\result.mzxml");
            System.IO.StreamReader file = new System.IO.StreamReader(address_mzXML);

            bool mslevel = false;
           // bool con = false;
            bool read = false;

            while ((line = file.ReadLine()) != null)
            {
                //con = false;
                read = false;
                string str = "";

                if (line.Contains("msLevel=\"2\""))
                    mslevel = true;

                if (mslevel == true)
                {
                    if (line.Contains("compressedLen") && read == false)        // Reading the lines with the base64 strings
                    {
                        str = line.Split('>')[1];
                        str = str.Split('<')[0];
                        raw.Add(str);
                        mslevel = false;
                    }
                }
            }

            file.Close();
        }

        public static void decrypt(ref string addr)
        {
            List<string> rawList = new List<string>();

            mzXMLReader(rawList, ref addr);        // calling the function

            Console.WriteLine("SPLIT ************************************");

            int offset = 0;

            for (int t = 0; t < rawList.Count; t++)
            {

                byte[] base64EncodedBytes = System.Convert.FromBase64String(rawList.ElementAt(t));      // decoding base64

                int peaksCount = base64EncodedBytes.Length / 8;

                List<float> mz = new List<float>();
                List<float> intensity = new List<float>();
                offset = 0;

                for (int i = 0; i < (peaksCount); i++)          // changing byte order
                {
                    // 1 2 3 4      5 6 7 8         (original)
                    // 4 3 2 1      8 7 6 5         (changed)

                    byte[] first4 = new byte[4];
                    byte[] last4 = new byte[4];

                    first4[0] = base64EncodedBytes[offset * 8];
                    first4[1] = base64EncodedBytes[(offset * 8) + 1];
                    first4[2] = base64EncodedBytes[(offset * 8) + 2];
                    first4[3] = base64EncodedBytes[(offset * 8) + 3];

                    last4[0] = base64EncodedBytes[(offset * 8) + 4];
                    last4[1] = base64EncodedBytes[(offset * 8) + 5];
                    last4[2] = base64EncodedBytes[(offset * 8) + 6];
                    last4[3] = base64EncodedBytes[(offset * 8) + 7];

                    Array.Reverse(first4);
                    Array.Reverse(last4);

                    mz.Add(System.BitConverter.ToSingle(first4, 0));       // adding extracted values
                    intensity.Add(System.BitConverter.ToSingle(last4, 0));        // adding extracted values
                    offset++;
                }

                string[] split_address = addr.Split('\\');
                string new_address = "";
                //string mzxmladdr = @"C:\Users\Urwa\Desktop\mzxmlTopDown\";
                string mzxmladdr2 = @"C:\Users\Urwa\Desktop\mzxmlTopDown2\";

                for (int i = 0; i < (split_address.Length) - 1; i++)
                {
                    new_address += (split_address[i] + '\\');
                }

                int intermed;
                intermed = t + 1;

                //if (intermed < 2)
                //{
                addr = mzxmladdr2 + "scan_1.txt";
                string pathname = mzxmladdr2 + "scan_" + intermed + ".txt";     // creating new files

                string path = @pathname;
                if (File.Exists(path))
                    File.Delete(path);

                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        for (int i = 0; i < mz.Count; i++)
                        {
                            sw.WriteLine(mz.ElementAt(i) + "\t" + intensity.ElementAt(i));
                        }
                    }
                }
                //}
            }
        }

        public static void mgf_reader(ref string address_mgf)
        {
            String charge_no = " ";
            String pep_mass = " ";
           // int intensity = 1;
            string charge = "CHARGE";
            string pepmass = "PEPMASS";
            int i = 1;
            FileStream fin = new FileStream(address_mgf, FileMode.Open);
            StreamReader sr = new StreamReader(fin);
            string s = sr.ReadLine();
            // bool IsNumeric=false ,Space=false;
        //    int lineCounter = 1;
            int maxCount = 1;
            string maxFilename = "";

            List<double> mass = new List<double>();
            List<double> intensities = new List<double>();


            string[] split_address = address_mgf.Split('\\');
            string new_address = "";


            for (int k = 0; k < (split_address.Length) - 1; k++)
            {
                new_address += (split_address[k] + '\\');
            }

            while (s != null)
            {
                charge_no = "";
                pep_mass = "";

                if (File.Exists(new_address + "scan" + i + ".txt"))
                    File.Delete(new_address + "scan" + i + ".txt");

                FileStream fout = new FileStream(new_address + "scan" + i + ".txt", FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fout);
                List<string> Numeric_List = new List<string>();
               // int cou = 1;


                while (s != "END IONS" && s != null)
                {
                    if (s.Contains(charge))
                    {
                        charge_no = (s.Split('='))[1];
                    }

                    if (s.Contains(pepmass))
                    {
                        pep_mass = (s.Split('='))[1];
                    }

                    if (!s.Contains("BEGIN IONS") && !s.Contains("="))
                    {

                        if (s.Contains(' '))
                        {
                            string[] arr = s.Split(' ');
                            mass.Add(Convert.ToDouble(arr[0]));
                            intensities.Add(Convert.ToDouble(arr[1]));
                        }
                        else if (s.Contains('\t'))
                        {
                            string[] arr = s.Split('\t');
                            mass.Add(Convert.ToDouble(arr[0]));
                            intensities.Add(Convert.ToDouble(arr[1]));
                        }
                        else
                        {
                            if (s != "")
                            {
                                mass.Add(Convert.ToDouble(s));
                                intensities.Add(-7);
                            }

                        }

                    }
                    s = sr.ReadLine();
                    //mass.Add(-13);
                    //intensities.Add(-13);
                }

                sw.WriteLine(pep_mass);

               // bool con = true;
                for (int x = 0; x < mass.Count; x++)
                {
                    if (intensities.ElementAt(x) == -7)
                    {
                        sw.WriteLine(mass.ElementAt(x));
                        //lineCounter++;
                    }
                    else
                    {
                        sw.WriteLine(mass.ElementAt(x) + "\t" + intensities.ElementAt(x));
                        //lineCounter++;
                    }

                }

                if ((mass.Count + 1) > maxCount)
                {
                    maxFilename = "scan" + i + ".txt";
                    maxCount = mass.Count + 1;
                }

                mass.Clear();
                intensities.Clear();

                /*if (lineCounter > maxCount)
                {
                    maxFilename = "scan" + i + ".txt";
                    maxCount = lineCounter;
                    lineCounter = 1;
                }*/

                s = sr.ReadLine();
                i++;

                sw.Close();
                fout.Close();

            }
            address_mgf = new_address + maxFilename;
        }

        public static double peakListReader(List<double> mw, List<double> intensity, string address, string fileType)
        {
            //string[] splt = address.Split('.');

            //fileType = splt[splt.Length];

            if (fileType == ".mzXML")
            {
                decrypt(ref address);
            }

            if (fileType == ".mgf")
            {
                mgf_reader(ref address);
            }

            int counter = 0;
            double m_weight;
            string line;
            string[] separators = { "\t", " " };
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(address);
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains('\t') || line.Contains(' '))
                {
                    string[] token = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    double a = double.Parse(token[0]);
                    double b = double.Parse(token[1]);
                    mw.Add(a);
                    intensity.Add(b);
                }
                else
                {
                    double a = double.Parse(line);
                    double b = 0;
                    mw.Add(a);
                    intensity.Add(b);
                }
                counter++;
            }
            file.Close();
            m_weight = mw[0];

            return (m_weight);
        }

    }
}