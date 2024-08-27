using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace Omegashipping.com
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void productname_TextChanged(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Generate a 16-digit random number
                string randomNumber = Guid.NewGuid().ToString("N").Substring(0, 16);


                string connectionString = ConfigurationManager.ConnectionStrings["dis"].ConnectionString; //SQL Server connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if the 'from' and 'to' values are the same
                    if (from.Text.Equals(To.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        // Show error message to the user
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('From and To values cannot be the same.');", true);
                        return;
                    }

                    // Validate Quantity as integer
                    int quantity;
                    if (!int.TryParse(Quantity.Text, out quantity))
                    {
                        // Show error message to the user
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Quantity must be an integer.');", true);
                        return;
                    }
                    SqlCommand command = new SqlCommand("AddExport", connection); // Replace with your stored procedure name
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the stored procedure
                    command.Parameters.AddWithValue("@ProductName", productname.Text);
                    command.Parameters.AddWithValue("@Quantity", Quantity.Text);
                    command.Parameters.AddWithValue("@FromLocation", from.Text);
                    command.Parameters.AddWithValue("@ToLocation", To.Text);
                    command.Parameters.AddWithValue("@Track", randomNumber);


                    // Upload the file to the server
                    if (FileUpload2.HasFile)
                    {
                        byte[] fileData = FileUpload2.FileBytes;
                        command.Parameters.AddWithValue("@FileData", fileData);
                        command.Parameters.AddWithValue("@FileName", FileUpload2.FileName);
                        
                    }
                    else
                    {
                        // Show success message to the user
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('please upload the product image');", true);
                    }

                    // Execute the stored procedure
                    int x =command.ExecuteNonQuery();
                    if (x == 1)
                    {
                        
                        string successMessage = "Order Booked successfully!";
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('{successMessage}');", true);
                        RandomNumberLabel.Text = "Tracking ID  : " + randomNumber;
                        tracklabel.Text = randomNumber;
                        string track = randomNumber;
                        productname.Text = "";
                        Quantity.Text = "";
                        from.Text = "";
                        To.Text = "";
                        return;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error From server');", true);
                        return;
                    }
                    
                } 
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Error: {ex.Message}');", true);
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            string track = tracklabel.Text;
            Response.Redirect("Status.aspx?track=" + track);
        }
    }
}