using System;
using System.Net.Http;
using System.Text;
using System.Web.UI;
using WebApplication1.web;

namespace WebApplication1.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var session = new WebService1();
            try
            {
                if (string.IsNullOrEmpty(Session["ID"].ToString()))
                    Response.Redirect("~/Account/Logout.aspx");
                if (session.Session_check(Session["ID"].ToString(), Session["guid"].ToString()))
                    Response.Redirect("~/Account/Logout.aspx");
            }
            catch
            {
                // ignored
            }
        }

        private string Decrypt_Password(string encryptpassword)
        {
            var encodePwd = new UTF8Encoding();
            var decode = encodePwd.GetDecoder();
            var todecodeByte = Convert.FromBase64String(encryptpassword);
            var charCount = decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
            var decodedChar = new char[charCount];
            decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
            var pwdstring = new string(decodedChar);
            return pwdstring;
        }

        private static string Encrypt_Password(string password)
        {
            var pwdEncode = Encoding.UTF8.GetBytes(password);
            var pwdstring = Convert.ToBase64String(pwdEncode);
            return pwdstring;
        }

        protected async void LogIn(object sender, EventArgs e)
        {
            var userId = text.Text;
            var userPass = Password.Text;
            var client = new HttpClient();
            string result;
            var sessionG = Guid.NewGuid();
            Session["guid"] = sessionG.ToString();
            Session["ID"] = userId;
            userPass = Encrypt_Password(userPass);
            var uri = "http://localhost:14625//api/users/Get_login/" + userId + "/" + userPass + "/" + sessionG;

            try
            {
                var task = client.GetStringAsync(uri);
                result = await task;
            }
            catch (Exception k)
            {
                result = k.Message;
            }

            login_stat.Text = result;

            if (result == "\"Login Successfull!\"")
                Response.Redirect("~/Search.aspx", false);
        }
    }
}