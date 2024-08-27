<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ExportAdmin.aspx.cs" Inherits="Omegashipping.com.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent1" runat="server">
    <link rel="stylesheet" type="text/css" href="../CSS/ExportAdmin.css">
     <style>
  @keyframes blink {
    0% { opacity: 1; }
    50% { opacity: 0; }
    100% { opacity: 1; }
  }

  .blink-text {
    animation: blink 1.5s infinite;
  }
</style>
<div class="maindiv">
  <div id="t1" class="blink-text" style="align-content:center">Shipping Details</div><br /><hr />
   <div class="row" >
       <div class="col-md-2">
           <label for="Track">Track ID:</label>
       </div>
       <div class="col-md-4">
           <asp:DropDownList ID="DropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_SelectedIndexChanged"  CssClass="DropDownbox"></asp:DropDownList>
       </div>
       <div class="col-md-2">
           <label for="Image1">Image:</label>
       </div>
       <div class="col-md-4">
           <div class="img" style="position:initial"><asp:Image ID="Image1" CssClass="img-thumbnail"  Enabled="False" runat="server" /></div>
         </div>
   </div>
  <div class="row">
    <div class="col-md-2">
      <label for="productname">Product Name:</label>
    </div>
    <div class="col-md-4">
        <asp:TextBox ID="productname" Style="width: max-content;" runat="server" Enabled="False"></asp:TextBox>
    </div>
    <div class="col-md-2">
      <label for="quantity">Quantity:</label>
    </div>
    <div class="col-md-4">
      <asp:TextBox ID="Quantity"  Enabled="False" runat="server"></asp:TextBox>
    </div>
  </div>
  <div class="row">
    <div class="col-md-2">
      <label for="from">From Address:</label> 
    </div>
    <div class="col-md-4">
      <asp:TextBox ID="from" runat="server"  Enabled="False" CssClass="scrollable-textbox"></asp:TextBox>
    </div>
    <div class="col-md-2">
      <label for="to">To Address:</label> 
    </div>
    <div class="col-md-4">
      <asp:TextBox ID="To" runat="server"  Enabled="False" style="max-height:50px;" CssClass="scrollable-textbox"></asp:TextBox>
    </div>
  </div>
    <div class="row">
        <div class="col-md-2">
        <label for="date">Date</label></div>
        <div class="col-md-4">
         <asp:TextBox ID="date1"  Enabled="False" runat="server"></asp:TextBox>
    </div><div class="col-md-2"></div>
        <div class="col-md-4"></div>
<div style="right:50%"><asp:Button ID="Button1" runat="server" CssClass="Button1" OnClick="Button1_Click" Text="Approve" /></div>
      
    </div>
</div>
    <asp:HiddenField ID="hidID" runat="server"/>
</asp:Content>