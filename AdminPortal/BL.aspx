<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="BL.aspx.cs" Inherits="Omegashipping.com.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="CSS/BL.css">
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
    <div id="t1" class="blink-text" style="align-content:center">DownLoad BL</div><br /><hr />
    <div class="row">
        <div class="col-md-2">
            <label for="Track">Tracking ID: </label>
        </div>
        <div class="col-md-4">
           
            <asp:TextBox ID="Track" style="width:100%" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" style="color:crimson" runat="server" ControlToValidate="Track" ValidationGroup="SubmitValidation" ErrorMessage="required*"></asp:RequiredFieldValidator>
        </div>
        <div class="col-md-2">
            <label for="Status">Status:&nbsp;</label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="Status" style="width:100%" Enabled="false" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2 text-right">
            <label for="From">From:&nbsp;</label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="From" Enabled="false" Style="width: 100%" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2 text-right">
            <label for="To">To:&nbsp;</label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="To" style="width:100%" Enabled="false" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2 text-right">
            <label for="Payment">Payment:&nbsp;</label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="Payment" style="width:100%"  Enabled="false" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-2 text-right">
            <label for="Estimation">Estimation:&nbsp;</label>
        </div>
        <div class="col-md-4">
            <asp:TextBox ID="Estimation" style="width:100%" Enabled="false" runat="server"></asp:TextBox>
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
    <div class="button-container">
        <div class="row">
            <div class="col-md-6">
                 <asp:Button ID="Button1" runat="server"  CssClass="Button1" ValidationGroup="SubmitValidation" Text="Track" OnClick="Button1_Click" />
            </div>
        <div class="col-md-6">
             <asp:Button ID="Button2" runat="server" CssClass="Button1" Text="Download BL"  OnClick="Button2_Click"/>
        </div>    
       
        </div>
       
    </div>
</div>
</asp:Content>
