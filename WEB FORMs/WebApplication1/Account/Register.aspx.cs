using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.UI;

namespace WebApplication1.Account
{
    public partial class Register : Page
    {
        public void Send_Account_Activation_Link(string emailaddress, string actCode)
        {
            using (var mailMessage = new MailMessage("abdul.rehman.127@gmail.com", Email.Text))
            {
                mailMessage.Subject = "Account Activation";
                var messageBody = "Hello " + UserKaID.Text.Trim() + ",";
                messageBody += "<br /><br />Please click the following link to activate your account";
                messageBody += "<br /><a href = '" +
                               Request.Url.AbsoluteUri.Replace("Register",
                                   "/CS_Activation.aspx?ActivationCode=" + actCode) +
                               "'>Click here to activate your account.</a>";
                messageBody += "<br /><br />Thanks";
                mailMessage.Body = messageBody;
                mailMessage.IsBodyHtml = true;
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    EnableSsl = true
                };
                var networkCred = new NetworkCredential("abdul.rehman.127@gmail.com", "hawking1900");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }

        private static string Encrypt_Password(string password)
        {
            var pwdEncode = Encoding.UTF8.GetBytes(password);
            var pwdstring = Convert.ToBase64String(pwdEncode);
            return pwdstring;
        }

        protected async void CreateUser_Click(object sender, EventArgs e)
        {
            var userEmail = Email.Text;
            var userPass = Password.Text;
            var name = Name.Text;
            var userId = UserKaID.Text;
            userPass = Encrypt_Password(userPass);

            var newGuid = Guid.NewGuid();
            Session["guid"] = newGuid;

            var uri = "http://localhost:14625//api/users/Get_registration/" + userId + "/" + name + "/" + userEmail +
                      "/" + userPass;
            var client = new HttpClient();
            string result;

            try
            {
                var task = client.GetStringAsync(uri);
                result = await task;
                reg_stat.Text = result;
            }
            catch (Exception k)
            {
                result = k.Message;
                reg_stat.Text = result;
            }

            if (result == "\"You are Registered!\"")
            {
                Send_Account_Activation_Link(Email.Text, Encrypt_Password(userEmail));
                Response.Redirect("~/Account/Account_Activation.aspx", false);
            }
        }
    }
}