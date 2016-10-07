using System;
using System.Net.Http;
using System.Web;
using System.Web.UI;

namespace WebApplication1.Account
{
    public partial class Logout : Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var userId = Session["ID"].ToString();
                var sessionG = Session["guid"].ToString();

                if (!string.IsNullOrEmpty(HttpContext.Current.Session["guid"].ToString()))
                {
                    Session.Remove("guid");
                    Session.Remove("ID");
                    var uri = "http://localhost:14625//api/users/Get_logout/" + userId + "/" + sessionG;
                    var client = new HttpClient();
                    var task = client.GetStringAsync(uri);
                    await task;
                }

                Response.Redirect("~/", false);
            }
            catch (Exception)
            {
                Response.Redirect("~/", false);
            }
        }
    }
}