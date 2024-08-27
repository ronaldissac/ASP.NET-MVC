using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Omegashipping.com
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["track"] != null)
                {
                    string selectedTrackID = Request.QueryString["track"];
                    Track.Text = selectedTrackID;
                    FetchData(selectedTrackID);
                }
            }
        }

        private void FetchData(string selectedTrackID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT FromLocation, ToLocation, Payment, Estimation, Location, Status, Vessel FROM Export_Status WHERE Track = @TrackID", connection))
                {
                    command.Parameters.AddWithValue("@TrackID", selectedTrackID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            From.Text = reader["FromLocation"].ToString();
                            To.Text = reader["ToLocation"].ToString();
                            Payment.Text = reader["Payment"].ToString();
                            Estimation.Text = reader["Estimation"].ToString();
                            Location.Text = reader["Location"].ToString();
                            Status.Text = reader["Status"].ToString();
                            Vessel.Text = reader["Vessel"].ToString();
                        }
                    }

                    reader.Close();
                }
            }
        }

        public bool ValidateTrack(string track)//Validate the TrackID is Correct or not 
        {
            bool isfound = false;
            string connectionString = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("select Track from Export_Status where Track=@track",connection);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@track", track);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            track = reader["Track"].ToString();
                            isfound = true;

                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Track Not Approved yet');", true);

                    }
                    connection.Close();
                   
                }
                

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           return isfound;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string track = Track.Text;
            if(ValidateTrack(track) is true)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Fetch data from the Update_Status table based on the track ID
                    string selectQuery = "SELECT * FROM Export_Status WHERE Track = @TrackID";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TrackID", track);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                From.Text = reader["FromLocation"].ToString();
                                To.Text = reader["ToLocation"].ToString();
                                Payment.Text = reader["Payment"].ToString();
                                Estimation.Text = reader["Estimation"].ToString();
                                Location.Text = reader["Location"].ToString();
                                Status.Text = reader["Status"].ToString();
                                Vessel.Text = reader["Vessel"].ToString();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Status is not yet Updated');", true);
                        }

                        reader.Close();
                    }
                }

            }
            
          
        }
    }
}