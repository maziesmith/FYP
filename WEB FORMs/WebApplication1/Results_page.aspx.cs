using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class Results_page : Page
    {
        private static string _xml;
        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var clientA = new HttpClient();
                if (!string.IsNullOrEmpty(Session["ID"].ToString()))
                {
                    var userId = Session["ID"].ToString();
                    var sessionG = Session["guid"].ToString();
                    string result;
                    var uri = "http://localhost:14625//api/users/Get_Session/" + userId + "/" + sessionG;

                    try
                    {
                        var task = clientA.GetStringAsync(uri);
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
                            var task = clientB.GetStringAsync(uri1);
                            var value = await task;
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
                else
                {
                    Response.Redirect("~/Account/Login", false);
                }
            }
            catch
            {
                Response.Redirect("~/Account/Login", false);
            }


            aspTable.Rows[0].Cells[0].Attributes.Add("style", "text-align:center !important;");
            aspTable.Rows[0].Cells[1].Attributes.Add("style", "text-align:center !important;");
            aspTable.Rows[0].Cells[2].Attributes.Add("style", "text-align:center !important;");
            aspTable.Rows[0].Cells[3].Attributes.Add("style", "text-align:center !important;");

            var results = new Results();

            var id = !string.IsNullOrEmpty(Request.QueryString["ID"])
                ? Request.QueryString["ID"]
                : Convert.ToString(-1);
            var fileId = Convert.ToInt32(id);

            try
            {
                var qId = Session["Qid"].ToString();
                var answer = (searchview) Session[qId];

                results = answer.result;
                Title = answer.param.title;
            }
            catch (Exception)
            {
                // Response.Redirect("~/Account/Login", false);
            }

            var tableRow = new TableRow();
            aspTable.Rows.Add(tableRow);

            if (results.final_prot == null) return;
            for (var i = 0; i < results.final_prot.Count; i++)
            {
                tableRow = new TableRow();
                aspTable.Rows.Add(tableRow);
                var tableCell = new TableCell();
                tableRow.Cells.Add(tableCell);
                tableCell.Text = (i + 1).ToString();
                tableCell.HorizontalAlign = HorizontalAlign.Center;
                tableCell = new TableCell();
                tableRow.Cells.Add(tableCell);
                tableCell.Text = results.final_prot[i].header;
                tableCell.HorizontalAlign = HorizontalAlign.Center;
                tableCell = new TableCell();
                tableRow.Cells.Add(tableCell);
                tableCell.Text = results.final_prot[i].score.ToString();
                tableCell.HorizontalAlign = HorizontalAlign.Center;
                tableCell = new TableCell();
                tableRow.Cells.Add(tableCell);
                tableCell.Text = results.final_prot[i].ptm_particulars != null
                    ? results.final_prot[i].ptm_particulars.Count.ToString()
                    : "0";
                tableCell.HorizontalAlign = HorizontalAlign.Center;

                var htmlAnchor = new HtmlAnchor
                {
                    ClientIDMode = ClientIDMode.Static,
                    InnerHtml = "[Details]",
                    HRef = "~/Detailed_Results.aspx?ID=" + i + "z" + fileId,
                    Target = "_blank"
                };

                tableCell = new TableCell();
                tableCell.Controls.Add(htmlAnchor);
                tableCell.HorizontalAlign = HorizontalAlign.Center;
                tableRow.Cells.Add(tableCell);


                if (i%2 == 0)
                    tableRow.CssClass = "active";
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            var z = _xml;
        }
    }
}