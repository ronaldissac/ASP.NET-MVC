using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Omegashipping.com
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["track"] != null)
                {
                    string selectedTrackID = Request.QueryString["track"];
                    Track.Text = selectedTrackID;
                }
            }
        }
        protected void Trackbtn_Click(object sender, EventArgs e)
        {
            try
            {


                string connectionString = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;
                string trackID = Track.Text;
                string query = "SELECT Estimation FROM Export_Status WHERE Track = @trackID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@trackID", trackID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        if (reader["Estimation"] != DBNull.Value)
                        {
                            string estimation = reader["Estimation"].ToString();
                            Estimation.Text = estimation;
                            Amounttxt.Text = estimation;
                        }
                        else
                        {
                            // Handle case when estimation is not yet updated for the given track ID
                            Estimation.Text = "Estimation is not yet updated";
                            Amounttxt.Text = string.Empty;
                        }
                    }
                    else
                    {
                        // Handle case when the track ID is invalid
                        Estimation.Text = string.Empty;
                        Amounttxt.Text = string.Empty;
                        ScriptManager.RegisterStartupScript(this, GetType(), "InvalidTrackID", "alert('Track ID is invalid');", true);
                    }


                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool CheckPayment(String track)//ChecK the Payment is done Already 
        {
            // Get the connection string from web.config
            string connectionString = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;
            string query = "Select Payment from Export_Status where Track=@track";
            string PaymentStatus = "";
            string Validate = "Payment Not Yet Updated";
            bool result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@track",track);
                    object resultObj = cmd.ExecuteScalar();

                    // Check if the result is not null and convert it to string
                    if (resultObj != null)
                    {
                        PaymentStatus = resultObj.ToString();
                        if (PaymentStatus == Validate)
                        {
                            result = true;
                        }
                    }
                    connection.Close();
                    

                }
            }
            catch(Exception ex)
            {
                throw new Exception (ex.Message);
            }
            return result;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            // Get the connection string from web.config
            string connectionString = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;

            // Get the payment amount from the textbox
            string Amount = Amounttxt.Text;

            // Get the track ID from the textbox
            string trackID = Track.Text;

            // Check if the track ID is in the table
            bool trackExists = false;

            //payment details
            string payment = "Payment completed";
            try
            {


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Export_Status WHERE Track = @TrackingID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TrackingID", trackID);

                    int count = (int)command.ExecuteScalar();
                    trackExists = (count > 0);
                }

                if (trackExists)
                {
                    if (CheckPayment(trackID) is true)
                    {
                        try
                        {
                            // Update the Export_Status table with the payment information
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                string query = "UPDATE Export_Status SET Amount = @Amount, Payment =@payment WHERE Track = @TrackingID";
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@Amount", Amount);
                                command.Parameters.AddWithValue("@TrackingID", trackID);
                                command.Parameters.AddWithValue("@payment", payment);
                                command.ExecuteNonQuery();
                            }

                            // Display success message
                            ClientScript.RegisterStartupScript(GetType(), "PaymentSuccess", "alert('Payment successful.');", true);
                        }
                        catch (Exception ex)
                        {
                            // Handle any exceptions that occurred during the update process
                            // Display error message or perform necessary error handling
                            ClientScript.RegisterStartupScript(GetType(), "PaymentError", $"alert('An error occurred while updating the payment: {ex.Message}');", true);
                        } 
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "TrackNotFound", "alert('Payment Is Already Completed');", true);
                    }


                }
                else
                {
                    // Track ID not found in the table
                    ClientScript.RegisterStartupScript(GetType(), "TrackNotFound", "alert('Track ID not found.');", true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}