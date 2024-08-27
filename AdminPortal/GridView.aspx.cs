using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Omegashipping.com
{
    public partial class GridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                string Conn = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Table_Product", connection);
                    cmd.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }

                GridView1.DataSource = dt;

                foreach (DataColumn column in dt.Columns)
                {
                    BoundField boundField = new BoundField();
                    boundField.DataField = column.ColumnName;
                    boundField.HeaderText = column.ColumnName;
                    GridView1.Columns.Add(boundField);
                }

                GridView1.DataBind();
            }
        }

    }


}