using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Default : Page
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
                }
            }
            catch (Exception)
            {
                // ignored
            } //Response.Redirect("~/Account/Login", false); }
        }

        protected void perform_search_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Search.aspx");
        }
    }
}