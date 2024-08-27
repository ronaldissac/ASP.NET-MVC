<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Omegashipping.com.Admin.Home" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>OmegaShipping.com</title>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="Content/Site.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <style>
        .iFrameST {
            margin-top: 2px;
            width: 100%;
            /*height:415px;*/
            height: 520px;
            /*overflow:auto;*/
            /*background-color:#FFF7F9;*/
        }
    </style>
</head>
<body>
    <form runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
            </Scripts>
        </asp:ScriptManager>
        <script type="text/javascript" src="Admin/Home.js"></script>


        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Omega Shipping(Admin)</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarText">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link active" id="HomeNav" href="Home.aspx">Home</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="BLNav" href="Admin/BLAdmin.aspx">BLAdmin</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="ExpNav" href="Admin/ExportAdmin.aspx">ExportAdmin</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="StsNav" href="Admin/StatusAdmin.aspx"">Status</a>
                        </li>
                    </ul>
                    <span class="navbar-text">
                        <asp:Label ID="lblWlc" runat="server" Visible="false" Text="Welcome "></asp:Label>
                    </span>
                </div>
            </div>
        </nav>

        <div class="container-fluid">
            <div class="row">
                <div class="col">
                    <marquee direction="left" class=" mb-1 bg-secondary text-white" scrollamount="5" loop="true" width="100%" bgcolor="#ffffff">
                    </marquee>
                </div>
            </div>

            <div class="container body-content">
                <iframe class="iFrameST"></iframe>
                <hr />
                <footer>
                    <p style="text-align: center">© Copyright-2023 OmegaShipping</p>
                </footer>
            </div>

        </div>

    </form>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/Scripts/bootstrap.js") %>
    </asp:PlaceHolder>
</body>
</html>
