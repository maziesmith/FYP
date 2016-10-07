using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class Detailed_Results : Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                if (string.IsNullOrEmpty(Session["ID"].ToString())) Response.Redirect("~/Account/Login", false);
                var client = new HttpClient();
                var userId = Session["ID"].ToString();
                var sessionG = Session["guid"].ToString();
                string result;
                var uri = "http://localhost:14625//api/users/Get_Session/" + userId + "/" + sessionG;

                try
                {
                    var task = client.GetStringAsync(uri);
                    result = await task;
                }
                catch (Exception k)
                {
                    result = k.Message;
                }

                if (result == "F")
                    Response.Redirect("~/Account/Login", false);
                else
                {
                    var regBtn = (HtmlAnchor)Master.FindControl("reg");
                    var heyBtn = (HtmlAnchor)Master.FindControl("hello");
                    regBtn.Style.Add("display", "none");
                    heyBtn.Style.Remove("display");
                    heyBtn.InnerHtml = Session["ID"].ToString();
                    client = new HttpClient();
                    userId = Session["ID"].ToString();
                    uri = "http://localhost:14625//api/users/Get_my_searches/" + userId;
                    var searchlists = new List<searchlist>();

                    try
                    {
                        var task = client.GetStringAsync(uri);
                        var value = await task;
                        searchlists = JsonConvert.DeserializeObject<List<searchlist>>(value);
                        searchlists = searchlists.OrderByDescending(e11 => DateTime.Parse(e11.date)).ToList();
                    }
                    catch (Exception k)
                    {
                        var result1 = k.Message;
                    }

                    var searchRec = (HtmlAnchor)Master.FindControl("A1");
                    var lgnBtn = (HtmlAnchor)Master.FindControl("lin");
                    searchRec.Style.Remove("display");
                    searchRec.InnerHtml = "Searches: " + searchlists.Count;
                    lgnBtn.InnerHtml = "Logout";
                    lgnBtn.HRef = "~/Account/Logout";
                    na.Checked = true;
                    han.Checked = false;
                    
                    var id = !string.IsNullOrEmpty(Request.QueryString["ID"])
                        ? Request.QueryString["ID"]
                        : Convert.ToString(-1);
                    var qid = Session["Qid"].ToString();

                    var qidArr = id.Split('z');
                    id = qidArr[0];
                    var fileId = Convert.ToInt32(qidArr[1]);
                    var answer = (searchview)Session[qid];
                    var results = answer.result;
                    var querryParameters = answer.param;
                    var proteins = results.final_prot[Convert.ToInt32(id)];
                    text1.Text = proteins.header;
                    Title = proteins.header;
                    head.Text = "[Details]";

                    if (text1.Text == "google ubiquitin")
                        head.NavigateUrl = "https://en.wikipedia.org/wiki/Ubiquitin";
                    else
                        head.NavigateUrl = "http://www.uniprot.org/uniprot/" + text1.Text;

                    rank1.Text = (Convert.ToInt32(id) + 1).ToString();
                    MW1.Text = proteins.MW.ToString();
                    Score1.Text = string.Format("{0:0.##}", proteins.score);
                    MW_S1.Text = string.Format("{0:0.##}", proteins.MW_score);
                    PST1.Text = string.Format("{0:0.##}", proteins.est_score);
                    Insilico1.Text = string.Format("{0:0.##}", proteins.insilico_score);
                    PTM1.Text = string.Format("{0:0.##}", proteins.ptm_score);

                    var exe = results.times;
                    Total1.Text = Convert.ToDateTime(exe.total_time).Second +
                                  Convert.ToDateTime(exe.total_time).Minute * 60 + "." +
                                  Convert.ToDateTime(exe.total_time).Millisecond + " secs";
                    MWM1.Text = Convert.ToDateTime(exe.mw_filter_time).Second * 1000 +
                                Convert.ToDateTime(exe.mw_filter_time).Millisecond + " msecs";
                    PSTM1.Text = Convert.ToDateTime(exe.pst_time).Second * 1000 +
                                 Convert.ToDateTime(exe.pst_time).Millisecond + " msecs";
                    PTMM1.Text = Convert.ToDateTime(exe.ptm_time).Second +
                                 Convert.ToDateTime(exe.ptm_time).Minute * 60 + "." +
                                 Convert.ToDateTime(exe.ptm_time).Millisecond + " secs";
                    ;
                    InsM1.Text = Convert.ToDateTime(exe.insilico_time).Second + "." +
                                 Convert.ToDateTime(exe.insilico_time).Millisecond + " secs";
                    TunerM1.Text = Convert.ToDateTime(exe.tuner_time).Second * 1000 +
                                   Convert.ToDateTime(exe.tuner_time).Millisecond + " msecs";


                    P_Search1.Text = querryParameters.title;
                    P_ProMass1.Text = querryParameters.GUI_mass.ToString();
                    var xx = answer.param.peakListFile[fileId].Substring(31 + querryParameters.userID.Length);
                    P_Data1.Text = xx;
                    P_PT1.Text = querryParameters.hopThreshhold.ToString();
                    P_PTU1.Text = "Da"; //qu.hopTolUnit;
                    P_DB1.Text = querryParameters.protDB;

                    if (querryParameters.insilico_frag_type == "*")
                        P_FRGL.Style.Add(HtmlTextWriterStyle.Color, "gray");
                    else
                        P_FRG1.Text = querryParameters.insilico_frag_type;

                    if (querryParameters.insilico_frag_type == "*")
                        P_SIL.Style.Add(HtmlTextWriterStyle.Color, "gray");
                    else
                        P_SI1.Text = querryParameters.HandleIons;

                    if (querryParameters.autotune == 1)
                    {
                        P_AU1.Text = "Yes";
                        if (querryParameters.filterDB == 1)
                        {
                        }
                        else
                        {
                            P_MT1.Text = querryParameters.MW_tolerance.ToString();
                            P_MTU1.Text = "Da"; //qu.MWTolUnit;
                        }
                    }
                    else
                    {
                        P_AU1.Text = "No";
                    }

                    if (querryParameters.filterDB == 1)
                    {
                        P_FDB1.Text = "Yes";
                        P_MT1.Text = querryParameters.MW_tolerance.ToString();
                        P_MTU1.Text = "Da"; // qu.MWTolUnit;
                    }

                    else
                    {
                        P_FDB1.Text = "No";
                        P_MTL.Style.Add(HtmlTextWriterStyle.Color, "gray");
                        P_MTUL.Style.Add(HtmlTextWriterStyle.Color, "gray");
                    }

                    if (querryParameters.denovo_allow == 1)
                    {
                        P_EPT1.Text = "Yes";
                        if ((querryParameters.maximum_est_length == -1) &&
                            (querryParameters.minimum_est_length == -1))
                        {
                            P_MINL.Style.Add(HtmlTextWriterStyle.Color, "gray");
                            P_MAXL.Style.Add(HtmlTextWriterStyle.Color, "gray");
                        }
                        else
                        {
                            P_MIN1.Text = querryParameters.minimum_est_length.ToString();
                            P_MAX1.Text = querryParameters.maximum_est_length.ToString();
                        }
                    }
                    else
                    {
                        P_EPT1.Text = "No";
                        P_MINL.Style.Add(HtmlTextWriterStyle.Color, "gray");
                        P_MAXL.Style.Add(HtmlTextWriterStyle.Color, "gray");
                    }

                    if (querryParameters.ptm_allow == 1)
                    {
                        P_PTM1.Text = "Yes";
                        P_NOS1.Text =
                            (querryParameters.ptm_code_fix.Count + querryParameters.ptm_code_var.Count).ToString
                                ();
                        P_PTMT1.Text = querryParameters.ptm_tolerance.ToString();
                        P_NOSL.Style.Add(HtmlTextWriterStyle.Color, "black");
                    }
                    else
                    {
                        P_PTM1.Text = "No";
                        P_NOSL.Style.Add(HtmlTextWriterStyle.Color, "gray");
                        P_PTMTL.Style.Add(HtmlTextWriterStyle.Color, "gray");
                    }

                    P_MWSW1.Text = querryParameters.MW_sweight.ToString();
                    P_PSTW1.Text = querryParameters.PST_sweight.ToString();
                    P_INSW1.Text = querryParameters.Insilico_sweight.ToString();
                    P_NO1.Text = querryParameters.NumberOfOutputs.ToString();

                    var tableHeaderRow = new TableHeaderRow();
                    aspTable1.Rows.Add(tableHeaderRow);
                    var tableHeaderCell = new TableHeaderCell();
                    tableHeaderRow.Cells.Add(tableHeaderCell);
                    tableHeaderCell.Text = "Res. #";
                    tableHeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    tableHeaderCell.Font.Bold = true;
                    tableHeaderCell.Attributes.Add("style", "text-align:center !important;");
                    tableHeaderCell.Style.Add("padding", "0px");
                    tableHeaderRow.BackColor = Color.WhiteSmoke;

                    var tableRow = new TableRow();
                    aspTable1.Rows.Add(tableRow);
                    var tableCell = new TableCell();
                    tableRow.Cells.Add(tableCell);
                    tableCell.Text = "SEQUENCE";
                    tableCell.HorizontalAlign = HorizontalAlign.Center;
                    tableCell.Font.Bold = true;
                    tableCell.Style.Add("padding", "0px");

                    var tableRow2 = new TableRow();
                    aspTable1.Rows.Add(tableRow2);
                    var tableCell2 = new TableCell();
                    tableRow2.Cells.Add(tableCell2);
                    tableCell2.Text = "C-term IONS";
                    tableCell2.HorizontalAlign = HorizontalAlign.Center;
                    tableCell2.ForeColor = Color.Green;
                    tableCell2.Font.Bold = true;
                    tableCell2.Style.Add("padding", "0px");


                    var tableRow3 = new TableRow();
                    aspTable1.Rows.Add(tableRow3);
                    var tableCell3 = new TableCell();
                    tableRow3.Cells.Add(tableCell3);
                    tableCell3.Text = "MATCHED";
                    tableCell3.HorizontalAlign = HorizontalAlign.Center;
                    tableCell3.ForeColor = Color.Green;
                    tableCell3.Font.Bold = true;
                    tableCell3.Style.Add("padding", "0px");


                    var tableRow4 = new TableRow();
                    aspTable1.Rows.Add(tableRow4);
                    var tableCell4 = new TableCell();
                    tableRow4.Cells.Add(tableCell4);
                    tableCell4.Text = "N-term IONS";
                    tableCell4.HorizontalAlign = HorizontalAlign.Center;
                    tableCell4.ForeColor = Color.Blue;
                    tableCell4.Font.Bold = true;
                    tableCell4.Style.Add("padding", "0px");


                    var tableRow5 = new TableRow();
                    aspTable1.Rows.Add(tableRow5);
                    var tableCell5 = new TableCell();
                    tableRow5.Cells.Add(tableCell5);
                    tableCell5.Text = "MATCHED";
                    tableCell5.HorizontalAlign = HorizontalAlign.Center;
                    tableCell5.ForeColor = Color.Blue;
                    tableCell5.Font.Bold = true;
                    tableCell5.Style.Add("padding", "0px");


                    var tableRow1 = new TableRow();
                    aspTable1.Rows.Add(tableRow1);
                    var tableCell1 = new TableCell();
                    tableRow1.Cells.Add(tableCell1);
                    tableCell1.Text = "MODIFICATIONS";
                    tableCell1.HorizontalAlign = HorizontalAlign.Center;
                    tableCell1.Font.Bold = true;
                    tableCell1.Style.Add("padding", "0px");


                    if (results.final_prot != null)
                        for (var i = 0; i < proteins.sequence.Length; i++)
                        {
                            if (i > 0)
                                if (i % 7 == 0)
                                {
                                    tableHeaderRow = new TableHeaderRow();
                                    aspTable1.Rows.Add(tableHeaderRow);
                                    tableHeaderCell = new TableHeaderCell();
                                    tableHeaderRow.Cells.Add(tableHeaderCell);
                                    tableHeaderCell.Text = "Res. #";
                                    tableHeaderCell.HorizontalAlign = HorizontalAlign.Center;
                                    tableHeaderCell.Font.Bold = true;
                                    tableHeaderCell.Attributes.Add("style", "text-align:center !important;");
                                    tableHeaderCell.Style.Add("padding", "0px");
                                    tableHeaderRow.BackColor = Color.WhiteSmoke;
                                }
                            tableHeaderCell = new TableHeaderCell();
                            tableHeaderRow.Cells.Add(tableHeaderCell);
                            tableHeaderCell.Text = (i + 1).ToString();
                            tableHeaderCell.Font.Bold = true;
                            tableHeaderCell.Attributes.Add("style", "text-align:center !important;");
                            tableHeaderCell.Style.Add("padding", "0px");


                            if (i > 0)
                                if (i % 7 == 0)
                                {
                                    tableRow = new TableRow();
                                    aspTable1.Rows.Add(tableRow);
                                    tableCell = new TableCell();
                                    tableRow.Cells.Add(tableCell);
                                    tableCell.Text = "SEQUENCE";
                                    tableCell.Style.Add("padding", "0px");
                                    tableCell.HorizontalAlign = HorizontalAlign.Center;
                                    tableCell.Font.Bold = true;
                                }
                            tableCell = new TableCell();
                            tableRow.Cells.Add(tableCell);
                            tableCell.Text = proteins.sequence[i].ToString();
                            tableCell.Style.Add("padding", "0px");
                            tableCell.HorizontalAlign = HorizontalAlign.Center;


                            if (i > 0)
                                if (i % 7 == 0)
                                {
                                    tableRow2 = new TableRow();
                                    aspTable1.Rows.Add(tableRow2);
                                    tableCell2 = new TableCell();
                                    tableRow2.Cells.Add(tableCell2);
                                    tableCell2.Text = "C-term IONS";
                                    tableCell2.HorizontalAlign = HorizontalAlign.Center;
                                    tableCell2.Font.Bold = true;
                                    tableCell2.Style.Add("padding", "0px");
                                    tableCell2.ForeColor = Color.Green;
                                }
                            tableCell2 = new TableCell();
                            tableRow2.Cells.Add(tableCell2);
                            tableCell2.Text = string.Format("{0:0.00}",
                                proteins.insilico_details.insilico_mass_left[i]);
                            tableCell2.ForeColor = Color.Green;
                            tableCell2.Style.Add("padding", "0px");
                            tableCell2.HorizontalAlign = HorizontalAlign.Center;


                            if (i > 0)
                                if (i % 7 == 0)
                                {
                                    tableRow3 = new TableRow();
                                    aspTable1.Rows.Add(tableRow3);
                                    tableCell3 = new TableCell();
                                    tableRow3.Cells.Add(tableCell3);
                                    tableCell3.Text = "MATCHED";
                                    tableCell3.HorizontalAlign = HorizontalAlign.Center;
                                    tableCell3.Font.Bold = true;
                                    tableCell3.Style.Add("padding", "0px");
                                    tableCell3.ForeColor = Color.Green;
                                }
                            tableCell3 = new TableCell();
                            tableRow3.Cells.Add(tableCell3);
                            tableCell3.Style.Add("padding", "0px");
                            if (proteins.insilico_details.peaklist_mass_left[i] == 0)
                                tableCell3.Text = "";
                            else
                            {
                                tableCell3.BackColor = Color.Green;
                                tableCell3.ForeColor = Color.White;
                                tableCell3.Text = string.Format("{0:0.00}",
                                    proteins.insilico_details.peaklist_mass_left[i]);

                                tableCell3.HorizontalAlign = HorizontalAlign.Center;
                            }


                            if (i > 0)

                                if (i % 7 == 0)
                                {
                                    tableRow4 = new TableRow();
                                    aspTable1.Rows.Add(tableRow4);
                                    tableCell4 = new TableCell();
                                    tableRow4.Cells.Add(tableCell4);
                                    tableCell4.Text = "N-term IONS";
                                    tableCell4.HorizontalAlign = HorizontalAlign.Center;
                                    tableCell4.Font.Bold = true;
                                    tableCell4.ForeColor = Color.Blue;
                                    tableCell4.Style.Add("padding", "0px");
                                }
                            tableCell4 = new TableCell();
                            tableRow4.Cells.Add(tableCell4);
                            tableCell4.Text = string.Format("{0:0.00}",
                                proteins.insilico_details.insilico_mass_right[i]);
                            tableCell4.ForeColor = Color.Blue;
                            tableCell4.Style.Add("padding", "0px");
                            tableCell4.HorizontalAlign = HorizontalAlign.Center;

                            if (i > 0)
                                if (i % 7 == 0)
                                {
                                    tableRow5 = new TableRow();
                                    aspTable1.Rows.Add(tableRow5);
                                    tableCell5 = new TableCell();
                                    tableRow5.Cells.Add(tableCell5);
                                    tableCell5.Style.Add("padding", "0px");
                                    tableCell5.Text = "MATCHED";
                                    tableCell5.HorizontalAlign = HorizontalAlign.Center;
                                    tableCell5.Font.Bold = true;
                                    tableCell5.ForeColor = Color.Blue;
                                }
                            tableCell5 = new TableCell();
                            tableCell5.Style.Add("padding", "0px");
                            tableRow5.Cells.Add(tableCell5);
                            if (proteins.insilico_details.peaklist_mass_right[i] == 0)
                                tableCell5.Text = "";
                            else
                            {
                                tableCell5.BackColor = Color.Blue;
                                tableCell5.Text = string.Format("{0:0.00}",
                                    proteins.insilico_details.peaklist_mass_right[i]);
                                tableCell5.ForeColor = Color.White;
                                tableCell5.HorizontalAlign = HorizontalAlign.Center;
                            }


                            if (i > 0)
                                if (i % 7 == 0)
                                {
                                    tableRow1 = new TableRow();
                                    aspTable1.Rows.Add(tableRow1);
                                    tableCell1 = new TableCell();
                                    tableRow1.Cells.Add(tableCell1);
                                    tableCell1.Text = "MODIFICATIONS";
                                    tableCell1.Style.Add("padding", "0px");
                                    tableCell1.HorizontalAlign = HorizontalAlign.Center;
                                    tableCell1.Font.Bold = true;
                                }
                            tableCell1 = new TableCell();
                            tableRow1.Cells.Add(tableCell1);
                            tableCell1.HorizontalAlign = HorizontalAlign.Center;
                            tableCell1.Style.Add("padding", "0px");
                            if (proteins.ptm_particulars.Count != 0)
                                foreach (Sites modSites in proteins.ptm_particulars)
                                    if (modSites.i == i)
                                    {
                                        tableCell1.Text = "";
                                        tableCell1.Text = modSites.mod_name;
                                        break;
                                    }
                                    else
                                        tableCell1.Text = "-";
                            else
                                tableCell1.Text = "-";
                        }
                }
            }


            catch
            {
                Response.Redirect("~/Account/Login", false);
            }
            na.Checked = true;
            han.Checked = false;
        }
    }
}