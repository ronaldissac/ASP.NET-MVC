<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Export.aspx.cs" Inherits="Omegashipping.com.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="CSS/Export.css">
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
  <div id="t1" class="blink-text" style="align-content:center">Enter the Booking Details</div><br /><hr />
  <div class="row">
    <div class="col-2-sm" id="pro">
      <label for="productname">Product Name:</label>
        <asp:TextBox ID="productname" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="productnameRequired" style="color:crimson" runat="server" ControlToValidate="productname" ValidationGroup="SubmitValidation" ErrorMessage="required*"></asp:RequiredFieldValidator>
        <asp:Label ID="RandomNumberLabel" CssClass="RandomNumberLabel" runat="server" Text=""></asp:Label>
       <asp:Label ID="tracklabel" CssClass="RandomNumberLabel hide-label" Text="" runat="server"></asp:Label>
    </div>
    <div class="col-2-sm">
      <label for="quantity">Quantity:</label>
        <asp:TextBox ID="Quantity" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="QuantityRequired" style="color:crimson"  runat="server" ControlToValidate="Quantity" ValidationGroup="SubmitValidation" ErrorMessage="required*"></asp:RequiredFieldValidator>
    </div>
          <div class="col-2-sm">
          <Label for="from">From Address:</Label> 
          <asp:TextBox ID="from" runat="server" CssClass="scrollable-textbox"></asp:TextBox>
          <asp:RequiredFieldValidator ID="fromRequired" style="color:crimson"  runat="server" ControlToValidate="from" ValidationGroup="SubmitValidation" ErrorMessage="required*"></asp:RequiredFieldValidator>
      </div>
      <div class="col-2-sm">
          <Label for="to">To Address:</Label> 
          <asp:TextBox ID="To" runat="server" CssClass="scrollable-textbox"></asp:TextBox>
          <asp:RequiredFieldValidator ID="toRequired" style="color:crimson"  runat="server" ControlToValidate="To" ValidationGroup="SubmitValidation" ErrorMessage="required*"></asp:RequiredFieldValidator>
      </div>
    <div class="col-2-sm"><asp:FileUpload ID="FileUpload2" runat="server" style="margin:10px;"/></div>
     <div class="row">
    <div class="col-md-6 text-center">
        <asp:Button ID="Button1" runat="server" CssClass="Button1" Text="Submit" ValidationGroup="SubmitValidation" OnClick="Button1_Click" />
    </div>
    <div class="col-md-6 text-center">
        <asp:Button ID="Button2" runat="server" CssClass="Button1" Text="Track" OnClick="Button2_Click" />
    </div>
</div>
</div>
</div>
</asp:Content>
