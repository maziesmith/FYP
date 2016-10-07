using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class Query_Record : Page
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
                    var regBtn = (HtmlAnchor) Master.FindControl("reg");
                    var heyBtn = (HtmlAnchor) Master.FindControl("hello");
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

                    var searchRec = (HtmlAnchor) Master.FindControl("A1");
                    var lgnBtn = (HtmlAnchor) Master.FindControl("lin");
                    searchRec.Style.Remove("display");
                    searchRec.InnerHtml = "Searches: " + searchlists.Count;
                    lgnBtn.InnerHtml = "Logout";
                    lgnBtn.HRef = "~/Account/Logout";

                    Result_table.Rows[0].Cells[0].Attributes.Add("style", "text-align:center !important;");
                    Result_table.Rows[0].Cells[1].Attributes.Add("style", "text-align:center !important;");
                    Result_table.Rows[0].Cells[2].Attributes.Add("style", "text-align:center !important;");
                    Result_table.Rows[0].Cells[3].Attributes.Add("style", "text-align:center !important;");

                    client = new HttpClient();
                    var qid = !string.IsNullOrEmpty(Request.QueryString["Qid"])
                        ? Request.QueryString["Qid"]
                        : Guid.Empty.ToString();
                    uri = "http://localhost:14625//api/users/Get_viewsearch/" + qid;

                    var qidArr = qid.Split('z');
                    qid = qidArr[0];
                    var fileId = Convert.ToInt32(qidArr[1]);
                    var resultList = new searchview();

                    try
                    {
                        var task = client.GetStringAsync(uri);
                        var value = await task;
                        resultList = JsonConvert.DeserializeObject<searchview>(value);
                    }
                    catch (Exception k)
                    {
                        var result1 = k.Message;
                    }

                    Session["Qid"] = qid;
                    Session[qid] = resultList;

                    var querryParameters = resultList.param;
                    P_Search1.Text = querryParameters.title;
                    P_ProMass1.Text = querryParameters.GUI_mass.ToString();
                    var xx = resultList.param.peakListFile[fileId].Substring(31 + querryParameters.userID.Length);
                    P_Data1.Text = xx;
                    P_PT1.Text = querryParameters.hopThreshhold.ToString();
                    P_PTU1.Text = "Da";
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
                            P_MTU1.Text = "Da";
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
                            (querryParameters.ptm_code_fix.Count + querryParameters.ptm_code_var.Count).ToString();
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

                    var results = resultList.result;
                    var tableRow = new TableRow();
                    Result_table.Rows.Add(tableRow);

                    if (results.final_prot != null)
                        for (var index = 0;
                            (index < results.final_prot.Count) && (index < querryParameters.NumberOfOutputs);
                            index++)
                        {
                            tableRow = new TableRow();
                            Result_table.Rows.Add(tableRow);
                            var tableCell = new TableCell();
                            tableRow.Cells.Add(tableCell);
                            tableCell.Text = (index + 1).ToString();
                            tableCell.HorizontalAlign = HorizontalAlign.Center;
                            tableCell = new TableCell();
                            tableRow.Cells.Add(tableCell);
                            tableCell.Text = results.final_prot[index].header;
                            tableCell.HorizontalAlign = HorizontalAlign.Center;
                            tableCell = new TableCell();
                            tableRow.Cells.Add(tableCell);
                            tableCell.Text = results.final_prot[index].score.ToString();
                            tableCell.HorizontalAlign = HorizontalAlign.Center;
                            tableCell = new TableCell();
                            tableRow.Cells.Add(tableCell);
                            tableCell.Text = results.final_prot[index].ptm_particulars != null
                                ? results.final_prot[index].ptm_particulars.Count.ToString()
                                : "0";
                            tableCell.HorizontalAlign = HorizontalAlign.Center;

                            var htmlAnchor = new HtmlAnchor
                            {
                                ClientIDMode = ClientIDMode.Static,
                                InnerHtml = "[Details]",
                                HRef = "~/Detailed_Results.aspx?ID=" + index + "z" + fileId,
                                Target = "_blank"
                            };

                            tableCell = new TableCell();
                            tableCell.Controls.Add(htmlAnchor);
                            tableCell.HorizontalAlign = HorizontalAlign.Center;
                            tableRow.Cells.Add(tableCell);

                            if (index%2 == 0)
                                tableRow.CssClass = "active";
                        }
                }
            }

            catch
            {
                Response.Redirect("~/Account/Login", false);
            }
        }
    }
}