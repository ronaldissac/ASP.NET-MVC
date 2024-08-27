using CustomerPortal.DataManager;
using CustomerPortal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace CustomerPortal.Controllers
{
    public class ExportController : Controller
    {
        private readonly static SqlMethod _Sql = new SqlMethod();
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult LoadPartial(int ViewId)
        //{
        //    switch (ViewId)
        //    {
        //        case 1:
        //            return PartialView("~/Views/PartialView/NewBookingView.cshtml");
        //        case 2:
        //            return PartialView("~/Views/PartialView/BookingListView.cshtml");
        //        default:
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid view ID");
        //    }
        //}

        [HttpPost]
        public JsonResult InsertBooking(BkgDetails bkg)
        {
            try
            {
                if (Session["customerID"].ToString() != "")
                {
                    bkg.HIDID = Convert.ToInt32(Session["HidID"]);
                    bkg.ShipperName = Session["customerName"].ToString();
                    bkg.BookingRefNo = _Sql.GeneratebkgRef();
                    int result = _Sql.InsertBooking(bkg);
                    if (result != 0)
                    {
                        return GetBooking(bkg.BookingRefNo);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return Json("Something went wrong");
        }

        [HttpGet]
        public JsonResult GetBooking(string bkgref)
        {
            try
            {
                var JsonBkgDetails = "";
                DataTable dt = _Sql.GetData("select ID,BookingRefNo, ShipperName,PlaceOfBooking,Consignee,DateOfStacking,PlaceOfRec," +
                    "POD,Voyage,Vessel,VesselOperator,PreCarriage,DestCarriage,TypeOfCargo,Container,Qty,Commodity,GrWt,DateOfBooking from booking " +
                    "where BookingRefNo='" + bkgref + "'");

                List<BkgDetails> BkgDtls = new List<BkgDetails>();

                if (dt.Rows.Count > 0)
                {
                    BkgDetails bkgList = new BkgDetails
                    {
                        BkgID = Convert.ToInt32(dt.Rows[0]["ID"]),
                        BookingRefNo = dt.Rows[0]["BookingRefNo"].ToString(),
                        ShipperName = dt.Rows[0]["ShipperName"].ToString(),
                        PlaceOfBooking = Convert.ToInt32(dt.Rows[0]["PlaceOfBooking"].ToString()),
                        Consignee = dt.Rows[0]["Consignee"].ToString(),
                        PlaceOfRec = Convert.ToInt32(dt.Rows[0]["PlaceOfRec"]),
                        DateOfStacking = dt.Rows[0]["DateOfStacking"].ToString(),
                        POD = Convert.ToInt32(dt.Rows[0]["POD"].ToString()),
                        Voyage = Convert.ToInt32(dt.Rows[0]["Voyage"].ToString()),
                        Vessel = Convert.ToInt32(dt.Rows[0]["Vessel"].ToString()),
                        VesselOperator = dt.Rows[0]["VesselOperator"].ToString(),
                        PreCarriage = Convert.ToInt32(dt.Rows[0]["PreCarriage"]),
                        DestCarriage = Convert.ToInt32(dt.Rows[0]["DestCarriage"]),
                        TypeOfCargo = Convert.ToInt32(dt.Rows[0]["TypeOfCargo"]),
                        Container = Convert.ToInt32(dt.Rows[0]["Container"]),
                        Commodity = Convert.ToInt32(dt.Rows[0]["Commodity"]),
                        Qty = Convert.ToInt32(dt.Rows[0]["Qty"]),
                        GrWt = Convert.ToInt32(dt.Rows[0]["GrWt"]),
                        DateOfBooking = dt.Rows[0]["DateOfBooking"].ToString()
                    };
                    BkgDtls.Add(bkgList);

                    JsonBkgDetails = JsonConvert.SerializeObject(BkgDtls);
                }
                return Json(JsonBkgDetails, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UpdateBooking(BkgDetails UpdateBkg)
        {
            int result = 0;
            try
            {
                if (UpdateBkg.BkgID != 0)
                {
                    result = _Sql.UpdateBooking(UpdateBkg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return Json(new { success = result},JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DeleteBooking(int BkgID) 
        {
            int result = 0;
            try
            {
                if (BkgID != 0)
                {
                  result = _Sql.DeleteBooking(BkgID);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
            return Json(new { success = result },JsonRequestBehavior.AllowGet);
        }

    }
}