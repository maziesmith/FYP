using System;
using System.Web.UI;

namespace WebApplication1.Account
{
    public partial class Account_Activation : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltMessage.Text =
                "Your Account has beeen created successfuly. You will recieve email with activation link shortly.";
        }
    }
}