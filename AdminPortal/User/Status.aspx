<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Status.aspx.cs" Inherits="Omegashipping.com.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <link rel="stylesheet" type="text/css" href="CSS/Status.css">
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

<script>
    function Button1_Click() {
    var trackTextBox = document.getElementById("Track");
    if (trackTextBox.value === "") {
      alert("Please enter the tracking number.");
      return false; // Prevent form submission
    }
    return true; // Allow form submission
  }
</script>
<div class="maindiv">
    <div id="t1" class="blink-text" style="align-content:center">Shipment Tracking</div><br /><hr />
    <div class="row">
        <div class="col-md-2">
            <label for="Track">Tracking ID: </label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="Track" style="width:100%;" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="Trackreq" style="color:crimson"  runat="server" ControlToValidate="Track" ValidationGroup="SubmitValidation" ErrorMessage="required*"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-2">
            <label for="Status">Status:&nbsp;</label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="Status" Enabled="false" style="width:100%" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2 text-right">
            <label for="From">From:&nbsp;</label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="From" Enabled="false" style="width:100%" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2 text-right">
            <label for="To">To:&nbsp;</label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="To" Enabled="false" style="width:100%" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2 text-right">
            <label for="Payment">Payment:&nbsp;</label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="Payment" Enabled="false" style="width:100%"  runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2 text-right">
            <label for="Estimation">Estimation:&nbsp;</label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="Estimation" Enabled="false" style="width:100%" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2 text-right">
            <label for="Vessel">Vessel:&nbsp;</label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="Vessel" Enabled="false" style="width:100%" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2 text-right">
            <label for="Location">Location:&nbsp;</label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="Location" Enabled="false" style="width:100%" runat="server"></asp:TextBox>
        </div>
    </div>
    <div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" ValidationGroup="SubmitValidation" CssClass="Button1" Text="Track" />
    </div>
</div>

</asp:Content>
