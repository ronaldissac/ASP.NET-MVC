using System;

namespace Omegashipping.com.Admin
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                #region session check
                lblWlc.Text += Session["UserID"];
                lblWlc.Visible = true;
                #endregion
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}