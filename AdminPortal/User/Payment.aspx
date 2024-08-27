<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Omegashipping.com.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="CSS/Payment.css">
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
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        $(document).ready(function () {
            $('input[name="PaymentOption"]').change(function () {
                var selectedOption = $('input[name="PaymentOption"]:checked').val();
                $('.payment-section').hide();
                $('#' + selectedOption + 'Section').show();
            });
        });
    </script>
    <div class="maindiv">
        <div id="t1" class="blink-text" style="align-content:center">Payment</div><br /><hr />
        <div style="height:150px;"> 
           <label style="height:50px;" for="Track">Tracking ID:&nbsp;&nbsp; <asp:TextBox ID="Track" style="width:100%"  runat="server"></asp:TextBox>
               <asp:Button ID="Trackbtn" CssClass="Button2" runat="server" Text="Search" OnClick="Trackbtn_Click"  ValidationGroup="SubmitValidation"/>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" style="color:crimson" runat="server" ControlToValidate="Track" ValidationGroup="SubmitValidation" ErrorMessage="required*"></asp:RequiredFieldValidator>
           </label>
            <label style="height:50px;" for="Estimation">Estimation:    <asp:TextBox ID="Estimation" style="width:100%" Enabled="false" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" style="color:crimson" runat="server" ControlToValidate="Estimation" ValidationGroup="Estimation" ErrorMessage="required*"></asp:RequiredFieldValidator>
           </label><br />
        </div>
        <div class="pay"> 
            <div class="payment-select">
                <label for="CardOption"><input type="radio" name="PaymentOption" id="CardOption" value="Card" checked="checked" />&nbsp;Card</label>&nbsp;&nbsp;&nbsp;&nbsp;
                <label for="UPIOption"><input type="radio" name="PaymentOption" id="UPIOption" value="UPI" />&nbsp;UPI</label>&nbsp;&nbsp;&nbsp;&nbsp;
                <label for="NetBankingOption"><input type="radio" name="PaymentOption" id="NetBankingOption" value="NetBanking" />&nbsp;Net Banking</label>
                <div class="img"><img src="cardlogo.png" height="50" width="150" /></div>
        </div><hr />

       
        <div class="payment-section" id="CardSection">
              <label for="CardNumber">Card Number :&nbsp;&nbsp;<input type="text" id="CardNumber" name="CardNumber" style="width: 100%;" /></label>
        </div>
        <div class="payment-section" id="UPISection" style="display: none;">
            <!-- UPI Payment Section -->
           
                    <label for="UPIID">UPI ID :&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp&nbsp;&nbsp&nbsp;&nbsp&nbsp;&nbsp&nbsp;&nbsp<input type="text" id="UPIID" name="UPIID" style="width: 100%;" /></label>
            </div>
        
        <div class="payment-section" id="NetBankingSection" style="display: none;">
          
                    <label style="height:5px;" for="Bank">Select Bank :&nbsp;&nbsp;&nbsp;&nbsp; <select id="Bank" name="Bank" style="width: 100%;">
                        <option value="">Select Bank</option>
                        <option value="SBI">SBI</option>
                        <option value="ICICI">ICICI</option>
                        <option value="HDFC">HDFC</option>
                        <option value="Indian">Indian Bank</option>
                        <!-- Add bank options here -->
                    </select></label>
             <label style="height:5px;">UserName:&nbsp;&nbsp;&nbsp;&nbsp <asp:TextBox ID="TextBox" runat="server"></asp:TextBox> </label> 
             <label style="height:5px;">Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox> </label> 

                </div><br />
                <label style="height:5px;" for="Amount"> Amount :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="Amounttxt" style="width: 100%;" runat="server"></asp:TextBox></label><br />
            <asp:Button ID="Button1" runat="server" CssClass="Button1" OnClick="Button1_Click" ValidationGroup="SubmitValidation" Text="Confirm" />
          </div> </div>
</asp:Content>

