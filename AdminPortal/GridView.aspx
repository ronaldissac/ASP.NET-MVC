<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="Omegashipping.com.GridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Product" HeaderText="Product Name" />
                    <asp:BoundField ApplyFormatInEditMode="True" DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Rate" HeaderText="Rate" />
                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
