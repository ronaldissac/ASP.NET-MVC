<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BLAdmin.aspx.cs" Inherits="Omegashipping.com.Admin.BLAdmin" %>

<!DOCTYPE html>
<html>
<head runat="server">
        <link href="../CSS/BL.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <webopt:BundleReference runat="server" Path="~/Content/css" />
     <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</head>
<body>
    <form runat="server">
        <div class="maindiv">
            <div id="t1" class="blink-text" style="align-content: center">DownLoad BL</div>
            <br />
            <hr />
            <div class="row">
                <div class="col-md-2">
                    <label for="Track">Tracking ID: </label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="Trackdp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Trackdp_SelectedIndexChanged" CssClass="DropDownbox form-text"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <label for="Status">Status:&nbsp;</label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="Status" Style="width: 100%" Enabled="false" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 text-right">
                    <label for="From">From:&nbsp;</label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="From" CssClass="form-text" Enabled="false" Style="width: 100%" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2 text-right">
                    <label for="To">To:&nbsp;</label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="To" CssClass="form-text" Style="width: 100%" Enabled="false" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 text-right">
                    <label for="Payment">Payment:&nbsp;</label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="Payment" CssClass="form-text" Style="width: 100%" Enabled="false" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2 text-right">
                    <label for="Estimation">Estimation:&nbsp;</label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="Estimation" CssClass="form-text" Style="width: 100%" Enabled="false" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2 text-right">
                    <label for="Vessel">Vessel:&nbsp;</label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="Vessel" CssClass="form-text" Enabled="false" Style="width: 100%" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2 text-right">
                    <label for="Location">Location:&nbsp;</label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="Location" CssClass="form-text" Enabled="false" Style="width: 100%" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="button-container">
                <div class="row">
                    <div class="col-md-6">
                        <asp:Button ID="btn_track" runat="server" CssClass="btn-secondary" ValidationGroup="SubmitValidation" Text="Track" OnClick="btn_clicktrack" />
                    </div>
                    <div class="col-md-6">
                        <asp:Button ID="btn_pfd" runat="server" CssClass="btn-dark" Text="PDF" OnClick="btn_clickPdf" />
                    </div>

                </div>

            </div>
        </div>
    </form>

</body>


</html>
