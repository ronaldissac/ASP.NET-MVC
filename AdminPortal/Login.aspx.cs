using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Linq;

namespace Omegashipping.com
{
    public partial class Login : System.Web.UI.Page
    {
        //private static string constr = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;
        //private SqlConnection sql = new SqlConnection(constr);
        //private SqlCommand command = new SqlCommand();
        //private SqlDataAdapter adapter = new SqlDataAdapter();
        omegabaseEntities db = new omegabaseEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TrackButton_Click(object sender, EventArgs e)
        {
            GridView.DataSource = db.GetExportData(txt_track.Text);
            GridView.DataBind();
            fs.Visible = true;
            fs.Visible = GridView.HasControls();
        }

        //private DataTable GetDistinctDataFromDatabase(string trackID)
        //{
        //    DataTable dt = new DataTable();
        //    {
        //        string query = "SELECT DISTINCT FromLocation, ToLocation, Status, Location FROM Export_Status WHERE Track = @TrackID";
        //        command = new SqlCommand(query, sql);
        //        command.Parameters.AddWithValue("@TrackID", trackID);
        //        adapter = new SqlDataAdapter(command);
        //        adapter.Fill(dt);
        //    }
        //    return dt;
        //}

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                int UserType = 0;

                if (Btn_admin.Checked)
                    UserType = 1;
                else if (Btn_User.Checked)
                    UserType = 2;


                var isValidate = db.ValidateLogin(UserType, UserID.Text.Trim(), Password.Text.Trim()).ToList();

                if (isValidate.Count >0)
                {
                    isValidate.ForEach(x => { HttpContext.Current.Session["UserID"] = x.UserID; HttpContext.Current.Session["UserType"] = x.user_type; });
                    Response.Redirect("/Home.aspx");
                }
                else
                {
                    string script = "alert('Invalid credentials. Please try again.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showInvalidCredentials", script, true);
                    return;
                }

            }
            catch (Exception ex)
            {
                string script = $"alert('An error occurred: {ex.Message}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "showErrorMessage", script, true);
            }
        }
    }
}
