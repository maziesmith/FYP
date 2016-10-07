using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testapi.Repository;
using Testapi.Models;
using Testapi.Engine;
using System.Threading;
using System.Diagnostics;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace Testapi.Service_Layer
{

    public class Search
    {
        //one modification: give querry ID from form
        static DBConnect db = new DBConnect();


        public static void ProteinSearch(QuerryParameters parameters)
        {/////////prg
            int location;
            if (CurrentJobs.current == null)
                location = 0;
            else
                location = CurrentJobs.current.Count;

            Job newJob = new Job();
            newJob.qid = parameters.queryid;
            newJob.uid = parameters.userID;
            newJob.progress = "Initiating Search!";//prg
            CurrentJobs.Initialize();
            CurrentJobs.current.Add(newJob);
            ////prg

            int q = db.queryStore(parameters);

            ////////////////////////////////////////////////////////////////////////////////////
            Worker workerObject = new Worker();
            workerObject.location = location;
            workerObject.parameters = parameters;
            //  Thread workerThread = new Thread(workerObject.DoWork);
            //workerThread.Name = "searchThread";
            //workerThread.Start();
            workerObject.DoWork();
           // return "ok";
        }//function

        public static string Progress_reporter(string qid)
        {
            // DBConnect db = new DBConnect();
            //return db.Get_Progress(qid).ToString();
            string pg = "-1";
            if (CurrentJobs.current != null)
            {
                for (int i = 0; i < CurrentJobs.current.Count; i++)
                {
                    if (CurrentJobs.current[i].qid == qid)
                        pg = CurrentJobs.current[i].progress;
                    if (pg == "Done")
                        CurrentJobs.current.RemoveAt(i);
                }
            }
            return pg;
        }
    }//class


    public class Worker
    {
        public QuerryParameters parameters;
        public int location;
        // This method will be called when the thread is started. 


        public void Send_Results_Link(QuerryParameters p)
        {
            DBConnect db = new DBConnect();
            string emailaddress = db.getEmail(p.userID);
            using (MailMessage mm = new MailMessage("abdul.rehman.127@gmail.com", emailaddress))
            {
                mm.Subject = "Perceptron: Protein Search Results";
                string body = "Hello " + p.userID + ",";
                body += "<br /><br /> The results for protein search query submitted at " + "##-##-####" + " job title " + p.title + " have been computed. To see the results please click on following link(s).<br />";
                for (int hijk = 0; hijk < p.peakListFile.Length; hijk++)
                {
                    body += "<br />"+ hijk.ToString() +". Title: " + p.peakListFile[hijk].Substring(28 + p.userID.Length); 
                    body += "&nbsp;&nbsp;&nbsp;&nbsp;<a href = \'http://localhost:43719/prog.aspx?ID=" + p.queryid + "z" + hijk + "'>Click here to see your Results.</a>";
                }
                body += "<br /><br />Thank You for using Perceptron.";
                body += "<br /><br />Best Regards,";
                body += "<br />Team Perceptron";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("abdul.rehman.127@gmail.com", "hawking1900");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }

        public void DoWork()
        {
            Stopwatch entire = new Stopwatch();
            entire.Start();
            for (int xyzxyz = 0; xyzxyz < parameters.peakListFile.Length; xyzxyz++)
            {
                Stopwatch total = new Stopwatch();
                total.Start();

                DBConnect db = new DBConnect();

                Peaks peakData = new Peaks();

                double mol_weight = PeakReader.peakListReader(peakData.mass, peakData.intens, parameters.peakListFile[xyzxyz], parameters.fileType);

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //long mem = 0;
                //mem = GC.GetTotalMemory(false);

                // db.Set_Progress(parameters.queryid, 10);///////////prg
                CurrentJobs.current[location].progress = "Module 1 of 9:  Running Mass tuner.";//prg

                Stopwatch timer = new Stopwatch();
                execution_time time = new execution_time();

                if (parameters.GUI_mass > 0)
                    mol_weight = parameters.GUI_mass;

                timer.Start();

                if (parameters.autotune == 1)
                {
                    //int massCount = peakData.mass.Count;
                    //double[] massArray = new double[peakData.mass.Count];
                    //massArray = peakData.mass.ToArray<double>();

                    // double[] b = new double[massCount * massCount];
                    //int[] c = new int[massCount * massCount];

                    WholeProteinMassTunerGPU.GPU_generator(peakData.mass, peakData.intens, ref mol_weight, parameters.MW_tolerance);
                }

                timer.Stop();

                time.tuner_time = timer.Elapsed.ToString();

                timer.Reset();

                // db.Set_Progress(parameters.queryid, 80);///////////prg
                CurrentJobs.current[location].progress = "Module 2 of 9:  Filtering DB on molecular weight.";
                timer.Start();
                // Thread.Sleep(5000);

                List<proteins> filter_prot = new List<proteins>();
                try
                {
                    filter_prot = MW_Module.Fasta_Reader(mol_weight, parameters.MW_tolerance, parameters.protDB, parameters.filterDB);
                }
                catch(Exception eez)
                {
                    string asdd = eez.InnerException.ToString();
                }
                timer.Stop();
                time.mw_filter_time = timer.Elapsed.ToString();
                timer.Reset();

                /////////////////////////////////////////////////////////////////////////////////////

                /////////////////////////////////////////////////////////////////////////////////////

                CurrentJobs.current[location].progress = "Module 3 of 9:  Generating PST's";
                timer.Start();

                string input = "";
                StringBuilder sb = new StringBuilder();
                sb.Clear();
                List<int> pro_ind = new List<int>();

                //for (int i = 0; i < 200000; i++ )

                for (int i = 0; i < filter_prot.Count; i++)
                {
                    sb.Append(filter_prot[i].sequence);
                    pro_ind.Add(filter_prot[i].sequence.Length);
                    //input += PROT[i].sequence;
                }
                //  PROT = new List<proteins>();
                input = sb.ToString();
                sb.Clear();
                int I_len = input.Length;

                if (parameters.denovo_allow == 1)
                {
                    List<tags> estTags = EST_module.findEST(peakData.mass, peakData.intens, parameters.hopThreshhold / 17, parameters.minimum_est_length, parameters.maximum_est_length);

                    //  db.Set_Progress(parameters.queryid, 85);///////////prg
                    CurrentJobs.current[location].progress = "Module 4 of 9:  Filtering on the basis of PST's.";

                    // filter_prot = EST_module.EST_filter(estTags, filter_prot);

                    String[] keys = new String[estTags.Count];

                    for (int est = 0; est < estTags.Count; est++)
                    {
                        keys[est] = estTags[est].AA.ToUpper();
                    }

                    if (filter_prot.Count > 0)
                    {
                            char[] matched_result = Device_search.Execute(keys, input, I_len);

                             EST_module.GPU_Filter(matched_result, estTags, pro_ind, filter_prot);
                             matched_result = null;
                    }
                    input = "";
                    keys = null;
                    pro_ind.Clear();
                    estTags.Clear();
                }

                timer.Stop();

                time.pst_time = timer.Elapsed.ToString();
                timer.Reset();

                // db.Set_Progress(parameters.queryid, 90);///////////prg
                CurrentJobs.current[location].progress = "Module 5 of 9:  Executing PTM module.";

                timer.Start();
                List<proteins> modified_proteins = new List<proteins>();    // EMPTY LIST
                List<proteins> shortlisted_proteins = new List<proteins>();

                if (parameters.ptm_allow == 1)
                    PTM_2.PTM_Control_2(filter_prot, parameters.ptm_tolerance, modified_proteins, parameters.ptm_code_var, parameters.ptm_code_fix, shortlisted_proteins, parameters.insilico_frag_type, parameters.HandleIons, peakData.mass, parameters.hopThreshhold, parameters.MW_sweight, parameters.PST_sweight, parameters.Insilico_sweight);


                    //PTM_Module.PTM_Control(filter_prot, parameters.ptm_tolerance, modified_proteins, parameters.ptm_code_var, parameters.ptm_code_fix, shortlisted_proteins);
                else
                {
                    shortlisted_proteins = filter_prot;
                    foreach (proteins kkk in shortlisted_proteins)
                    {
                        kkk.ptm_particulars = new List<Sites>();
                    }
                }


                if (parameters.ptm_code_fix.Count != 0 && parameters.ptm_code_var.Count != 0)
                {
                    if (shortlisted_proteins.Count > 1)
                    {
                        double buffer = 0;
                        for (int p = 1; p < shortlisted_proteins.Count; p++)
                        {
                            buffer = MW_Module.MW_filter(mol_weight, parameters.MW_tolerance, shortlisted_proteins.ElementAt(p).MW, false);
                            if (buffer == -7)
                                shortlisted_proteins.Remove(shortlisted_proteins.ElementAt(p));
                            else
                                shortlisted_proteins.ElementAt(p).MW_score = buffer;
                        }
                    }
                }

                //foreach(pr)

                timer.Stop();
                time.ptm_time = timer.Elapsed.ToString();
                timer.Reset();
                //  db.Set_Progress(parameters.queryid, 93);///////////prg
                CurrentJobs.current[location].progress = "Module 6 of 9:  Generating Insilico Fragments.";
                //Thread.Sleep(5000);
                timer.Start();
                //List<Fragment> insilico = new List<Fragment>();

                //insilico = 
                if (parameters.ptm_allow == 0)
                    Insilico_Module.insilico_fragmentation(shortlisted_proteins, parameters.insilico_frag_type, parameters.HandleIons);

                // db.Set_Progress(parameters.queryid, 95);///////////prg
                CurrentJobs.current[location].progress = "Module 7 of 9:  Insilico Filteration.";

                //INSILICO FIltering of xxx
                if (parameters.ptm_allow == 0)
                    Insilico_Module.Insilico_filter(shortlisted_proteins, peakData.mass, parameters.hopThreshhold);
                //Insilico_Module.Insilico_filter_U(modified_proteins, peakData.mass, parameters.hopThreshhold);

                timer.Stop();
                time.insilico_time = timer.Elapsed.ToString();
                timer.Reset();
                //  db.Set_Progress(parameters.queryid, 98);///////////prg
                CurrentJobs.current[location].progress = "Module 8 of 9:  Evaluating Final Scores.";
                //Thread.Sleep(5000);

                for (int i = 0; i < shortlisted_proteins.Count; i++)
                {
                    shortlisted_proteins[i].set_score(parameters.MW_sweight, parameters.PST_sweight, parameters.Insilico_sweight);
                }
                //modified_proteins.Sort((x,y)=>y.score.CompareTo(x.score));
                shortlisted_proteins.AsParallel().OrderBy(x => x.score);
                //List<proteins> SortedList = modified_proteins.OrderByDescending(o => o.score).ToList();

                //  db.Set_Progress(parameters.queryid, 100);///////////prg
                CurrentJobs.current[location].progress = "Module 9 of 9:  Storing Results.";

                shortlisted_proteins.Sort((x, y) => y.score.CompareTo(x.score));

                List<proteins> store_prot = new List<proteins>();
                //Console.ReadKey();
                for (int store_i = 0; store_i < 30 && store_i < shortlisted_proteins.Count; store_i++)
                {
                    store_prot.Add(shortlisted_proteins[store_i]);
                }

                //Results final = new Results(parameters.queryid, SortedList);
                //Results final = new Results(parameters.queryid, modified_proteins);
                Results final = new Results(parameters.queryid, store_prot, time);

                total.Stop();
                final.times.total_time = total.Elapsed.ToString();

                db.store_results(final, parameters.peakListFile[xyzxyz],xyzxyz);
                //Send_Results_Link(parameters);

                CurrentJobs.current[location].progress = "Done";

            }
            Send_Results_Link(parameters);
            entire.Stop();
            String timeForLoop;
            timeForLoop = entire.Elapsed.ToString();
            //string result_serial = Newtonsoft.Json.JsonConvert.SerializeObject(final);            
        }
    }



    public class UsersQueueMember : Search
    {

        public static List<Attributes> high = new List<Attributes>();
        public static List<Attributes> medium = new List<Attributes>();
        public static List<Attributes> low = new List<Attributes>();
        public static void Entry(QuerryParameters p)
        {
            Attributes element = new Attributes();
            element.querrpara = p;
            element.priority = 0;
            int vv;
            vv=p.peakListFile.Length;
            if (vv == 1)
                medium.Add(element);
            else
                low.Add(element);

            IA.checkQueuee();
                 
        }

        public static void job_starter()
        {
            string res;
            while (high.Count > 0)
            {
                ProteinSearch(high[0].querrpara);
                high.RemoveAt(0);


            }

            while (medium.Count > 0)
            {

                ProteinSearch(medium[0].querrpara);
                medium.RemoveAt(0);


            }

            while (low.Count > 0)
            {

                ProteinSearch(low[0].querrpara);
                low.RemoveAt(0);
            }





        }
    }



    public class IA
    {
        public static Thread workerThread2 = new Thread(UsersQueueMember.job_starter);
        // public static readonly object dumb = new object();
        public static void checkQueuee()
        {



            if (!workerThread2.IsAlive)
            {
                workerThread2 = new Thread(UsersQueueMember.job_starter);
            }

            if (workerThread2.ThreadState == System.Threading.ThreadState.Unstarted)
            {
                workerThread2.Name = "wait";
                workerThread2.Start();

            }
        }
    }


    public class Attributes
    {
        public int priority;
        public QuerryParameters querrpara;
        

        public void SetPriority(int n, QuerryParameters a)
        {
           
            if (n >= 0 && n < 3)
                priority = n;
            
        }

        public int GetPriority(QuerryParameters a)
        {
            return priority;
        }

        

    }




}
