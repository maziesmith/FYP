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
    public partial class batchView : Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                if (!string.IsNullOrEmpty(Session["ID"].ToString()))
                {
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
                            
                        var id = !string.IsNullOrEmpty(Request.QueryString["ID"])
                            ? Request.QueryString["ID"]
                            : Guid.Empty.ToString();
                        
                        var batchId = Convert.ToInt32(id);
                        var fileId = searchlists[batchId].file.Split('<');
                            
                        var row = new TableRow();
                        Query_table.Rows.Add(row);
                        var cell = new TableCell();
                        for (var index1 = 0; index1 < fileId.Length; index1++)
                        {
                            row.Cells.Add(cell);
                            cell.Text = index1.ToString();
                            cell.HorizontalAlign = HorizontalAlign.Center;

                            cell = new TableCell();
                            row.Cells.Add(cell);
                            cell.Text = fileId[index1].Substring(31 + userId.Length);
                            cell.HorizontalAlign = HorizontalAlign.Center;

                            var htmlAnchor = new HtmlAnchor
                            {
                                ClientIDMode = ClientIDMode.Static,
                                ID = searchlists[batchId].qid,
                                InnerHtml = "[Details]",
                                Target = "_Blank",
                                HRef = "~/Query_Record.aspx?Qid=" + searchlists[batchId].qid + "z" + index1
                            };

                            cell = new TableCell();
                            cell.Controls.Add(htmlAnchor);
                            row.Cells.Add(cell);

                            if (index1 % 2 == 0)
                                row.CssClass = "active";
                            row = new TableRow();
                            Query_table.Rows.Add(row);
                        }
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
        }
    }
}