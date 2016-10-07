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
    public partial class prog : Page
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
            
            catch
            {
                Response.Redirect("~/Account/Login", false);
            }

            var progressClient = new HttpClient();
            var qid = !string.IsNullOrEmpty(Request.QueryString["ID"])
                ? Request.QueryString["ID"]
                : Guid.Empty.ToString();
            var qidArr = qid.Split('z');
            qid = qidArr[0];
            Session["Qid"] = qid;
            var fileId = Convert.ToInt32(qidArr[1]);
            var uri11 = "http://localhost:14625//api/Users/Get_viewsearch/" + qid + "z" + fileId;
            var progClient = progressClient.GetStringAsync(uri11);
            var progValue = await progClient;
            if (progValue != null)
            {
                var answer = JsonConvert.DeserializeObject<searchview>(progValue);
                Session[qid] = answer;
            }
            Response.Redirect("~/Results_page?ID=" + fileId, false);
        }
    }
}