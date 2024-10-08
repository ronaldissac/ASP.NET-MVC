﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Omegashipping.com
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class omegabaseEntities : DbContext
    {
        public omegabaseEntities()
            : base("name=omegabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdminTable> AdminTables { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Bookingconfig> Bookingconfigs { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Export> Exports { get; set; }
        public virtual DbSet<Number> Numbers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }
    
        public virtual int add_export(string productName, Nullable<int> quantity, string from, string to, byte[] fileData, string fileName)
        {
            var productNameParameter = productName != null ?
                new ObjectParameter("ProductName", productName) :
                new ObjectParameter("ProductName", typeof(string));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("Quantity", quantity) :
                new ObjectParameter("Quantity", typeof(int));
    
            var fromParameter = from != null ?
                new ObjectParameter("From", from) :
                new ObjectParameter("From", typeof(string));
    
            var toParameter = to != null ?
                new ObjectParameter("To", to) :
                new ObjectParameter("To", typeof(string));
    
            var fileDataParameter = fileData != null ?
                new ObjectParameter("FileData", fileData) :
                new ObjectParameter("FileData", typeof(byte[]));
    
            var fileNameParameter = fileName != null ?
                new ObjectParameter("FileName", fileName) :
                new ObjectParameter("FileName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("add_export", productNameParameter, quantityParameter, fromParameter, toParameter, fileDataParameter, fileNameParameter);
        }
    
        public virtual int AddExport(string productName, Nullable<int> quantity, string fromLocation, string toLocation, byte[] fileData, string fileName, string track)
        {
            var productNameParameter = productName != null ?
                new ObjectParameter("ProductName", productName) :
                new ObjectParameter("ProductName", typeof(string));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("Quantity", quantity) :
                new ObjectParameter("Quantity", typeof(int));
    
            var fromLocationParameter = fromLocation != null ?
                new ObjectParameter("FromLocation", fromLocation) :
                new ObjectParameter("FromLocation", typeof(string));
    
            var toLocationParameter = toLocation != null ?
                new ObjectParameter("ToLocation", toLocation) :
                new ObjectParameter("ToLocation", typeof(string));
    
            var fileDataParameter = fileData != null ?
                new ObjectParameter("FileData", fileData) :
                new ObjectParameter("FileData", typeof(byte[]));
    
            var fileNameParameter = fileName != null ?
                new ObjectParameter("FileName", fileName) :
                new ObjectParameter("FileName", typeof(string));
    
            var trackParameter = track != null ?
                new ObjectParameter("Track", track) :
                new ObjectParameter("Track", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddExport", productNameParameter, quantityParameter, fromLocationParameter, toLocationParameter, fileDataParameter, fileNameParameter, trackParameter);
        }
    
        public virtual ObjectResult<GetExportData_Result> GetExportData(string trackID)
        {
            var trackIDParameter = trackID != null ?
                new ObjectParameter("TrackID", trackID) :
                new ObjectParameter("TrackID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetExportData_Result>("GetExportData", trackIDParameter);
        }
    
        public virtual ObjectResult<string> spGetBkg(string bookingRefNo)
        {
            var bookingRefNoParameter = bookingRefNo != null ?
                new ObjectParameter("BookingRefNo", bookingRefNo) :
                new ObjectParameter("BookingRefNo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("spGetBkg", bookingRefNoParameter);
        }
    
        public virtual ObjectResult<Update_Status_Result> Update_Status(string fromLocation, string toLocation, string payment, string location, Nullable<int> estimation, string status, string trackID, string vessel)
        {
            var fromLocationParameter = fromLocation != null ?
                new ObjectParameter("FromLocation", fromLocation) :
                new ObjectParameter("FromLocation", typeof(string));
    
            var toLocationParameter = toLocation != null ?
                new ObjectParameter("ToLocation", toLocation) :
                new ObjectParameter("ToLocation", typeof(string));
    
            var paymentParameter = payment != null ?
                new ObjectParameter("Payment", payment) :
                new ObjectParameter("Payment", typeof(string));
    
            var locationParameter = location != null ?
                new ObjectParameter("Location", location) :
                new ObjectParameter("Location", typeof(string));
    
            var estimationParameter = estimation.HasValue ?
                new ObjectParameter("Estimation", estimation) :
                new ObjectParameter("Estimation", typeof(int));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var trackIDParameter = trackID != null ?
                new ObjectParameter("TrackID", trackID) :
                new ObjectParameter("TrackID", typeof(string));
    
            var vesselParameter = vessel != null ?
                new ObjectParameter("Vessel", vessel) :
                new ObjectParameter("Vessel", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Update_Status_Result>("Update_Status", fromLocationParameter, toLocationParameter, paymentParameter, locationParameter, estimationParameter, statusParameter, trackIDParameter, vesselParameter);
        }
    
        public virtual ObjectResult<ValidateCustomer_Result> ValidateCustomer(string customerid, string customerpass)
        {
            var customeridParameter = customerid != null ?
                new ObjectParameter("customerid", customerid) :
                new ObjectParameter("customerid", typeof(string));
    
            var customerpassParameter = customerpass != null ?
                new ObjectParameter("customerpass", customerpass) :
                new ObjectParameter("customerpass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ValidateCustomer_Result>("ValidateCustomer", customeridParameter, customerpassParameter);
        }
    
        public virtual ObjectResult<ValidateLogin_Result> ValidateLogin(Nullable<int> userType, string userID, string password)
        {
            var userTypeParameter = userType.HasValue ?
                new ObjectParameter("UserType", userType) :
                new ObjectParameter("UserType", typeof(int));
    
            var userIDParameter = userID != null ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ValidateLogin_Result>("ValidateLogin", userTypeParameter, userIDParameter, passwordParameter);
        }
    }
}
