using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Printing;
using static iTextSharp.text.pdf.PdfDocument;

namespace Omegashipping.com.Admin
{
    public partial class StatusAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["trackID"] != null)
                {
                    string SelectedTrackID = Request.QueryString["trackID"];
                    Track.Text = SelectedTrackID;
                    FetchData(SelectedTrackID);

                }
                else
                {
                    FetchData();
                }
            }
        }
        private void FetchData(string selectedTrackID)
        {
            // Fetch the data from the "export" table based on the selected track ID;
            string fromAddress = "";
            string toAddress = "";

            // Use your preferred method to fetch data from the "export" table based on the selected track ID
            // Example: using ADO.NET and SQLDataReader

            // Execute a stored procedure to fetch the data from other columns based on the track ID
            // Assuming you have a stored procedure named "GetExportData" that takes the track ID as a parameter
            try
            {


                string connectionString = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetExportData", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TrackID", selectedTrackID);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Retrieve the data from each columN
                                fromAddress = reader["FromLocation"].ToString();
                                toAddress = reader["ToLocation"].ToString();
                            }
                        }

                        reader.Close();

                    }
                }

                From.Text = fromAddress;
                To.Text = toAddress;
                // Fetch data from the "Update_Status" table based on the selected track ID
                // Example: using ADO.NET and SQLDataReader
                string statusQuery = "SELECT Payment, Estimation, Location, Status, Vessel FROM Export_Status WHERE Track = @TrackID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(statusQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TrackID", selectedTrackID);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            String payment = "";
                            int estimation = 0;
                            string location = "";
                            string status = "";
                            string vessel = "";

                            while (reader.Read())
                            {
                                payment = reader["Payment"].ToString();
                                estimation = Convert.ToInt32(reader["Estimation"]);
                                location = reader["Location"].ToString();
                                status = reader["Status"].ToString();
                                vessel = reader["vessel"].ToString();
                            }
                            // Populate the corresponding textboxes with the retrieved values
                            Payment.Text = payment.ToString();
                            Estimation.Text = estimation.ToString();
                            Location.Text = location;
                            Status.Text = status;
                            Vessel.Text = vessel;
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string track = Track.Text;
            string status = Status.Text;
            string fromLocation = From.Text;
            string toLocation = To.Text;
            string location = Location.Text;
            string vessel = Vessel.Text;

            // Validate Payment as integer
            //int payment;
            //if (!int.TryParse(Payment.Text, out payment))
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Payment must be an integer.');", true);
            //    return;
            //} // Payment will be added in payment page

            // Validate Estimation as integer
            try
            {


                int estimation;
                if (!int.TryParse(Estimation.Text, out estimation))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Estimation must be an integer.');", true);
                    return;
                }
                //Validate TrackId 
                string trackID = Track.Text;
                if (track == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Cannot Update Without TrackID');", true);
                    return;
                }

                string payment = "Payment Not Yet Updated";
                string connectionString = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if the track exists in the Export_Status table
                    string checkQuery = "SELECT COUNT(*) FROM Export_Status WHERE Track = @TrackID";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@TrackID", track);
                        int count = (int)checkCommand.ExecuteScalar();

                        // Execute the stored procedure to update or insert the values based on the track existence
                        using (SqlCommand updateCommand = new SqlCommand("Update_Status", connection))
                        {
                            updateCommand.CommandType = CommandType.StoredProcedure;

                            // Add parameters and set their values
                            updateCommand.Parameters.AddWithValue("@FromLocation", fromLocation);
                            updateCommand.Parameters.AddWithValue("@ToLocation", toLocation);
                            updateCommand.Parameters.AddWithValue("@Payment", payment);
                            updateCommand.Parameters.AddWithValue("@Location", location);
                            updateCommand.Parameters.AddWithValue("@Estimation", estimation);
                            updateCommand.Parameters.AddWithValue("@Status", status);
                            updateCommand.Parameters.AddWithValue("@TrackID", track);
                            updateCommand.Parameters.AddWithValue("@Vessel", vessel);

                            // Execute the stored procedure
                            int x = updateCommand.ExecuteNonQuery();

                            if (count == 0)
                            {
                                // Track doesn't exist, a new row has been inserted
                                if (x == 1)
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Status Updated Successfully');", true);
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error From server');", true);
                                }
                            }
                            else
                            {
                                // Track exists, other columns have been updated
                                if (x > 0)
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Status Updated Successfully');", true);
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error From server');", true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }
        
        public void FetchData()
        {
            string track ="";
            string fromLocation = "";
            string toLocation = "";
            string payment = "";
            try
            {
                string Query = "Select top 1 Track,fromlocation,Payment,ToLocation from Export_Status order by Track desc";
                string connectionString = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(Query,connection);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        track = Convert.ToString(reader["Track"]);
                        fromLocation = Convert.ToString(reader["fromlocation"]);
                        payment = reader["Payment"].ToString();
                        toLocation = reader["ToLocation"].ToString();

                    }
                    Track.Text = track;
                    From.Text = fromLocation;
                    Payment.Text = payment;
                    To.Text = toLocation;
                }

            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Retrieve the selected track ID from the dropdown list
            string TrackId = Track.Text;

            // Redirect to the "status.aspx" page with the selected track ID as a query parameter
            Response.Redirect("StatusAdmin.aspx?trackID=" + TrackId);
        }

    }
}

