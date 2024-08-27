using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using CustomerPortal.Models;

namespace CustomerPortal.DataManager
{
    public interface IFactory
    {
    }

    public class SqlMethod : IFactory
    {
        private static string cnstr = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;
        private SqlConnection sqlCon = new SqlConnection(cnstr);
        private SqlCommand cmd = new SqlCommand();
        private SqlDataAdapter adapter = new SqlDataAdapter();

        //private static string cnstr = ConfigurationManager.ConnectionStrings["dis"].ConnectionString;
        //private SqlConnection sqlCon = null;
        //private SqlCommand cmd = null;
        //private SqlDataAdapter adapter = null;
        //public SqlMethod(SqlConnection sqlConnection,SqlCommand sqlCommand,SqlDataAdapter adapter) 
        //{
        //    sqlCon = sqlConnection;
        //    sqlCon.ConnectionString = cnstr;
        //    cmd = sqlCommand;
        //    this.adapter = adapter;
        //}
        public int InsertData(string sql)
        {
            int num = 0;
            try
            {
                if (sql != "")
                {
                    cmd.Connection = sqlCon;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    num = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if ((sqlCon == null ? false : sqlCon.State != ConnectionState.Closed))
                {
                    sqlCon.Close();
                }
            }
            return num;
        }

        public int UpdateData(string tbl, string rowid ,string where)
        {
            int num = 0;
            if (where !="")
                where = "where =" + where;

            string sql = "UPDATE " + tbl + " SET " + rowid + " " + where;
            try
            {
                if (sql != "")
                {
                    cmd.Connection = sqlCon;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    num = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (sqlCon == null ? false : sqlCon.State != ConnectionState.Closed)
                {
                    sqlCon.Close();
                }
            }
            return num;
        }
        public DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            try
            {   
                if (sql != "")
                {
                    cmd.Connection = sqlCon;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                    cmd.Connection.Close();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if ((sqlCon == null ? false : sqlCon.State != ConnectionState.Closed))
                {
                    sqlCon.Close();
                }
            }

            return dt;
        }

        public string GetValue(string sql)
        {
             string value = string.Empty;
            try
            {
                if (sql != "")
                {
                    cmd.Connection = sqlCon;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                    {
                        value = obj.ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if ((sqlCon == null ? false : sqlCon.State != ConnectionState.Closed))
                {
                    sqlCon.Close();
                }
            }

            return value;
        }

        public int ExectuteSql(string sql)
        {
            int num = 0;
            try
            {
                if (sql != "")
                {
                    cmd.Connection = sqlCon;
                    cmd.CommandText = sql;
                    cmd.Connection.Open();
                    num = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if ((sqlCon == null ? false : sqlCon.State != ConnectionState.Closed))
                {
                    sqlCon.Close();
                }
            }
            return num;
        }

        #region InsertBooking
        public int InsertBooking(BkgDetails bkg)
        {

            int num = 0;
            string InsertSql = $@"INSERT INTO [omegabase].[dbo].[Booking] 
              (CustomerID, BookingRefNo ,ShipperName, PlaceOfBooking, Consignee, DateOfStacking, PlaceOfRec, POD, Voyage, Vessel, VesselOperator, PreCarriage, DestCarriage, TypeOfCargo, Container, Qty, Commodity, GrWt, DateOfBooking)
              VALUES ({bkg.HIDID},'{bkg.BookingRefNo}' ,'{bkg.ShipperName}', '{bkg.PlaceOfBooking}', '{bkg.Consignee}', '{bkg.DateOfStacking}', '{bkg.PlaceOfRec}', '{bkg.POD}', '{bkg.Voyage}', '{bkg.Vessel}', '{bkg.VesselOperator}', '{bkg.PreCarriage}', '{bkg.DestCarriage}', 
             '{bkg.TypeOfCargo}', '{bkg.Container}', {bkg.Qty}, '{bkg.Commodity}', {bkg.GrWt}, '{bkg.DateOfBooking}')";

            num = this.InsertData(InsertSql);

            return num;
        }
        #endregion

        public int UpdateBooking(BkgDetails bkg)
        {
            int num = 0;
            string UpdateSql = $@"UPDATE [omegabase].[dbo].[Booking] SET CustomerID = {bkg.HIDID}, ShipperName = '{bkg.ShipperName}',PlaceOfBooking = '{bkg.PlaceOfBooking}',Consignee = '{bkg.Consignee}', DateOfStacking = '{bkg.DateOfStacking}', PlaceOfRec = '{bkg.PlaceOfRec}', 
             POD = '{bkg.POD}',Voyage = '{bkg.Voyage}', Vessel = '{bkg.Vessel}', VesselOperator = '{bkg.VesselOperator}', PreCarriage = '{bkg.PreCarriage}',DestCarriage = '{bkg.DestCarriage}',TypeOfCargo = '{bkg.TypeOfCargo}',Container = '{bkg.Container}',Qty = {bkg.Qty},Commodity = '{bkg.Commodity}',GrWt = {bkg.GrWt}, DateOfBooking = '{bkg.DateOfBooking}' WHERE ID = {bkg.BkgID}";

            num = this.ExectuteSql(UpdateSql);

            return num;
        }

        public int DeleteBooking(int bkgid)
        {
            int num = 0;
            string DeleteSql = $@"Delete from Booking where ID='{bkgid}'";

            num = this.ExectuteSql(DeleteSql);

            return num;
        }

        public string GeneratebkgRef()
        {
            string seq = string.Empty;
            string prefix = "BKGIN00";

            seq = GetValue("select Seq from Bookingconfig");
            if (!string.IsNullOrEmpty(seq))
            {
                int num = Convert.ToInt32(seq.Substring(prefix.Length));
                num++;
                seq = prefix + num.ToString();
                this.UpdateData("Bookingconfig", "seq ='" + seq+"'", "");
            }

            return seq;
        }

    }
}