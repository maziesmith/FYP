using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Account
{
    public partial class User : Page
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
                    var userId = Session["ID"].ToString();
                    var sessionG = Session["guid"].ToString();
                    var uri = "http://localhost:14625//api/users/Get_Session/" + userId + "/" + sessionG;
                    var task = clientA.GetStringAsync(uri);
                    var result = await task;

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

                        if (IsPostBack) return;
                        uri = "http://localhost:14625//api/users/Get_User_information/" + userId;
                        task = clientA.GetStringAsync(uri);
                        result = await task;
                        var user = JsonConvert.DeserializeObject<user_details>(result);
                        Email.Text = user.Email;
                        Name.Text = user.Name;
                    }
                }
            }
            catch
            {
                Response.Redirect("~/Account/Login", false);
            }
        }

        private static string Encrypt_Password(string password)
        {
            var pwdEncode = Encoding.UTF8.GetBytes(password);
            var pwdstring = Convert.ToBase64String(pwdEncode);
            return pwdstring;
        }

        protected async void Unnamed_Click(object sender, EventArgs e)
        {
            var emailText = Email.Text;
            var nameText = Name.Text;
            var userid = Session["ID"].ToString();
            var client = new HttpClient();
            string result;
            var uri = "http://localhost:14625//api/users/Get_UpdateInfo/" + userid + "/" + emailText + "/" + nameText;

            try
            {
                var task = client.GetStringAsync(uri);
                result = await task;
            }
            catch (Exception k)
            {
                result = k.Message;
            }

            Update.Text = result;
        }

        protected async void Unnamed_Click1(object sender, EventArgs e)
        {
            var passwordText = Password.Text;
            var userId = Session["ID"].ToString();
            var userPass = TextBox1.Text;
            var client = new HttpClient();
            string result;
            var newGuid = Guid.NewGuid();
            Session["guid"] = newGuid.ToString();
            userPass = Encrypt_Password(userPass);


            var uri = "http://localhost:14625//api/users/Get_login/" + userId + "/" + userPass + "/" + newGuid;

            try
            {
                var task = client.GetStringAsync(uri);
                result = await task;
            }
            catch (Exception k)
            {
                result = k.Message;
            }


            if (result == "\"Login Successfull!\"")
            {
                passwordText = Encrypt_Password(passwordText);
                client = new HttpClient();
                uri = "http://localhost:14625//api/users/Get_UpdatePassword/" + userId + "/" + passwordText;

                try
                {
                    var task = client.GetStringAsync(uri);
                    result = await task;
                }
                catch (Exception k)
                {
                    result = k.Message;
                }

                Update.Text = result;
            }
        }
    }
}