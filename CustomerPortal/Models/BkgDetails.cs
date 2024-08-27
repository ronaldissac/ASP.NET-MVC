using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Data.Common;
using Newtonsoft.Json;
using CustomerPortal.DataManager;

namespace CustomerPortal.Models
{ 
    public class BkgDetails
    {
        public int HIDID { get; set; }

        public int BkgID { get; set; }

        public string BookingRefNo { get; set; }
        public int CustomerID { get; set; }

        public string ShipperName { get; set; }

        public int PlaceOfBooking { get; set; }

        public string Consignee { get; set; }

        public string DateOfStacking { get; set; }

        public int PlaceOfRec { get; set; }

        public int POD { get; set; }

        public int Voyage { get; set; }

        public int Vessel { get; set; }

        public string VesselOperator { get; set; }

        public int PreCarriage { get; set; }

        public int DestCarriage { get; set; }

        public int TypeOfCargo { get; set; }

        public int Container { get; set; }

        public int Qty { get; set; }

        public int Commodity { get; set; }

        public int GrWt { get; set; }

        public String DateOfBooking { get; set; }
    }
}