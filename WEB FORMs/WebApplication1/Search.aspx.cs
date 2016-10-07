using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class About : Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var clientA = new HttpClient();

                if (string.IsNullOrEmpty(Session["ID"].ToString()))
                {
                    Response.Redirect("~/Account/Login", false);
                }
                else
                {
                    var userid = Session["ID"].ToString();
                    var sessionG = Session["guid"].ToString();
                    var uri = "http://localhost:14625//api/users/Get_Session/" + userid + "/" + sessionG;
                    var task = clientA.GetStringAsync(uri);
                    var result = await task;
                 
                    if (IsPostBack)
                    {
                    }
                    else
                    {
                        optionsRadios4.Checked = true;
                        optionsRadios6.Checked = true;
                        optionsRadios10.Checked = true;
                        optionsRadios12.Checked = true;
                        optionsRadios3.Checked = false;
                        optionsRadios5.Checked = false;
                        optionsRadios9.Checked = false;
                        optionsRadios11.Checked = false;
                        filterDB.Checked = false;
                        length.Checked = false;
                    }

                    if (result == "F")
                        Response.Redirect("~/Account/Login", false);
                    else
                    {
                        var regBtn = (HtmlAnchor) Master.FindControl("reg");
                        regBtn.Style.Add("display", "none");
                        var heyBtn = (HtmlAnchor) Master.FindControl("hello");
                        heyBtn.Style.Remove("display");
                        heyBtn.InnerHtml = Session["ID"].ToString();

                        var clientB = new HttpClient();
                        var userid1 = Session["ID"].ToString();
                        var uri1 = "http://localhost:14625//api/users/Get_my_searches/" + userid1;
                        var searchlists = new List<searchlist>();
                        try
                        {
                            var stringAsync = clientB.GetStringAsync(uri1);
                            var value = await stringAsync;
                            searchlists = JsonConvert.DeserializeObject<List<searchlist>>(value);
                        }
                        catch (Exception k)
                        {
                            var result1 = k.Message;
                        }


                        var searchRec = (HtmlAnchor) Master.FindControl("A1");
                        searchRec.Style.Remove("display");
                        searchRec.InnerHtml = "Searches: " + searchlists.Count;
                        var lgnBtn = (HtmlAnchor) Master.FindControl("lin");
                        lgnBtn.InnerHtml = "Logout";
                        lgnBtn.HRef = "~/Account/Logout";
                    }
                }
            }
            catch
            {
                Response.Redirect("~/Account/Login", false);
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
        }


        protected void Remove_Click(object sender, EventArgs e)
        {
        }

        protected void fix_Add_Click(object sender, EventArgs e)
        {
        }

        protected void fix_Remove_Click(object sender, EventArgs e)
        {
        }

        protected void Reset_Button_Click(object sender, EventArgs e)
        {
            search_title.Text = "";
            pro_mass.Text = "";
            peptide_tol.Text = "";
            protein_tol.Text = "";
            ptm_tol.Text = "";
            No_of_outputs.Text = "";
            var fixedMods = Fixed_modifications.Items;
            for (var i = 0; i < fixedMods.Count; i++)
                modifications_select.Items.Add(fixedMods[i]);
            Fixed_modifications.Items.Clear();
            var variableMods = Variable_modifications.Items;
            for (var i = 0; i < variableMods.Count; i++)
                modifications_select.Items.Add(variableMods[i]);
            Variable_modifications.Items.Clear();
            PST_Length_max.SelectedIndex = 0;
            PST_Length_min.SelectedIndex = 0;
            fragtype.SelectedIndex = 0;
            database.SelectedIndex = 0;
            modifications_select.SelectedIndex = -1;
            MW_Wei.Text = "";
            PST_Wei.Text = "";
            Insilico_Wei.Text = "";
            optionsRadios3.Checked = false;
            optionsRadios5.Checked = false;
            optionsRadios9.Checked = false;
            optionsRadios11.Checked = false;
            optionsRadios4.Checked = true;
            optionsRadios6.Checked = true;
            optionsRadios10.Checked = true;
            optionsRadios12.Checked = true;
            filterDB.Checked = false;
            length.Checked = false;
        }

        protected void load_def(object sender, EventArgs e)
        {
            //File_Upload

            optionsRadios3.Checked = false;
            optionsRadios5.Checked = false;
            optionsRadios9.Checked = false;
            optionsRadios11.Checked = false;
            filterDB.Checked = false;
            length.Checked = false;
            optionsRadios4.Checked = true;
            optionsRadios6.Checked = true;
            optionsRadios10.Checked = true;
            optionsRadios12.Checked = true;
            ss.Value = "";
            search_title.Text = "Search";
            pro_mass.Text = "8556.1";
            No_of_outputs.Text = "10";
            database.SelectedIndex = 9;
            peptide_tol.Text = "0.5";
        }

        protected void Search_Button_Click(object sender, EventArgs e)
        {
        }

        protected void update(string prog)
        {
            trigger.Text = prog;
        }


        protected async void Button2_Click(object sender, EventArgs e)
        {
            var fileNameArray = new string[File_Upload.PostedFiles.Count];
            if (File_Upload.HasFile)
            {
                try
                {
                    for (var i = 0; i < File_Upload.PostedFiles.Count; i++)
                    {
                        fileNameArray[i] = Path.Combine(@"C:\inetpub\wwwroot\shifaa\Peaklists\" + Session["ID"],
                            File_Upload.PostedFiles[i].FileName);
                        File_Upload.SaveAs(fileNameArray[i]);
                    }
                    var ext = Path.GetExtension(File_Upload.FileName);

                    if (Session["ID"] == null)
                        Response.Redirect("~/Account/Login", false);

                    var sessionId = Session["ID"];
                    if (sessionId != null)
                    {
                        var userId = sessionId.ToString();

                        var fixedMods = fixi.Value.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        var variableMods = vari.Value.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);


                        var fixedItems = fixedMods.Select(mods => Convert.ToInt32(mods)).ToList();
                        var variableItems = variableMods.Select(mods => Convert.ToInt32(mods)).ToList();
                        var querryParameters = new QuerryParameters();
                        var qId = Guid.NewGuid();
                        Session["Qid"] = qId;

                        //General Info
                        querryParameters.userID = userId;
                        querryParameters.queryid = qId.ToString();
                        querryParameters.title = search_title.Text;
                        querryParameters.fileType = ext;
                        querryParameters.peakListFile = fileNameArray;
                        if (pro_mass.Text == "")
                            pro_mass.Text = "-1";
                        querryParameters.GUI_mass = Convert.ToDouble(pro_mass.Text);
                        querryParameters.protDB = database.Value;
                        querryParameters.NumberOfOutputs = Convert.ToInt32(No_of_outputs.Text);


                        //////     MS/MS
                        querryParameters.insilico_frag_type = fragtype.Value;
                        querryParameters.HandleIons = ss.Value;
                        if (peptide_tol.Text == "")
                            peptide_tol.Text = "0.5";
                        querryParameters.hopThreshhold = Convert.ToDouble(peptide_tol.Text);
                        querryParameters.hopTolUnit = "Da";


                        ////         Protein Filter
                        if (filterDB.Checked)
                        {
                            querryParameters.MWTolUnit = "Da";
                            if (protein_tol.Text == "")
                                protein_tol.Text = "100";
                            querryParameters.MW_tolerance = Convert.ToDouble(protein_tol.Text);
                            querryParameters.filterDB = 1;
                        }
                        else
                        {
                            querryParameters.MW_tolerance = 1000;
                            querryParameters.MWTolUnit = "Da";
                            querryParameters.filterDB = 0;
                        }


                        //          Tuner
                        if (optionsRadios3.Checked)
                        {
                            if (!filterDB.Checked)
                            {
                                if (protein_tol.Text == "")
                                    protein_tol.Text = "100";
                                querryParameters.MW_tolerance = Convert.ToDouble(protein_tol.Text);
                            }
                            querryParameters.autotune = 1;
                        }
                        else
                        {
                            querryParameters.autotune = 0;
                        }


                        ////////         Denovo
                        if (optionsRadios5.Checked)
                        {
                            querryParameters.denovo_allow = 1;


                            //////////         Length base
                            if (length.Checked)
                            {
                                querryParameters.maximum_est_length = Convert.ToInt32(PST_Length_max.SelectedItem.Value);
                                querryParameters.minimum_est_length = Convert.ToInt32(PST_Length_min.SelectedItem.Value);
                            }
                            else
                            {
                                querryParameters.maximum_est_length = -1;
                                querryParameters.minimum_est_length = -1;
                            }
                        }
                        else
                        {
                            querryParameters.denovo_allow = 0;
                            querryParameters.maximum_est_length = -1;
                            querryParameters.minimum_est_length = -1;
                        }


                        //      PTM Filter
                        if (optionsRadios9.Checked)
                        {
                            querryParameters.ptm_allow = 1;
                            if (ptm_tol.Text == "")
                                ptm_tol.Text = "0.5";
                            querryParameters.ptm_tolerance = Convert.ToDouble(ptm_tol.Text);
                            querryParameters.ptm_code_fix = fixedItems;
                            querryParameters.ptm_code_var = variableItems;

                            if ((fixedItems.Count == 0) && (variableItems.Count == 0))
                                querryParameters.ptm_allow = 0;
                        }
                        else
                        {
                            querryParameters.ptm_allow = 0;
                            querryParameters.ptm_tolerance = -1;
                            fixedItems.Clear();
                            variableItems.Clear();
                            querryParameters.ptm_code_fix = fixedItems;
                            querryParameters.ptm_code_var = variableItems;
                        }


                        //          Final weightage
                        if (optionsRadios11.Checked)
                        {
                            if (Insilico_Wei.Text == "")
                                Insilico_Wei.Text = "1";

                            if (MW_Wei.Text == "")
                                MW_Wei.Text = "1";


                            if (PST_Wei.Text == "")
                                PST_Wei.Text = "1";

                            querryParameters.Insilico_sweight = Convert.ToDouble(Insilico_Wei.Text);
                            querryParameters.MW_sweight = Convert.ToDouble(MW_Wei.Text);
                            querryParameters.PST_sweight = Convert.ToDouble(PST_Wei.Text);
                        }
                        else
                        {
                            querryParameters.Insilico_sweight = 1;
                            querryParameters.MW_sweight = 1;
                            querryParameters.PST_sweight = 1;
                        }


                        var paramContent = JsonConvert.SerializeObject(querryParameters);
                        var client = new HttpClient();
                        HttpContent httpCont = new StringContent(paramContent);
                        httpCont.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        const string uri = "http://localhost:14625//api/search/Post_search";
                        string result;

                        try
                        {
                            var getStringTask = client.PostAsync(uri, httpCont);
                            var xyz = await getStringTask;
                            result = xyz.Content.ReadAsStringAsync().Result;
                            Response.Redirect("~/jobQueue.aspx", false);
                        }
                        catch (Exception tt)
                        {
                            stat.Text = tt.Message;
                            result = "noty noty !";
                        }
                    }
                }


                catch (Exception w)
                {
                    stat.Text = w.Message;
                    Debug.WriteLine(w.Message);
                    Debug.WriteLine(PST_Length_max.SelectedItem.Value);
                    optionsRadios3.Checked = false;
                    optionsRadios5.Checked = false;
                    optionsRadios9.Checked = false;
                    optionsRadios11.Checked = false;
                    filterDB.Checked = false;
                    length.Checked = false;
                    optionsRadios4.Checked = true;
                    optionsRadios6.Checked = true;
                    optionsRadios10.Checked = true;
                    optionsRadios12.Checked = true;
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('Please Uploa File to Continue!');",
                    true);
                optionsRadios3.Checked = false;
                optionsRadios5.Checked = false;
                optionsRadios9.Checked = false;
                optionsRadios11.Checked = false;
                filterDB.Checked = false;
                length.Checked = false;
                optionsRadios4.Checked = true;
                optionsRadios6.Checked = true;
                optionsRadios10.Checked = true;
                optionsRadios12.Checked = true;
            }
        }

        protected void Lenth_allow_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}