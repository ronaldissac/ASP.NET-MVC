using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Omegashipping.com.Admin
{
    public partial class BLAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["TrackID"] != null)
                {
                    string trackId = Request.QueryString["TrackID"];
                    Trackdp.Text = trackId;
                    FetchData(trackId);
                    
                }
                else
                {
                    PopulateDropdownList();
                    string trackid = Trackdp.Text;
                    FetchData(trackid); 
                    
                }
            }
            

        }
        #region FetchData
        private void FetchData(string trackid)
        {
            string status = "";
            string from = "";
            String to = "";
            string payment = "";
            string estimation = "";
            string vessel = "";
            string location = "";
            string Con = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(Con))
                {
                    string query = "Select top 1 Track,Status,FromLocation,ToLocation,Vessel,Payment,Estimation,Location from Export_Status where Track=@track";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@track", trackid);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        status = reader["Status"].ToString();
                        from = reader["FromLocation"].ToString() ;
                        to = reader["ToLocation"].ToString() ;
                        payment = reader["Payment"].ToString();
                        estimation = reader["Estimation"].ToString();
                        vessel = reader["Vessel"].ToString();
                        location = reader["Location"].ToString();

                    }
                    Status.Text = status;
                    From.Text = from;
                    To.Text = to;
                    Payment.Text = payment;
                    Estimation.Text = estimation;
                    Vessel.Text = vessel;
                    Location.Text = location;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public void FetchData()
        //{
        //    string track = "";
        //    string status = "";
        //    string from = "";
        //    String to = "";
        //    string payment = "";
        //    string estimation = "";
        //    string vessel = "";
        //    string location = "";
        //    try
        //    {
        //        string Query = "Select top 1 Track,Status,FromLocation,ToLocation,Vessel,Payment,Estimation,Location from Export_Status group by Track order by Track desc";
        //        string connectionString = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            SqlCommand cmd = new SqlCommand(Query, connection);
        //            cmd.CommandType = CommandType.Text;
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                track = reader["Track"].ToString();
        //                from = reader["Status"].ToString();
        //                payment = reader["Payment"].ToString();
        //                location = reader["Location"].ToString();
        //                estimation = reader["Estimation"].ToString();
        //                vessel = reader["Vessel"].ToString();
        //                to = reader["ToLocation"].ToString();
        //            }
        //            Trackdp.Text = track;
        //            From.Text = from;
        //            Payment.Text = payment;
        //            To.Text = to;
        //            Estimation.Text = estimation;
        //            Vessel.Text = vessel;
        //            Status.Text = status;
        //            Location.Text = location;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
            #endregion
        protected void btn_clicktrack(object sender, EventArgs e)
        {
            string trackId = Trackdp.Text;

            if (!string.IsNullOrEmpty(trackId))
            {
                // Check if the track detail exists in the Export_Status table
                if (IsTrackExist(trackId))
                {
                    // Fetch the details from the Export_Status table using the track
                    DataTable detailsTable = GetExportStatusDetails(trackId);

                    if (detailsTable.Rows.Count > 0)
                    {
                        DataRow row = detailsTable.Rows[0];

                        // Display the details in the respective textboxes
                        Status.Text = row["Status"].ToString();
                        From.Text = row["FromLocation"].ToString();
                        To.Text = row["ToLocation"].ToString();
                        Payment.Text = row["Payment"].ToString();
                        Estimation.Text = row["Estimation"].ToString();
                        Vessel.Text = row["Vessel"].ToString();
                        Location.Text = row["Location"].ToString();
                    }
                }
                else
                {
                    // Track detail doesn't exist in the table, show an alert message
                    ScriptManager.RegisterStartupScript(this, GetType(), "TrackNotFound", "alert('The provided tracking ID does not exist.');", true);
                }
            }
        }
        protected void btn_clickPdf(object sender, EventArgs e)
        {
            string trackId = Trackdp.Text;

            if (!string.IsNullOrEmpty(trackId))
            {
                // Check if the track detail exists in the Export_Status table
                if (IsTrackExist(trackId))
                {
                    // Fetch the details from the Export_Status table using the track
                    DataTable detailsTable = GetExportStatusDetails(trackId);

                    if (detailsTable.Rows.Count > 0)
                    {
                        DataRow row = detailsTable.Rows[0];

                        // Store the details in the BL table and generate a unique BL number
                        string blNumber = StoreInBLTable(row);
                        string connectionString = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;
                        // Generate a PDF to display the details
                        GeneratePDF(connectionString, blNumber);
                    }
                }
                else
                {
                    // Track detail doesn't exist in the table, show an alert message
                    ScriptManager.RegisterStartupScript(this, GetType(), "TrackNotFound", "alert('The provided tracking ID does not exist.');", true);
                }
            }
            else
            {
                // Track detail doesn't exist in the table, show an alert message
                ScriptManager.RegisterStartupScript(this, GetType(), "TrackNotFound", "alert('The provided tracking ID does not exist.');", true);
            }
        }
        private bool IsTrackExist(string trackId)
        {
            // Check if the track detail exists in the Export_Status table
            string connectionString = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Export_Status WHERE Track = @TrackId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrackId", trackId);

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
        private DataTable GetExportStatusDetails(string trackId)
        {
            // Fetch the details from the Export_Status table using the track
            DataTable detailsTable = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT DISTINCT * FROM BL WHERE Track = @TrackId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrackId", trackId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(detailsTable);
            }

            return detailsTable;
        }
        private string StoreInBLTable(DataRow sourceRow)
        {
            // Store the details in the BL table and generate a unique BL number
            // Implement your database connection and query here
            string blNumber = GenerateUniqueBLNumber();

            string connectionString = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO BL (Track, Status, FromLocation, ToLocation, Payment, Estimation, Vessel, Location, BLNumber) " +
                               "VALUES (@Track, @Status, @FromLocation, @ToLocation, @Payment, @Estimation, @Vessel, @Location, @BLNumber)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Track", sourceRow["Track"]);
                command.Parameters.AddWithValue("@Status", sourceRow["Status"]);
                command.Parameters.AddWithValue("@FromLocation", sourceRow["FromLocation"]);
                command.Parameters.AddWithValue("@ToLocation", sourceRow["ToLocation"]);
                command.Parameters.AddWithValue("@Payment", sourceRow["Payment"]);
                command.Parameters.AddWithValue("@Estimation", sourceRow["Estimation"]);
                command.Parameters.AddWithValue("@Vessel", sourceRow["Vessel"]);
                command.Parameters.AddWithValue("@Location", sourceRow["Location"]);
                command.Parameters.AddWithValue("@BLNumber", blNumber);


                command.ExecuteNonQuery();
            }

            return blNumber;
        }
        private string GenerateUniqueBLNumber()
        {
            // Generate a unique BL number

            return Guid.NewGuid().ToString();
        }
        private void GeneratePDF(string connectionString, string blNumber)
        {
            // Fetch data from the database
            DataTable detailsTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT distinct * FROM BL WHERE BLNumber = @Track", connection);
                command.Parameters.AddWithValue("@Track", blNumber);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(detailsTable);
            }

            // Generate a PDF to display the details
            MemoryStream memoryStream = new MemoryStream();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

            document.Open();

            document.Add(new Paragraph("OmegaShipping PVT LTD"));
            // Add the BL number as a QR code
            BarcodeQRCode qrCode = new BarcodeQRCode(blNumber, 100, 100, null);
            iTextSharp.text.Image qrCodeImage = qrCode.GetImage();
            qrCodeImage.SetAbsolutePosition(50, document.PageSize.Height - 150);
            document.Add(qrCodeImage);

            // Add some spacing
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));

            // Add the details to the PDF
            PdfPTable table = new PdfPTable(detailsTable.Columns.Count);
            table.WidthPercentage = 100;

            // Add table headers
            foreach (DataColumn column in detailsTable.Columns)
            {
                PdfPCell headerCell = new PdfPCell(new Phrase(column.ColumnName));
                table.AddCell(headerCell);
            }

            // Add table rows
            foreach (DataRow row in detailsTable.Rows)
            {
                foreach (DataColumn column in detailsTable.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(row[column].ToString()));
                    table.AddCell(cell);
                }
            }

            document.Add(table);
            document.Close();

            // Provide the PDF file for download
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=BL_" + blNumber + ".pdf");
            Response.BinaryWrite(memoryStream.ToArray());
            Response.End();
        }
        public void PopulateDropdownList()
        {
            // Fetch the track IDs from the "export" table and populate the dropdown list
            string connectionString = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("select distinct Track from Export_Status order by Track desc ", connection))
                {
                    string Trackid = "";
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Add each track ID to the dropdown list
                           Trackid = reader["Track"].ToString();
                            Trackdp.Items.Add(Trackid);
                           

                        }
                    }

                    reader.Close();
                 
                }
            }
        }
        protected void Trackdp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedid = Trackdp.SelectedValue;
            FetchData(selectedid);
        }

    }
}