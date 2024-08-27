<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Omegashipping.com.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title class="card-title">Omega Shipping</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.1.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="./CSS/LoginPage.css" />
    <script type="text/javascript" src="../Scripts/jquery-3.4.1.min.js"></script>
    <style>
        #progressContainer {
            display: none;
        }
    </style>
</head>
<body>
    <div class="row" style="background-color: white">
        <div class="col">
            <img src="../Images/Logo.png" class="img-fluid" height="60" width="150" alt="omega" />
        </div>
        <div class="col-10 d-flex justify-content-center align-items-center">
            <h1 class="modal-title" style="margin-right: 275px;">Omega Shipping Agency</h1>
        </div>
    </div>

    <form id="form1" runat="server" visible="true">
          <asp:ScriptManager ID="ScriptManager1" runat="server" />
          <asp:UpdatePanel ID="UpdatePanel1" runat="server" />
        <div class="container-fluid">
            <br />
            <div class="row">
                <div class="col-3">
                    <div class="track-section form-control">
                        <h2 class="text-center text-white-50 text-opacity-25">Track Details</h2>
                        <div class="col md-3">
                            <asp:TextBox ID="txt_track" runat="server" CssClass="form-control" ValidationGroup="Tracking" placeholder="Enter Track No"></asp:TextBox>
                        </div>
                        <br />
                        <div class="col">
                            <asp:Button ID="btn_tack" runat="server" Text="Track" OnClick="TrackButton_Click" ValidationGroup="Tracking" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
                <div class="col-4">
                    <fieldset id="fs" runat="server" visible="false">
                        <div class="card">
                            <div class="card-header text-center">Tracking Details</div>
                            <div class="card-body">
                                <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
                                    <Columns>
                                        <asp:BoundField DataField="FromLocation" HeaderText="From Location" />
                                        <asp:BoundField DataField="ToLocation" HeaderText="To Location" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                        <asp:BoundField DataField="Location" HeaderText="Current Location" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </fieldset>
                </div>
                <div class="col-md"></div>
                <div class="col">
                    <div class="container login-section">
                        <h2 class=" text-center text-white-50 text-opacity-25">Login</h2>
                        <br />
                        <div class="row md-5">
                            <div class=" col-5">
                                <asp:RadioButton ID="Btn_admin" Checked="true" runat="server" CssClass="form-check-inline" GroupName="UserType" Text="&nbsp;Admin" />
                            </div>
                            <div class="col-5">
                                <asp:RadioButton ID="Btn_User" runat="server" CssClass="form-check-inline" GroupName="UserType" Text="&nbsp;User" />
                            </div>
                        </div>
                        <p></p>
                        <div class="mb-3">
                            <asp:TextBox ID="UserID" runat="server" CssClass="form-control" placeholder="UserID"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserID" ValidationGroup="SubmitValidation" ErrorMessage="Required" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control" ValidationGroup="SubmitValidation" placeholder="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ValidationGroup="SubmitValidation" ErrorMessage="Required" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="text-center">
                            <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-primary" OnClick="LoginButton_Click" OnClientClick="loginClick();" ValidationGroup="SubmitValidation" Text="Login" />
                            <p>
                                <asp:Label ID="LoginResultLabel" runat="server" Visible="false"></asp:Label>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>

</html>
