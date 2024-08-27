<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WebForm6.aspx.cs" Inherits="Omegashipping.com.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="age" HeaderText="Age" />
                </columns>
        </asp:GridView>
          <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="FromLocation" HeaderText="From Location" />
                            <asp:BoundField DataField="ToLocation" HeaderText="To Location" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:BoundField DataField="Location" HeaderText="current Location" />
                        </Columns>
                    </asp:GridView>
        
        
    </div>
</asp:Content>
