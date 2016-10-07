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
    public partial class QueryList : Page
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

                    Query_table.Rows[0].Cells[0].Attributes.Add("style", "text-align:center !important;");
                    Query_table.Rows[0].Cells[1].Attributes.Add("style", "text-align:center !important;");
                    Query_table.Rows[0].Cells[2].Attributes.Add("style", "text-align:center !important;");

                    var tableRow = new TableRow();
                    Query_table.Rows.Add(tableRow);
                    var temp = 1;
                    if (searchlists.Count == 0) return;
                    for (var i = searchlists.Count - 1; i >= 0; i--)
                    {
                        tableRow = new TableRow();
                        Query_table.Rows.Add(tableRow);
                        var tableCell = new TableCell();
                        tableRow.Cells.Add(tableCell);
                        tableCell.Text = temp.ToString();
                        tableCell.HorizontalAlign = HorizontalAlign.Center;

                        tableCell = new TableCell();
                        tableRow.Cells.Add(tableCell);
                        tableCell.Text = searchlists[i].title;
                        tableCell.HorizontalAlign = HorizontalAlign.Center;

                        tableCell = new TableCell();
                        tableRow.Cells.Add(tableCell);
                        tableCell.Text = searchlists[i].date;
                        tableCell.HorizontalAlign = HorizontalAlign.Center;

                        var htmlAnchor = new HtmlAnchor
                        {
                            ClientIDMode = ClientIDMode.Static,
                            ID = searchlists[i].qid,
                            InnerHtml = "[Details]",
                            Target = "_Blank"
                        };

                        var fileId = searchlists[i].file.Split('<');
                        if (fileId.Length == 1)
                            htmlAnchor.HRef = "~/Query_Record.aspx?Qid=" + searchlists[i].qid + "z0";
                        else
                            htmlAnchor.HRef = "~/batchView.aspx?ID=" + i;
                        tableCell = new TableCell();
                        tableCell.Controls.Add(htmlAnchor);
                        tableRow.Cells.Add(tableCell);


                        temp++;
                        if (i % 2 == 0)
                            tableRow.CssClass = "active";
                    }
                }
            }
            catch
            {
                Response.Redirect("~/Account/Login", false);
            }
        }


        protected void btnTest_Click(object sender, EventArgs e)
        {
            Response.Redirect("Query_Record.aspx");
        }
    }
}