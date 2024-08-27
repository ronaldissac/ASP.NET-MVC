<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="StatusAdmin.aspx.cs" Inherits="Omegashipping.com.Admin.StatusAdmin" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Status Admin</title>
    <link rel="stylesheet" type="text/css" href="../CSS/Status.css">
        <webopt:BundleReference runat="server" Path="~/Content/css" />

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
</head>
<body>
    <form id="form1" runat="server">
        <div class="maindiv">
            <div id="t1" class="blink-text" style="text-align:center">Add Tracking Details</div><br /><hr />
            <div class="row">
                <div class="col-md-2">
                    <label for="Track">Tracking ID: </label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="Track" style="width:100%" Enabled="false" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <label for="Status">Status:&nbsp;</label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="Status" style="width:100%" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" style="color:crimson" runat="server" ControlToValidate="Status" ValidationGroup="SubmitValidation" ErrorMessage="required*"></asp:RequiredFieldValidator>
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
                    <asp:TextBox ID="Payment" style="width:100%"  runat="server" Enabled="false"></asp:TextBox>
                </div>
                <div class="col-md-2 text-right">
                    <label for="Estimation">Estimation:&nbsp;</label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="Estimation" style="width:100%" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" style="color:crimson" runat="server" ControlToValidate="Estimation" ValidationGroup="SubmitValidation" ErrorMessage="required*"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 text-right">
                    <label for="Vessel">Vessel:&nbsp;</label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="Vessel" style="width:100%" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" style="color:crimson" runat="server" ControlToValidate="Vessel" ValidationGroup="SubmitValidation" ErrorMessage="required*"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2 text-right">
                    <label for="Location">Location:&nbsp;</label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="Location" style="width:100%" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" style="color:crimson" runat="server" ControlToValidate="Location" ValidationGroup="SubmitValidation" ErrorMessage="required*"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="button-container">
                <asp:Button ID="Button1" runat="server" CssClass="btn-primary " ValidationGroup="SubmitValidation" Text="Update" OnClick="Button1_Click" />
            </div>
            <div>
                <asp:Button ID="Button2" runat="server" CssClass="btn-primary" Text="Download BL" OnClick="Button2_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
