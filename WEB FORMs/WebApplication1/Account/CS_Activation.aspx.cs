using System;
using System.Net.Http;
using System.Web.UI;

namespace WebApplication1.Account
{
    public partial class CS_Activation : Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var client = new HttpClient();

            var activationCode = !string.IsNullOrEmpty(Request.QueryString["ActivationCode"])
                ? Request.QueryString["ActivationCode"]
                : Guid.Empty.ToString();

            var uri = "http://localhost:14625//api/users/Get_activate/" + activationCode;
            try
            {
                var task = client.GetStringAsync(uri);
                var result = await task;
                if (result == "true")
                    ltMessage.Text =
                        "Activation successful. Please Login to continue! <a href=\"Login.aspx\">Login</a>";
            }
            catch (Exception e3111)
            {
                ltMessage.Text =
                    "Invalid Activation code. Please Register to Continue!  <a href=\"Register.aspx\">Register</a>";
            }
        }
    }
}